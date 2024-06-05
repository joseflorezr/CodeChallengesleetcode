namespace ChallengeImplementation.Model
{
		public interface IReader
		{
				string ReadInput(string text);
				void WriteOutput(string text);
				void Clear();
		}
}
