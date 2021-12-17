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
let ``slice testInput 0 SHOULD return 011110011100`` () =
    testInput
    |> slice 0
    |> should equal ['0';'1';'1';'1';'1';'0';'0';'1';'1';'1';'0';'0']

[<Fact>]
let ``oxigen rating for testInput SHOULD return 10111`` () =
    testInput
    |> oxigenRate
    |> should equal 23

[<Fact>]
let ``c02 rating for testInput SHOULD return 10111`` () =
    testInput
    |> co2Rate
    |> should equal 10

[<Fact>]
let ``solvePart2 with the testInput SHOULD return 230`` () =
    testInput
    |> solvePart2
    |> should equal 230