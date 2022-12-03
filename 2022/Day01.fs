module Day01

let private calories lines =
    let folder (acc, result) = function
    | "" -> ([], acc::result)
    | s -> (s::acc, result)

    let (last, elves) =
        lines
        |> List.fold folder ([],[])

    last::elves
        |> List.map ((List.map int) >> List.sum)

let part1 =
    calories 
    >> List.max

let part2 =
    calories
    >> List.sortDescending
    >> List.take 3
    >> List.sum