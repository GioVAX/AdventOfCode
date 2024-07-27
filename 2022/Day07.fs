module Day07

open Utils

type File = 
    | File of size: int
    | Dir of files: Map<string, File>

type Command =
    | Cd of dest:string
    | Ls

type ParseStatus = {
    currentDir: File
}

let root = Dir

let (|Command|_|) input =
    match input with
    | Regex "\$ cd (.*)$" [path] -> Some (Cd path)
    | "$ ls\n" -> Some Ls
    | _ -> None

// let executeCmd status cmd = 
//     match cmd with
//     | Utils.Regex "$ cd (.*)" path ->
//         ()
//     | "$ ls" ->
//         ()




