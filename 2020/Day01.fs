module Day01

open FsUnit.Xunit
open Xunit

let data = []


let result1 =
    1
    
let result2 =
    2

[<Theory>]
[<InlineData(12, 2)>]
let ``Given a mass SHOULD compute correct fuel`` (mass, expected) =
    result1 |> should equal 1

[<Fact>]
let ``Simple test`` () =
    result2 |> should equal 2