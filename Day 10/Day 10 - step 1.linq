<Query Kind="Program">
  <Output>DataGrids</Output>
  <NuGetReference>LinqToExcel</NuGetReference>
  <Namespace>LinqToExcel</Namespace>
</Query>

void Main()
{
	var nodes = Enumerable.Range(0, 256).ToArray();

	var input = //		new int[] { 3, 4, 1, 5 }; // Test TO BE DONE ON 5 ELEMENTS-- Expected answer -> 12
		File.ReadAllText(@"C:\Users\pezzinog\Documents\LINQPad Queries\AdventOfCode2017\Day 10\input.txt");

	var lengthsStep1 = input
			.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
			.Select(f => int.Parse(f))
			.ToArray();

	ComputeStep1(nodes.Select(n => n).ToArray(), lengthsStep1, 0, 0).Dump();
}

int ComputeStep1(int[] nodes, int[] lengths, int initialPos, int initialSkipSize)
{
	var nodesLen = nodes.Count();
	foreach (var len in lengths)
	{
		nodes = reverseNodes(nodes, initialPos, len);

		initialPos = (initialPos + len + initialSkipSize) % nodesLen;
		++initialSkipSize;
	}

	return nodes[0] * nodes[1];
}

int[] reverseNodes(int[] nodes, int offset, int length)
{
	var rotate = nodes.Skip(offset).Concat(nodes.Take(offset));
	var reverse = rotate.Take(length).Reverse().Concat(rotate.Skip(length));

	var rotateBack = nodes.Count() - offset;
	return reverse.Skip(rotateBack).Concat(reverse.Take(rotateBack)).ToArray();
}