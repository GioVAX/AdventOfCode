module Day12Tests

open FsUnit.Xunit
open Xunit

open Commons
open Day12

let testData =
    [
        "N3";
        "F10";
        "F7";
        "R90";
        "F11"
    ]

[<Fact>]
let ``Test case 1`` () =
    let (x,y,d) = 
        testData
        |> List.map parse
        |> List.fold turtle (0,0, Right)
        
    (x,y,d)
    |> should equal (17, -8, Down)

    manhattanDistance (0,0) (x,y)
    |> should equal 25

[<Fact>]
let ``Test case 2 - sub 1`` () =
    let r = turtle' (10, 1, 0,0) (Forward 10)
    r |> should equal (10, 1, 100, 10)


[<Fact>]
let ``Test case 2 - sub 2`` () =
    let r = turtle' (10, 1, 100, 10) (Nord 3)
    r |> should equal (10, 4, 100, 10)


[<Fact>]
let ``Test case 2 - sub 3`` () =
    let r = turtle' (10, 4, 100, 10) (Forward 7)
    r |> should equal (10, 4, 170, 38)

[<Fact>]
let ``Test case 2 - sub 4`` () =
    let r = turtle' (10, 4, 170, 38) (TurnRight 90)
    r |> should equal (4, -10, 170, 38)

[<Fact>]
let ``Test case 2 - sub 5`` () =
    let r = turtle' (4, -10, 170, 38) (Forward 11)
    r |> should equal (4, -10, 214, -72)

// [<Fact>]
// let ``Test case 2`` () =
//     let (x,y,sx, sy) = 
//         testData
//         |> List.map parse
//         |> List.fold turtle' (10, 1, 0,0)
        
//     (sx, sy)
//     |> should equal (214, 72)

//     manhattanDistance (0,0) (sx,sy)
//     |> should equal 286
