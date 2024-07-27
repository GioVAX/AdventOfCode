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
let ``parse cd line`` () =
    match "$ cd /\n" with
    | Line l -> 
        l |> should equal (Cd(dest = "/"))
    | _ -> failwith "failed on cd"

[<Fact>]
let ``parse ls line`` () =
    match "$ ls\n" with
    | Line l -> 
        l |> should equal Ls
    | _ -> failwith "failed on ls"

[<Fact>]
let ``parse file line`` () =
    match "14848514 b.txt\n" with
    | Line l -> 
        l |> should equal (FileInfo(14848514, "b.txt"))
    | _ -> failwith "failed on fileinfo"
    
[<Fact>]
let ``parse dir line`` () =
    match "dir foo\n" with
    | Line l -> 
        l |> should equal (Directory("foo"))
    | _ -> failwith "failed on dir info"
    
    
[<Fact>]
let ``executing "cd /" moves to the root`` () =
    let currDir =
        { 
            parent = Parent root;
            files = Map.empty |> Map.add "x" (File { size = 1 }) 
        }

    currDir |> should not' (equal root)
    cd currDir "/" |> should equal root

[<Fact>]
let ``executing cd to existing dir should work`` () =
    let tmpDir =
        { 
            parent=Parent root;
            files = Map.empty |> Map.add "x" (File { size = 1 })
        }
    let subdir =
        { 
            parent = Parent tmpDir;
            files = Map.empty |> Map.add "z" (File { size = 2 }) 
        } 
    let currDir = {tmpDir with files = (Map.add "y" (Dir subdir) tmpDir.files) }
    
    currDir |> should not' (equal root)

    let destDir = cd currDir "y"
    
    destDir |> should equal subdir
    destDir |> should not' (equal root)

[<Fact>]
let ``executing cd to not existing dir should throw`` () =
    let tmpDir =
        { 
            parent=Parent root;
            files = Map.empty |> Map.add "x" (File { size = 1 })
        }
    let subdir =
        { 
            parent = Parent tmpDir;
            files = Map.empty |> Map.add "z" (File { size = 2 }) 
        } 
    let currDir = {tmpDir with files = (Map.add "y" (Dir subdir) tmpDir.files) }

    currDir |> should not' (equal root)

    (fun () -> cd currDir "k" |> ignore) 
        |> should (throwWithMessage "folder k not found") typeof<System.Exception>