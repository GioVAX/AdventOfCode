module Day13Tests

open FsUnit.Xunit
open Xunit

open Day13

let testData = "7,13,x,x,59,x,31,19"

[<Fact>]
let ``parseWithIndex`` () =
    "17,x,13,19" 
    |> parseWithIndex
    |> Seq.toList
    |> should matchList [(0,17);(2,13);(3,19)]

[<Theory>]
[<InlineData("17,x,13,19", "3417")>]
[<InlineData("67,7,59,61", "754018")>]
[<InlineData("67,x,7,59,61", "779210")>]
[<InlineData("7,13,x,x,59,x,31,19", "1068781")>]
[<InlineData("67,7,x,59,61", "1261476")>]
[<InlineData("1789,37,47,1889", "1202161486")>]
let ``Test part 2`` (busList, expected) =
    computeTime2 busList
    |> should equal (expected |> bigint.Parse)