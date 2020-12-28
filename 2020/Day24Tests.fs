module Day24Tests

open FsUnit.Xunit
open Xunit

open Day24

let testInput = 
    [
        "sesenwnenenewseeswwswswwnenewsewsw";
        "neeenesenwnwwswnenewnwwsewnenwseswesw";
        "seswneswswsenwwnwse";
        "nwnwneseeswswnenewneswwnewseswneseene";
        "swweswneswnenwsewnwneneseenw";
        "eesenwseswswnenwswnwnwsewwnwsene";
        "sewnenenenesenwsewnenwwwse";
        "wenwwweseeeweswwwnwwe";
        "wsweesenenewnwwnwsenewsenwwsesesenwne";
        "neeswseenwwswnwswswnw";
        "nenwswwsewswnenenewsenwsenwnesesenew";
        "enewnwewneswsewnwswenweswnenwsenwsw";
        "sweneswneswneneenwnewenewwneswswnese";
        "swwesenesewenwneswnwwneseswwne";
        "enesenwswwswneneswsenwnewswseenwsese";
        "wnwnesenesenenwwnenwsewesewsesesew";
        "nenewswnwewswnenesenwnesewesw";
        "eneswnwswnwsenenwnwnwwseeswneewsenese";
        "neswnwewnwnwseenwseesewsenwsweewe";
        "wseweeenwnesenwwwswnew";
    ]

[<Fact>]
let ``parse test`` () =
    let actual = 
        parse "nwnwneseeswswnenewneswwnewseswneseene"
        |> List.indexed
    let expected = 
        [(0,1);(0,1);(1,1);(1,-1);(1,0);(0,-1);(0,-1);(1,1);
         (1,1);(-1,0);(1,1);(0,-1);(-1,0);(1,1);(-1,0)
         (1,-1);(0,-1);(1,1);(1,-1);(1,0);(1,1)]
        |> List.indexed
    
    actual |> should matchList expected

[<Theory>]
[<InlineData("esew", 0,-1)>]
[<InlineData("nwwswee", 0,0)>]
let ``walk tests`` (path, fx, fy) =
    path
    |> parse
    |> walk (0,0)
    |> should equal (fx, fy)