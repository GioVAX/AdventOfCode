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

let p1 = @"(?<container>.*) bags contain (\d+ (?<contained>.*) bags?,?)*"
let p2 = @"(?<container>[\w\s]*) bags contain (\d+ (?<contained>[\w\s]*) bags?[,.])*"
let p3 = @"\d+ (?<color>.*?) bags?[.,]?"

[<Fact>]
let ``Parse data with single contained`` () =
    let m = Regex.Matches(testData.[0], @"(?<container>.*) bags contain( \d+ (?<contained>.*?) bags?,?)*")
    m.Count |> should equal 1
    
    let container = m.[0].Groups.["container"]
    container.Captures.Count |> should equal 1
    container.Value |> should equal "light red"
    container.Captures.[0].Value |> should equal "light red"

    let contained = m.[0].Groups.["contained"]
    contained.Captures.Count |> should equal 2
    contained.Value |> should equal "muted yellow"
    contained.Captures
    |> Seq.map (fun c -> c.Value)
    |> Seq.toList
    |> should matchList ["muted yellow"; "bright white"]

[<Fact>]
let ``Parse data with multiple contained`` () =
    let m = Regex.Matches(testData.[3], @"(?<container>.*) bags contain( \d+ (?<contained>.*?) bags?,?)*")
    m.Count |> should equal 1

    let container = m.[0].Groups.["container"]
    container.Captures.Count |> should equal 1
    container.Value |> should equal "muted yellow"
    container.Captures.[0].Value |> should equal "muted yellow"

    let contained = m.[0].Groups.["contained"]
    contained.Captures.Count |> should equal 2
    contained.Value |> should equal "faded blue"
    contained.Captures
    |> Seq.map (fun c -> c.Value)
    |> Seq.toList
    |> should matchList ["faded blue"; "shiny gold"]

[<Theory>]
[<InlineData(12, 2)>]
let ``Test case 2`` (p1, p2) =
    [] |> should matchList []