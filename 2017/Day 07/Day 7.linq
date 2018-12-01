<Query Kind="Program">
  <Output>DataGrids</Output>
  <NuGetReference>LinqToExcel</NuGetReference>
  <Namespace>LinqToExcel</Namespace>
</Query>

class Node
{
	public Node( string s, List<string> programs ) {
		var nodeParts = s.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries );
		var node = nodeParts[0].Split( ' ' );
		Children = new List<Node>();
		
		Name = node[0];
		Weight = int.Parse( node[1].Split(new char[] {'(', ' ', ')'}, StringSplitOptions.RemoveEmptyEntries)[0]);
		
		if( nodeParts.Count() > 1 )
			foreach (var childName in nodeParts[1].Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries ))
				AddChild( new Node( programs.Single(p => p.StartsWith( childName)), programs ));
	}
	
	public void AddChild( Node child ) {
		Children.Add( child );
	}

	public string Name { get; set; }
	public int Weight { get; set; }
	public int TotalWeight => Weight + Children.Select(c => c.TotalWeight).Sum();
	public List<Node> Children { get; set; }
};

int FindUnbalance( Node root ) {
	
	if( root.Children.Count == 0 ) 
		return 0;

	var unbalance = root.Children.Select( c => FindUnbalance(c)).SingleOrDefault(u => u != 0 );
	if( unbalance != 0 )
		return unbalance;

	var weights = root.Children.GroupBy(w => w.TotalWeight);
	
	if( weights.Count() == 1 )
		return 0;

	var x = weights.Single(g => g.Count() == 1);
		
	root.Dump();
	return x.First().Weight + (weights.Single(g => g.Count() != 1).Key - x.Key);
}

void Main()
{
	
	var programs = File.ReadAllLines( @"C:\Users\pezzinog\Documents\LINQPad Queries\AdventOfCode2017\Day 07\Day 7 Input.txt").ToList();
//		new List<string>{
//			"pbga (66)",
//			"xhth (57)",
//			"ebii (61)",
//			"havc (66)",
//			"ktlj (57)",
//			"fwft (72) -> ktlj, cntj, xhth",
//			"qoyq (66)",
//			"padx (45) -> pbga, havc, qoyq",
//			"tknk (41) -> ugml, padx, fwft",
//			"jptl (61)",
//			"ugml (68) -> gyxo, ebii, jptl",
//			"gyxo (61)",
//			"cntj (57)",
//		};
	
	var dependents = programs.Where(p => p.Contains("->"))
		.SelectMany(p => p.Split(new string[] { "->"}, StringSplitOptions.RemoveEmptyEntries )[1]
							.Trim()
								.Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries ));
	
	var root = programs.Single(p => !dependents.Contains( p.Split(' ')[0]));
	root.Dump();	// Solution step 1
	
	var tree = new Node( root, programs );
	
	FindUnbalance( tree ).Dump();
}