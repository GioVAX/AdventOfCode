module Day02

type Game = {
    id : int;
    minRed: int;
    minBlue: int;
    minGreen: int
}

let parseGame (s:string) =
    let a1 = s.Split(':')
    let g = a1.[0].Split(' ')
    let gameId = g.[1] |> int

    let samples = a1.[1].Split(';',
        System.StringSplitOptions.RemoveEmptyEntries + System.StringSplitOptions.TrimEntries) |> Array.map (fun s -> s.Trim())

    
    
    {
        id = gameId;
        minRed = 1;
        minBlue = 2;
        minGreen = 3
    }
