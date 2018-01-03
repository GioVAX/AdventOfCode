<Query Kind="Statements">
  <Output>DataGrids</Output>
  <NuGetReference>LinqToExcel</NuGetReference>
  <Namespace>LinqToExcel</Namespace>
</Query>

var input =
new string[] {
	"0: 3",
	"1: 2",
	"4: 4",
	"6: 4"
};

input
	.Select(i => i.Split(new char[] { ':', ' '}, StringSplitOptions.RemoveEmptyEntries ))
	.Select( p => new { layer = int.Parse(p[0]), depth = int.Parse( p[1]) } )
	.Where( s => (s.layer / (s.depth - 1)) % 2 == 0)
	.Sum( h => h.layer * h.depth )
.Dump();

//top = (depth - 1) * 2 * x
//top / (depth -1) / 2 = x