module Utils

let readData filePath = 
    System.IO.File.ReadLines filePath
    |> Seq.toList

let seqToString : char seq -> string =
    Seq.toArray
    >> System.String