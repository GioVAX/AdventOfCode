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

let digits = [
    ("one","1");
    ("two","2");
    ("three","3");
    ("four","4");
    ("five","5");
    ("six","6");
    ("seven","7");
    ("eight","8");
    ("nine","9")]
    
let rec convertSpelledDigits = function
    | "" -> ""
    | Prefix "one" rest -> 
        "1" + (convertSpelledDigits rest)
    | Prefix "two" rest ->
        "2" + (convertSpelledDigits rest)
    | Prefix "three" rest -> 
        "3" + (convertSpelledDigits rest)
    | Prefix "four" rest ->
        "4" + (convertSpelledDigits rest)
    | Prefix "five" rest -> 
        "5" + (convertSpelledDigits rest)
    | Prefix "six" rest ->
        "6" + (convertSpelledDigits rest)
    | Prefix "seven" rest -> 
        "7" + (convertSpelledDigits rest)
    | Prefix "eight" rest -> 
        "8" + (convertSpelledDigits rest)
    | Prefix "nine" rest -> 
        "9" + (convertSpelledDigits rest)
    | s -> 
        (s.Chars(0) |> string) + (s.Substring(1) |> convertSpelledDigits)

let part1 input =
    input 
    |> splitInput
    |> Array.map (justDigits >> firstAndLast)
    |> Array.filter (System.String.IsNullOrEmpty >> not)
    |> Array.sumBy convertToInt

let part2 input =
    input 
    |> splitInput
    |> Array.map (convertSpelledDigits >> justDigits >> firstAndLast)
    |> Array.filter (System.String.IsNullOrEmpty >> not)
    |> Array.sumBy convertToInt