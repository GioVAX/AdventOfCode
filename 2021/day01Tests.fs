module day01Tests

open FsUnit.Xunit
open Xunit

open Day01

let testInput = [199; 200; 208; 210; 200; 207; 240; 269; 260; 263]

[<Fact>]
let ``solvePart1 with the testInput SHOULD return 7`` () =
    let result = solvePart1 testInput
    result |> should equal 7

[<Fact>]
let ``solvePart2 with the testInput SHOULD return 5`` () =
    let result = solvePart2 testInput
    result |> should equal 5