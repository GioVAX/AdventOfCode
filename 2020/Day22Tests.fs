module Day22Tests

open FsUnit.Xunit
open Xunit

open Day22

let testDeck1 = [9;2;6;3;1]
let testDeck2 = [5;8;4;7;10]

[<Fact>]
let ``playGame test`` () =
    let res =
        playGame testDeck1 testDeck2
        |> List.indexed
    
    let expected = [3; 2; 10; 6; 8; 5; 9; 4; 7; 1] |> List.indexed
    
    res |> should matchList expected

[<Fact>]
let ``scoreGame test`` () =
    [3; 2; 10; 6; 8; 5; 9; 4; 7; 1]
    |> scoreDeck
    |> should equal 306I

[<Fact>]
let ``recursiveCombat SHOULD avoid infinite loops`` () =
    let (winner, _) = recursiveCombat [43;19] [2;29;14] Set.empty
    winner
    |> should equal 1

[<Fact>]
let ``Test part 2`` () =
    result2 testDeck1 testDeck2
    |> should equal 291I