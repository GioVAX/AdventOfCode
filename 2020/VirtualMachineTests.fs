module VirtualMachineTests

open FsUnit.Xunit
open Xunit

open VirtualMachine

[<Fact>]
let ``parse test`` () =
    let tests = 
        [
            ("nop +400", Nop 400);
            ("nop -2", Nop -2);
            ("nop -0", Nop 0);
            ("acc -18", Acc -18);
            ("acc 8", Acc 8);
            ("jmp -3", Jmp -3);
            ("jmp -0", Jmp 0);
            ("jmp 4", Jmp 4);
        ]

    tests
    |> List.iter
        (fun (s, expected) -> s |> parse |> should equal expected)

[<Fact>]
let ``loadProgram SHOULd add an End op at the end of the program`` () =
    let source = 
        [
            "nop +0";
            "acc +1";
            "jmp -4";
            "acc +3"
        ]

    loadProgram source
    |> Seq.mapi (fun i o -> (i, o))
    |> Seq.toList
    |> should matchList [(0,Nop 0); (1, Acc 1); (2, Jmp -4); (3, Acc 3); (4, End)]

// [<Theory>]
// [<InlineData("nop +400", (Nop))>]
// [<InlineData("acc -18", Acc -18)>]
// let ``parse tests`` (s, expected) =
//     let actual = parse s
//     actual |>should equal expected