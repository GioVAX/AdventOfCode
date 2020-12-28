module Day24

open Commons

let data = []

let offsets =
    Map.empty
        .Add("e", (1,0))
        .Add("se", (1,-1))
        .Add("sw", (0,-1))
        .Add("w", (-1,0))
        .Add("nw", (0,1))
        .Add("ne", (1,1))

let parse s =
    match s with
    | MultiRegex "^(?<d>se|sw|nw|ne|s|e|w|n)+$" ds ->
        ds.["d"] 
        |> List.map (fun v -> offsets |> Map.find v)
    | _ -> failwith $"Syntax error -> {s}"

let walk (start:(int*int)) (moves: (int*int) list) =
    moves
    |> List.fold 
        (fun (ox, oy) (dx, dy) -> (ox+dx, oy+dy))
        start

let result1 =
    1
    
let result2 =
    2
