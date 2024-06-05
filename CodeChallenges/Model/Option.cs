namespace CodeChallenges.Model
{
		internal class Option
		{
        public  int Id { get; set; }
        public string? Description { get; set; }
				public string? ClassName { get; set; }
				public override string ToString()
				{
						return $"{Id}. {Description}";
				}
		}
}
