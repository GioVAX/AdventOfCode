module day01Tests

open System
open FsUnit.Xunit
open Xunit

open Day01

let testSource = [199; 200; 208; 210; 200; 207; 240; 269; 260; 263]

[<Fact>]
let ``when called with the testSource SHOULD return 7`` () =
    let result = solvePart1 testSource
    result |> should equal 7
