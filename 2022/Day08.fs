module Day08

open Utils

let inputTo2dArray (i:string) =
    i.Split '\n'
    |> Array.toList
    |> List.map 
        (fun s -> 
            s 
            |> Seq.toList
            |> Seq.map (fun c -> int c - int '0')
        )
    |> array2D