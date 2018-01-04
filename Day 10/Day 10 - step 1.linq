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
	
	var lengths = 
//		new int[] { 3, 4, 1, 5 }; // Test TO BE DONE ON 5 ELEMENTS-- Expected answer -> 12
		new int[] { 18, 1, 0, 161, 255, 137, 254, 252, 14, 95, 165, 33, 181, 168, 2, 188 };
	
	foreach( var len in lengths ) {
		reverseNodes( nodes, current_pos, len );
		
		current_pos = (current_pos + len + skip_size) % nodes.Length;
		++skip_size;
		
//		nodes.ToList().Dump();
//		current_pos.Dump();
//		skip_size.Dump();
//		"".Dump();
	}
	
	(nodes[0] * nodes[1]).Dump();
}

void reverseNodes(int[] nodes, int begin, int len)
{
	var endBase = begin + len - 1;
	for( var i = 0; i < len/ 2; ++i )
	{
		begin = (begin + i) % nodes.Length;
		var end = (endBase - i) % nodes.Length;
		
		var tmp = nodes[begin];
		nodes[begin] = nodes[end];
		nodes[end] = tmp;
		
//		nodes[begin] ^= nodes[end];
//		nodes[end] ^= nodes[begin];
//		nodes[begin] ^= nodes[end];

//		++begin;
	}
}