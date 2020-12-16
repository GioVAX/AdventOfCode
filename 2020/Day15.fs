module Day15

let data = [1;17;0;10;18;11;6]

let nextNumber (map, last) turn =
    let res = 
        match Map.tryFind last map with
        | Some v -> turn - v - 1
        | None -> 0

    (Map.add last (turn - 1) map, res)

let compute nth (input: int seq) =
    let (map, _) = 
        input
        |> Seq.zip (Seq.initInfinite ((+) 2))
        |> Seq.fold
            (fun (m, _) (i,n) -> nextNumber (m, n) i ) 
            (Map.empty, 0)
    
    let (lastStep, lastSpoken) = input |> Seq.indexed |> Seq.last

    [lastStep + 2..nth]
    |> Seq.fold nextNumber (map, lastSpoken)
    |> snd
    
let result1 = compute 2020 data

let result2 = lazy (compute 30000000 data)