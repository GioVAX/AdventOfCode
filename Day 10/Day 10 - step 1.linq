<Query Kind="Program">
  <Output>DataGrids</Output>
  <NuGetReference>LinqToExcel</NuGetReference>
  <Namespace>LinqToExcel</Namespace>
</Query>

void Main()
{
	var current_pos = 0;
	var skip_size = 0;
	var nodes = Enumerable.Range(0, 255).ToArray();
	
	var lengths = new List<int>( new int [] { 3,4,1,5 });
	
	foreach( var len in lengths ) {
	
		reverseNodes( nodes, current_pos, len );
		
		current_pos = (current_pos + len + skip_size) % nodes.Length;
		++skip_size;
	}
	
	(nodes[0] * nodes[1]).Dump();
}

void reverseNodes(int[] nodes, int begin, int len)
{
	for( var i = 0; i < (len +1)/ 2; ++i )
	{
		begin = (begin + i) % nodes.Length;
		var end = (begin + len - i) %nodes.Length;
		
		nodes[begin] ^= nodes[end];
		nodes[end] ^= nodes[begin];
		nodes[begin] ^= nodes[end];

		++begin;
	}
}
