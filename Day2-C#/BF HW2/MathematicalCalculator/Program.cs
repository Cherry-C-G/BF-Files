using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MathematicalCalculator
{
    public class Program
    {
   

			//        1.	Develop a mathematical Calculator

			//a.  (2 Variables -- X=5,Y=7) -->> Add, Sub, Mul, Div

			//b.  (3 Variables -- X= 5, Y= 6, Z= 7) -->> Add, Sub, Mul, Div

			//The input contains two arrays, an array of variables and an array of operators: input1 = [5,6,14,7], input2 = [“Add”, “Sub”, “Div”]
			//        The precedence of operator needs to be taken care of, for example, the above example should be 5 + 6 - (14 / 7) = 9 instead of(5 + 6 - 14) / 7 = 0 (if the end result is not an integer, output the floor of the decimal result)





			

			public static void Main()
			{
				int[] values = { 5, 6, 14, 7 };
				string[] operators = { "Add", "Sub", "Div" };
				Console.WriteLine(Calculate(values, operators));
			}

			public static int Calculate(int[] values, string[] operators)
			{
				if (((values.Length - 1) == operators.Length) && values != null && operators != null)
				{
					List<object> final = new List<object>();
					//Add int values to object type list so that it can take both integer and string.
					foreach (int val in values)
					{
						final.Add(val);
					}

					//Insert operators string to the list between integers.
					int j = 1;
					foreach (string op in operators)
					{
						final.Insert(j, op);
						j += 2;
					}

					/*foreach(var f in final)
						Console.WriteLine(f); */

					//Go through the list for "mul" and "div", calculate according to the indexs, values and operator
					//then take out 3 items including operator.
					//insert back the calculated value.
					for (int i = 0; i < final.Count; i++)
					{
						if (final[i].GetType() == typeof(string) && final[i] == "Mul")
						{
							int result = (int)final[i - 1] * (int)final[i + 1];
							final.RemoveRange(i - 1, 3);
							final.Insert(i - 1, result);
							i = 0;
						}
						else if (final[i].GetType() == typeof(string) && final[i] == "Div")
						{
							int result = (int)final[i - 1] / (int)final[i + 1];
							final.RemoveRange(i - 1, 3);
							final.Insert(i - 1, result);
							i = 0;
						}
					}

					//Go through the list again for "add" and "sub", calculate according to the indexs, values and operator
					//then take out 3 items including operator.
					//insert back the calculated value.
					for (int i = 0; i < final.Count; i++)
					{
						if (final[i].GetType() == typeof(string) && final[i] == "Add")
						{
							int result = (int)final[i - 1] + (int)final[i + 1];
							final.RemoveRange(i - 1, 3);
							final.Insert(i - 1, result);
							i = 0;
						}
						else if (final[i].GetType() == typeof(string) && final[i] == "Sub")
						{
							int result = (int)final[i - 1] - (int)final[i + 1];
							final.RemoveRange(i - 1, 3);
							final.Insert(i - 1, result);
							i = 0;
						}
					}

					//Since the last one will be the value of the equation.
					return (int)final[0];
				}
				else
					return 0;
			}
		}
	}
