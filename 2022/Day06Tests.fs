module Day06Tests

open FsUnit.Xunit
open Xunit

open Utils
open Day06

type TestInput = {
    data: string
    expected: int
}

let testInput =
    [
        {data="mjqjpqmgbljsphdztnvjfqwrcgsmlb"; expected=7};
        {data="bvwbjplbgvbhsrlpgdmjqwftvncz"; expected=5};
        {data="nppdvjthqldpwncqszvftbrmjlhg";expected=6};
        {data="nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg";expected=10};
        {data="zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw";expected=11};
    ]

[<Fact>]
let ``recognize all chars are different`` () =
    containsNoRepeated 4 "abcd" |> should equal true

[<Fact>]
let ``recognize a repeated char`` () =
    containsNoRepeated 4 "abad" |> should equal false

[<Fact>]
let ``find window with repetition`` ()=
    "mjqjpqmgbljsphdztnvjfqwrcgsmlb"
    |> findMarker 4
    |> should equal 3

[<Theory>]
[<InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb",7)>]
[<InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz",5)>]
[<InlineData("nppdvjthqldpwncqszvftbrmjlhg",6)>]
[<InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg",10)>]
[<InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw",11)>]
let ``test part1`` data expected =
    solve 4 data
    |> should equal expected

[<Theory>]
[<InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb",19)>]
[<InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz",23)>]
[<InlineData("nppdvjthqldpwncqszvftbrmjlhg",23)>]
[<InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg",29)>]
[<InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw",26)>]
let ``test part2`` data expected =
    solve 14 data
    |> should equal expected