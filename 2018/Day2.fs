// --- Day 2: Inventory Management System ---

// You stop falling through time, catch your breath, and check the screen on the device. "Destination reached. Current Year: 1518. Current Location: North Pole Utility Closet 83N10." You made it! Now, to find those anomalies.

// Outside the utility closet, you hear footsteps and a voice. "...I'm not sure either. But now that so many people have chimneys, maybe he could sneak in that way?" Another voice responds, "Actually, we've been working on a new kind of suit that would let him fit through tight spaces like that. But, I heard that a few days ago, they lost the prototype fabric, the design plans, everything! Nobody on the team can even seem to remember important details of the project!"

// "Wouldn't they have had enough fabric to fill several boxes in the warehouse? They'd be stored together, so the box IDs should be similar. Too bad it would take forever to search the warehouse for two similar box IDs..." They walk too far away to hear any more.

// Late at night, you sneak to the warehouse - who knows what kinds of paradoxes you could cause if you were discovered - and use your fancy wrist device to quickly scan every box and produce a list of the likely candidates (your puzzle input).

// To make sure you didn't miss any, you scan the likely candidate boxes again, counting the number that have an ID containing exactly two of any letter and then separately counting those with exactly three of any letter. You can multiply those two counts together to get a rudimentary checksum and compare it to what your device predicts.

// For example, if you see the following box IDs:

//     abcdef contains no letters that appear exactly two or three times.
//     bababc contains two a and three b, so it counts for both.
//     abbcde contains two b, but no letter appears exactly three times.
//     abcccd contains three c, but no letter appears exactly two times.
//     aabcdd contains two a and two d, but it only counts once.
//     abcdee contains two e.
//     ababab contains three a and three b, but it only counts once.

// Of these box IDs, four of them contain a letter which appears exactly twice, and three of them contain a letter which appears exactly three times. Multiplying these together produces a checksum of 4 * 3 = 12.

// What is the checksum for your list of box IDs?

let boxIDs = Array.toList [| "mvgowxqubnhaefjslkjlrptzyi"; "pvgowlqubnhaefmslkjdrpteyi"; "ovgowoqubnhaefmslkjnrptzyi"; "cvgowxqubnrxefmslkjdrptzyo"; "cvgowxqubnhaefmsokjdrprzyf"; 
    "cvgowxqubnhjeflslkjgrptzyi"; "cvgowxqvbnhaefmslkhdrotzyi"; "hvgowxqmbnharfmslkjdrptzyi"; "cvgoaxqubqhaefmslkjdrutzyi"; "cvxowxqdbnhaefmslkjdgptzyi"; 
    "cvgikxqubnhaefmslkjdrptzyz"; "cvgnwxqubnhaqfjslkjdrptzyi"; "cqgowxqubnhaecmslkjgrptzyi"; "cvpowxqucnhaefmslkjdrptzyz"; "fvuoexqubnhaefmslkjdrptzyi";
    "svgowxqubnhaefmsvkjdrttzyi"; "cvgowxqubnhaefmblkjdfpbzyi"; "cvkoyxqubnhaefsslkjdrptzyi"; "bvgowxqublhaefmslkjdrptzfi"; "xvgewxqubnhaefmslkjdrztzyi";
    "cvgowxqubzhaefmslkkrrptzyi"; "cvgowxqubnhaefmslkudruuzyi"; "cvgowxqubnhaefmvlkjdrptwyl"; "cvgoyxqubnhaefmslkjvrotzyi"; "cvgowxoubnhaewmslkjdrpbzyi";
    "cvgowxgubnhaefmslijdrptzxi"; "lvgowxqkbnhaefmslkjdrptzqi"; "xvgowxqubyhaefmflkjdrptzyi"; "wvnowxgubnhaefmslkjdrptzyi"; "cvgowxguwnhaefhslkjdrptzyi"; 
    "cvgowfquxnhaefmdlkjdrptzyi"; "cvgywxqubnuaefmsldjdrpfzyi"; "cvkowxqzbrhaefmslkjdrptzyi"; "cviowxzubnhaefmslkjdrptqyi"; "cvgowxqubnhaefmsozjdrptzyc"; 
    "cvglwxuubnhaewmslkjdrptzyi"; "cvgowxquknhaebmsfkjdrptzyi"; "vvgowxqubnhaesmslkjdrptzri"; "cvgowxoubndaefmslkjdrftzyi"; "cvgowxqubghaefmslkjdeptzyw"; 
    "cvgowxqubnhaetmhlkjdrpvzyi"; "cvgowmquunhaefmslkjdrptzyt"; "cvgooxqpbniaefmslkjdrptzyi"; "cvgowxqubnhaeumslkjdkptiyi"; "cvgrwxqsbnhaemmslkjdrptzyi"; 
    "cvrowxqubnhaefmslkjdrctcyi"; "dvgcwxqubnhaefmslkjdrptzyq"; "cugowxqubnhasfmmlkjdrptzyi"; "cwgowxqobzhaefmslkjdrptzyi"; "cvgowxquwnhaefmulkjdrptbyi"; 
    "nvgowxqmbnhaefmslyjdrptzyi"; "cvgowxqubniakvmslkjdrptzyi"; "cvyowxqubnhaefmslejdrptzyx"; "cvgobxqubghaefeslkjdrptzyi"; "cvgowxiubnhaebmslkjdfptzyi"; 
    "cvgosbqubnhaefmslkvdrptzyi"; "cvgpwxqubnhaefvslkjdrptzyh"; "cvgowxqubnyaefmslgjdsptzyi"; "cvgowxqubnhaefmslkjdrprzzp"; "cvgowxqubwhaemmslkjdrpazyi"; 
    "cvgowxqpbnhaemmslkjdrpczyi"; "cvgoqxqubnhaelmslkjdrptzye"; "cvgowxqubnhaefmslbjdrttzvi"; "cvgowxqubnhlefmslkvurptzyi"; "cvgowxqujngaefmslktdrptzyi"; 
    "cvgowxqubnhaefmsckjdcwtzyi"; "cvcowxqubnhaetmslkjorptzyi"; "jvnowxqubnhaefmslkjdrptzyf"; "cygowxqkbnhaefmslejdrptzyi"; "cvmowxqubnhaefmslkjdritzoi"; 
    "cvgowxqubnpaefmslkjdrpnnyi"; "cvgowxqubnhaefmolkjdrpnzyy"; "uvgowxoubnhaefmslkjdrptzvi"; "cvgowxbabehaefmslkjdrptzyi"; "cvgokxqubnhaefmsckjdrjtzyi"; 
    "cvgoxwqubahaefmslkjdrptzyi"; "cvgowxqusnhaefmslijdrptyyi"; "cvgowxqubmhaeqmslkxdrptzyi"; "cvgouxhubnhaefmslkjdrjtzyi"; "cvgowxqubnhaefmslrjdqptzyk"; 
    "cvgowxiublhaefsslkjdrptzyi"; "cvgowxqubnxgefmslkadrptzyi"; "ovgowxqugshaefmslkjdrptzyi"; "cvgowxquznhaeemslsjdrptzyi"; "cvkowxqubnhaeomslkjdeptzyi"; 
    "cvgvwxqubxhaefmslkjdrptzyu"; "cvglwxqybnhaefmslkjdrptzyb"; "cvgowxqubnlfwfmslkjdrptzyi"; "cvaowxqubnhaefmslkjdrvtzbi"; "cvgowxqubnrmefaslkjdrptzyi"; 
    "cvgowxqubnhaefmsnkjdfpwzyi"; "cvgawxqmbnhaefmsykjdrptzyi"; "chgowmqubnhaefmslkjdrptwyi"; "cogowxqubnhaefmslkjxrptzri"; "cvgohxqubnoaesmslkjdrptzyi"; 
    "cvdowxqubnhaofmslkjdrpvzyi"; "vvgowrqubnhaefmslkjdrpthyi"; "cvgowxquknhuefmslkjdoptzyi"; "cvyowxeubnhaefmslhjdrptzyi"; "cvglwxqubnhaefmslkjdrptdyq"; 
    "cvgowxqubnhaefmsikgdrptayi"; "cvgowxqubnhaefjhlkjdrpczyi"; "cvgzwxkubnhaefmslkjdjptzyi"; "cxgowxqubnhaefmslkjdrptwyy"; "cvgowxqubnhaefeslkjdrmqzyi"; 
    "cvgowxvubnhaefmilijdrptzyi"; "cvgowxqzbthaeomslkjdrptzyi"; "cvgowhqubndaefmglkjdrptzyi"; "cvgowxvubnhaeamylkjdrptzyi"; "cvgowiqubnhgefmslkjdrctzyi"; 
    "cvgowxqubchaefmslksdritzyi"; "cvgowxqubnhaefmsnkjdreyzyi"; "cvgowxqubihaefmslkgdrutzyi"; "cvgowxqjbnhaeamslkjdrptzwi"; "cvgowxzubnhaefmsxkjdrrtzyi"; 
    "cvgowxqubyhaetmslnjdrptzyi"; "cvgowxquhnhaebmslkjdxptzyi"; "cvgowxqubnhanfmslujdxptzyi"; "cvgowxqublhnefaslkjdrptzyi"; "cvgmwxqtbnhaefmslkjsrptzyi"; 
    "jvgowxqubnhaeamslkjdrpmzyi"; "cvgowxqubhiaefmsljjdrptzyi"; "svgowxqubnhaefmswkjdrpozyi"; "cvgowxqebnhaeqmslkjdiptzyi"; "cveowxqubnhayzmslkjdrptzyi";
    "cvglwxqubnhaefmxlkjdiptzyi"; "cvgowkqubdhaefmszkjdrptzyi"; "cvgowxkxbnhaeffslkjdrptzyi"; "cugowxqubnnaefmslujdrptzyi"; "cqgowxwubnhaepmslkjdrptzyi"; 
    "cvgowxqubnhayfmmlkjwrptzyi"; "cvgowxquenhaefmsskxdrptzyi"; "cvgowxqubnhiefmsrkjdtptzyi"; "mvgowxkubnhaefmjlkjdrptzyi"; "cvgowkquunhaefmglkjdrptzyi"; 
    "cvgowxqubqhaexmslgjdrptzyi"; "jvgowxqubnhaefmslkjddptlyi"; "cvgiwxqubnhaefmslkjdpptmyi"; "czgowxqubntaevmslkjdrptzyi"; "cvgotmqubnhaefmslkjdrpazyi"; 
    "cvgowxtubnhaefmslkqdtptzyi"; "cvbowxqhnnhaefmslkjdrptzyi"; "cvgowkqubshaefmstkjdrptzyi"; "cvgowqqrbnaaefmslkjdrptzyi"; "cvgoixqubnhaefmslkjdrpmryi"; 
    "cvgoxxqubnhaeimsxkjdrptzyi"; "cvgowxqubzhaebmslkjyrptzyi"; "cjgewxqubnhaefsslkjdrptzyi"; "cvgowxqdbnkaefmslwjdrptzyi"; "cvgowxqzbnhaeamslkjdrftzyi"; 
    "cvgoixqubnsaewmslkjdrptzyi"; "cvgswxqubnhaxfmslkjdrptzni"; "cvwowxmubnhgefmslkjdrptzyi"; "cvggwxqubnhaefmslqjdbptzyi"; "cvgzwxqjbnhaefaslkjdrptzyi"; 
    "cvgowzqubnharfmspkjdrptzyi"; "cvgowxqubnhawfmslkjdeptzyb"; "cvuowequbnhaefmslkjdrntzyi"; "gvgowxqubnxaefmslkjdrjtzyi"; "cvgowxqubnhmetmsldjdrptzyi"; 
    "cvgowxqubnhamfmsqkjdrptyyi"; "cvgoqxqubnhaefmslkjtrpazyi"; "cvgoexqubhhaefmslkjdrhtzyi"; "cvgowwqubnhaeflslkjdrptzyf"; "cvgowlpubnhaefmslkjdrptvyi"; 
    "cvgowxouunhaebmslkjdrptzyi"; "cvdowhqubnhaefmslijdrptzyi"; "cvgowxqubnkatfmslkjdrhtzyi"; "cvgowxqpbnhxeumslkjdrptzyi"; "cvgowxqubnhaefmsukjjrptzyn"; 
    "cvgowxqubnhmefmslzjdrvtzyi"; "cvtowxqubihaefmclkjdrptzyi"; "chgowcqubnhayfmslkjdrptzyi"; "cvguwxqubnhaefmblkjarptzyi"; "cvgowoqubnhaefmsikjdrytzyi"; 
    "cvgkwxqubnhaefmslkjdrptchi"; "cvhowxqubnhaefmslkjdrvlzyi"; "cvlowxfubnhaefmslkjkrptzyi"; "cvgowxqubhhaefoslkjdrytzyi"; "cvgowxsubqhaefmslpjdrptzyi"; 
    "cvgowxpubnhaefmslhjdrptzyb"; "cvgowxqubnhrefmjlkddrptzyi"; "cvgowxqubnhaxfmykkjdrptzyi"; "mvgowxqubnhakfmslkjdrptnyi"; "cwgowxqubnhaffmslkadrptzyi"; 
    "chgowxquwnhaefmslsjdrptzyi"; "cvgowxqubnhaefmslkjdwpnsyi"; "cvgawxqubnhaefmslkldyptzyi"; "cvgowxqubnhiefmslkjdiprzyi"; "cvgkqxqubnhaefcslkjdrptzyi"; 
    "cvgovoqubnhaefmslkjdrpuzyi"; "cvgowxqubnhaefmszkjdrjtzyk"; "cvgopxqubnhaefmslkjdqpnzyi"; "cvgtwxqubnhaefmslkjnrptzri"; "cvgowxqurnhaedmslfjdrptzyi"; 
    "cvpowxqubnhaefmswkjdrltzyi"; "cvgowxqujnpaefmslkjdrptdyi"; "cvgowgqubnhzifmslkjdrptzyi"; "lvgowxqubnhaenmslkjdbptzyi"; "ebgowxqubnhaeymslkjdrptzyi";
    "cvgowxtubqhaefmslkedrptzyi"; "cvgowxqubshaesmslkjdrptryi"; "cvgowxqubnhaefmflkjmrpkzyi"; "cvgowxqubngaefmslkjdrytzgi"; "cvgowxqubnhaefmslklhzptzyi"; 
    "cveowxqubnhgefmslkjdrpezyi"; "cvgowxqubnhaeomslkjdrqtzym"; "cvgowxqubzhaefmslwjdrptfyi"; "cmgowxqubnhaefmsdkjdrptzui"; "cvlowxqubnhaefmslsjdrptzwi"; 
    "cvhowxpubnhaefmslkjhrptzyi"; "cveosxqurnhaefmslkjdrptzyi"; "cvgowxqubnhaefgsdkjdrptjyi"; "cvgvwxqubnhaefmslzjdmptzyi"; "cviowxqubnhalfmslkjdrptzyr"; 
    "cvgowxqubchqefmslkjdrptzoi"; "cvgownqubnhaefmsyktdrptzyi"; "cvgywxqubnuaefmslkjdrpfzyi"; "cvgobxqunnhaefmslkjdrptzbi"; "cvgowxqubshaefgslkjdrxtzyi"; 
    "cvghwxqubnhaefmslkjdrbtmyi"; "cvhowxqubnhaefmslkjdrpnzys"; "cvgowxqubnmaefmslejdrptzyq"; "cvmrwxqubnhaefmslkjdrpzzyi"; "cvgowxqubshaefmslkfdrptzyu"; 
    "cvgowqqubnhaefmslkodrpjzyi"; "cvgnwnquknhaefmslkjdrptzyi"; "cvgowxquxnhacfmflkjdrptzyi"; "ovgowxqubnhaefmslkjmrmtzyi"; "cvgowxqubneaefmslkedrptzqi"; 
    "cvgowxqubphweflslkjdrptzyi"; "cvgowxqudnhaefmplkjdrptdyi"; "cvwowxbubnhaefmslkjurptzyi"; "cvgowxtubnhaefmslkjdrwwzyi"; "cvgowxqubnhkefmslajdrptzyn"; 
    "cvgowxqxbphaefmslkjdrptzsi"; "cvgowxquenhaefmslmjwrptzyi"; "zvgowdqubnhaeftslkjdrptzyi"; "csgowxqubnhgefmslkjdrptzyy"; "cvgolxqubahaefmslkjdrpvzyi"; 
    "cvgoqxquhwhaefmslkjdrptzyi"; "cvgawxqubghaefmsrkjdrptzyi"; "cvgozxqubnhaefmslkwdfptzyi"; "cvgowxqubnhaefmslhjdkptzzi"; "cvnowxqubnhaefmsqkjdrptqyi"; 
    "cvpowxqubnhaefmslkpdrptdyi"; "cvgowxoubnhaermslkjdrctzyi"; "cvgowxqubnheefmslkjdrctzyr"; "cvgowxqunnhaqfhslkjdrptzyi"; "cvgowxqulnhaefmslrjdrntzyi" |];;
// let groupedByChar = boxIDs |> List.map (fun s -> Seq.toList s |> List.countBy (fun c -> c))

let contains value charCounts =
    if charCounts |> Seq.exists (fun t -> (snd t) = value) 
        then 1 
        else 0;;

let counts = boxIDs 
                |> List.map (fun s ->  s |> Seq.countBy (fun c -> c ))
                |> Seq.fold (fun acc sc -> ((fst acc) + (contains 2 sc), (snd acc)+(contains 3 sc))) (0,0);;

printfn "%i" (fst counts * snd counts);;

// Confident that your list of box IDs is complete, you're ready to find the boxes full of prototype fabric.

// The boxes will have IDs which differ by exactly one character at the same position in both strings. For example, given the following box IDs:

// abcde
// fghij
// klmno
// pqrst
// fguij
// axcye
// wvxyz

// The IDs abcde and axcye are close, but they differ by two characters (the second and fourth). However, the IDs fghij and fguij differ by exactly one character, the third (h and u). Those must be the correct boxes.

// What letters are common between the two correct box IDs? (In the example above, this is found by removing the differing character from either ID, producing fgij.)
let rec pairs seq =
    match seq with
    | [] -> Seq.empty
    | h::t -> Seq.append (Seq.map (fun elem -> (h, elem)) t) (pairs t);;
let numOfDifferentChars s1 s2 =
    Seq.zip s1 s2 
    |> Seq.fold 
        (fun acc (c1,c2) -> acc + if c1 <> c2 then 1 else 0) 
        0;;
let concatenateCommonChars (s1:string, s2:string) =
    Seq.zip s1 s2 
    |> Seq.fold 
        (fun s (c1,c2) -> if c1 = c2 then s + string c1 else s) 
        "";;
        
printfn "%s" (boxIDs
                |> pairs
                |> Seq.find (fun (s1, s2) -> numOfDifferentChars s1 s2 = 1 )
                |> concatenateCommonChars);;
