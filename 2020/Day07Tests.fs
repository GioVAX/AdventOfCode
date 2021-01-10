module Day07Tests

open FsUnit.Xunit
open Xunit

open System.Text.RegularExpressions

open Day07

let testData = 
    [|
        "light red bags contain 1 bright white bag, 2 muted yellow bags.";
        "dark orange bags contain 3 bright white bags, 4 muted yellow bags.";
        "bright white bags contain 1 shiny gold bag.";
        "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.";
        "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.";
        "dark olive bags contain 3 faded blue bags, 4 dotted black bags.";
        "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.";
        "faded blue bags contain no other bags.";
        "dotted black bags contain no other bags.";
    |]

[<Fact>]
let ``Parse data with single contained`` () =
    let bag = parse testData.[0]
    bag.Color |> should equal "light red"
    bag.Contains |> Seq.toList
    |> should matchList ["muted yellow"; "bright white"]

[<Fact>]
let ``Parse data with multiple contained`` () =
    let bag = parse testData.[3]
    bag.Color |> should equal "muted yellow"
    bag.Contains |> Seq.toList
    |> should matchList ["faded blue"; "shiny gold"]

[<Fact>]
let ``Parse data with nothing contained`` () =
    let bag = parse testData.[8]
    bag.Color |> should equal "dotted black"
    bag.Contains |> Seq.toList
    |> should matchList []

[<Fact>]
let ``createMap tests`` () =
    let map = createMap testData

    map.["faded blue"]
    |> should matchList ["dark olive"; "muted yellow"; "vibrant plum"]

    map.["muted yellow"]
    |> should matchList ["light red"; "dark orange"]

[<Fact>]
let ``walkTheMap tests`` () =
    let map =
        testData 
        |> createMap
    
    walkTheMap map "shiny gold"
    |> should matchList ["shiny gold"; "bright white"; "muted yellow"; "light red"; "dark orange"]


[<Fact>]
let ``result1 test`` () =
    result1 testData 
    |> should equal 4
    
// [<Theory>]
// [<InlineData(12, 2)>]
// let ``Test case 2`` (p1, p2) =
//     [] |> should matchList []