<Query Kind="Program">
  <Output>DataGrids</Output>
  <NuGetReference>LinqToExcel</NuGetReference>
  <Namespace>LinqToExcel</Namespace>
</Query>

enum Mode {
	Normal,
	Garbage
}

void Main()
{
	var input = 
		File.ReadAllLines( @"C:\Users\pezzinog\Documents\LINQPad Queries\AdventOfCode2017\Day 09\Input.txt")[0];
//		"{{<a!>},{<a!>},{<ab>}}"; // Test -- Expected result --> 3
	
	int level = 0;
	int total = 0;
	int nonCancelled = 0;
	Mode mode = Mode.Normal;
	int chr = 0;

	var rdr = new StringReader(input);
	while ((chr = rdr.Read()) != -1)
	{

		if (mode == Mode.Normal)
		{
			switch (chr)
			{
				case 123:
					total += ++level;
					break;
				case 125:
					--level;
					break;
				case 60:
					mode = Mode.Garbage;
					break;
				default:
					break;
			}
		}
		else
		{
			switch (chr)
			{
				case 62:
					mode = Mode.Normal;
					break;
				case 33:
					rdr.Read();
					break;
				default:
					++nonCancelled;
					break;
			}
		}
	}
	
	total.Dump(); // Step 1
	nonCancelled.Dump(); // Step 2
}