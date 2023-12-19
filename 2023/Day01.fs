module Day01

open AoCUtils

let example = """1abc2
pqr3stu8vwx
a1b2c3d4e5f
treb7uchet"""

let splitInput (s:string) =
    s.Split([|'\n'|])
    |> Array.map (fun s -> s.TrimEnd('\n', '\r'))

let justDigits:(string -> string) = 
    Seq.filter System.Char.IsDigit
    >> System.String.Concat

let firstAndLast (s:string) =
    match s.Length with
    | 0 -> ""
    | 1 -> 
        [|Seq.head s;Seq.head s|]
        |> System.String.Concat
    | _ ->
        [|Seq.head s;Seq.last s|]
        |> System.String.Concat

let convertToInt s = 
    try
        s |> int
    with :? System.FormatException ->
        failwithf "bad input <%s>" s

let part1 input =
    input 
    |> splitInput
    |> Array.map (justDigits >> firstAndLast)
    |> Array.filter (System.String.IsNullOrEmpty >> not)
    |> Array.sumBy convertToInt