module Day10

let data = 
    [|
        71;
        183;
        111;
        89;
        92;
        142;
        25;
        101;
        52;
        86;
        18;
        22;
        70;
        2;
        135;
        163;
        34;
        143;
        153;
        35;
        144;
        24;
        23;
        94;
        100;
        102;
        17;
        57;
        76;
        182;
        134;
        38;
        7;
        103;
        66;
        31;
        11;
        121;
        77;
        113;
        128;
        82;
        99;
        148;
        137;
        41;
        32;
        48;
        131;
        60;
        127;
        138;
        73;
        28;
        10;
        84;
        180;
        63;
        125;
        53;
        176;
        165;
        114;
        145;
        152;
        72;
        107;
        167;
        59;
        164;
        78;
        126;
        118;
        136;
        83;
        79;
        58;
        14;
        106;
        69;
        51;
        39;
        157;
        42;
        177;
        173;
        93;
        141;
        3;
        33;
        13;
        19;
        45;
        154;
        95;
        170;
        54;
        181;
        6;
        151;
        1;
        112;
        96;
        115;
        85;
        108;
        166;
        160;
        40;
        122;
        12;
    |] |> Array.toList

let rec toDiffs = function
    | [] 
    | [_] -> []
    | n1::n2::ns -> (n2-n1)::toDiffs (n2::ns)

let result1 =
    let data' =
        0::data
        |> List.sort

    let devJolts = (+) 3 <| List.max data'

    let data'' =
        data' @ [devJolts]        
        |> toDiffs

    data''
    |> List.groupBy id
    |> List.map (snd >> List.length)
    |> List.fold (*) 1      // This assumes that the differences are all 1s and 3s!!!!

let array = Array2D.init 4 data.Length (fun i j -> if i = 1 || j = 1 then Some 1 else None)

let rec howManyWays getTo jump =
    match array.[jump,getTo] with
    | Some n -> n
    | None ->
        let v = (howManyWays getTo jump-1) + (howManyWays (getTo-jump) jump)
        Array2D.set array jump getTo 
        <| Some v
        v

let result2 =
    2
