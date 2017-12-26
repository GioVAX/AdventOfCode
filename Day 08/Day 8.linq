<Query Kind="Program">
  <Output>DataGrids</Output>
  <NuGetReference>LinqToExcel</NuGetReference>
  <Namespace>LinqToExcel</Namespace>
</Query>

void Main()
{
	var input = File.ReadAllLines( @"C:\Users\pezzinog\Documents\LINQPad Queries\AdventOfCode2017\Day 08\Day 8 Input.txt").ToList();
//		new List<string> {
//			"b inc 5 if a > 1",
//			"a inc 1 if b < 5",
//			"c dec -10 if c == 10",
//			"c inc -20 if c == 10"
//		};

	var registers = new Dictionary<string, int>();
	
	foreach (var instr in input)
	{
		var parts = instr.Split(new string[] { "if"}, StringSplitOptions.RemoveEmptyEntries );

		if( CheckCondition( parts[1], registers ))
			ExecuteCmd(parts[0], registers);
	}

	registers.Max(r => r.Value ).Dump();
}

bool CheckCondition(string expr, Dictionary<string, int> registers)
{
	var check = expr.Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries );
	
	var regValue = GetRegValue( check[0], registers );
	var value = int.Parse( check[2] );
	
	switch (check[1])
	{
		case "<":
			return regValue < value;
		case "==":
			return regValue == value;
		case ">":
			return regValue > value;
		case "<=":
			return regValue <= value;
		case ">=":
			return regValue >= value;
		case "!=":
			return regValue != value;
		default:
			throw new Exception( $"Invalid check: {check[1]}" );
	}
}

void ExecuteCmd(string expr, Dictionary<string, int> registers)
{
	var cmd = expr.Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries );

	var regValue = GetRegValue(cmd[0], registers);
	var value = int.Parse(cmd[2]);
	
	if( cmd[1] == "inc" )
		registers[cmd[0]] = regValue + value;
	else
		registers[cmd[0]] = regValue - value;
}

int GetRegValue( string reg, Dictionary<string, int> registers ) {

	if (!registers.Keys.Contains(reg))
		return registers[reg] = 0;
	
	return registers[reg];
}