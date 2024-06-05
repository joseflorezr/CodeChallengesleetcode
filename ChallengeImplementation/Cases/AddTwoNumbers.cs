using ChallengeImplementation.Model;

namespace ChallengeImplementation.Cases
{

		public class AddTwoNumbers:IOption
		{
				readonly IReader reader;
				public AddTwoNumbers(IReader reader)
				{
						this.reader = reader;
						var input = reader.ReadInput("Write the first array separated by comma");
						if (input != null)
								firstNode = ConvertToNodeList(input,",");

						input = reader.ReadInput("Write the second array separated by comma");
						if (input != null)
								secondNode = ConvertToNodeList(input,",");
						counter = string.Empty;
				}
				string counter;
				readonly ListNode? firstNode;
				readonly ListNode? secondNode;
				/// <summary>
				/// You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, 
				/// and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
				/// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
				/// </summary>
				/// <example>
				/// Input: l1 = [2,4,3], l2 = [5,6,4]
				/// Output: [7,0,8]
				/// Explanation: 342 + 465 = 807.
				/// 
				/// Input: l1 = [0], l2 = [0]
				/// Output: [0]
				/// 
				/// Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
				/// Output: [8,9,9,9,0,0,0,1]
				/// </example>
				ListNode? Solution(ListNode l1,ListNode l2)
				{
						if (l1 == null || l2 == null)
								return null;
						counter = string.Empty;
						string getNextNumber = GetNumber(l1);
						int firstListNumber = !string.IsNullOrWhiteSpace(getNextNumber) ? Convert.ToInt32(getNextNumber) : 0;
						counter = string.Empty;
						getNextNumber = GetNumber(l2);
						int secondListNumber = !string.IsNullOrWhiteSpace(getNextNumber) ? Convert.ToInt32(getNextNumber) : 0;
						int returnValue = firstListNumber + secondListNumber;
						var values = returnValue.ToString().ToCharArray();
						string valueToConvert = string.Empty;
						for (int i = values.Length - 1;i >= 0;i--)
						{
								valueToConvert = $"{valueToConvert}{values[i]},";
						}
						valueToConvert = valueToConvert.Length > 0 ? valueToConvert.Remove(valueToConvert.Length - 1) : valueToConvert;
						return ConvertToNodeList(valueToConvert,",");
				}

				string GetNumber(ListNode node)
				{
						if (node.next != null)
						{
								counter = $"{counter}{node.val}{GetNumber(node.next)}";
								return counter;
						}
						else
						{
								counter = $"{counter}{node.val}";
						}
						return counter;
				}
				static ListNode? ConvertToNodeList(string data,string? separator = null)
				{
						string[] values = data.Split(separator);
						var builNodesList = new ListNode[values.Length];
						for (int i = values.Length - 1;i >= 0;i--)
						{
								builNodesList[i] = new ListNode(Convert.ToInt32(values[i]));
						}
						int index = 1;
						foreach (var item in builNodesList)
						{
								item.next = index < builNodesList.Length ? builNodesList[index] : null;
								index++;
						}
						return builNodesList.FirstOrDefault();

				}
				public void Execute()
				{
						if (firstNode != null && secondNode != null)
						{
								reader.WriteOutput($"Result [{Solution(firstNode,secondNode)}]");
						}
						else
						{
								reader.WriteOutput("Missing nodes");
						}
				}
		}
}

