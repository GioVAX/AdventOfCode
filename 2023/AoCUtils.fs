module AoCUtils

open FsHttp

let aoc_token="53616c7465645f5f11f1ae4157653608ee8c58b4a4c90b9cb9deb9c4e309ed179b38cc991e69cc916acad93e43e18f42ca25ebd9cd68cd85ac492981add30a39"

let fetchDayInput day =
    http {
        GET $"https://adventofcode.com/2023/day/%d{day}/input"
        Cookie "session" aoc_token
    }
    |> Request.send
    |> Response.toText