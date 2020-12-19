module Day19Tests

open FsUnit.Xunit
open Xunit

open System.Text.RegularExpressions

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
    s |> should equal "^a(ab|ba)$"

[<Fact>]
let ``The main input only contains Sequence of 2 and Alternative of 2 and 2`` () =
    buildMap rules

[<Fact>]
let ``Part 1 - second example`` () =
    let rules = [
        "0: 4 1 5";
        "1: 2 3 | 3 2";
        "2: 4 4 | 5 5";
        "3: 4 5 | 5 4";
        "4: \"a\"";
        "5: \"b\"";
    ]

    let m = buildMap rules
    let regex = buildRegex 0 m

    regex |> should equal "^a((aa|bb)(ab|ba)|(ab|ba)(aa|bb))b$"

    let messages = 
        [
            "ababbb";
            "bababa";
            "abbbab";
            "aaabbb";
            "aaaabbb";
        ]

    messages
    |> List.map (fun s -> Regex.Match(s, regex))
    |> List.where (fun m -> m.Success)
    |> List.length
    |> should equal 2

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