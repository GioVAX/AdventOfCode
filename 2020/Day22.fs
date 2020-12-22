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

let scoreDeck deck = 
    deck
    |> List.rev
    |> List.indexed
    |> List.foldBack (fun (i,v) s -> s + ((i+1)*v |> bigint)) <| 0I

let result1 =
    let winner = playGame deck1 deck2
    scoreDeck winner

let rec recursiveCombat deck1 deck2 pastRounds =
    let round = (scoreDeck deck1, scoreDeck deck2)
    if pastRounds |> Set.contains round
    then (1, deck1)
    else 
        let pastRounds' = pastRounds |> Set.add round
        match (deck1, deck2) with
        | (_,[]) -> (1, deck1)
        | ([],_) -> (2, deck2)
        | (x1::xs1, x2::xs2) when x1 > xs1.Length || x2 > xs2.Length ->
            if x1 > x2 then (1, deck1) else (2, deck2)
        | (x1::xs1, x2::xs2) ->
            let deck1' = xs1 |> List.take x1
            let deck2' = xs2 |> List.take x2
            match (recursiveCombat deck1' deck2' pastRounds') with
            | (1, _) -> recursiveCombat (xs1@[x1;x2]) xs2 pastRounds'
            | (2, _) -> recursiveCombat xs1 (xs2@[x2;x1]) pastRounds'
            | _ -> failwith "Impossible winner"

let result2 deck1 deck2 =
    let (winner, deck) = recursiveCombat deck1 deck2 Set.empty
    scoreDeck deck
