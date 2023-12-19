module Day01Tests

open FsUnit.Xunit
open Xunit

open Day01

let testDataPart1 = """1abc2
pqr3stu8vwx
a1b2c3d4e5f
treb7uchet"""

let testDataPart2 = """two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen"""

[<Fact>]
let ``multiline string to string array`` () =
    testDataPart1
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

[<Theory>]
[<InlineData("two1nine","219")>]
[<InlineData("eightwothree","8wo3")>]
[<InlineData("abcone2threexyz","abc123xyz")>]
[<InlineData("xtwone3four","x2ne34")>]
[<InlineData("4nineeightseven2","49872")>]
[<InlineData("zoneight234","z1ight234")>]
[<InlineData("7pqrstsixteen","7pqrst6teen")>]
let ``convert spelled digits`` input expected =
    convertSpelledDigits input
    |> should equal expected

[<Fact>]
let ``part1`` () =
    part1 testDataPart1
    |> should equal 142

[<Fact>]
let ``part2`` () =
    part2 testDataPart2
    |> should equal 281
