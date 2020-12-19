module Day19Tests

open FsUnit.Xunit
open Xunit

open Day19

let rulesPart1Case1 = [
    "0: 1 2";
    "1: \"a\"";
    "2: 1 3 | 3 1";
    "3: \"b\""
]

let rulesPart1Case2 = [
    "0: 1 2";
    "1: \"a\"";
    "2: 1 3 | 3 1";
    "3: \"b\""
]

[<Fact>]
let ``buildMap NoRef`` () =
    buildMap [rulesPart1Case1.[1]]
    |> Map.toList
    |> should matchList 
        [(1, {Uses=NoRef; Regex="a"})]

[<Fact>]
let ``buildMap Alternative`` () =
    buildMap [rulesPart1Case1.[2]]
    |> Map.toList
    |> should matchList 
        [(2, {Uses=Alternative ([1; 3], [3;1]); Regex=""})]

[<Fact>]
let ``buildMap Sequence`` () =
    buildMap [rulesPart1Case1.[0]]
    |> Map.toList
    |> should matchList 
        [(0, {Uses=Sequence [1;2]; Regex=""})]

[<Fact>]
let ``Part 1 - example case 1 - regex string`` () =
    let s = 
        buildMap rulesPart1Case1
        |> buildRegex 0
    s |> should equal "a[ab|ba]"

[<Fact>]
let ``The main input only contains Sequence of 2 and Alternative of 2 and 2`` () =
    buildMap rules

// [<Fact>]
// let ``The main input can produce a regex string`` () =
//     let s = 
//         buildMap rules
//         |> buildRegex 0
//     s |> should not' (equal "")

[<Theory>]
[<InlineData(12, 2)>]
let ``Test case 2`` (p1, p2) =
    [] |> should matchList []