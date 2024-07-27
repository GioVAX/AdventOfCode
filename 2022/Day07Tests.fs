module Day07Tests

open FsUnit.Xunit
open Xunit

open Utils
open Day07

let input =
    "$ cd /\n\
    $ ls\n\
    dir a\n\
    14848514 b.txt\n\
    8504156 c.dat\n\
    dir d\n\
    $ cd a\n\
    $ ls\n\
    dir e\n\
    29116 f\n\ng
    2557 g\n\
    62596 h.lst\n\
    $ cd e\n\
    $ ls\n\
    584 i\n\
    $ cd ..\n\
    $ cd ..\n\
    $ cd d\n\
    $ ls\n\
    4060174 j\n\
    8033020 d.log\n\
    5626152 d.ext\n\
    7214296 k"

[<Fact>]
let ``input contains multiple lines`` () =
    input.Split '\n'
    |> Array.length
    |> should be (greaterThan 1)

[<Fact>]
let ``input lines include the trailing \n`` () =
    (input.Split '\n')[1]
    |> String.exists ((=) '\n')

[<Fact>]
let ``command parse`` () =
    match "$ cd /\n" with
    | Command c -> c |> should equal (Cd(dest = "/"))
    | _ -> failwith "failed on cd"

    match "$ ls\n" with
    | Command c -> c |> should equal Ls
    | _ -> failwith "failed on ls"

[<Fact>]
let ``executing "cd /" moves to the root`` () =
    let currDir =
        { files = Map.empty |> Map.add "x" (File { size = 1 }) }

    currDir |> should not' (equal root)

    cd currDir "/" |> should equal root

[<Fact>]
let ``executing cd to existing dir should work`` () =
    let subdir =
        { files = Map.empty |> Map.add "z" (File { size = 2 }) }

    let currDir =
        { files =
            Map.empty
            |> Map.add "x" (File { size = 1 })
            |> Map.add "y" (Dir subdir) }

    currDir |> should not' (equal root)

    let destDir = cd currDir "y"
    
    destDir |> should equal subdir
    destDir |> should not' (equal root)

[<Fact>]
let ``executing cd to existing dir should throw`` () =
    let subdir =
        { files = Map.empty |> Map.add "z" (File { size = 2 }) }

    let currDir =
        { files =
            Map.empty
            |> Map.add "x" (File { size = 1 })
            |> Map.add "y" (Dir subdir) }

    currDir |> should not' (equal root)

    (fun () -> cd currDir "k" |> ignore) 
        |> should (throwWithMessage "folder k not found") typeof<System.Exception>