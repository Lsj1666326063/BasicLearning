using System;

namespace BasicLearning
{
    /*
     * 题目：
        在计算机主机（MainFrame）中，只需要按下主机的开机按钮(on())，就可以调用其他硬件设备和软件的启动方法，
        如内存(Memory)的自检(check())，CPU的运行(run())，硬盘(Harddisk)的读取(read())，操作系统(OS)的载入(load())等，
        如果某一过程发生错误，则计算机启动失败，使用外观模式模拟该过程绘制类图并编程实现。
     */
    
    
    // 抽象开机外观类
    public abstract class AbstractOnFacade
    {
        protected Memory memory;
        protected Cpu cpu;
        protected Harddisk harddisk;
        protected Os os;
        
        public abstract void On();
    }

    // 具体外观类
    public class Win10OnFacade : AbstractOnFacade
    {
        public Win10OnFacade()
        {
            memory = new Memory();
            cpu = new Cpu();
            harddisk = new Harddisk();
            os = new Win10Os();
        }
        public override void On()
        {
            ConsoleUtil.WriteLine("开始启动Win10系统主机", ConsoleColor.Green);
            
            if (!memory.Chedk() || !cpu.Run() || !harddisk.Read() || !os.Load())
            {
                ConsoleUtil.WriteLine("启动失败", ConsoleColor.Red);
                return;
            }
            
            ConsoleUtil.WriteLine("启动成功", ConsoleColor.Green);
        }
    }

    // 具体外观类
    public class MacOnFacade : AbstractOnFacade
    {
        public MacOnFacade()
        {
            memory = new Memory();
            cpu = new Cpu();
            harddisk = new Harddisk();
            os = new MacOs();
        }
        public override void On()
        {
            ConsoleUtil.WriteLine("开始启动Mac系统主机", ConsoleColor.Green);
            
            if (!memory.Chedk() || !cpu.Run() || !harddisk.Read() || !os.Load())
            {
                ConsoleUtil.WriteLine("启动失败", ConsoleColor.Red);
                return;
            }
            
            ConsoleUtil.WriteLine("启动成功", ConsoleColor.Green);
        }
    }
    
    

    // 子系统类
    public class Memory
    {
        public bool Chedk()
        {
            ConsoleUtil.WriteLine($"内存检测 无异常", ConsoleColor.Green);
            return true;
        }
    }

    // 子系统类
    public class Cpu
    {
        public bool Run()
        {
            ConsoleUtil.WriteLine($"启动Cpu 成功", ConsoleColor.Green);
            return true;
        }
    }

    // 子系统类
    public class Harddisk
    {
        public bool Read()
        {
            ConsoleUtil.WriteLine($"读取硬盘数据 成功", ConsoleColor.Green);
            return true;
        }
    }

    // 抽象子系统类
    public abstract class Os
    {
        public abstract bool Load();
    }
    // 具体子系统类
    public class Win10Os : Os
    {
        public override bool Load()
        {
            ConsoleUtil.WriteLine($"加载Win10操作系统 成功", ConsoleColor.Green);
            return true;
        }
    }
    // 具体子系统类
    public class MacOs : Os
    {
        public override bool Load()
        {
            ConsoleUtil.WriteLine($"加载Mac操作系统 失败", ConsoleColor.Red);
            return false;
        }
    }
}