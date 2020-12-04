module Day04Tests

open FsUnit.Xunit
open Xunit

open Day04

let testData = 
    [
        "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd";
        "byr:1937 iyr:2017 cid:147 hgt:183cm";
        "";
        "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884";
        "hcl:#cfa07d byr:1929";
        "";
        "hcl:#ae17e1 iyr:2013";
        "eyr:2024";
        "ecl:brn pid:760753108 byr:1931";
        "hgt:179cm";
        "";
        "hcl:#cfa07d eyr:2025 pid:166559648";
        "iyr:2011 ecl:brn hgt:59in";
    ]

[<Fact>]
let ``groupPassportData SHOULD return 4 strings`` () =
    testData
    |> groupPassportData
    |> should haveLength 4

let withIndex s =
    s 
    |> Seq.mapi (fun i p -> (i, p))
    |> List.ofSeq

[<Fact>]
let ``parsePassport SHOULD work`` () =
    let actual = 
        testData
        |> groupPassportData
        |> Seq.map (parsePassport >> (fun p -> p.Count))
        |> withIndex

    let expected = [8;7;7;6] |> withIndex
    
    actual
    |> should matchList expected

[<Fact>]
let ``isValid`` () =
    let res = 
        testData
        |> groupPassportData
        |> Seq.map (parsePassport >> isValid)

    let expected = 
        [true; false; true; false] |> withIndex

    res |> withIndex
    |> should matchList expected
