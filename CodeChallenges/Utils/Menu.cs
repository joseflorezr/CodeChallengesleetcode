using ChallengeImplementation.Model;
using CodeChallenges.Model;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace CodeChallenges.Utils
{
		/// <summary>
		/// Builds the menu into the console
		/// </summary>
		/// <param name="configuration">Configuration from appsettings.json</param>
		internal class Menu(IConfiguration configuration,IReader reader)
		{

				IOption? option = null;
				readonly IConfiguration _configuration = configuration;
				ICollection<Option> options=[];
				/// <summary>
				/// Gets the data from the appsettings json file
				/// </summary>
				internal  void ShowMainMenu()
				{
						options = [];
						reader.WriteOutput("Code Challenges:");
						var section= _configuration.GetSection("Options");
						foreach (var item in section.GetChildren())
						{
								if (item != null)
								{
												var option = new Option {
														ClassName = item.GetSection("className").Value,
														Description= item.GetSection("description").Value,
														Id = Convert.ToInt32(item.GetSection("id").Value),
												};
										if(option != null)
												{
														reader.WriteOutput(option.ToString());
														options.Add(option);
												}
										}
						}
				}
				/// <summary>
				/// Builds the challenge instance
				/// </summary>
				/// <param name="key">selected option</param>
				/// <returns>Option instance</returns>
				internal IOption? BuildOption(int key)
				{

					if(key==0)
						{
								reader.Clear();
								ShowMainMenu();
						}
						else
						{
								var currentOption=options.FirstOrDefault(data=>data.Id==key);
								if(currentOption!=null)
								{
										string? assemblyName = _configuration.GetSection("assemblyChallenge").Value;
										if(!string.IsNullOrEmpty(assemblyName))
										{
												LoadAssembly(reader,key,currentOption,assemblyName);
										}

								}
						}
						return option;
				}

				private void LoadAssembly(IReader reader,int key,Option currentOption,string assemblyName)
				{
						var assembly = Assembly.LoadFrom(assemblyName);


						if (!string.IsNullOrWhiteSpace(currentOption.ClassName))
						{
								if (assembly != null)
								{
										LoadOptions(reader,currentOption,assembly);
								}



						}
						else
						{
								option = new OptionFactory(key,reader);
						}
				}

				private void LoadOptions(IReader reader,Option currentOption,Assembly assembly)
				{
						var type = assembly.GetTypes().FirstOrDefault(type => type.Name == currentOption.ClassName);
						if (type != null)
						{
								var instantiatedType = Activator.CreateInstance(type,[reader]);
								if (instantiatedType != null)
										option = (IOption)instantiatedType;
						}
				}
		}
}
