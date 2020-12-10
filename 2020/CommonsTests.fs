module CommonsTests

open FsUnit.Xunit
open FsCheck.Xunit
open Xunit

open Commons

[<Property>]
let ``sortedInsert test`` (list: int list) =
    let actual =
        list
        |> List.fold (fun sorted n -> sortedInsert n sorted) []
        |> withIndex
        |> Seq.toList

    let expected =
        list
        |> List.sort
        |> withIndex
        |> Seq.toList

    actual
    |> should matchList expected