module VirtualMachine

type Operation =
    | Nop
    | Acc of int
    | Jmp of int
    | AlreadyVisited

let parse (s:string) =
    match s.[0..2] with
    | "nop" -> Nop
    | "jmp" -> s.[3..] |> int |> Jmp
    | "acc" -> s.[3..] |> int |> Acc
    | _ -> failwith "Unknown opCode"

let loadProgram s = 
    s |> Seq.map parse

let executeProgram (instructions:Operation array) = 
    let rec loop (idx, acc) =
        match instructions.[idx] with
        | AlreadyVisited -> acc
        | Nop -> 
            instructions.SetValue(AlreadyVisited, idx)
            loop (idx+1, acc)
        | Acc n -> 
            instructions.SetValue(AlreadyVisited, idx)
            loop (idx+1, acc+n)
        | Jmp n ->
            instructions.SetValue(AlreadyVisited, idx)
            loop (idx+n, acc)
    
    loop (0, 0)
    
