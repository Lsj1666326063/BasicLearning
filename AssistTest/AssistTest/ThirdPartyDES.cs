using System;

namespace AssistTest
{
    public interface IDES
    {
        void ThirdPartyEncryption(string info);
        void ThirdPartyDecryption();
    }
    
    public class ThirdPartyDES:IDES
    {
        public void ThirdPartyEncryption(string info)
        {
            Console.WriteLine($"第三方加密 info:{info}");
        }

        public void ThirdPartyDecryption()
        {
            Console.WriteLine("第三方解密");
        }
    }
}