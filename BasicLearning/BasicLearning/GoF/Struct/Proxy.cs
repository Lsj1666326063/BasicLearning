using System;

namespace BasicLearning
{
    /*--
     * 习题
       1. Windows操作系统中的应用程序快捷方式是(    )模式的应用实例。
       A. 代理 (Proxy)            B. 组合 (Composite)
       C. 装饰 (Decorator)         D. 外观 (Facade)

       2. 毕业生通过职业介绍所找工作，请问该过程蕴含了哪种设计模式，绘制相应的类图。

       3. 在某应用软件中需要记录业务方法的调用日志，在不修改现有业务类的基础上为每一个类提供一个日志记录代理类，在代理类中输出日志，
       如在业务方法Method()调用之前输出“方法Method()被调用，调用时间为2012-11-5 10:10:10”，调用之后如果没有抛异常则输出“方法Method()调用成功”，
       否则输出“方法Method()调用失败”。在代理类中调用真实业务类的业务方法，使用代理模式设计该日志记录模块的结构，绘制类图并使用C#语言编程模拟实现。

       4. 某软件公司欲开发一款基于C/S的网络图片查看器，具体功能描述如下：用户只需在图片查看器中输入网页URL，
       程序将自动将该网页所有图片下载到本地，考虑到有些网页图片比较多，而且某些图片文件比较大，因此将先以图标的方式显示图片，
       不同类型的图片使用不同的图标，并且在图标下面标注该图片的文件名，用户单击图标后可查看真正的图片，界面效果如图15-7所示。
       试使用虚拟代理模式设计并实现该图片查看器。（注：可以结合多线程机制，使用一个线程显示小图标，同时启动另一个线程在后台加载原图。）
     */
    
    public interface ICompany
    {
        void SubmitResume(string resume);
    }
    
    public class GameCompany:ICompany
    {
        public void SubmitResume(string resume)
        {
            Console.WriteLine($"收到简历: {resume}");
        }
    }

    public class GameCompanyProxy : ICompany
    {
        private ICompany company;

        public GameCompanyProxy()
        {
            company = new GameCompany();
        }
        
        public void SubmitResume(string resume)
        {
            Console.WriteLine($"方法 提交简历SubmitResume() 被调用，调用时间为：{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            try
            {
                company.SubmitResume(resume);
            }
            catch (Exception e)
            {
                Console.WriteLine($"提交简历失败 {e}");
                return;
            }
            Console.WriteLine($"提交简历成功");
        }
    }
}