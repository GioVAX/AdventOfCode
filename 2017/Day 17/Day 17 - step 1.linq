<Query Kind="Statements">
  <Output>DataGrids</Output>
  <NuGetReference>LinqToExcel</NuGetReference>
  <Namespace>LinqToExcel</Namespace>
</Query>

var input = 348;
var buffer = new List<int>();
buffer.Add( 0 );
var position = 0;

for( var i = 1; i <= 2017; ++i ) {
	var insertAt = ((position + input) % buffer.Count)+1;
	buffer.Insert(insertAt, i);
	position = insertAt;
}

buffer.SkipWhile(b => b != 2017).Skip(1).First().Dump();
