module Day02Tests

open FsUnit.Xunit
open Xunit

open AoCUtils
open Day02

let testDataPart1 = """Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"""

[<Fact(Skip=":(")>]
let ``I can use regexs to parse a game`` () =
    let game = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"
    let gamePattern = @"Game (\d*): (.*);?? (.*)??;?? (.*)??$"
    let gamePattern' = @"Game (\d*): ((\d+ (red|green|blue)),?){1,3};?? ((\d+ (red|green|blue)),?){1,3}??;?? ((\d+ (red|green|blue)),?){1,3}??$"

    let (sample1, sample2, sample3) =
        match game with
            | ParseRegex gamePattern' [gameId; s1; s2; s3]
                -> 
                gameId |> should equal "1"
                s1 |> should equal "3 blue, 4 red"
                s2 |> should equal "1 red, 2 green, 6 blue"
                s3 |> should equal "2 green"
                (s1, s2, s3)
            | _ -> failwith "No pattern match"

    match "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green" with
    | ParseRegex gamePattern matches ->
        matches.[0] |> should equal "5"
        matches |> should haveLength 3
        matches.[1] |> should equal "6 red, 1 blue, 3 green"
        matches.[2] |> should equal "2 blue, 1 red, 2 green"
    | _ -> failwith "No second match"

    let m = System.Text.RegularExpressions.Regex(@"((\d+ (red|green|blue)),?){1,3}").Match(sample1)
    m.Success |> should be True
    m.Groups.Count |> should equal 4
    
    match sample1 with
    | ParseGroups @"(\d+ red,?|\d+ green,?|\d+ blue,?)" matches
        ->
            matches |> should haveLength 2
            matches.[0] |> should equal "3 blue,"
            matches.[1]  |> should equal "4 red"
    | _ -> failwith $"no sample in <{sample1}>"

[<Fact>]
let ``parse game`` () =
    let game1 = parseGame "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"
    game1.id |> should equal 1