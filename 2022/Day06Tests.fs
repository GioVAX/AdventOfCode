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

// [<Fact>]
