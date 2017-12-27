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
	var input = "{{<a!>},{<a!>},{<ab>}}";
	int level = 0;
	int total = 0;
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
					break;
			}
		}
	}
	
	total.Dump();
}

// Define other methods and classes here
