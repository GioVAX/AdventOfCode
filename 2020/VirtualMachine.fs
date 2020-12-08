module VirtualMachine

open Commons

type Operation =
    | Nop of int
    | Acc of int
    | Jmp of int
    | End
    | AlreadyVisited

type Result =
    | EndProg of int
    | Cont of int * int

let parse (s:string) =
    match s with
    | Regex @"([a-z]{3}) ([+-]?\d+)" [op; value] ->
        match op with
        | "nop" -> value |> int |> Nop
        | "jmp" -> value |> int |> Jmp
        | "acc" -> value |> int |> Acc
        | _ -> failwith <| "Unknown opCode - " + op
    | _ -> failwith <| "Syntax error - " + s

let loadProgram s = 
    let prog = s |> Seq.map parse
    Seq.append prog [End]

let executeProgram (instructions:Operation array) = 
    let executeOp (idx, acc) = function
        | End
        | AlreadyVisited -> EndProg acc
        | Nop _ -> 
            Cont (idx+1, acc)
        | Acc n -> 
            Cont (idx+1, acc+n)
        | Jmp n ->
            Cont (idx+n, acc)

    let rec loop ((idx, _) as state) =
        match executeOp state instructions.[idx] with
        | EndProg res -> (idx, res)
        | Cont (idx', acc') ->
            instructions.SetValue(AlreadyVisited, idx)
            loop (idx', acc')
    
    loop (0, 0)