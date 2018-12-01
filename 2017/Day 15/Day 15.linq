<Query Kind="Program">
  <Output>DataGrids</Output>
  <NuGetReference>LinqToExcel</NuGetReference>
  <Namespace>LinqToExcel</Namespace>
</Query>

class Generator {
	private long _start;
	private long _factor;
	private long _multipleOf;

	public Generator( long start, long factor, long multipleOf ) {
		_start = start;
		_factor = factor;
		_multipleOf = multipleOf;
	}
	
	public long Next() {
		do
			_start = (_start * _factor) % 2147483647;
		while( _start % _multipleOf != 0 );
		return _start;
	}
}

void Main()
{
	var genA = new Generator(618, 16807, 1);
	var genB = new Generator(814, 48271, 1);

	Enumerable.Range(1, 40000000)
		.Count( _ => (genA.Next() & 0xFFFF) == (genB.Next() & 0xFFFF) )
	.Dump();    // Step 1

	genA = new Generator(618, 16807, 4);
	genB = new Generator(814, 48271, 8);

	Enumerable.Range(1, 5000000)
		.Count(_ => (genA.Next() & 0xFFFF) == (genB.Next() & 0xFFFF))
	.Dump();
}
