using System;

namespace BasicLearning
{
    /*
     * 练习
        Sunny软件公司欲推出一款新的手机游戏软件，该软件能够支持Symbian、Android和Windows Mobile等多个智能手机操作系统平台，
        针对不同的手机操作系统，该游戏软件提供了不同的游戏操作控制(OperationController)类和游戏界面控制(InterfaceController)类，
        并提供相应的工厂类来封装这些类的初始化过程。软件要求具有较好的扩展性以支持新的操作系统平台，为了满足上述需求，试采用抽象工厂模式对其进行设计。
     */
    public abstract class SystemFactory
    {
        public abstract IOperationController CreateOperationController();
        public abstract IInterfaceController CreateIInterfaceController();
    }
    public class SymbianSystemFactory:SystemFactory
    {
        public override IOperationController CreateOperationController()
        {
            IOperationController oc = new SymbianOperationController();
            return oc;
        }

        public override IInterfaceController CreateIInterfaceController()
        {
            IInterfaceController ic = new SymbianInterfaceController();
            return ic;
        }
    }
    public class AndroidSystemFactory:SystemFactory
    {
        public override IOperationController CreateOperationController()
        {
            IOperationController oc = new AndroidOperationController();
            return oc;
        }

        public override IInterfaceController CreateIInterfaceController()
        {
            IInterfaceController ic = new AndroidInterfaceController();
            return ic;
        }
    }
    public class WindowsSystemMobileFactory:SystemFactory
    {
        public override IOperationController CreateOperationController()
        {
            IOperationController oc = new WindowsMobileOperationController();
            return oc;
        }

        public override IInterfaceController CreateIInterfaceController()
        {
            IInterfaceController ic = new WindowsMobileInterfaceController();
            return ic;
        }
    }

    
    public interface IOperationController
    {
        void Move();
        void Attack();
    }

    public class SymbianOperationController : IOperationController
    {
        public void Move()
        {
            Console.WriteLine("Symbian平台操作控制 Move");
        }

        public void Attack()
        {
            Console.WriteLine("Symbian平台操作控制 Attack");
        }
    }

    public class AndroidOperationController : IOperationController
    {
        public void Move()
        {
            Console.WriteLine("Android平台操作控制 Move");
        }

        public void Attack()
        {
            Console.WriteLine("Android平台操作控制 Attack");
        }
    }

    public class WindowsMobileOperationController : IOperationController
    {
        public void Move()
        {
            Console.WriteLine("WindowsMobile平台操作控制 Move");
        }

        public void Attack()
        {
            Console.WriteLine("WindowsMobile平台操作控制 Attack");
        }
    }
    

    public interface IInterfaceController
    {
        void Show();
        void Close();
    }

    public class SymbianInterfaceController : IInterfaceController
    {
        public void Show()
        {
            Console.WriteLine("Symbian平台界面控制 Show");
        }

        public void Close()
        {
            Console.WriteLine("Symbian平台界面控制 Close");
        }
    }

    public class AndroidInterfaceController : IInterfaceController
    {
        public void Show()
        {
            Console.WriteLine("Android平台界面控制 Show");
        }

        public void Close()
        {
            Console.WriteLine("Android平台界面控制 Close");
        }
    }

    public class WindowsMobileInterfaceController : IInterfaceController
    {
        public void Show()
        {
            Console.WriteLine("WindowsMobile平台界面控制 Show");
        }

        public void Close()
        {
            Console.WriteLine("WindowsMobile平台界面控制 Close");
        }
    }
    
}