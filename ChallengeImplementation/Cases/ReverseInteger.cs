using ChallengeImplementation.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeImplementation.Cases
{
		/// <summary>
		/// Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.
		///Assume the environment does not allow you to store 64-bit integers(signed or unsigned).
		/// </summary>
		///<example>
		///Example 1:
		///Input: x = 123
		///Output: 321
		///Example 2:
		///
    ///Input: x = -123
    ///Output: -321
    ///Example 3:
		///
    ///Input: x = 120
    ///Output: 21
    ///Constraints:
    ///-231 <= x <= 231 - 1
		/// </example>
		public class ReverseInteger(IReader reader):IOption
		{
				readonly IReader reader = reader;
				readonly string input = reader.ReadInput("Write the number:");

				public void Execute()
				{

						int data = Reverse(Convert.ToInt32(input));
						reader.WriteOutput(data.ToString());
				}

				static int Reverse(int x)
				{
						var data = x.ToString().ToCharArray();
						string reverse = string.Empty;
						if (data[0]=='-')
						{
								reverse = "-";
								data[0] = ' ';
						}
						for (int i = data.Length - 1;i >= 0;i--)
						{
								reverse = $"{reverse}{data[i]}";
						}
						_ = int.TryParse(reverse,out int result);
						return result;
				}
		}
}
