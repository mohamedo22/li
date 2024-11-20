namespace Library_DEMO.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Author Author {  get; set; }
    }
}
