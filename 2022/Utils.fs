module Utils

open System.Text.RegularExpressions

let readData filePath = 
    System.IO.File.ReadLines filePath
    |> Seq.toList

let seqToString : char seq -> string =
    Seq.toArray
    >> System.String

let (|Regex|_|) pattern input =
    let m = Regex.Match(input, pattern)
    if m.Success 
        then Some(List.tail [ for g in m.Groups -> g.Value ])
        else None