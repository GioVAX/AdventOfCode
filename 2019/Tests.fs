module Tests

open System
open FsUnit.Xunit
open Xunit

let f = (*) 2

[<Fact>]
let ``My test`` () =
    let res = f 3
    res |> should equal 6