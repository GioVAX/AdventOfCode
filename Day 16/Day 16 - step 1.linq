<Query Kind="Program">
  <Output>DataGrids</Output>
  <NuGetReference>LinqToExcel</NuGetReference>
  <Namespace>LinqToExcel</Namespace>
</Query>

void Main()
{
	//	var dancers = "abcde".ToCharArray();
	//	var input = "s1,x3/4,pe/b"; // Expected result -> "baedc"

	var dancers = "abcdefghijklmnop".ToCharArray();
	var input = File.ReadAllText(@"C:\Users\pezzinog\Documents\LINQPad Queries\AdventOfCode2017\Day 16\input.txt");

	new String(
	input.Split(',')
		.Aggregate(dancers, (dncrs, cmd) =>
		{
			switch (cmd[0])
			{
				case 's':
					return rotate(dncrs, int.Parse(cmd.Substring(1)));
				case 'x':
					return swapPositions(dncrs, cmd.Substring(1));
				case 'p':
					return swapDancers(dncrs, cmd.Substring(1));
			}
			throw new Exception( $"Invalid command <{cmd}>" );
		})
	).Dump();
}

public char[] rotate(char[] dancers, int places)
{
	var n = dancers.Count() - places;
	return dancers.Skip(n).Concat(dancers.Take(n)).ToArray();
}

public char[] swapPositions(char[] dancers, string positions)
{
	var pos = positions.Split('/').Select(p => int.Parse(p)).ToArray();
	return swap(dancers, pos[0], pos[1]);
}

public char[] swapDancers(char[] dancers, string dancerNames)
{
	var pos = dancerNames.Split('/').Select(p => Array.IndexOf(dancers, p[0])).ToArray();
	return swap(dancers, pos[0], pos[1]);
}

public char[] swap(char[] dancers, int pos1, int pos2)
{

	char c = dancers[pos1];
	dancers[pos1] = dancers[pos2];
	dancers[pos2] = c;

	return dancers;
}