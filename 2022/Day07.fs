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

let(|Line|_|) input =
    match input with 
    | Regex "\$ cd (.*)$" [path] ->
        Some (Cd path)
    | "$ ls\n" ->
        Some Ls
    | Regex "dir (.*)$" [dirName] ->
        Some (Directory dirName)
    | Regex "(\d*) (.*)$" [size; name] ->
        Some (FileInfo (int size , name))
    | _ ->
        None

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




