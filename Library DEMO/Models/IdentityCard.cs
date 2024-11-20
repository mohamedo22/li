namespace Library_DEMO.Models
{
    public class IdentityCard
    {
        public int Id { get; set; }
        public DateTime ExpireDate { get; set; }
        public Author Author { get; set; }
    }
}
