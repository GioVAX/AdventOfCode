module Day06

open Utils

let containsNoRepeated n s =
    s
    |> Seq.toList
    |> Set.ofList
    |> Set.count
    |> (=) n

let findMarker n s =
    s
    |> Seq.windowed n
    |> Seq.findIndex (containsNoRepeated n)


let solve n s =
    s
    |> findMarker n
    |> (+) n

let runPart1 =
    fetchDayInput 6
    |> solve 4

let runPart2 =
    fetchDayInput 6
    |> solve 14