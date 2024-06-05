using ChallengeImplementation.Model;
using ExtensionUtils.Utils;

namespace ChallengeImplementation.Cases
{
		/// <summary>
		/// Two sum challenge
		/// </summary>
		public class TwoSum(IReader reader):IOption
		{
				readonly string? input = reader.ReadInput("Write the array separated by comma:");
				readonly string? target = reader.ReadInput("Write the target");
				readonly IReader reader = reader;

				public void Execute()
				{
						var numbers = Solve(input.ToIntArray(),Convert.ToInt32(target));
						reader.WriteOutput($"Result [{numbers[0]},{numbers[1]}]");
				}

				/// <summary>
				/// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
				///You may assume that each input would have exactly one solution,and you may not use the same element twice.
				///You can return the answer in any order.
				/// </summary>
				/// <param name="nums">Num array</param>
				/// <param name="target">Target number</param>
				/// <returns>positions</returns>
				///<example>
				///				Example 1:
				///       Input: nums = [2,7,11,15],target = 9
				///Output: [0,1]
				///Explanation: Because nums[0] + nums[1] == 9,we return [0, 1].
				///Example 2:
				///Input: nums = [3,2,4],target = 6
				///Output: [1,2]
				///		Example 3:
				///Input: nums = [3,3],target = 6
				///Output: [0,1]
				///Constraints:
				///2 <= nums.length <= 104
				///-109 <= nums[i] <= 109
				///-109 <= target <= 109
				///Only one valid answer exists.
				/// </example>
				static int[] Solve(int[] nums,int target)
				{
						int[] result = new int[2];
						if (nums == null || nums.Length == 0)
						{
								return result;
						}

						for (int i = 0;i < nums.Length;i++)
								for (int j = 1;j < nums.Length;j++)
								{
										if (nums[i] + nums[j] == target)
										{
												result[0] = i;
												result[1] = j;
												i = j = nums.Length;
										}

								}

						return result;
				}

		}
}
