module Day03Tests

open FsUnit.Xunit
open Xunit

open Day03

let testInput = 
    [ "00100"; "11110"; "10110"; "10111"; "10101"; "01111"; "00111"; "11100"; "10000"; "11001"; "00010"; "01010"; ]

[<Fact>]
let ``solvePart1 with the testInput SHOULD return 198`` () =
    testInput
    |> solvePart1
    |> should equal 198

[<Fact>]
let ``solvePart2 with the testInput SHOULD return 230`` () =
    testInput
    |> solvePart2
    |> should equal 230