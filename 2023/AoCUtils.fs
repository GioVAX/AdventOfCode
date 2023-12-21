module AoCUtils

open FsHttp
open System.Text.RegularExpressions

let aoc_token="53616c7465645f5f11f1ae4157653608ee8c58b4a4c90b9cb9deb9c4e309ed179b38cc991e69cc916acad93e43e18f42ca25ebd9cd68cd85ac492981add30a39"

let fetchDayInput day =
    http {
        GET $"https://adventofcode.com/2023/day/%d{day}/input"
        Cookie "session" aoc_token
    }
    |> Request.send
    |> Response.toText

let (|Prefix|_|) (p:string) (s:string) =
    if s.StartsWith(p) then
        Some(s.Substring(p.Length))
    else
        None

let (|ParseRegex|_|) regex str =
    let m = Regex(regex).Match(str)
    if m.Success
    then Some (List.tail [ for x in m.Groups -> x.Value ])
    else None

let (|ParseGroups|_|) regex str =
    match Regex(regex).Matches(str) with
    | s when Seq.isEmpty s -> 
        printf "No match"
        None
    | s ->
        printf "Matched!!!"
        s |> Seq.map (fun m -> m.Value) |> Seq.toList |> Some