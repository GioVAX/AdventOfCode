module Day05

open System.Text.RegularExpressions

let endOfConfig numStacks =
    let x = [for i in 1..numStacks -> " " + string i + " "]
    System.String.Join(' ', x)

let regexForConfig = "(   )|\\[([A-Z])]"

let readConfigLine s =
    Regex.Split(s, regexForConfig)
    |> Array.chunkBySize 2
    |> Array.filter (fun l -> l.Length = 2)
    |> Array.map (fun l -> 
        match l[1] with
        | "   " -> ""
        | s -> s)

let initialConfigParser (lines: string list) numStacks : char list array =
    let output = Array.init numStacks (fun _ -> []:char list)

    let eoc = endOfConfig numStacks

    let config = 
        lines
        |> List.takeWhile (fun l -> l.Equals(endOfConfig))
        |> List.map readConfigLine
    
