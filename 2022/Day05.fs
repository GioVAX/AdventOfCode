module Day05

open System.Text.RegularExpressions

open Utils

type MoveCommand = {
    number: int;
    source: int;
    dest: int;
}

let createEndOfConfig numStacks =
    let x = [for i in 1..numStacks -> " " + string i + " "]
    System.String.Join(' ', x)


let readConfigLine s  =
    let regexForConfig = "(   )|\\[([A-Z])]"
    Regex.Split(s, regexForConfig)
    |> Array.chunkBySize 2
    |> Array.filter (fun a -> a.Length = 2)
    |> Array.mapi (fun idx a -> (idx, a[1][0]))

let loadConfigStacks (stacks:array<stack<char>>) (idx, letter) =
    match letter with
    | ' ' -> stacks
    | s -> 
        stacks.[idx] <- push s stacks.[idx]
        stacks

let parseInitialConfig lines numStacks configLineIndex //: array<stack<char>>
 =
    let configLines = 
        lines
        |> List.take configLineIndex
        |> List.map readConfigLine

    let initialStackConfig =
        List.foldBack 
            (fun l s -> l |> Array.fold loadConfigStacks s)
            configLines
            (Array.init numStacks (fun _ -> emptyStack))
    
    initialStackConfig


let findSplittingLine lines numStacks =
    let endOfConfig = createEndOfConfig numStacks

    lines |> List.findIndex ((=) endOfConfig)

let readCommandLine line = 
    match line with
    | Utils.Regex @"(?<number>\d*) from (?<from>\d*) to (?<to>\d*)" [n;s;d] ->
        {number=int n; source= int s; dest=int d}
    | _ ->
        failwith "Parser error"