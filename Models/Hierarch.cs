namespace Wizardsoft.Models
{
	public class Hierarch
	{
		public int Id { get; set; }
		public int ParentId { get; set; }
        public string? Name { get; set; }
        public string? Addr { get; set; }
	}
}