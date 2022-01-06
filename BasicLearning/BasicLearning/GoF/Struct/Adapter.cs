using System;
using AssistTest;

namespace BasicLearning
{
    /*
     * 练习
       Sunny软件公司OA系统需要提供一个加密模块，将用户机密信息（如口令、邮箱等）加密之后再存储在数据库中，系统已经定义好了数据库操作类。
       为了提高开发效率，现需要重用已有的加密算法，这些算法封装在一些由第三方提供的类中，有些甚至没有源代码。
       试使用适配器模式设计该加密模块，实现在不修改现有类的基础上重用第三方加密方法。
     */
    
    // 对象适配器
    public class ObjectAdapter:IDES
    {
        ThirdPartyDES thirdPartyDes = new ThirdPartyDES();
        public void Encryption(string info)
        {
            Console.WriteLine("使用对象适配器调用第三方接口");
            thirdPartyDes.ThirdPartyEncryption(info);
        }

        public void Decryption()
        {
            Console.WriteLine("使用对象适配器调用第三方接口");
            thirdPartyDes.ThirdPartyDecryption();
        }
    }

    // 类适配器
    public class ClassAdapter : ThirdPartyDES, IDES
    {
        public void Encryption(string info)
        {
            Console.WriteLine("使用类适配器调用第三方接口");
            ThirdPartyEncryption(info);
        }

        public void Decryption()
        {
            Console.WriteLine("使用类适配器调用第三方接口");
            ThirdPartyDecryption();
        }
    }

    public class DataBaseOperation
    {
        private IDES des;

        public DataBaseOperation(IDES des)
        {
            this.des = des;
        }
        
        public void SaveUserInfo(string userInfo)
        {
            des.Encryption(userInfo);
            Console.WriteLine("保存用户信息");
        }

        public void/*string*/ GetUserInfo(/*string userId*/)
        {
            des.Decryption();
            Console.WriteLine("获取用户信息");
        }
    }

    public interface IDES
    {
        void Encryption(string info);
        void Decryption();
    }
    

    public class MyDES:IDES
    {
        public void Encryption(string info)
        {
            Console.WriteLine($"自己加密 info:{info}");
        }

        public void Decryption()
        {
            Console.WriteLine("自己解密");
        }
    }
}