module Day05Tests

open FsUnit.Xunit
open Xunit

open Utils
open Day05

open System.Text.RegularExpressions

let testInput = Utils.readData "..\\..\\..\\Day05InputTest.txt"

[<Fact>]
let ``endOfConfig for 3 stacks`` () =
    endOfConfig 3
    |> should equal " 1   2   3 "

[<Fact>]
let ``endOfConfig for 9 stacks`` () =
    endOfConfig 9
    |> should equal " 1   2   3   4   5   6   7   8   9 "

[<Fact>]
let ``readConfigLine 1 for 3 stacks`` () =
    readConfigLine "    [D]    "
    |> should equal [|"";"D";""|]

[<Fact>]
let ``readConfigLine 2 for 3 stacks`` () =
    readConfigLine "[Z] [M] [P]"
    |> should equal [|"Z";"M";"P"|]
    
[<Fact>]
let ``readConfigLine 3 for 3 stacks`` () =
    readConfigLine "[N] [C]    "
    |> should equal [|"N";"C";""|]


[<Fact>]
let ``readConfigLine for 9 stacks`` () =
    readConfigLine "    [G] [N] [H] [S] [B]     [R] [F]"
    |> should equal [|"";"G";"N";"H";"S";"B";"";"R";"F"|]

[<Fact(Skip="ss")>]
let ``initialConfigParser with test input`` () =
    let expected = [|
        ['N'; 'Z']
        ['D'; 'C'; 'M']
        ['P']
    |]

    initialConfigParser testInput 3
    |> should equal expected