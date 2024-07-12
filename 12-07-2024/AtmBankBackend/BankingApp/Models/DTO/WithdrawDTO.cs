using System.ComponentModel.DataAnnotations;

namespace BankingApp.Models.DTO
{
    public class WithdrawDTO
    {

        
        public long CardNumber { get; set; }

       
        public string PIN { get; set; }

        
        public double Amount { get; set; }

        public int AtmId { get; set; }


    }
}
