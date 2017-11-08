using System;

namespace BlockChainCourse.ProofOfWorkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ProofOfWork pow1 = new ProofOfWork("Mary had a little lamb", 1);
            Console.WriteLine("Difficulty 1 : " + pow1.CalculateProofOfWork());


            ProofOfWork pow2 = new ProofOfWork("Mary had a little lamb", 2);
            Console.WriteLine("Difficulty 2 : " + pow2.CalculateProofOfWork());


            ProofOfWork pow3 = new ProofOfWork("Mary had a little lamb", 3);
            Console.WriteLine("Difficulty 3 : " + pow3.CalculateProofOfWork());


            ProofOfWork pow4 = new ProofOfWork("Mary had a little lamb", 4);
            Console.WriteLine("Difficulty 4 : " + pow4.CalculateProofOfWork());

            ProofOfWork pow5 = new ProofOfWork("Mary had a little lamb", 5);
            Console.WriteLine("Difficulty 5 : " + pow5.CalculateProofOfWork());


            ProofOfWork pow6 = new ProofOfWork("Mary had a little lamb", 6);
            Console.WriteLine("Difficulty 6 : " + pow6.CalculateProofOfWork());

        }
    }
}
