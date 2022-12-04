module Day02

let private playMatch (scorer: (string -> int)) =
    List.map scorer
    >> List.sum

let private scorePart1 = function
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

let part1 =
    playMatch scorePart1

let private scorePart2 = function
    | "A X" -> 3
    | "A Y" -> 4
    | "A Z" -> 8
    | "B X" -> 1
    | "B Y" -> 5
    | "B Z" -> 9
    | "C X" -> 2
    | "C Y" -> 6
    | "C Z" -> 7
    | _ -> failwith "wrong combo"


let part2 =
    playMatch scorePart2