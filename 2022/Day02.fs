module Day02

let score = function
    | "A X" -> 4
    | "A Y" -> 8
    | "A Z" -> 3
    | "B X" -> 1
    | "B Y" -> 5
    | "B Z" -> 9
    | "C X" -> 7
    | "C Y" -> 2
    | "C Z" -> 6
    | _ -> failwith "wrong combo"

let part1 lines =
    lines
    |> List.map score
    |> List.sum