module Utils

open FsHttp
open System.Text.RegularExpressions

let aoc_token="53616c7465645f5f11f1ae4157653608ee8c58b4a4c90b9cb9deb9c4e309ed179b38cc991e69cc916acad93e43e18f42ca25ebd9cd68cd85ac492981add30a39"
let fetchDayInput day =
    http {
        GET $"https://adventofcode.com/2022/day/%d{day}/input"
        Cookie "session" aoc_token
    }
    |> Request.send
    |> Response.toText

let readData filePath = 
    System.IO.File.ReadLines filePath
    |> Seq.toList

let seqToString : char seq -> string =
    Seq.toArray
    >> System.String

let (|Regex|_|) pattern input =
    let m = Regex.Match(input, pattern)
    if m.Success 
        then Some(List.tail [ for g in m.Groups -> g.Value ])
        else None

type stack<'a> = {value: 'a Option; count: int; next: stack<'a> Option}
let emptyStack = {value = None; count = 0; next = None}
let push v s = {value = Some v; count = s.count + 1; next = Some s}
let pop s = match s.next with | Some next -> next | None -> s
let isEmpty s = s.count = 0