module Day13

let data = 
    [|
        "1000186";
        "17,x,x,x,x,x,x,x,x,x,x,37,x,x,x,x,x,907,x,x,x,x,x,x,x,x,x,x,x,19,x,x,x,x,x,x,x,x,x,x,23,x,x,x,x,x,29,x,653,x,x,x,x,x,x,x,x,x,41,x,x,13";
    |]

let parse (buses:string) =
    buses.Split(",")
    |> Seq.filter ((<>) "x")
    |> Seq.map int
    
let busAfterTime t b =
    let passingBefore = t % b
    (b, b - passingBefore)

let result1 =
    let beginWait = data.[0] |> int
    let buses = data.[1] |> parse
    
    let nextBus = 
        buses
        |> Seq.map (busAfterTime beginWait)
        |> Seq.minBy snd
    
    (fst nextBus) * (snd nextBus)

let result2 =
    2
