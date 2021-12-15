using System;

namespace BasicLearning
{
    /*--
     * 实例练习
        显示某个目录下全部文件的名字，
        比如可以按文件的大小顺序，
        按最后修改的时间顺序
        或按文件名字的字典顺序
        来显示某个目录下全部文件的名字
     */

    /*
     * 模板方法模式：
     * 定义一个操作中算法的框架，而将一些步骤延迟到子类中。
     * 模板方法模式使得子类可以不改变一个算法的结构即可重定义该算法的某些特定步骤。
     */
    
    public abstract class DirectoryDisplay
    {
        private string dirPath;

        public DirectoryDisplay(string directoryPath)
        {
            dirPath = directoryPath;
        }
        
        // 模板方法
        public void DisplayAllFileName()
        {
            GetAllFileName();
            if(IsSort())
                Sort();
            Display();
        }
        
        // 具体方法
        protected void GetAllFileName()
        {
            Console.WriteLine($"获得 {dirPath} 目录下所有文件名");
        }
        
        // 抽象方法
        protected abstract void Sort();
        
        // 钩子方法
        protected virtual bool IsSort()
        {
            Console.WriteLine($"需要排序");
            return true;
        }

        // 具体方法
        protected void Display()
        {
            Console.WriteLine($"显示 {dirPath} 目录下所有文件名");
        }
    }

    public class DirectoryDisplayByFileSize:DirectoryDisplay
    {
        public DirectoryDisplayByFileSize(string directoryPath) : base(directoryPath)
        {
        }

        protected override void Sort()
        {
            Console.WriteLine($"按文件大小排序");
        }
    }

    public class DirectoryDisplayByModifyTime:DirectoryDisplay
    {
        public DirectoryDisplayByModifyTime(string directoryPath) : base(directoryPath)
        {
        }

        protected override void Sort()
        {
            Console.WriteLine($"按修改时间排序");
        }
    }

    public class DirectoryDisplayByFileName:DirectoryDisplay
    {
        public DirectoryDisplayByFileName(string directoryPath) : base(directoryPath)
        {
        }

        protected override void Sort()
        {
            Console.WriteLine($"按文件名字排序");
        }

        protected override bool IsSort()
        {
            Console.WriteLine($"不用排序");
            return false;
        }
    }
    
}