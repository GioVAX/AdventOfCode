<Query Kind="Statements">
  <Output>DataGrids</Output>
  <NuGetReference>LinqToExcel</NuGetReference>
  <Namespace>LinqToExcel</Namespace>
</Query>

var input = new List<int> {
//0,2,7,0 //--> step1 = 5, step2 = 4
	5,	1,	10,	0,	1,	7,	13,	14,	3,	12,	8,	10,	7,	12,	0,	6
};

var input_len = input.Count;
var oldStatuses = new List<string>();
string status = null;
var cycles = 0;

while( !oldStatuses.Contains( status )) {

if( status != null )
	oldStatuses.Add(status);

	var items = input.Max();
	var curr_idx = input.IndexOf(items);

	for(input[curr_idx] = 0; items > 0; items--) {
		curr_idx = ++curr_idx % input_len;
		input[curr_idx]++;
	}

	cycles++;

	status = string.Join(",", input.Select(i => i.ToString()));
};

$"iterations = {cycles}".Dump();
$"loop size = {(oldStatuses.Count - oldStatuses.IndexOf(status))}".Dump();