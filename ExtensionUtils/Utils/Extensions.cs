namespace ExtensionUtils.Utils
{
		public static class Extensions
		{
				public static int[] ToIntArray(this string? input)
				{
						if (string.IsNullOrWhiteSpace(input))
						{
								return [];
						}
						string[] inputArray = input.Split(',');
						int[] intArray = new int[inputArray.Length];
						for (int i = 0;i < inputArray.Length;i++)
								intArray[i] = int.Parse(inputArray[i]);
						return intArray;
				}


				public static int ToInt(this string? text)
				{
						return string.IsNullOrWhiteSpace(text) ? 0 : Convert.ToInt32(text);
				}
				public static string NullStringToEmpty(this string? text)
				{
						return string.IsNullOrWhiteSpace(text) ? string.Empty : text;
				}
		}
}
