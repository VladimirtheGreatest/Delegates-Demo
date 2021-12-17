//another beautiful example					

public class BeautifulExample
{
	public delegate double Rounder(double value);
	public static Rounder[] delegateArray = new Rounder[]{
		new Rounder(RounderAwayFromZero),
		new Rounder(RoundToEven)
	};
	public static void Main()
	{		
		foreach(var del in delegateArray){
			var result = DoTheCalculation(44.20, 32.46, del);
			Console.WriteLine(result);
		};
		//I can also call them directly by index if neccessary
			var roundedAwayFromZero =  delegateArray[0](44.44);
			Console.WriteLine(roundedAwayFromZero);
			
			var roundedToEven =  delegateArray[1](44.44);
			Console.WriteLine(roundedToEven);
	}
	public static double DoTheCalculation(double input1, double input2, Rounder rounder)
	{
    var intermediate1 = Math.Pow(input1, input2);
    // more calculations...
    var intermediate5 = rounder(intermediate1);
    // more calculations...
    var intermediate10 = Math.Abs(intermediate5);

    return intermediate10;
	}
	private static double RounderAwayFromZero(double value)
	{
    return Math.Round(value, MidpointRounding.AwayFromZero);
	}
	private static double RoundToEven(double value)
	{
    return Math.Round(value,  MidpointRounding.ToEven);
	}
}
