module Commons

open System.Text.RegularExpressions

let (|Regex|_|) pattern input =
    let m = Regex.Match(input, pattern)
    if m.Success
    then Some(List.tail [for g in m.Groups -> g.Value])
    else None

let (|MultiRegex|_|) pattern input =
    match Regex.Matches(input, pattern)  with
    | m when m |> Seq.isEmpty -> 
        None
    | matches ->
        matches
        |> Seq.collect 
            (fun m -> 
                m.Groups 
                |> Seq.map 
                    (fun g -> (g.Name, [for h in g.Captures -> h.Value])))
        |> Map.ofSeq
        |> Some

let groupDataOnSeparator (groupSeparator:string) (separator:string) =
    let rec loop = function 
    | [] -> []
    | [s1] -> [s1]
    | s1::s2::tail when s2 = groupSeparator -> 
        s1::(loop tail)
    | s1::s2::tail -> 
        (s1 + separator + s2)::tail
        |> loop
    loop

let withIndex s =
    s |> Seq.mapi (fun i p -> (i, p))

let findCouple target sortedList =
    let rec search l1 l2 =
        match (l1, l2) with
        | ([], _) | (_, []) -> None
        | (h1::_,h2::_) when h1 + h2 = target -> Some (h1, h2)
        | (h1::_,h2::t2) when h1 + h2 > target -> search l1 t2
        | (h1::t1,h2::_) (*when h1 + h2 < target*) -> search t1 l2

    let data' = List.rev sortedList

    search sortedList data'

let rec sortedInsert' lessThan list v =
    match list with
    | [] -> [v]
    | head::tail when lessThan v head -> v::head::tail
    | head::tail -> head::(sortedInsert' lessThan tail v)

// let sortedInsert = (sortedInsert' (<))

let rec sortedRemove cmp v = function
    | [] -> []
    | head::tail when cmp head v -> tail
    | head::tail -> head::(sortedRemove cmp v tail)

type Direction =
    | Right
    | Left
    | Up
    | Down

let manhattanDistance (x1, y1) (x2, y2) =
    let x = abs (x2 - x1)
    let y = abs  (y2 - y1)
    x + y

let rec reverse = function 
    | [] -> []
    | x::xs -> (reverse xs) @ [x]

let reverseSeq s = 
    s 
    |> Seq.toList 
    |> reverse 
    |> List.toSeq

let reverseString (s:string) = s |> reverseSeq |> System.String.Concat

let (|SeqEmpty|Seq|) (xs: 'a seq) = //'
  if Seq.isEmpty xs 
  then SeqEmpty
  else Seq(Seq.head xs, Seq.tail xs)