module Day02Tests

open FsUnit.Xunit
open Xunit

open Day02

let testData =
    [
        "1-3 a: abcde";
        "1-3 b: cdefg";
        "2-9 c: ccccccccc"
    ]

[<Fact>]
let ``parse SHOULD work`` () =
    parse "1-3 a: abcde"
    |> should equal {Min=1; Max=3; Char='a'; Pwd="abcde"}

    parse "1-3 b: cdefg"
    |> should equal {Min=1; Max=3; Char='b'; Pwd="cdefg"}

    parse "2-9 c: ccccccccc"
    |> should equal {Min=2; Max=9; Char='c'; Pwd="ccccccccc"}

[<Fact>]
let ``Test case 1`` () =
    ()