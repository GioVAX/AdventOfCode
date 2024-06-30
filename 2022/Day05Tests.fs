module Day05Tests

open FsUnit.Xunit
open Xunit

open Utils
open Day05

open System.Text.RegularExpressions

let testInput =
    Utils.readData "..\\..\\..\\Day05InputTest.txt"

[<Fact>]
let ``endOfConfig for 3 stacks`` () =
    createEndOfConfig 3 |> should equal " 1   2   3 "

[<Fact>]
let ``endOfConfig for 9 stacks`` () =
    createEndOfConfig 9
    |> should equal " 1   2   3   4   5   6   7   8   9 "

[<Fact>]
let ``readConfigLine 1 for 3 stacks`` () =
    readConfigLine "    [D]    "
    |> should equal [| (0, ' '); (1, 'D'); (2, ' ') |]

[<Fact>]
let ``readConfigLine 2 for 3 stacks`` () =
    readConfigLine "[Z] [M] [P]"
    |> should equal [| (0, 'Z'); (1, 'M'); (2, 'P') |]

[<Fact>]
let ``readConfigLine 3 for 3 stacks`` () =
    readConfigLine "[N] [C]    "
    |> should equal [| (0, 'N'); (1, 'C'); (2, ' ') |]


[<Fact>]
let ``readConfigLine for 9 stacks`` () =
    readConfigLine "    [G] [N] [H] [S] [B]     [R] [F]"
    |> should
        equal
        [| (0, ' ')
           (1, 'G')
           (2, 'N')
           (3, 'H')
           (4, 'S')
           (5, 'B')
           (6, ' ')
           (7, 'R')
           (8, 'F') |]

[<Fact>]
let ``parseInitialConfig with test input`` () =

    let expected =
        [| emptyStack |> push 'Z' |> push 'N'
           emptyStack |> push 'M' |> push 'C' |> push 'D'
           emptyStack |> push 'P' |]

    let endOfConfigIdx = findSplittingLine testInput 3

    parseInitialConfig testInput 3 endOfConfigIdx
    |> should equal expected

[<Fact>]
let ``parse a command line`` () =
    readCommandLine "move 311 from 12 to 2"
    |> should equal {number=311; source=12; dest=2}