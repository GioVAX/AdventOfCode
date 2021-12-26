module Day06Tests

open FsUnit.Xunit
open Xunit

open Day06

let testInput = "3,4,3,1,2"

[<Fact>]
let ``parse testInput  should produce the correct result`` () =
    parse testInput
    |> should equal [3;4;3;1;2]

[<Fact>]
let ``solvePart1 with testInput SHOULD result 5934`` () =
    solvePart1 testInput
    |> should equal 5934

[<Theory>]
[<InlineData(0, 1)>]
[<InlineData(1, 2)>]

[<InlineData(7, 2)>]
[<InlineData(8, 3)>]

[<InlineData(9, 3)>]
[<InlineData(10, 4)>]

[<InlineData(14, 4)>]
[<InlineData(15, 5)>]

[<InlineData(16, 5)>]
// [<InlineData(17, 6)>]
let ``computeGenerations 1 * SHOULD return the correct result`` (daysToGo, expected:int) =
    computeGenerations 1 daysToGo
    |> should equal (bigint expected)

[<Fact>]
let ``nextBirths should return the correct result`` () =
    nextBirths 1 50
    |> should equal [49;42;35;28;21;14;7;0]

[<Fact>]
let ``nextBirths  2 should return the correct result`` () =
    nextBirths 9 49
    |> should equal [40;33;26;19;12;5]

[<Fact>]
let ``nextBirths  3 should return the correct result`` () =
    nextBirths 9 5
    |> should haveLength 0

[<Fact>]
let ``nextBirths 4 should return the correct result`` () =
    nextBirths 3 18
    |> should equal [15;8;1]

[<Fact>]
let ``nextBirths 5 should return the correct result`` () =
    nextBirths 4 18
    |> should equal [14;7;0]

[<Fact>]
let ``nextBirths 6 should return the correct result`` () =
    nextBirths 9 17
    |> should equal [8;1]

[<Fact>]
let ``nextBirths 7 should return the correct result`` () =
    nextBirths 9 8
    |> should haveLength 0

[<Fact>]
let ``solve part1 with computeGenerations SHOULD give the correct result`` () =
    let state0 = parse testInput

    let result = 
        state0
        |> List.map (fun d -> computeGenerations d 79)
        |> List.sum

    result |> should equal 5934I

[<Fact>]
let ``solvePart2 with testInput SHOULD result 26984457539`` () =
    solvePart2 testInput
    |> should equal 26984457539I