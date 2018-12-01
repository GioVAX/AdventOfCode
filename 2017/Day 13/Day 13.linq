<Query Kind="Program">
  <Output>DataGrids</Output>
  <NuGetReference>LinqToExcel</NuGetReference>
  <Namespace>LinqToExcel</Namespace>
</Query>

void Main()
{
	var input =
		File.ReadAllLines(@"C:\Users\pezzinog\Documents\LINQPad Queries\AdventOfCode2017\Day 13\input.txt");
//		new string[] {
//			"0: 3",
//			"1: 2",
//			"4: 4",
//			"6: 4"
//		}; // Expected results --> Step 1: 24 / Step 2: 10

	var firewall = input
		.Select(i => i.Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries))
		.ToDictionary(k => int.Parse(k[0]), v=> int.Parse( v[1]) );

	computeHits(firewall, 0)
		.Sum(h => h.Key * h.Value)
		.Dump(); // Step 1

	var delay = 1;
	while( true ) {
		if( !computeHits( firewall, delay ).Any())
			break;
		++delay;
	}
	delay.Dump();	// Step 2
}

IEnumerable<KeyValuePair<int,int>> computeHits(Dictionary<int, int> firewall, int delay)
{
	return firewall
		.Where(s => ((s.Key + delay) % (s.Value * 2 - 2)) == 0 );
}