namespace JoeBlogs
{
	/// <summary> 
	/// Represents information about a user. 
	/// </summary> 
	public class Data
	{
        public string Name { get; set; }
        public string Type { get; set; }
        public string Base64 { get; set; }
        public bool Overwrite { get; set; }
	}
}