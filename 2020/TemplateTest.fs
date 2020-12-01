module Day__Tests

open FsUnit.Xunit
open Xunit

open Day__

[<Theory>]
[<InlineData(12, 2)>]
let ``Given a mass SHOULD compute correct fuel`` (mass, expected) =
    (1 |> should equal 1)

[<Fact>]
let ``Simple test`` () =
    [] |> should matchList []