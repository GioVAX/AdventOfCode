<Query Kind="Program">
  <Output>DataGrids</Output>
  <NuGetReference>LinqToExcel</NuGetReference>
  <Namespace>LinqToExcel</Namespace>
</Query>

class Path
{
	public int StartPoint { get; set; }
	public IEnumerable<int> Connections { get; set; }

	public Path(int start, IEnumerable<int> conns)
	{
		StartPoint = start;
		Connections = conns;
	}
}

void Main()
{
	var input =
		File.ReadAllLines( @"C:\Users\pezzinog\Documents\LINQPad Queries\AdventOfCode2017\Day 12\Input.txt").ToList();
//		new List<string> {
//			"0 <-> 2",
//			"1 <-> 1",
//			"2 <-> 0, 3, 4",
//			"3 <-> 2, 4",
//			"4 <-> 2,3,6",
//			"5 <-> 6",
//			"6 <-> 4, 5"
//		}; // Expected result -> 6

	var connected = new bool[input.Count];
	var starting_point = 0;

	var network = input.Select(c =>
	{
		var x = c.Split(new string[] { "<->" }, StringSplitOptions.RemoveEmptyEntries);
		return new Path(int.Parse(x[0]),
			x[1].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)));
	}).ToArray();

	var nodesQueue = new Queue<int>();
	nodesQueue.Enqueue(network[starting_point].StartPoint);

	FollowConnections(nodesQueue, network, connected);

	connected.Count(c => c ).Dump();
}

void FollowConnections(Queue<int> expand, Path[] network, bool[] connected)
{
	var step = expand.Dequeue();

	connected[step] = true;
	network[step].Connections
		.Where(c => !connected[c]).ToList()
		.ForEach(conn => expand.Enqueue(conn));

	if (expand.Any())
		FollowConnections(expand, network, connected);
}