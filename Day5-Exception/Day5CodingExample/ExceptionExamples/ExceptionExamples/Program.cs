

#region Try Catch Example
try
{
    Console.WriteLine("Please enter a number to divide 100: ");
    int userInput = int.Parse(Console.ReadLine());

    int result = 100 / userInput;

    Console.WriteLine("100 / {0} = {1}", userInput, result);

}
catch (DivideByZeroException ex)
{
	Console.WriteLine("Cannot divide by zero. Try again:");
}
catch(OverflowException ex) 
{
    Console.WriteLine("Over flow");
}
catch(FormatException ex)
{
	Console.WriteLine("Invalid format");
}
catch (Exception ex)
{
	Console.WriteLine("Something went wrong");
}
#endregion




