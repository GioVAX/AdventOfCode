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
    containsNoRepeated "abcd" |> should equal true

[<Fact>]
let ``recognize a repeated char`` () =
    containsNoRepeated "abad" |> should equal false

[<Fact>]
let ``find window with repetition`` ()=
    "mjqjpqmgbljsphdztnvjfqwrcgsmlb"
    |> findMarker
    |> should equal 3

[<Theory>]
[<InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb",7)>]
[<InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz",5)>]
[<InlineData("nppdvjthqldpwncqszvftbrmjlhg",6)>]
[<InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg",10)>]
[<InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw",11)>]
let ``test part1`` data expected =
    part1 data
    |> should equal expected