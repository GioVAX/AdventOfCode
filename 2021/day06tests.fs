module Day06Tests

open FsUnit.Xunit
open Xunit

open Day06

let testInput = "3,4,3,1,2"

[<Fact>]
let ``parse testInput  should produce the correct result`` () =
    parse testInput
    |> should equal [3;4;3;1;2]

[<Fact>]
let ``solvePart1 with testInput SHOULD result 5934`` () =
    solvePart1 testInput
    |> should equal 5934

[<Theory>]
[<InlineData(3, 2)>]
[<InlineData(7, 2)>]
[<InlineData(8, 3)>]
[<InlineData(10, 3)>]
[<InlineData(11, 4)>]
[<InlineData(15, 5)>]
// [<InlineData(16, 6)>]
// [<InlineData(17, 7)>]
let ``computeGenerations 1 * SHOULD return the correct result`` (daysToGo, expected:int) =
    computeGenerations 1 daysToGo
    |> should equal (bigint expected)

// [<Fact(Skip="")>]
// let ``solvePart2 with testInput SHOULD result 26984457539`` () =
//     solvePart2 testInput
//     |> should equal 26984457539I