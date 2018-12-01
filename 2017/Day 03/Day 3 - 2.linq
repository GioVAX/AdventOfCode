<Query Kind="Statements">
  <Output>DataGrids</Output>
  <NuGetReference>LinqToExcel</NuGetReference>
  <Namespace>LinqToExcel</Namespace>
</Query>

var input = 347991;

var offsets = new int[,] {
	{-1, 0},
	{0, -1},
	{1, 0},
	{0,1},
};

var cells = new int[100][];
for (int i = 0; i < 100; ++i)
	cells[i] = new int[100];


cells[50][50]=1;
cells[50][51]=1;

var moveIdx = 0;
var checkIdx = 1;
var currRow = 50;
var currCol = 51;

do
{
	currRow += offsets[moveIdx,0];
	currCol += offsets[moveIdx,1];

	cells[currRow][currCol] =
		cells.Skip( currRow -1 ).Take( 3 ).SelectMany(row => row.Skip( currCol - 1).Take(3)).Sum();
	
	if( cells[currRow + offsets[checkIdx,0]][ currCol + offsets[checkIdx,1]] == 0 ) {
		moveIdx = (++moveIdx % 4);
		checkIdx = (++checkIdx % 4);
	}
	
} while( cells[currRow][currCol] <= input );

cells[currRow][currCol].Dump();


