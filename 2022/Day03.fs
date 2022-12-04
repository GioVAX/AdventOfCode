module Day03

let split (s:string) =
    let l = s.Length / 2
    (s.[0..l-1], s.[l..])

let findCommon (s1, s2) =
    s1 |> Seq.find (fun c -> s2 |> Seq.contains c)

let priority c =
    let priorityList = ' ' :: (List.append ['a'..'z'] ['A'..'Z'])
    priorityList |> List.findIndex (fun cl -> cl = c)

let part1 =
    List.map (split >> findCommon >> priority)
    >> List.sum

    