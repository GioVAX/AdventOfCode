module Day07Tests

open FsUnit.Xunit
open Xunit

open Day07

[<Fact>]
let ``Test case 1`` () =
    (1 |> should equal 1)

[<Theory>]
[<InlineData(12, 2)>]
let ``Test case 2`` (p1, p2) =
    [] |> should matchList []