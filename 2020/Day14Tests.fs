module Day14Tests

open FsUnit.Xunit
open Xunit

open Day14

let testData = 
    [
        "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X";
        "mem[8] = 11";
        "mem[7] = 101";
        "mem[8] = 0"
    ]

[<Fact>]
let ``Test case 1`` () =
    result1 testData
    |> should equal 165L

[<Theory>]
[<InlineData(12, 2)>]
let ``Test case 2`` (p1, p2) =
    [] |> should matchList []