using ChallengeImplementation.Model;

namespace ChallengeImplementation.Cases
{
		/// <summary>
		/// Given an integer x, return true if x is a 
		/// palindrome, and false otherwise.
		/// </summary>
		/// <example>
		/// Example 1:
		/// Input: x = 121
		/// Output: true
		/// Explanation: 121 reads as 121 from left to right and from right to left.
		/// Example 2:
		/// Input: x = -121
		/// Output: false
		/// Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
		/// Example 3:
		/// Input: x = 10
		/// Output: false
		/// Explanation: Reads 01 from right to left.Therefore it is not a palindrome.
		/// Constraints:
		/// -231 <= x <= 231 - 1
		/// </example>
		public class PalindromeNumber:IOption
		{
				readonly IReader reader;
				readonly string input;
        public PalindromeNumber(IReader reader)
        {
            this.reader = reader;
						input=reader.ReadInput("Write the input number");
        }
        public void Execute()
				{
						int inputNumber = 0;
						if (string.IsNullOrEmpty(input)||!int.TryParse(input,out inputNumber))
						{
								reader.WriteOutput("Choose a valid input");
						}
						else
						{
								reader.WriteOutput($"Result:{IsPalindrome(inputNumber)}");
						}
				}
				static bool IsPalindrome(int x)
				{
						var stringArray = x.ToString().ToCharArray();
						var reverse = string.Empty;
						for (int i = stringArray.Length-1;i >= 0;i--) {
								reverse = $"{reverse}{stringArray[i]}";
						}
						return x.ToString().Equals(reverse);
				}

		}
}
