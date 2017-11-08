using System;
using System.Text;
using BlockChainCourse.Cryptography;

namespace BlockChainCourse.ProofOfWorkTest
{
    public class ProofOfWork
    {
        public string MyData { get; private set; }
        public int Difficulty { get; private set; }
        public int Nonce { get; private set; }

        public ProofOfWork(string dataToHash, int difficulty)
        {
            MyData = dataToHash;
            Difficulty = difficulty;
        }

        public string CalculateProofOfWork()
        {
            string difficulty = DifficultyString();

            while(true)
            {
                string hashedData = Convert.ToBase64String(HashData.ComputeHashSha256(Encoding.UTF8.GetBytes(Nonce + MyData)));

                if (hashedData.StartsWith(difficulty, StringComparison.Ordinal))
                {
                    return hashedData;
                }

                Nonce++;
            }
        }

        private string DifficultyString()
        {
            string difficultyString = string.Empty;

            for (int i = 0; i < Difficulty; i++ )
            {
                difficultyString += "0";    
            }

            return difficultyString;
        }
    }
}
