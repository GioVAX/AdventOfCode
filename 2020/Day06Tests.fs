module Day06Tests

open FsUnit.Xunit
open Xunit

open Day06

let data =
    [
        "abc";
        "";
        "a";
        "b";
        "c";
        "";
        "ab";
        "ac";
        "";
        "a";
        "a";
        "a";
        "a";
        "";
        "b";
    ]

[<Fact>]
let ``groupAnswers test`` () =
    data
    |> groupAnswers
    |> should matchList ["abc";"abc";"abac";"aaaa";"b"]

[<Fact>]
let ``Test case 1`` () =
    solve1 data |> should equal 11

[<Fact>]
let ``Test case 1 - partial`` () =
    data 
    |> groupAnswers
    |> Seq.map (Seq.distinct >> Seq.length)
    |> Seq.toList
    |> should matchList [3;3;3;1;1]

[<Fact>]
let ``Set properties`` () =
    let ab = "ab" |> Set<char>
    let ca = "ca" |> Set<char>

    ab
    |> Set.count
    |> should equal 2

    let int = Set.intersect ab ca
    int.Count |> should equal 1

let fullSet = ['a'..'z'] |> Set

let folder (set:Set<char>, count:int) (s:string) =
    match s with
    | "" ->
        (fullSet, count + set.Count)
    | _ ->
        let set' = Set.intersect set (s |> Set)
        (set', count)

[<Fact>]
let ``folder test`` () =
    // let state = (Set<char>("ab"), 1)
    // let res = folder state ""
    // res |> should equal (Set.empty, 3)

    let state' = (fullSet, 1)
    let res' = folder state' "ab"
    res' |> should equal (set<char>("ab"), 1)

[<Fact>]
let ``part 2 with fold - first group`` () =
    let (set, cnt) = 
        data.[0..1]
        |> Seq.fold folder (fullSet, 0)
    
    cnt |> should equal 3

[<Fact>]
let ``part 2 with fold - second group`` () =
    let (set, cnt) = 
        data.[2..5]
        |> Seq.fold folder (fullSet, 0)
    
    cnt |> should equal 0


[<Fact>]
let ``part 2 with fold - third group`` () =
    let (set, cnt) = 
        data.[6..8]
        |> Seq.fold folder (fullSet, 0)
    
    cnt |> should equal 1

[<Fact>]
let ``part 2 with fold - fourth group`` () =
    let (set, cnt) = 
        data.[9..13]
        |> Seq.fold folder (fullSet, 0)
    
    cnt |> should equal 1
    

[<Fact>]
let ``part 2 with fold - fifth group`` () =
    let (set, cnt) = 
        data.[14..]
        |> Seq.fold folder (fullSet, 0)
    
    set.Count |> should equal 1
    cnt |> should equal 0
    
[<Fact>]
let ``part 2 with fold`` () =
    let (set, cnt) = data |> Seq.fold folder (fullSet, 0)
    
    cnt + set.Count
    |> should equal 6