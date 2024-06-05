using ChallengeImplementation.Model;
using ExtensionUtils.Utils;

namespace CodeChallenges.Model
{
		internal class ConsoleReader:IReader
		{
				public void Clear()
				{
						Console.Clear();
				}

				public string ReadInput(string text)
				{
						return  ReadConsoleLine(text).NullStringToEmpty();
				}
				internal static string? ReadConsoleLine(string text)
				{
						Console.WriteLine(text);
						return Console.ReadLine();
				}

				public void WriteOutput(string text)
				{
						Console.WriteLine(text);
				}
		}
}
