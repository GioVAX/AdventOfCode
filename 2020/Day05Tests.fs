module Day05Tests

open FsUnit.Xunit
open Xunit

open Day05

let testCases = 
    [
        ("FBFBBFFRLR", 357);
        ("BFFFBBFRRR", 567);
        ("FFFBBBFRRR", 119);
        ("BBFFBBFRLL", 820);
    ]

[<Fact>]
let ``Test case 1`` () =
    let sorted = 
        testCases
        |> List.sortBy fst
    
    sorted.[0] |> snd 
    |> should equal 820

[<Theory>]
[<InlineData(12, 2)>]
let ``Test case 2`` (p1, p2) =
    [] |> should matchList []