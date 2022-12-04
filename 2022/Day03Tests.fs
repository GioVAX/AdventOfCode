module Day03Tests

open FsUnit.Xunit
open Xunit

open Day03
open Utils

let testInput = readData "..\\..\\..\\Day03InputTest.txt"

[<Fact>]
let ``part1 with the testInput SHOULD return 157`` () =
    part1 testInput
    |>  should equal 157