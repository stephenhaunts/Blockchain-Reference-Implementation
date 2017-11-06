using System;
using System.Text;
using BlockChainCourse.Cryptography;

namespace BlockChainCourse.BlockWithMultipleTransactions
{
    public class Block : IBlock
    {
        public ITransaction Transaction { get; set; }

        // Set as part of the block creation process.
        public int BlockNumber { get; private set; }
        public DateTime CreatedDate { get; set; }
        public string BlockHash { get; private set; }
        public string PreviousBlockHash { get; set; }
        public IBlock NextBlock { get; set; }

        public Block(int blockNumber, ITransaction transaction)
        {
            BlockNumber = blockNumber;
            Transaction = transaction;

            CreatedDate = DateTime.UtcNow;
        }

        public string CalculateBlockHash(string previousBlockHash)
        {
            string blockheader = BlockNumber + CreatedDate.ToString() + previousBlockHash;
            string combined = Transaction.CalculateTransactionHash() + blockheader;

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

      
        public bool IsValidChain(string prevBlockHash, bool verbose)
        {
            bool isValid = true;

            // Is this a valid block and transaction
            string newBlockHash = CalculateBlockHash(prevBlockHash);
            if (newBlockHash != BlockHash)
            {
                isValid = false;
            }

            // Does the previous block hash match the latest previous block hash
            isValid |= PreviousBlockHash == prevBlockHash;

            PrintVerificationMessage(verbose, isValid);

            // Check the next block by passing in our newly calculated blockhash. This will be compared to the previous
            // hash in the next block. They should match for the chain to be valid.
            if (NextBlock != null)
            {
                return NextBlock.IsValidChain(newBlockHash, verbose);
            }

            return isValid;
        }

        private void PrintVerificationMessage(bool verbose, bool isValid)
        {
            if (verbose)
            {
                if (!isValid)
                {
                    Console.WriteLine("Block Number " + BlockNumber + " : FAILED VERIFICATION");
                }
                else
                {
                    Console.WriteLine("Block Number " + BlockNumber + " : PASS VERIFICATION");
                }
            }
        }
    }
}
