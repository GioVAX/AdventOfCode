module Day18Tests

open Xunit
open FsCheck
open FsCheck.Xunit
open FsUnit.Xunit

open Day18

[<Property>]
let ``evaluate literal number`` (n:PositiveInt) =
    let n' = n.Get
    evaluate (n' |> string) 0
    |> should equal n'

[<Property>]
let ``evaluate sum of 2 numbers`` (n:PositiveInt) (m:PositiveInt) =
    let n' = n.Get
    let m' = m.Get

    evaluate $"{n'} + {m'}" 0
    |> should equal <| n' + m'

[<Fact>]
let ``Part 1 - base case`` () =
    evaluate "1 + 2 * 3 + 4 * 5 + 6" 0
    |> should equal 71

[<Fact(Skip="not implementated yet")>]
let ``Part 1 - parenthesis have precedence`` () =
    evaluate "1 + (2 * 3) + (4 * (5 + 6))" 0
    |> should equal 51

[<Theory(Skip="not implementated yet")>]
[<InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51)>]
[<InlineData("2 * 3 + (4 * 5)", 26)>]
[<InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 437)>]
[<InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12240)>]
[<InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13632)>]
let ``Part 1 - example cases`` (expression, expected) =
    [] |> should matchList []