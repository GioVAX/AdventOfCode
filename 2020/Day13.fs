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
    
let firstBusAfterTime t b =
    let passingBefore = t % b
    (b, b - passingBefore)

let result1 =
    let beginWait = data.[0] |> int
    let buses = data.[1] |> parse
    
    let nextBus = 
        buses
        |> Seq.map (firstBusAfterTime beginWait)
        |> Seq.minBy snd
    
    (fst nextBus) * (snd nextBus)

// ----------------- part 2 --------------------------------

let parseWithIndex (buses:string) =
    buses.Split(",")
    |> Seq.indexed
    |> Seq.filter (snd >> (<>) "x")
    |> Seq.map (fun (i, s) -> (i, s |> int))

let check (maxBus:bigint) (offset:bigint) buses (n:bigint) =
    let baseline = (maxBus * n) - offset  
    buses
    |> Seq.forall (fun (off, bus) -> (baseline % bus) = (bus - off) % bus);;

let computeTime2 (input:string) =
    let buses = 
        input
        |> parseWithIndex
        |> Seq.map (fun (o, b) -> (bigint o, bigint b))
    
    let (offset, maxBus) =
        buses
        |> Seq.maxBy snd

    let n =
        Seq.initInfinite bigint
        |> Seq.find (check maxBus offset buses)

    (maxBus*n)-offset


let result2 =
    computeTime2 data.[1]    