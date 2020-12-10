module Day09Tests

open FsUnit.Xunit
open Xunit

open Day09

let testData =
    [
        35UL;
        20UL;
        15UL;
        25UL;
        47UL;
        40UL;
        62UL;
        55UL;
        65UL;
        95UL;
        102UL;
        117UL;
        150UL;
        182UL;
        127UL;
        219UL;
        299UL;
        277UL;
        309UL;
        576UL;
    ]



[<Fact>]
let ``Test case 1`` () =
    (1 |> should equal 1)

[<Theory>]
[<InlineData(12, 2)>]
let ``Test case 2`` (p1, p2) =
    [] |> should matchList []