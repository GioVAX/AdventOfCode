module Day05Tests

open FsUnit.Xunit
open Xunit

open Day05

let testInput = 
    [
        "0,9 -> 5,9";
        "8,0 -> 0,8";
        "9,4 -> 3,4";
        "2,2 -> 2,1";
        "7,0 -> 7,4";
        "6,4 -> 2,0";
        "0,9 -> 2,9";
        "3,4 -> 1,4";
        "0,0 -> 8,8"; 
        "5,5 -> 8,2"; 
    ]

[<Fact>]
let ``parse first test item SHOULD return the expected result`` () =
    let result = parse "0,9 -> 5,9"
    result |> should equal (Point(0,9), Point(5,9))

[<Fact>]
let ``generateLines with first teest item SHOULD return the expected result`` () =
    let result = 
        "0,9 -> 5,9" 
        |> parse
        |> generateLines

    result |> should equal [Point(0,9); Point(1,9); Point(2,9); Point(3,9); Point(4,9); Point(5,9)]

[<Fact>]
let ``solvePart1 with testInput SHOULD result 5`` () =
    let result = solvePart1 testInput
    result |> should equal 5