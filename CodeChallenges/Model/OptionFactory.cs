using ChallengeImplementation.Model;

namespace CodeChallenges.Model
{
		/// <summary>
		/// Creates the option instance depending on the selected option
		/// </summary>
		internal class OptionFactory:IOption
		{
				/// <summary>
				/// Class constructor
				/// </summary>
				/// <param name="key">Key</param>
				/// <remarks>
				/// To create a challenge, add the option on appsettings file
				/// they must inherint from IOption
				/// </remarks>
				internal OptionFactory(int key,IReader reader)
        {
						switch (key)
						{
								case 0:
										break;
								case 151:
										reader.WriteOutput("Bye");
										break;
								default:
										reader.WriteOutput("Not implemented option, please try again");
										break;
						}
				}
        public void Execute()
				{
				}
		}
}
