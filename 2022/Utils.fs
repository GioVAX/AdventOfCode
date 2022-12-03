module Utils

let readData filePath = 
    System.IO.File.ReadLines filePath
    |> Seq.toList