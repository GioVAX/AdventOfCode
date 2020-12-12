module Day10Tests

open FsUnit.Xunit
open Xunit

open Day10

let testData = [16;10;15;5;1;11;7;19;6;12;4]
let testData' = [28;33;18;42;31;14;46;20;48;47;24;23;49;45;19;38;39;11;1;32;25;35;8;17;7;9;4;2;34;10;3]

[<Fact>]
let ``Test case 1`` () =
    let data' =
        0::testData
        |> List.sort
        |> toDiffs

    data'
    |> List.groupBy id
    |> List.map (fun (j,l) -> (j, List.length l))
    |> should matchList [(1,7); (3,4)]

[<Fact>]
let ``Test case part 2`` () =
    let data' =
        0::testData
        |> List.sort

    let devJolts = (+) 3 <| List.max data'

    let diffs =
        data' @ [devJolts]        
        |> toDiffs
    
    diffs |> List.indexed |> should matchList <| List.indexed [1;3;1;1;1;3;1;1;3;1;3;3]

    let ways =
        Map.empty
            .Add(1, 1u)
            .Add(2, 2u)
            .Add(3, 4u)
            .Add(4, 5u)

    let seqs = 
        diffs
        |> List.fold countSeqs1 [0]
        |> List.filter ((<>) 0) 
        |> List.map (fun n -> ways.[n])

    seqs |> should matchList [1u;2u;4u;1u]

    let res = 
        seqs |> List.fold (*) 1u
    
    res |> should equal 8u

[<Fact>]
let ``Test case part 2 - 2`` () =
    let data' =
        0::testData'
        |> List.sort

    let devJolts = (+) 3 <| List.max data'

    let diffs =
        data' @ [devJolts]        
        |> toDiffs
    
    // diffs |> List.indexed |> should matchList <| List.indexed [1;3;1;1;1;3;1;1;3;1;3;3]

    let ways =
        Map.empty
            .Add(1, 1I)
            .Add(2, 2I)
            .Add(3, 4I)
            .Add(4, 5I)

    let seqs = 
        diffs
        |> List.fold countSeqs1 [0]
        |> List.filter ((<>) 0) 
        |> List.map (fun n -> ways.[n])

    // seqs |> should matchList [1u;2u;4u;1u]

    let res = 
        seqs |> List.fold (*) 1I
    
    res |> should equal 19208I