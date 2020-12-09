module Day01Tests

open System
open FsUnit.Xunit
open Xunit

open Commons
open Day01

[<Fact>]
let ``Puzzle 1 - example case`` () =
    let data = [1721;979;366;299;675;1456]
   
    let (f1, f2) =
        match findCouple 2020 data with
        | None -> failwith "No couple found"
        | Some (f1, f2) -> (f1, f2)
    
    f1 + f2 |> should equal 2020
    f1 * f2 |> should equal 514579

[<Fact>]
let ``Puzzle 2 - example case`` () =
    let data = [1721;979;366;299;675;1456]

    let (f1, f2, f3) =
        match findTriple 2020 data with
        | None -> failwith "No triple found"
        | Some (f1, f2, f3) -> (f1, f2, f3)

    f1 + f2 + f3 |> should equal 2020
    f1 * f2 * f3 |> should equal 241861950