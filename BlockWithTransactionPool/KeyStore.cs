using System.Security.Cryptography;

namespace BlockChainCourse.BlockWithTransactionPool
{

    public class KeyStore : IKeyStore
    {
        public RSAParameters PrivateSigningKey { get; private set; }
        public RSAParameters PublicSigningKey { get; private set; }
        public byte[] AuthenticatedHashKey { get; private set; }

        public KeyStore(RSAParameters privateSigningKey, RSAParameters publicSigningKey, byte[] authenticatedHashKey)
        {
            PrivateSigningKey = privateSigningKey;
            PublicSigningKey = publicSigningKey;
            AuthenticatedHashKey = authenticatedHashKey;
        }
    }
}
