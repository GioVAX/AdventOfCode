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

