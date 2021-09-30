

using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class BankAccount
    {
        [Key]
        public int AccoıuntId { get; set; }
        public long AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string AccountBranch { get; set; }
        public int AccountBalance { get; set; }
        public int AccountCreditLine { get; set; }
        public bool AccountStatus { get; set; }

    }
}
