module Day04

open Utils
open System.Text.RegularExpressions

type Interval = 
    {
        begin1: int
        end1: int
        begin2: int
        end2: int
    }

let convert s =
    match s with
    | Utils.Regex @"([0-9]{1,2})-([0-9]{1,2}),([0-9]{1,2})-([0-9]{1,2})" [i1s;i1e;i2s;i2e] ->
        Some {begin1=int i1s; end1=int i1e; begin2=int i2s; end2=int i2e}
    | _ ->
        failwith "Parser error"

let fullOverlap = function
    | None -> false
    | Some i ->
        (i.begin1 <= i.begin2 && i.end1 >= i.end2)
        ||
        (i.begin2 <= i.begin1 && i.end2 >= i.end1)

let partialOverlap = function
    | None -> false
    | Some i as x ->
        fullOverlap x
        ||
        (i.begin1 < i.begin2 && i.end1>= i.begin2 && i.end1 <= i.end2)
        ||
        (i.begin2 < i.begin1 && i.end2>= i.begin1 && i.end2 <= i.end1)

let private processor f =
    List.map convert
    >> List.filter f
    >> List.length

let part1 =
    processor fullOverlap

let part2 =
    processor partialOverlap