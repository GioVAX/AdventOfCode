module Day06

let input = "1,4,2,4,5,3,5,2,2,5,2,1,2,4,5,2,3,5,4,3,3,1,2,3,2,1,4,4,2,1,1,4,1,4,4,4,1,4,2,4,3,3,3,3,1,1,5,4,2,5,2,4,2,2,3,1,2,5,2,4,1,5,3,5,1,4,5,3,1,4,5,2,4,5,3,1,2,5,1,2,2,1,5,5,1,1,1,4,2,5,4,3,3,1,3,4,1,1,2,2,2,5,4,4,3,2,1,1,1,1,2,5,1,3,2,1,4,4,2,1,4,5,2,5,5,3,3,1,3,2,2,3,4,1,3,1,5,4,2,5,2,4,1,5,1,4,5,1,2,4,4,1,4,1,4,4,2,2,5,4,1,3,1,3,3,1,5,1,5,5,5,1,3,1,2,1,4,5,4,4,1,3,3,1,4,1,2,1,3,2,1,5,5,3,3,1,3,5,1,5,3,5,3,1,1,1,1,4,4,3,5,5,1,1,2,2,5,5,3,2,5,2,3,4,4,1,1,2,2,4,3,5,5,1,1,5,4,3,1,3,1,2,4,4,4,4,1,4,3,4,1,3,5,5,5,1,3,5,4,3,1,3,5,4,4,3,4,2,1,1,3,1,1,2,4,1,4,1,1,1,5,5,1,3,4,1,1,5,4,4,2,2,1,3,4,4,2,2,2,3"

let parse (s:string) = 
    s.Split [|','|]
    |> Array.map int
    |> Array.toList

let dayIteration fishes _ =
    fishes
    |> List.collect 
        (fun daysToHatch ->
            match daysToHatch with
            | 0 -> [6;8]
            | _ -> [daysToHatch-1]
        )

let nextBirths daysToHatch daysToGo = 
    [daysToGo - daysToHatch .. -7 .. 0]

let rec computeGenerations daysToHatch daysToGo =
    let births = nextBirths daysToHatch daysToGo

    1I +
    match births with
    | [] -> 0I  // not enough time left to hatch
    | _ -> 
         births
            |> List.map (computeGenerations 9)
            |> List.sum
    
let solvePart1 (input:string) =
    let state0 = parse input

    [1..80]
    |> List.fold dayIteration state0
    |> List.length

let solvePart2 (input:string) =
    let state0 = parse input

    state0
    |> List.map (fun d -> computeGenerations d 255)
    |> List.sum