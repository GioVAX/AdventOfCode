module VirtualMachineTests

open FsUnit.Xunit
open Xunit

open VirtualMachine

[<Fact>]
let ``parse test`` () =
    let tests = 
        [
            ("nop +400", Nop);
            ("acc -18", Acc -18)
        ]

    tests
    |> List.iter
        (fun (s, expected) -> s |> parse |> should equal expected)
    
// [<Theory>]
// [<InlineData("nop +400", (Nop))>]
// [<InlineData("acc -18", Acc -18)>]
// let ``parse tests`` (s, expected) =
//     let actual = parse s
//     actual |>should equal expected