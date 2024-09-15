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
    |> String.exists ((=) ' ')