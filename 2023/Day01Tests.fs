module Day01Tests

open FsUnit.Xunit
open Xunit

open Day01

let testData = """1abc2
pqr3stu8vwx
a1b2c3d4e5f
treb7uchet"""

[<Fact>]
let ``multiline string to string array`` () =
    testData
    |> splitInput
    |> should equal [|"1abc2";"pqr3stu8vwx";"a1b2c3d4e5f";"treb7uchet"|]

[<Theory>]
[<InlineData("", "")>]
[<InlineData("abc", "")>]
[<InlineData("1", "1")>]
[<InlineData("18", "18")>]
[<InlineData("4abc", "4")>]
[<InlineData("ab7c", "7")>]
[<InlineData("abc0", "0")>]
[<InlineData("a1b2c", "12")>]
[<InlineData("1a3b5c0", "1350")>]
let ``only digits`` input expected =
    justDigits input
    |> should equal expected

[<Theory>]
[<InlineData("", "")>]
[<InlineData("a", "aa")>]
[<InlineData("abc", "ac")>]
[<InlineData("4abc", "4c")>]
let ``first and last`` input expected =
    firstAndLast input
    |> should equal expected

// [<Theory>]
// [<InlineData("1abc2",12)>]
// [<InlineData("pqr3stu8vwx",38)>]
// [<InlineData("a1b2c3d4e5f",15)>]
// [<InlineData("treb7uchet",77)>]


[<Fact>]
let ``part1`` ()=
    part1 testData
    |> should equal 142
