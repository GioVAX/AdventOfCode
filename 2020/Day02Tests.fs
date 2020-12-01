module Day02Tests

open FsUnit.Xunit
open Xunit

open Day02

[<Theory>]
[<InlineData(12, 2)>]
let ``Given a mass SHOULD compute correct fuel`` (mass, expected) =
    (1 |> should equal 1)

[<Fact>]
let ``Simple test`` () =
    [] |> should matchList []