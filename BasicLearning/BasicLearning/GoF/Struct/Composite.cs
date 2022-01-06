using System;
using System.Collections.Generic;

namespace BasicLearning
{
    /*
     * 练习
        Sunny软件公司欲开发一个界面控件库，界面控件分为两大类，
        一类是单元控件，例如按钮、文本框等，
        一类是容器控件，例如窗体、中间面板等，
        试用组合模式设计该界面控件库。
     */

    #region 透明组合 叶子构件和容器构件 都能调用添加 删除 获取子节点的方法，但是叶子节点调用时会报错，（可以统一管理）
    
    // public abstract class Widget
    // {
    //     public abstract void AddChild(Widget widget);
    //     public abstract void RemoveChild(Widget widget);
    //     public abstract Widget GetChild(int index);
    //     public abstract void Show();
    //     public abstract void Hide();
    // }
    //
    // public abstract class SingleWidget : Widget
    // {
    //     public override void AddChild(Widget widget)
    //     {
    //         ConsoleUtil.WriteLine("无法添加子控件", ConsoleColor.Red);
    //     }
    //
    //     public override void RemoveChild(Widget widget)
    //     {
    //         ConsoleUtil.WriteLine("无法移除子控件", ConsoleColor.Red);
    //     }
    //
    //     public override Widget GetChild(int index)
    //     {
    //         ConsoleUtil.WriteLine("无法获取子控件", ConsoleColor.Red);
    //         return null;
    //     }
    // }
    //
    // public class MultiWidget : Widget
    // {
    //     protected List<Widget> childs = new List<Widget>();
    //     
    //     public override void AddChild(Widget widget)
    //     {
    //         childs.Add(widget);
    //     }
    //
    //     public override void RemoveChild(Widget widget)
    //     {
    //         childs.Remove(widget);
    //     }
    //
    //     public override Widget GetChild(int index)
    //     {
    //         return childs[index];
    //     }
    //
    //     public override void Show()
    //     {
    //         for (int i = 0; i < childs.Count; i++)
    //         {
    //             childs[i].Show();
    //         }
    //     }
    //
    //     public override void Hide()
    //     {
    //         for (int i = 0; i < childs.Count; i++)
    //         {
    //             childs[i].Hide();
    //         }
    //     }
    // }
    
    #endregion
    
    #region 安全组合 如果是叶子构件将不会出现添加 删除 获取子节点的方法，避免了子构件调用不能使用的方法，但是容器构件也调不了了，外部需要转成容器构件才能调用，（不能统一管理）
    
    public abstract class Widget
    {
        public abstract void Show();
        public abstract void Hide();
    }

    public abstract class SingleWidget : Widget
    {
    }
    
    public class MultiWidget : Widget
    {
        protected List<Widget> childs = new List<Widget>();
        
        public void AddChild(Widget widget)
        {
            childs.Add(widget);
        }

        public void RemoveChild(Widget widget)
        {
            childs.Remove(widget);
        }

        public Widget GetChild(int index)
        {
            return childs[index];
        }

        public override void Show()
        {
            for (int i = 0; i < childs.Count; i++)
            {
                childs[i].Show();
            }
        }

        public override void Hide()
        {
            for (int i = 0; i < childs.Count; i++)
            {
                childs[i].Hide();
            }
        }
    }
    
    #endregion

    #region 具体构件
    
    public class Button : SingleWidget
    {
        public override void Show()
        {
            Console.WriteLine("显示按钮");
        }

        public override void Hide()
        {
            Console.WriteLine("隐藏按钮");
        }
    }

    public class Text : SingleWidget
    {
        public override void Show()
        {
            Console.WriteLine("显示文本");
        }

        public override void Hide()
        {
            Console.WriteLine("隐藏文本");
        }
    }

    public class Window : MultiWidget
    {
        public override void Show()
        {
            Console.WriteLine("先显示窗口 再显示窗口子控件");
            Console.WriteLine("显示窗口");
            base.Show();
            Console.WriteLine("显示窗口完成");
        }

        public override void Hide()
        {
            Console.WriteLine("先隐藏窗口子控件 再隐藏窗口");
            base.Hide();
            Console.WriteLine("隐藏窗口");
            Console.WriteLine("隐藏窗口完成");
        }
    }

    public class Panel : MultiWidget
    {
        public override void Show()
        {
            Console.WriteLine("先显示面板 再显示面板子控件");
            Console.WriteLine("显示面板");
            base.Show();
            Console.WriteLine("显示面板完成");
        }

        public override void Hide()
        {
            Console.WriteLine("先隐藏面板子控件 再隐藏面板");
            base.Hide();
            Console.WriteLine("隐藏面板");
            Console.WriteLine("隐藏面板完成");
        }
    }
    
    #endregion
}