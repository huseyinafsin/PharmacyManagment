

using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace EntityLayer.Concrete
{
    public class BankAccount: IEntity
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
