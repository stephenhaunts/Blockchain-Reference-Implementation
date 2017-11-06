using System;

namespace BlockChainCourse.BlockWithMultipleTransactions
{
    class Program
    {
        static void Main(string[] args)
        {

            ITransaction txn1 = new Transaction("ABC123", 1000.00m, DateTime.Now, "QWE123", 10000, ClaimType.TotalLoss);
            ITransaction txn2 = new Transaction("VBG345", 2000.00m, DateTime.Now, "JKH567", 20000, ClaimType.TotalLoss);
            ITransaction txn3 = new Transaction("XCF234", 3000.00m, DateTime.Now, "DH23ED", 30000, ClaimType.TotalLoss);
            ITransaction txn4 = new Transaction("CBHD45", 4000.00m, DateTime.Now, "DH34K6", 40000, ClaimType.TotalLoss);
            ITransaction txn5 = new Transaction("AJD345", 5000.00m, DateTime.Now, "28FNF4", 50000, ClaimType.TotalLoss);
            ITransaction txn6 = new Transaction("QAX367", 6000.00m, DateTime.Now, "FJK676", 60000, ClaimType.TotalLoss);
            ITransaction txn7 = new Transaction("CGO444", 7000.00m, DateTime.Now, "LKU234", 70000, ClaimType.TotalLoss);
            ITransaction txn8 = new Transaction("PLO254", 8000.00m, DateTime.Now, "VBN456", 80000, ClaimType.TotalLoss);


            IBlock block1 = new Block(0, txn1);
            IBlock block2 = new Block(1, txn2);
            IBlock block3 = new Block(2, txn3);
            IBlock block4 = new Block(3, txn4);
            IBlock block5 = new Block(4, txn5);
            IBlock block6 = new Block(5, txn6);
            IBlock block7 = new Block(6, txn7);
            IBlock block8 = new Block(7, txn8);

            block1.SetBlockHash(null);
            block2.SetBlockHash(block1);
            block3.SetBlockHash(block2);
            block4.SetBlockHash(block3);
            block5.SetBlockHash(block4);
            block6.SetBlockHash(block5);
            block7.SetBlockHash(block6);
            block8.SetBlockHash(block7);

            BlockChain chain = new BlockChain();
            chain.AcceptBlock(block1);
            chain.AcceptBlock(block2);
            chain.AcceptBlock(block3);
            chain.AcceptBlock(block4);
            chain.AcceptBlock(block5);
            chain.AcceptBlock(block6);
            chain.AcceptBlock(block7);
            chain.AcceptBlock(block8);

            chain.VerifyChain();

            Console.WriteLine("");
            Console.WriteLine("");

            block4.Transaction.CarRegistration = "INVALID";

            chain.VerifyChain();

            Console.WriteLine();
        }
    }
}
