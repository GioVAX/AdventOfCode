module Day04Tests

open FsUnit.Xunit
open Xunit

open Day04

let testInput = Utils.readData "..\\..\\..\\Day04InputTest.txt"

[<Fact>]
let ``part1 with the testInput SHOULD return 2`` () =
    Day04.part1 testInput
    |> should equal 2
