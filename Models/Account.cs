namespace Qbank.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? AccountHolder { get; set; }
        public string? AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}