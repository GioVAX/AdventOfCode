<Query Kind="Statements">
  <Output>DataGrids</Output>
  <NuGetReference>LinqToExcel</NuGetReference>
  <Namespace>LinqToExcel</Namespace>
</Query>

var input = 347991;
var max = (int)(Math.Ceiling( Math.Sqrt( input )));

var circle = Enumerable.Range( 0, max ).First(e => Math.Pow( e*2+1, 2) >= input );

var innerArea = Math.Pow((circle -1)*2+1, 2 );

var axis = Enumerable.Range( 0, 4 ).Select( n => innerArea + circle + (circle*2)*n );

//axis.Min(a => Math.Abs(input - a )).Dump();

var distance = circle + axis.Min(a => Math.Abs(input - a ) );
distance.Dump();