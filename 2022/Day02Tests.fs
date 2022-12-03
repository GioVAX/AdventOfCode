module Day02Tests

open FsUnit.Xunit
open Xunit

open Day02
open Utils

let testInput = readData "..\\..\\..\\Day02InputTest.txt"

[<Fact>]
let ``part1 with the testInput SHOULD return 15`` () =
    testInput
    |> part1
    |> should equal 15
