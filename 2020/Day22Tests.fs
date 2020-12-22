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
    |> scoreGame
    |> should equal 306I

[<Theory>]
[<InlineData(12, 2)>]
let ``Test case 2`` (p1, p2) =
    [] |> should matchList []