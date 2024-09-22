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

let countVisibleTrees =
    Array.fold
        (fun (maxH, count) h ->
            match h with
            | _ when h > maxH ->
                (h, count + 1)
            | _ -> (maxH, count))
        (-1,0)
    >> snd