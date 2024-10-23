namespace QBankApi.DTOs
{
    public class AccountDTO 
    {
        public int Id {get; set; }
        
        public string AccountNumber {get; set; } = string.Empty;
        
        public string AccountHolder {get; set; } = string.Empty;
        
        public decimal balance {get; set; }

        
    }
}