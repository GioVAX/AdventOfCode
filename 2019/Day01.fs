module Day01

open System
open FsUnit.Xunit
open Xunit

let data = [143845;
86139;
53043;
124340;
73213;
108435;
126874;
131397;
85618;
107774;
66872;
94293;
51015;
51903;
147655;
112891;
100993;
143374;
83737;
145868;
144768;
89793;
124127;
135366;
94017;
81678;
102325;
75394;
103852;
81896;
148050;
142780;
50503;
110691;
117851;
137382;
92841;
138222;
128414;
146834;
59968;
136456;
122397;
147157;
83595;
59916;
75690;
125025;
147797;
112494;
76247;
100221;
63389;
59070;
97466;
91905;
126234;
76561;
128170;
102778;
82342;
131097;
51609;
148204;
74812;
64925;
127927;
79056;
73307;
78431;
88770;
97688;
103564;
76001;
105232;
145361;
77845;
87518;
117293;
110054;
135599;
85005;
85983;
118255;
103031;
142440;
140505;
99614;
69593;
69161;
78795;
54808;
115582;
117976;
148858;
84193;
147285;
89038;
92677;
106574;]

let fuel m =
    (m / 3) - 2

let rec fuel4fuel = function
    | z when z <= 0 -> 0
    | n -> 
        let k = (fuel n)
        n + fuel4fuel(k)

let result1 =
    data
    |> List.sumBy fuel

let result2 =
    data
    |> List.sumBy (fuel >> fuel4fuel)

[<Theory>]
[<InlineData(12, 2)>]
[<InlineData(14, 2)>]
[<InlineData(1969, 654)>]
[<InlineData(100756, 33583)>]
let ``Given a mass SHOULD compute correct fuel`` (mass, expected) =
    let res = fuel mass
    res |> should equal expected

[<Theory>]
[<InlineData(12, 2)>]
[<InlineData(14, 2)>]
[<InlineData(1969, 966)>]
[<InlineData(100756, 50346)>]
let ``Given a mass SHOULD compute correct fuel including the added fuel mass`` (mass, expected) =
    let fuel = fuel mass
    let totalFuel = fuel4fuel fuel
    totalFuel |> should equal expected