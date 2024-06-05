using ChallengeImplementation.Model;

namespace ChallengeImplementation.Cases
{
		public class LongestSubstring(IReader reader):IOption
		{
				readonly string? input = reader.ReadInput("Write the input:");
				readonly IReader reader = reader;

				/// <summary>
				/// Given a string s, find the length of the longest substring without repeating characters.
				/// </summary>
				/// <param name="s">input</param>
				/// <returns>longest substring</returns>
				/// <example>
				/// Example 1:
				/// Input: s = "abcabcbb"
				/// Output: 3
				/// Explanation: The answer is "abc", with the length of 3.
				/// Example 2:
				/// Input: s = "bbbbb"
				/// Output: 1
				/// Explanation: The answer is "b", with the length of 1.
				/// Example 3:
				/// Input: s = "pwwkew"
				/// Output: 3
				/// Explanation: The answer is "wke", with the length of 3.
				/// Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
				/// </example>
				static int Solution(string s)
				{
						if (string.IsNullOrEmpty(s))
								return 0;
						int longestTotal = 0;
						var indexes = GetRepeatedIndexes(s);

						foreach (var item in indexes)
						{
								if (item.Length > longestTotal)
										longestTotal = item.Length;
						}
						return longestTotal;
				}
				static List<string> GetRepeatedIndexes(string data)
				{
						var result = new List<string>();
						string search = string.Empty;
						int index;
						char[] charArray;
						string subStringData;
						for (int j = 0;j < data.Length;j++)
						{
								subStringData = data[j..];
								charArray = [.. subStringData];
								for (int i = 0;i < charArray.Length;i++)
								{
										search = !search.Contains(charArray[i]) ? $"{search}{charArray[i]}" : search;
										index = CountStrings(data,search);
										if (index > 0)
										{
												result.Add(search);
										}
								}
								search = string.Empty;
						}
						return result;
				}
				/// <summary>
				/// Counts the lenght and returns the total
				/// </summary>
				/// <param name="data"></param>
				/// <param name="search"></param>
				/// <returns></returns>
				static int CountStrings(string data,string search)
				{
						int count = 0;
						int lenght;
						for (int i = 0;i < data.Length;i++)
						{
								lenght = data.IndexOf(search,i);
								if (lenght > 1)
										count++;
						}

						return count;
				}

				public void Execute()
				{
						if (!string.IsNullOrWhiteSpace(input))
						{
								reader.WriteOutput($"Result [{Solution(input)}]");
						}
						else
						{
								reader.WriteOutput("There's no input");
						}

				}
		}
}
