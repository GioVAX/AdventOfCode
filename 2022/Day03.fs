module Day03

let split (s:string) =
    let l = s.Length / 2
    (s.[0..l-1], s.[l..])

let findCommon (s1, s2) =
    s1 |> Seq.find (fun c -> s2 |> Seq.contains c)

let findCommons (s1:string) (s2:string) =
    s1
    |> Seq.filter (fun c -> s2 |> Seq.contains c)
    |> Seq.toArray
    |> System.String
        
let priority c =
    let priorityList = ' ' :: (List.append ['a'..'z'] ['A'..'Z'])
    priorityList |> List.findIndex (fun cl -> cl = c)

let part1 =
    List.map (split >> findCommon >> priority)
    >> List.sum

let part2 (s: string list)=
    s |>
    (List.chunkBySize 3
    >> List.map (fun g -> (g |> List.reduce findCommons) |> Seq.head |> priority)
    >> List.sum)