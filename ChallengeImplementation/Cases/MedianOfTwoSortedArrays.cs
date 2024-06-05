using ChallengeImplementation.Model;
using ExtensionUtils.Utils;

namespace ChallengeImplementation.Cases
{

		public class MedianOfTwoSortedArrays:IOption
		{
				readonly string? input;
				readonly int[] firstInputArray;
				readonly int[] secondInputArray;
				readonly IReader reader;
				public MedianOfTwoSortedArrays(IReader reader)
				{
						this.reader = reader;
						input = reader.ReadInput("Write the first array separated by comma");
						firstInputArray = input.ToIntArray();
						input = reader.ReadInput("Write the second list separated by comma:");
						secondInputArray = input.ToIntArray();
				}
				public void Execute()
				{
						reader.WriteOutput($"Result [{Solution(firstInputArray,secondInputArray)}]");
				}

				/// <summary>
				/// Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
				/// The overall run time complexity should be O(log (m+n)).
				/// </summary>
				/// <example>
				/// Example 1:
				/// Input: nums1 = [1,3], nums2 = [2]
				/// Output: 2.00000
				/// Explanation: merged array = [1,2,3] and median is 2.
				/// Example 2:
				/// Input: nums1 = [1,2], nums2 = [3,4]
				/// Output: 2.50000
				/// Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
				/// </example>
				static double Solution(int[] nums1,int[] nums2)
				{
						var merged = nums1.ToList();
						foreach (var item in nums2)
						{
								if (!merged.Contains(item))
										merged.Add(item);
						}
						return merged.Sum() / (double)merged.Count;
				}
		}
}
