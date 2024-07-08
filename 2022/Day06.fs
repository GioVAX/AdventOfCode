module Day06

open Utils

let containsNoRepeated s =
    s
    |> Seq.toList
    |> Set.ofList
    |> Set.count
    |> (=) 4

let findMarker s =
    s
    |> Seq.windowed 4
    |> Seq.findIndex containsNoRepeated

let receivedChars idx =
    idx + 4

let part1 s =
    s
    |> findMarker
    |> receivedChars

let runPart1 =
    fetchDayInput 6
    |> part1