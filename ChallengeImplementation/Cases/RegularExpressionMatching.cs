using ChallengeImplementation.Model;

namespace ChallengeImplementation.Cases
{
		/// <summary>
		/// Given an input string s and a pattern p, implement regular expression matching with support for '.' and '*' where:
		/// '.' Matches any single character.
		/// '*' Matches zero or more of the preceding element.
		/// The matching should cover the entire input string (not partial).
		/// </summary>
		/// <example>
		/// Example 1:
		/// Input: s = "aa", p = "a"
		/// Output: false
		/// Explanation: "a" does not match the entire string "aa".
		/// Example 2:
		/// Input: s = "aa", p = "a*"
		/// Output: true
		/// Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".
		/// Example 3:
		/// Input: s = "ab", p = ".*"
		/// Output: true
		/// Explanation: ".*" means "zero or more (*) of any character (.)".
		/// Constraints:
		/// 
		/// 1 <= s.length <= 20
		/// 1 <= p.length <= 20
		/// </example>
		public class RegularExpressionMatching:IOption
		{
				readonly IReader reader;
				readonly string pattern;
				readonly string expression;
				public RegularExpressionMatching(IReader reader)
				{
						this.reader = reader;
						expression= reader.ReadInput("Input to evaluate:");
						pattern = reader.ReadInput("Write the pattern:");
				}
				public void Execute()
				{
						reader.WriteOutput($"Result:[{IsMatch(expression,pattern)}]");
				}
				public bool IsMatch(string s,string p)
				{
						if(string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(p)) 
								return false;
						if(s==p)
								return true;
						if (s.Length != p.Length)
								return false;
						const char single = '.';
						const char all = '*';
						
						
						var expressionArray = s.ToCharArray();
						var patternArray = p.ToCharArray();

            for (int i = 0; i < expressionArray.Length; i++)
            {
								if (expressionArray[i] != patternArray[i] && (patternArray[i] != single
										&& patternArray[i] != all))
								{
										return false;
								}
								else
								{
										if (patternArray[i] == single)
										{
												if (i - 1 < 0)
												{
														return false;
												}
												else if (expressionArray[i-1]!= expressionArray[i])
												{
														return false;
												}
										}
										else if (patternArray[i] == all)
										{
												var subString = s.Substring(0,i);
												if (!subString.Contains(expressionArray[i]))
												{
														return false;
												}
										}
								}
            }
            return true;
				}
		}
}
