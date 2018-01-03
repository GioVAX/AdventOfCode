<Query Kind="Program">
  <Output>DataGrids</Output>
  <NuGetReference>LinqToExcel</NuGetReference>
  <Namespace>LinqToExcel</Namespace>
</Query>

class Path {
	public int StartPoint {get;set;}
	public IEnumerable<int> Connections {get;set;}
	
	public Path( int start, IEnumerable<int> conns ){
		StartPoint = start;
		Connections = conns;
	}
}

void Main()
{
	var input = 
		new List<string> {
			"0 <-> 2",
			"1 <-> 1",
			"2 <-> 0, 3, 4",
			"3 <-> 2, 4",
			"4 <-> 2,3,6",
			"5 <-> 6",
			"6 <-> 4, 5"
		};
		
	var connected = new bool[input.Count];
	var starting_point = 0;
	
	var network = input.Select(c =>
	{
		var x = c.Split(new string[] { "<->" }, StringSplitOptions.RemoveEmptyEntries);
		return new Path( int.Parse(x[0]),
			x[1].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)));
	}).ToList();

	FollowConnections( new int[] { network[starting_point].StartPoint}.ToList(), network, connected );

	connected.Dump();
}

void FollowConnections(List<int> expand, List<Path> network, bool[] connected)
{
	if( expand.Count== 0 )
		return;

	var step = expand.First();
	expand.RemoveAt( 0 );

	if (!connected[step])
	{
		connected[step] = true;
		expand.AddRange(network[step].Connections);
	}

	FollowConnections( expand, network, connected );
}

