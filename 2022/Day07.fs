module Day07

open Utils

type File = {
    size: int;
} and Dir = {
    files: Map<string, Node>
} and Node = 
    | File of File
    | Dir of Dir

type Command =
    | Cd of dest:string
    | Ls

type ParseStatus = {
    currentDir: File
}

let root = {files=Map.empty}

let (|Command|_|) input =
    match input with
    | Regex "\$ cd (.*)$" [path] -> Some (Cd path)
    | "$ ls\n" -> Some Ls
    | _ -> None

let cd currDir path =
    match path with
    | "/" -> root
    | _ ->
        match Map.tryFind path currDir.files with
        | Some(Dir d) ->
            d
        | Some _ 
        | None ->
            "folder " + path + " not found"
            |> failwith

// let executeCmd status cmd = 
//     match cmd with
//     | Utils.Regex "$ cd (.*)" path ->
//         ()
//     | "$ ls" ->
//         ()




