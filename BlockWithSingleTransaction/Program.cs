using System;

namespace BlockChainCourse.BlockWithSingleTransaction
{
    class Program
    {
        static void Main(string[] args)
        {
            IBlock block1 = new Block(0, "ABC123", 1000.00m, DateTime.Now, "QWE123", 10000, ClaimType.TotalLoss);
            IBlock block2 = new Block(1, "VBG345", 2000.00m, DateTime.Now, "JKH567", 20000, ClaimType.TotalLoss);
            IBlock block3 = new Block(2, "XCF234", 3000.00m, DateTime.Now, "LKH765", 30000, ClaimType.TotalLoss);

            block1.SetBlockHash(null);
            block2.SetBlockHash(block1);
            block3.SetBlockHash(block2);

            BlockChain chain = new BlockChain();
            chain.AcceptBlock(block1);
            chain.AcceptBlock(block2);
            chain.AcceptBlock(block3);
        }
    }
}
