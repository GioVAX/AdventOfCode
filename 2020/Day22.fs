module Day22

let deck1 = 
    [
        21;
        50;
        9;
        45;
        16;
        47;
        27;
        38;
        29;
        48;
        10;
        42;
        32;
        31;
        41;
        11;
        8;
        33;
        25;
        30;
        12;
        40;
        7;
        23;
        46;
    ]

let deck2 =
    [
        22;
        20;
        44;
        2;
        26;
        17;
        34;
        37;
        43;
        5;
        15;
        18;
        36;
        19;
        24;
        35;
        3;
        13;
        14;
        1;
        6;
        39;
        49;
        4;
        28;        
    ]

let rec playGame deck1 deck2 =
    match (deck1, deck2) with
    | (_,[]) -> deck1
    | ([],_) -> deck2
    | (x1::xs1, x2::xs2) when x1 > x2 ->
        playGame (xs1@[x1;x2]) xs2
    | (x1::xs1, x2::xs2) ->
        playGame xs1 (xs2@[x2;x1])

let scoreGame deck = 
    deck
    |> List.rev
    |> List.indexed
    |> List.foldBack (fun (i,v) s -> s + ((i+1)*v |> bigint)) <| 0I

let result1 =
    let winner = playGame deck1 deck2
    scoreGame winner
    
let result2 =
    2
