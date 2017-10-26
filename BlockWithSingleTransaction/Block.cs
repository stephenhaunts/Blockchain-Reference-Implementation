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

        int BlockNumber { get; }
        DateTime CreatedDate { get; }
        string BlockHash { get; }
        string PreviousBlockHash { get; set; }

        string CalculateBlockHash();
        void SetBlockHash();
        IBlock NextBlock { get; }
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
        public int BlockNumber { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string BlockHash { get; private set; }
        public string PreviousBlockHash { get; set; }
        public IBlock NextBlock { get; private set; }

        public Block(string claimNumber,
                     decimal settlementAmount,
                     DateTime settlementDate,
                     string carRegistration,
                     int mileage,
                     ClaimType claimType)
        {
            ClaimNumber = claimNumber;
            SettlementAmount = settlementAmount;
            SettlementDate = settlementDate;
            CarRegistration = carRegistration;
            Mileage = mileage;
            ClaimType = claimType;
        }

        // Calculate and return the block hash
        public string CalculateBlockHash()
        {
            return "";
        }

        // Set the block hash
        public void SetBlockHash()
        {
            BlockHash = CalculateBlockHash();
        }

        public void SetNextBlock (IBlock nextBlock)
        {
            // Assign next block
            NextBlock = nextBlock;

            // Calculate the hash for this block
            SetBlockHash();

            // Then assign it to the previous block hash of the next block in the chain.
            NextBlock.PreviousBlockHash = BlockHash;
        }
    }
}
