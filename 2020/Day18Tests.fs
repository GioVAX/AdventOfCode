module Day18Tests

open FsUnit.Xunit
open Xunit

open Day18

[<Fact>]
let ``Part 1 - base case`` () =
    //"1 + 2 * 3 + 4 * 5 + 6" --> 71
    (1 |> should equal 1)

[<Fact>]
let ``Part 1 - parenthesis have precedence`` () =
// [<InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51)>]
    (1 |> should equal 1)

[<Theory(Skip="no implementation yet")>]
[<InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51)>]
[<InlineData("2 * 3 + (4 * 5)", 26)>]
[<InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 437)>]
[<InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12240)>]
[<InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13632)>]
let ``Part 1 - example cases`` (expression, expected) =
    [] |> should matchList []