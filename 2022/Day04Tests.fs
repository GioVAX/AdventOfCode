module Day04Tests

open FsUnit.Xunit
open Xunit

open Day04

let testInput = Utils.readData "..\\..\\..\\Day04InputTest.txt"

[<Fact>]
let ``convert 1`` () =
    "1-3,5-6"
    |> convert
    |> should equal (Some {begin1=1; end1=3;begin2=5;end2=6})


[<Fact>]
let ``part1 with the testInput SHOULD return 2`` () =
    Day04.part1 testInput
    |> should equal 2

[<Fact>]
let ``part2 with the testInput SHOULD return 4`` () =
    Day04.part2 testInput
    |> should equal 4