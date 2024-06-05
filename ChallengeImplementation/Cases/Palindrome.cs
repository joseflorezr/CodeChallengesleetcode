using ChallengeImplementation.Model;
namespace ChallengeImplementation.Cases
{
		/// <summary>
		/// Palindrome challenge
		/// </summary>
		public class Palindrome(IReader reader):IOption
		{
				readonly string? input = reader.ReadInput("Write the string:");
				readonly IReader reader = reader;

				/// <summary>
				/// Given a string s, return the longest 	palindromic substring in s.
				/// </summary>
				/// <example>
				/// Example 1:
				/// Input: s = "babad"
				/// Output: "bab"
				/// Explanation: "aba" is also a valid answer.
				/// Example 2:
				/// Input: s = "cbbd"
				/// Output: "bb"
				/// Constraints:
				/// 1 <= s.length <= 1000
				/// s consist of only digits and English letters.
				/// </example>
				public static string LongestPalindrome(string s)
				{
						if (string.IsNullOrWhiteSpace(s) || s.Length < 0 ||
						s.Length > 1000)
						{
								return string.Empty;
						}

						//Convert into a char array

						var leftToRightArray = s.ToCharArray();
						//get the opposite

						string rightSide = string.Empty;
						for (int j = leftToRightArray.Length - 1;j >= 0;j--)
						{
								rightSide = string.Concat(rightSide,leftToRightArray[j]);
						}


						string result = string.Empty;
						string palindrome;

						for (int j = 0;j < leftToRightArray.Length;j++)
						{

								palindrome = GetPalindrome(leftToRightArray,rightSide);
								leftToRightArray[j] = '\0';
								if (!string.IsNullOrWhiteSpace(palindrome))
								{
										result = palindrome.Length == result.Length && result != palindrome ?
												$"{result}, {palindrome}" : palindrome;
								}
						}


						return result;
				}
				/// <summary>
				/// Gets the palindrome
				/// </summary>
				/// <param name="leftToRightArray">Array to compare</param>
				/// <param name="rightSide">string to search</param>
				/// <returns>palindrome</returns>
				static string GetPalindrome(char[] leftToRightArray,string rightSide)
				{
						string result = string.Empty;
						int index;
						int counter = 0;
						string leftSide = string.Empty;
						int lenght;
						int leftSideLenght;
						for (var i = 0;i < leftToRightArray.Length;i++)
						{
								leftSide = string.Concat(leftSide,leftToRightArray[i]);
								index = rightSide.IndexOf(leftSide);
								leftSideLenght = leftSide.Length;
								if (index > 0 && counter < leftSideLenght)
								{
										lenght = leftSideLenght - index;
										result = rightSide.Substring(index,lenght < 0 ? leftSideLenght : lenght);
										counter = leftSide.Length;
								}
						}
						return result;
				}

				public void Execute()
				{
						if (!string.IsNullOrWhiteSpace(input))
								reader.WriteOutput($"Result {LongestPalindrome(input)}");
						else
								reader.WriteOutput("There's no input");
				}

		}
}
