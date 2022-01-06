using System;

namespace BasicLearning
{
    /*
     * 练习
        使用工厂方法模式设计一个程序来读取各种不同类型的图片格式，针对每一种图片格式都设计一个图片读取器，
        如GIF图片读取器用于读取GIF格式的图片、JPG图片读取器用于读取JPG格式的图片。需充分考虑系统的灵活性和可扩展性。
     */
    public abstract class PictureReaderFactory
    {
        public abstract IPictureReader Create();
        public abstract IPictureReader Create(string parm);
    }
    
    public class GifPictureReaderFactory:PictureReaderFactory
    {
        public override IPictureReader Create()
        {
            Console.WriteLine("GifPictureReaderFactory 不使用参数创建 GifPictureReader");
            return new GifPictureReader();
        }

        public override IPictureReader Create(string parm)
        {
            Console.WriteLine($"GifPictureReaderFactory 使用参数{parm}创建 GifPictureReader");
            return new GifPictureReader();
        }
    }
    
    public class JpgPictureReaderFactory:PictureReaderFactory
    {
        public override IPictureReader Create()
        {
            Console.WriteLine("JpgPictureReaderFactory 不使用参数创建 JpgPictureReader");
            return new JpgPictureReader();
        }

        public override IPictureReader Create(string parm)
        {
            Console.WriteLine($"JpgPictureReaderFactory 使用参数{parm}创建 JpgPictureReader");
            return new JpgPictureReader();
        }
    }
    
    // public class PngPictureReaderFactory:PictureReaderFactory
    // {
    //     public override IPictureReader Create()
    //     {
    //         Console.WriteLine("PngPictureReaderFactory 不使用参数创建 PngPictureReader");
    //         return new PngPictureReader();
    //     }
    //
    //     public override IPictureReader Create(string parm)
    //     {
    //         Console.WriteLine($"PngPictureReaderFactory 使用参数{parm}创建 PngPictureReader");
    //         return new PngPictureReader();
    //     }
    // }

    
    
    
    public interface IPictureReader
    {
        void PictureReader();
    }

    public class GifPictureReader:IPictureReader
    {
        public void PictureReader()
        {
            Console.WriteLine("读取Gif格式图片");
        }
    }

    public class JpgPictureReader:IPictureReader
    {
        public void PictureReader()
        {
            Console.WriteLine("读取Jpg格式图片");
        }
    }

    // public class PngPictureReader:IPictureReader
    // {
    //     public void PictureReader()
    //     {
    //         Console.WriteLine("读取Png格式图片");
    //     }
    // }
}