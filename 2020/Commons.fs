module Commons

open System.Text.RegularExpressions

let (|Regex|_|) pattern input =
    let m = Regex.Match(input, pattern)
    if m.Success then Some(List.tail [for g in m.Groups -> g.Value])
    else None

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