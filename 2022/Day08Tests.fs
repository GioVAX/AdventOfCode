module Day08Tests

open FsUnit.Xunit
open Xunit

open Utils
open Day08

let input =
    "30373\n\
    25512\n\
    65332\n\
    33549\n\
    35390"

[<Fact>]
let ``input contains multiple lines`` () =
    input.Split '\n'
    |> Array.length
    |> should equal 5

[<Fact>]
let ``input lines include the trailing \n`` () =
    (input.Split '\n')[1]
    |> String.exists ((=) '\n')

[<Fact>]
let ``input lines do not include leading spaces`` () =
    (input.Split '\n')[1]
    |> should not' (startWith " ")

[<Fact>]
let ``input is converted to the right 2d array`` () =
    let expected = array2D [
            ['3';'0';'3';'7';'3'];
            ['2';'5';'5';'1';'2'];
            ['6';'5';'3';'3';'2'];
            ['3';'3';'5';'4';'9'];
            ['3';'5';'3';'9';'0']]

    let actual = 
        input
        |> inputTo2dArray
    
    actual |> should equal expected

[<Fact>]
let ``understanding slicing`` () =
    let actual = 
        input
        |> inputTo2dArray

    actual[0,*] |> should equal [|'3';'0';'3';'7';'3'|]
    actual[*,1] |> should equal [|'0';'5';'5';'3';'5'|]