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

let getCrates stack n = 
    let (l,s) =
        [1..n]
        |> List.fold 
            (fun (l, s) _ -> (s.value.Value::l, pop s))
            ([],stack)
    (l |> List.rev, s)

let applyMoveCommand (status:array<stack<char>>) (cmd:MoveCommand) =
    let (moved, remaining) = getCrates status.[cmd.source-1] cmd.number

    let moveCrates (cmd:MoveCommand) idx stack =
        match idx with
        | _ when idx+1 = cmd.source -> remaining
        | _ when idx+1 = cmd.dest -> 
            moved
                |> List.fold (fun stack crate -> push crate stack)
                stack
        | _ -> stack

    status
    |> Array.mapi (moveCrates cmd)

let readInitials (stacks:array<stack<char>>) =
    stacks
    |> Array.map (fun s -> s.value.Value |> string)
    |> Array.reduce (+)

let part1 input numStacks =
    let splitLineIdx = findSplittingLine input numStacks
    let stacks = parseInitialConfig input numStacks splitLineIdx

    input
    |> List.skip (splitLineIdx + 2)
    |> List.fold
        (fun s line -> 
            let cmd = readCommandLine line
            applyMoveCommand s cmd
        ) stacks
    |> readInitials
