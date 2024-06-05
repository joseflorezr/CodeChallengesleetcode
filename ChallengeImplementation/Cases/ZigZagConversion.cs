using ChallengeImplementation.Model;
using ExtensionUtils.Utils;

namespace ChallengeImplementation.Cases
{
		public class ZigZagConversion(IReader reader):IOption
		{
				readonly string? input = reader.ReadInput("Write the input:");
				readonly int rows = reader.ReadInput("Write the rows:").ToInt();

				public void Execute()
				{
						Console.WriteLine($"Result [{Convert(input.NullStringToEmpty(),rows)}]");
				}

				/// <summary>
				/// The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)
				/// P   A   H   N
				/// A P L S I I G
				/// Y   I R
				/// And then read line by line: "PAHNAPLSIIGYIR"
				/// Write the code that will take a string and make this conversion given a number of rows:
				/// </summary>
				/// <param name="s"></param>
				/// <param name="numRows"></param>
				/// <returns></returns>
				static string Convert(string s,int numRows)
				{
						if(string.IsNullOrWhiteSpace(s))
								return string.Empty;

						var splittedInput = s.ToCharArray();
						var conversionArray = LocateData(splittedInput,numRows);
						var result=string.Empty;
            for (int i = 0; i < conversionArray.Length; i++)
            {
								result = $"{result}{conversionArray[i]}";
            }
            return result;
				}
				/// <summary>
				/// Locates the data into an array with the specified rows
				/// </summary>
				/// <param name="splittedInput">splitted input</param>
				/// <param name="numRows">Rows of the array</param>
				/// <returns>Array with the conversion</returns>
				private static string[] LocateData(char[] splittedInput,int numRows)
				{
						var result=new string[numRows];
						int charcounter = 0;
						int index = 0;
						while (charcounter < splittedInput.Length)
						{
								for (int i = index;i < result.Length;i++)
								{
										if (charcounter >= splittedInput.Length)
												break;
										result[i] = $"{result[i]}{splittedInput[charcounter]}";
										charcounter++;
								}

								for (int j = result.Length - 2;j >= 0;j--)
								{
										if (charcounter >= splittedInput.Length)
												break;
										result[j] = $"{result[j]}{splittedInput[charcounter]}";
										charcounter++;
								}
								index=1;
						}
						return result;
				}
		}
}
