<Query Kind="Program">
  <Output>DataGrids</Output>
  <NuGetReference>LinqToExcel</NuGetReference>
  <Namespace>LinqToExcel</Namespace>
</Query>

class Node
{
	public Node(string x) {
		
	}
	
	public string Name { get; set; }
	public int Weight { get; set; }
	public List<Node> children { get; set; }
};

void Main()
{
	
var programs = new List<string>{
//"pbga (66)",
//"xhth (57)",
//"ebii (61)",
//"havc (66)",
//"ktlj (57)",
//"fwft (72) -> ktlj, cntj, xhth",
//"qoyq (66)",
//"padx (45) -> pbga, havc, qoyq",
//"tknk (41) -> ugml, padx, fwft",
//"jptl (61)",
//"ugml (68) -> gyxo, ebii, jptl",
//"gyxo (61)",
//"cntj (57)",
};

var inputFile = File.OpenText( @"C:\Users\pezzinog\Documents\LINQPad Queries\Code Advent Calendar\Day 7 Step 1 Input");
var line = "";
while( (line = inputFile.ReadLine())!= null ) 
	programs.Add( line);

var dependents = programs.Where(p => p.Contains("->"))
	.SelectMany(p =>  p.Split(new string[] { "->"}, StringSplitOptions.RemoveEmptyEntries )[1]
						.Trim()
							.Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries ));

var root = programs.Single(p => !dependents.Contains( p.Split(' ')[0]));

root.Dump();	// Solution step 1

var tree = new Node(
}


