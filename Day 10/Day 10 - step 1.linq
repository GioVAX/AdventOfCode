<Query Kind="Program">
  <Output>DataGrids</Output>
  <NuGetReference>LinqToExcel</NuGetReference>
  <Namespace>LinqToExcel</Namespace>
</Query>

void Main()
{
	var current_pos = 0;
	var skip_size = 0;
	var nodes = Enumerable.Range(0, 256).ToArray();

	var lengths =
		//		new int[] { 3, 4, 1, 5 }; // Test TO BE DONE ON 5 ELEMENTS-- Expected answer -> 12
		File.ReadAllText(@"C:\Users\pezzinog\Documents\LINQPad Queries\AdventOfCode2017\Day 10\input.txt")
			.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
			.Select(f => int.Parse(f))
			.ToArray();

	var nodesLen = nodes.Count();
	foreach (var len in lengths)
	{
		nodes = reverseNodes(nodes, current_pos, len);

		current_pos = (current_pos + len + skip_size) % nodesLen;
		++skip_size;
	}

	(nodes[0] * nodes[1]).Dump();
}

int[] reverseNodes(int[] nodes, int offset, int length)
{
	var rotate = nodes.Skip(offset).Concat(nodes.Take(offset));
	var reverse = rotate.Take(length).Reverse().Concat(rotate.Skip(length));

	var rotateBack = nodes.Count() - offset;
	return reverse.Skip(rotateBack).Concat(reverse.Take(rotateBack)).ToArray();
}