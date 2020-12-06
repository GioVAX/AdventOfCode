module Day06Tests

open FsUnit.Xunit
open Xunit

open Day06

let data =
    [
        "abc";
        "";
        "a";
        "b";
        "c";
        "";
        "ab";
        "ac";
        "";
        "a";
        "a";
        "a";
        "a";
        "";
        "b";
    ]

[<Fact>]
let ``groupAnswers test`` () =
    data
    |> groupAnswers
    |> should matchList ["abc";"abc";"abac";"aaaa";"b"]

[<Fact>]
let ``Test case 1`` () =
    solve1 data |> should equal 11

[<Fact>]
let ``Test case 1 - partial`` () =
    data 
    |> groupAnswers
    |> Seq.map (Seq.distinct >> Seq.length)
    |> Seq.toList
    |> should matchList [3;3;3;1;1]

[<Theory>]
[<InlineData(12, 2)>]
let ``Test case 2`` (p1, p2) =
    [] |> should matchList []