<Query Kind="Program">
  <Output>DataGrids</Output>
  <NuGetReference>LinqToExcel</NuGetReference>
  <Namespace>LinqToExcel</Namespace>
</Query>

class KnotHash
{
	private IEnumerable<int> _nodes;
	private int _currentPos;
	private int _skipSize;
	private int _nodesLength;

	public KnotHash(IEnumerable<int> nodes, int initialPos, int initialSkipSize)
	{
		_nodes = nodes;
		_nodesLength = _nodes.Count();
		_currentPos = initialPos;
		_skipSize = initialSkipSize;
	}

	public IEnumerable<int> Nodes { get { return _nodes; } }
	public int CurrentPos { get { return _currentPos; } }
	public int SkipSize { get { return _skipSize; } }

	public void TwistNodes(int length)
	{
		_nodes = reverseNodes(_nodes, _currentPos, length);

		_currentPos = (_currentPos + length + _skipSize) % _nodesLength;
		++_skipSize;
	}

	private IEnumerable<int> reverseNodes(IEnumerable<int> nodes, int offset, int length)
	{
		var nds = nodes.ToArray();
		var rotate = nds.Skip(offset).Concat(nds.Take(offset));
		var reverse = rotate.Take(length).Reverse().Concat(rotate.Skip(length));

		var rotateBack = nds.Length - offset;
		return reverse.Skip(rotateBack).Concat(reverse.Take(rotateBack));
	}
}

void Main()
{
	//	var nodes = Enumerable.Range(0, 5);
	//	var input = "3, 4, 1, 5"; // Expected answer -> 12

	var nodes = Enumerable.Range(0, 256);
	var input = File.ReadAllText(@"C:\Users\pezzinog\Documents\LINQPad Queries\AdventOfCode2017\Day 10\input.txt").Trim();

	ComputeHash1(nodes, input).Dump();

	ComputeHash2(nodes, input).Dump();
}

int ComputeHash1(IEnumerable<int> nodes, string input)
{
	var lengthsStep1 = input
		.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
		.Select(f => int.Parse(f));
	var hash1 = new KnotHash(nodes, 0, 0);

	foreach (var len in lengthsStep1)
		hash1.TwistNodes(len);

	return hash1.Nodes.Take(2).Aggregate(1, (mult, n) => mult *= n);
}

string ComputeHash2(IEnumerable<int> nodes, string input)
{
	var lengthsStep2 = input.ToCharArray()
		.Select(c => (int)c)
		.Concat(new int[] { 17, 31, 73, 47, 23 });
	
	var hash2 = new KnotHash(nodes, 0, 0);

	for (var i = 0; i < 64; ++i)
		foreach (var len in lengthsStep2)
			hash2.TwistNodes(len);

	return String.Join("", Enumerable.Range(0, 16)
		.Select(i => hash2.Nodes.Skip(i * 16).Take(16)
			   				.Aggregate(0, (accum, n) => accum ^= n))
		.Select(b => $"{b:x2}"));
}

