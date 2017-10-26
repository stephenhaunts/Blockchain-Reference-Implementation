using System;

namespace BlockChainCourse.BlockWithSingleTransaction
{
    public enum ClaimType
    {
        TotalLoss = 0    
    }

    public interface IBlock
    {
        string ClaimNumber { get; set; }
        decimal SettlementAmount { get; set; }
        DateTime SettlementDate { get; set; }
        string CarRegistration { get; set; }
        int Mileage { get; set; }
        ClaimType ClaimType { get; set; }

        DateTime CreatedDate { get; }
        string BlockHash { get; }
        string PreviousBlockHash { get; }
    }

    public class Block : IBlock
    {
        // Provided by the user
        public string ClaimNumber { get; set; }
        public decimal SettlementAmount { get; set; }
        public DateTime SettlementDate { get; set; }
        public string CarRegistration { get; set; }
        public int Mileage { get; set; }
        public ClaimType ClaimType { get; set; }

        // Set as part of the block creation process.
        public DateTime CreatedDate { get; private set; }
        public string BlockHash { get; private set; }
        public string PreviousBlockHash { get; private set; }

        public Block()
        {
         
        }

     

    }
}
