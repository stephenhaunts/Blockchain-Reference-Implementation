using System;
using System.Text;
using BlockChainCourse.Cryptography;

namespace BlockChainCourse.BlockWithSingleTransaction
{
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
        public IBlock NextBlock { get; set; }

        public Block(int blockNumber,
                     string claimNumber,
                     decimal settlementAmount,
                     DateTime settlementDate,
                     string carRegistration,
                     int mileage,
                     ClaimType claimType)
        {
            BlockNumber = blockNumber;
            ClaimNumber = claimNumber;
            SettlementAmount = settlementAmount;
            SettlementDate = settlementDate;
            CarRegistration = carRegistration;
            Mileage = mileage;
            ClaimType = claimType;
            CreatedDate = DateTime.UtcNow;
        }

        public string CalculateBlockHash(string previousBlockHash)
        {
            string txnHash = ClaimNumber + SettlementAmount + SettlementDate + CarRegistration + Mileage + ClaimType;
            string blockheader = BlockNumber + txnHash + CreatedDate + previousBlockHash;
            string combined = txnHash + blockheader;

            return Convert.ToBase64String(HashData.ComputeHashSha256(Encoding.UTF8.GetBytes(combined)));
        }

        // Set the block hash
        public void SetBlockHash(IBlock parent)
        {
            if (parent != null)
            {
                PreviousBlockHash = parent.BlockHash;
                parent.NextBlock = this;
            }
            else
            {
                // Previous block is the genesis block.
                PreviousBlockHash = null;
            }

            BlockHash = CalculateBlockHash(PreviousBlockHash);
        }

      
        public void IsValidChain(string prevBlockHash)
        {
            bool failed = false;

            // Is this a valid block and transaction
            string newBlockHash = CalculateBlockHash(prevBlockHash);
            if (newBlockHash != BlockHash)
            {
                failed = true;
            }
  
            // Does the previous block hash match the latest previous block hash
            failed |= PreviousBlockHash != prevBlockHash;

            if (failed)
            {
                Console.WriteLine("Block Number " + BlockNumber + " : FAILED VERIFICATION");
            }
            else
            {
                Console.WriteLine("Block Number " + BlockNumber + " : PASS VERIFICATION");
            }

            // Check the next block
            if (NextBlock != null)
            {
                NextBlock.IsValidChain(newBlockHash);
            }
        }
    }
}
