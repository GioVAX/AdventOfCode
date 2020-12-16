module Day15Tests

open FsUnit.Xunit
open Xunit

open Day15

let testData = [0;3;6]

[<Fact>]
let ``Test case 1`` () =
    compute 2020 testData
    |> should equal 436

[<Theory>]
[<InlineData(12, 2)>]
let ``Test case 2`` (p1, p2) =
    [] |> should matchList []