module Day02Tests

open FsUnit.Xunit
open Xunit

open Day02

let testInput = 
    [ "forward 5"; "down 5"; "forward 8"; "up 3"; "down 8"; "forward 2"; ]

[<Fact>]
let ``solvePart1 with the testInput SHOULD return 150`` () =
    solvePart1 testInput |> should equal 150

[<Fact>]
let ``solvePart2 with the testInput SHOULD return 900`` () =
    solvePart2 testInput |> should equal 900