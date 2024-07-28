module Day07

open Utils

type File = {
    size: int;
} 

type ParentDir =
    | Root
    | Parent of Dir
and Dir = {
    parent: ParentDir
    files: Map<string, Node>
} and Node = 
    | File of File
    | Dir of Dir

type Line =
    | Cd of dest:string
    | Ls
    | FileInfo of size:int * name:string
    | Directory of name:string

type ParseStatus = {
    currentDir: File
}

let rec root = {
    parent=Root; 
    files=Map.empty
    }

let (|Line|_|) = function
    | Regex "^\$ cd (.+)$" [path] ->
        Cd path |> Some
    | "$ ls\n"
    | "$ ls" ->
        Some Ls
    | Regex "^dir (.+)$" [dirName] ->
        Directory dirName |> Some
    | Regex "^(\d+) (.+)$" [size; name] ->
        FileInfo (int size , name)  |> Some
    | _ ->
        None

let cd currDir path =
    match path with
    | "/" -> root
    | ".." -> 
        match currDir.parent with
        | Root -> currDir
        | Parent p -> p
    | _ ->
        match Map.tryFind path currDir.files with
        | Some(Dir d) ->
            d
        | Some _ 
        | None ->
            "folder " + path + " not found"
            |> failwith

let convertToLine input = 
    match input with
    | Line l -> l
    | _ -> failwith ("bad input " + input)

// let executeCmd status cmd = 
//     match cmd with
//     | Utils.Regex "$ cd (.*)" path ->
//         ()
//     | "$ ls" ->
//         ()




