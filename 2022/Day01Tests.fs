module Day01Tests

open FsUnit.Xunit
open Xunit

open Day01
open Utils

let testInput = readData "..\\..\\..\\Day01TestData.txt"

[<Fact>]
let ``part1 with the testInput SHOULD return 24000`` () =
    testInput
    |> Day01.part1
    |> should equal 24000

[<Fact>]
let ``part2 with the testInput SHOULD return 45000`` () =
    testInput
    |> Day01.part2
    |> should equal 45000
    