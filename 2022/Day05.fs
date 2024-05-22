module Day05

open System.Text.RegularExpressions

open Utils

let createEndOfConfig numStacks =
    let x = [for i in 1..numStacks -> " " + string i + " "]
    System.String.Join(' ', x)

let regexForConfig = "(   )|\\[([A-Z])]"

let readConfigLine s  =
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

    let initialConfig =
        List.foldBack 
            (fun l s -> l |> Array.fold loadConfigStacks s)
            configLines
            (Array.init numStacks (fun _ -> emptyStack))
    
    initialConfig


let findSplittingLine lines numStacks =
    let endOfConfig = createEndOfConfig numStacks

    lines |> List.findIndex ((=) endOfConfig)

