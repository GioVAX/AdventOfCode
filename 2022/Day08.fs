module Day08

open Utils

let inputTo2dArray (i:string) =
    i.Split '\n'
    |> Array.toList
    |> List.map Seq.toList
    |> array2D