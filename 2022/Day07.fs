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
    | FileNode of File
    | DirNode of Dir

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
        | Some(DirNode d) ->
            d
        | Some _ 
        | None ->
            "folder " + path + " not found"
            |> failwith

let convertToLine input = 
    match input with
    | Line l -> l
    | _ -> failwith ("bad input " + input)

let executeLine currentDir = function
    | Cd path ->
        cd currentDir path
    | Ls ->
        currentDir
    | FileInfo (size, name) ->
        let f = FileNode {size=size}
        {currentDir with files = Map.add name f currentDir.files}
    | Directory name ->
        let d = DirNode {parent=Parent currentDir; files=Map.empty}
        {currentDir with files = Map.add name d currentDir.files}