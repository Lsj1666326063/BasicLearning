using System;

namespace BasicLearning
{
    /*
     * 练习
        Sunny软件公司欲开发了一个数据加密模块，可以对字符串进行加密。
        最简单的加密算法通过对字母进行移位来实现，同时还提供了稍复杂的逆向输出加密，还提供了更为高级的求模加密。
        用户先使用最简单的加密算法对字符串进行加密，如果觉得还不够可以对加密之后的结果使用其他加密算法进行二次加密，当然也可以进行第三次加密。
        试使用装饰模式设计该多重加密系统。
     */
    
    /*
     * 装饰器模式? 外面套一层模式(dog)
     */

    // 抽象构件
    public abstract class Encrypt
    {
        public abstract string Encryption(string data);
    }

    // 具体构件
    public class GressionEncrypt:Encrypt
    {
        public override string Encryption(string data)
        {
            Console.WriteLine($"移位加密");
            return data;
        }
    }
    
    #region 透明装饰模式 客户端可针对抽象构件编程
    
    // // 抽象装饰器
    // public abstract class EncryptDecorator:Encrypt
    // {
    //     private Encrypt encrypt;
    //
    //     public EncryptDecorator(Encrypt encrypt)
    //     {
    //         this.encrypt = encrypt;
    //     }
    //
    //     public override string Encryption(string data)
    //     {
    //         string result = encrypt.Encryption(data);
    //         return result;
    //     }
    // }
    //
    // // 具体装饰器
    // public class ReverseOutPutEncrypt : EncryptDecorator
    // {
    //     public ReverseOutPutEncrypt(Encrypt encrypt) : base(encrypt){}
    //
    //     public override string Encryption(string data)
    //     {
    //         string result = base.Encryption(data);
    //         result = ReverseOutPutEncryption(result);
    //         return result;
    //     }
    //
    //     public string ReverseOutPutEncryption(string data)
    //     {
    //         Console.WriteLine($"逆向输出加密");
    //         return data;
    //     }
    // }
    //
    // // 具体装饰器    
    // public class ModEncrypt : EncryptDecorator
    // {
    //     public ModEncrypt(Encrypt encrypt) : base(encrypt){}
    //
    //     public override string Encryption(string data)
    //     {
    //         string result = base.Encryption(data);
    //         result = ModEncryption(result);
    //         return result;
    //     }
    //
    //     public string ModEncryption(string data)
    //     {
    //         Console.WriteLine($"求模加密");
    //         return data;
    //     }
    // }
    
    #endregion
    
    #region 半透明装饰模式 客户端需针对抽象构件和具体装饰器编程
    
    // 抽象装饰器
    public abstract class EncryptDecorator:Encrypt
    {
        private Encrypt encrypt;
    
        public EncryptDecorator(Encrypt encrypt)
        {
            this.encrypt = encrypt;
        }
    
        public override string Encryption(string data)
        {
            string result = encrypt.Encryption(data);
            return result;
        }
    }
    
    // 具体装饰器
    public class ReverseOutPutEncrypt : EncryptDecorator
    {
        public ReverseOutPutEncrypt(Encrypt encrypt) : base(encrypt){}
    
        public string ReverseOutPutEncryption(string data)
        {
            Console.WriteLine($"逆向输出加密");
            return data;
        }
    }
    
    // 具体装饰器    
    public class ModEncrypt : EncryptDecorator
    {
        public ModEncrypt(Encrypt encrypt) : base(encrypt){}
    
        public string ModEncryption(string data)
        {
            Console.WriteLine($"求模加密");
            return data;
        }
    }
    
    #endregion
}