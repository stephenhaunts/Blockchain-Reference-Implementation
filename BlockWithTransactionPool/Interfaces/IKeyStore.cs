using System.Security.Cryptography;

namespace BlockChainCourse.BlockWithTransactionPool
{
    public interface IKeyStore
    {
        RSAParameters PrivateSigningKey { get; }
        RSAParameters PublicSigningKey { get; }
        byte[] AuthenticatedHashKey { get; }
    }
}
