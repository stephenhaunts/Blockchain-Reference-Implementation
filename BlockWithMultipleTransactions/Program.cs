using System;
using Clifton.Blockchain;

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


            IBlock block1 = new Block(0);
            IBlock block2 = new Block(1);
            IBlock block3 = new Block(2);
            IBlock block4 = new Block(3);
            IBlock block5 = new Block(4);
            IBlock block6 = new Block(5);
            IBlock block7 = new Block(6);
            IBlock block8 = new Block(7);

            block1.AddTransaction(txn1);
            block2.AddTransaction(txn2);
            block3.AddTransaction(txn3);
            block4.AddTransaction(txn4);
            block5.AddTransaction(txn5);
            block6.AddTransaction(txn6);
            block7.AddTransaction(txn7);
            block8.AddTransaction(txn8);


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

            block4.Transaction[0].CarRegistration = "INVALID";

            chain.VerifyChain();

            Console.WriteLine();






            //MerkleTree tree = new MerkleTree();
            //tree.AppendLeaf(MerkleHash.Create("abc"));
            //tree.AppendLeaf(MerkleHash.Create("def"));
            //tree.AppendLeaf(MerkleHash.Create("123"));
            //tree.AppendLeaf(MerkleHash.Create("456"));
            //tree.BuildTree();
            //tree.RootNode.ToString();

            //MerkleTree tree2 = new MerkleTree();
            //tree2.AppendLeaf(MerkleHash.Create("abc"));
            //tree2.AppendLeaf(MerkleHash.Create("def"));
            //tree2.AppendLeaf(MerkleHash.Create("123"));
            //tree2.AppendLeaf(MerkleHash.Create("456"));
            //tree2.BuildTree();
            //tree2.RootNode.ToString();

            //if (tree.RootNode.ToString() == tree2.RootNode.ToString())
            //{
            //    Console.WriteLine("yay");
            //}
        }
    }
}
