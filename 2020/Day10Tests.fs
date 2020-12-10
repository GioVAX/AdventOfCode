module Day10Tests

open FsUnit.Xunit
open Xunit

open Day10

[<Fact>]
let ``Test case 1`` () =
    let data = [16;10;15;5;1;11;7;19;6;12;4]

    let data' =
        0::data
        |> List.sort
        |> toDiffs

    data'
    |> List.groupBy id
    |> List.map (fun (j,l) -> (j, List.length l))
    |> should matchList [(1,7); (3,4)]

[<Theory>]
[<InlineData(12, 2)>]
let ``Test case 2`` (p1, p2) =
    [] |> should matchList []