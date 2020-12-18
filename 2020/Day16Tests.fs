module Day16Tests

open FsUnit.Xunit
open Xunit

open Day16

let testData = 
    [
        "class: 1-3 or 5-7";
        "row: 6-11 or 33-44";
        "seat: 13-40 or 45-50";
        "";
        "your ticket:";
        "7,1,14";
        "";
        "nearby tickets:";
        "7,3,47";
        "40,4,50";
        "55,2,20";
        "38,6,12";
    ]

[<Fact>]
let ``parse field`` () =
    parse testData.[0]
    |> should equal <| Field ("class", (1,3), (5,7))

[<Fact>]
let ``parse ticket`` () =
    parse testData.[8]
    |> should equal <| Ticket [7;3;47]

let ``parse testData`` () =
    let s = 
        testData
        |> Seq.map parse
        |> Seq.filter (fun r -> match r with | Ticket _ -> true | _ -> false)

    s |> should haveLength 5
    s |> Seq.head
    |> should equal <| Ticket [7;1;14]

let ``part 1`` () =
    result1 testData
    |> should equal 71


[<Theory>]
[<InlineData(12, 2)>]
let ``Test case 2`` (p1, p2) =
    [] |> should matchList []