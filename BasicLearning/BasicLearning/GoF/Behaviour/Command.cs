using System;
using System.Collections.Generic;

namespace BasicLearning
{
    #region 练习1
    
    // /*--
    //  * https://blog.csdn.net/lovelion/article/details/8806509
    //  * 练习
    //     修改简易计算器源代码，使之能够实现多次撤销(Undo)和恢复(Redo)。
    //  */
    //
    // public class Calculator
    // {
    //     public int Result { get; private set; }
    //     private Command command;
    //
    //     public void SetCommand(Command command)
    //     {
    //         this.command = command;
    //     }
    //
    //     public void Compute(int num)
    //     {
    //         Result = command.Execute(num);
    //     }
    //     
    //     public void Undo()
    //     {
    //         Result = command.Undo();
    //     }
    //     
    //     public void Redo()
    //     {
    //         Result = command.Redo();
    //     }
    // }
    // public abstract class Command
    // {
    //     public abstract int Execute(int num);
    //     public abstract int Undo();
    //     public abstract int Redo();
    // }
    // public class AddCommand:Command
    // {
    //     private AddHandler handler = new AddHandler();
    //     private Stack<int> record = new Stack<int>();
    //     private Stack<int> undoRecord = new Stack<int>();
    //     
    //     public override int Execute(int num)
    //     {
    //         undoRecord.Clear();
    //         record.Push(num);
    //         return handler.Add(num);
    //     }
    //
    //     public override int Undo()
    //     {
    //         if (record.Count <= 0)
    //         {
    //             ConsoleUtil.WriteLine($"当前已是第一步，无法再进行撤销", ConsoleColor.Yellow);
    //             return handler.Sum;
    //         }
    //
    //         int num = record.Pop();
    //         undoRecord.Push(num);
    //         return handler.Add(-num);
    //     }
    //
    //     public override int Redo()
    //     {
    //         if (undoRecord.Count <= 0)
    //         {
    //             ConsoleUtil.WriteLine($"当前已是最后一步，无法再进行恢复", ConsoleColor.Yellow);
    //             return handler.Sum;
    //         }
    //
    //         int num = undoRecord.Pop();
    //         record.Push(num);
    //         return handler.Add(num);
    //     }
    // }
    // public class AddHandler
    // {
    //     public int Sum => sum;
    //
    //     private int sum = 0;
    //     public int Add(int num)
    //     {
    //         sum += num;
    //         return sum;
    //     }
    // }
    
    #endregion
            
    #region 练习2

    /*--
     * 练习
        Sunny软件公司欲开发一个基于Windows平台的公告板系统。
        该系统提供了一个主菜单(Menu)，在主菜单中包含了一些菜单项(MenuItem)，
        可以通过Menu类的addMenuItem()方法增加菜单项。
        菜单项的主要方法是click()，每一个菜单项包含一个抽象命令类，
        具体命令类包括OpenCommand(打开命令)，CreateCommand(新建命令)，EditCommand(编辑命令)等，
        命令类具有一个execute()方法，用于调用公告板系统界面类(BoardScreen)的open()、create()、edit()等方法。
        试使用命令模式设计该系统，以便降低MenuItem类与BoardScreen类之间的耦合度。
     */

    public class MenuItem
    {
        private Command cmd;

        public void SetCommand(Command command)
        {
            cmd = command;
        }
        
        public void OnClick()
        {
            cmd?.Execute();
        }
    }

    public class Menu
    {
        public MenuItem CreateMenu;
        public MenuItem OpenMenu;
        public MenuItem EditMenu;
        public MenuItem MacroMenu;
        
        public Menu()
        {
            Command createCommand = new CreateCommand();
            CreateMenu = new MenuItem();
            CreateMenu.SetCommand(createCommand);
            
            Command openCommand = new OpenCommand();
            OpenMenu = new MenuItem();
            OpenMenu.SetCommand(openCommand);
            
            Command editCommand = new EditCommand();
            EditMenu = new MenuItem();
            EditMenu.SetCommand(editCommand);
            
            MacroCommand createOpenEditCommand = new CreateOpenEditCommand();
            MacroMenu = new MenuItem();
            MacroMenu.SetCommand(createOpenEditCommand);
        }
    }
    

    public abstract class Command
    {
        public abstract void Execute();
    }

    public class MacroCommand : Command
    {
        protected List<Command> cmds;

        public MacroCommand()
        {
            cmds = new List<Command>();
        }

        public override void Execute()
        {
            for (int i = 0; i < cmds.Count; i++)
            {
                cmds[i].Execute();
            }
        }

        public void AddCommand(Command command)
        {
            cmds.Add(command);
        }

        public void RemoveCommand(Command command)
        {
            cmds.Remove(command);
        }
    }

    public class CreateCommand : Command
    {
        public override void Execute()
        {
            // TODO：获取公告版实例，调用方法
            BoardScreen.Create();
        }
    }

    public class OpenCommand : Command
    {
        public override void Execute()
        {
            BoardScreen.Open();
        }
    }

    public class EditCommand : Command
    {
        public override void Execute()
        {
            BoardScreen.Edit();
        }
    }

    public class CreateOpenEditCommand : MacroCommand
    {
        public CreateOpenEditCommand()
        {
            AddCommand(new CreateCommand());
            AddCommand(new EditCommand());
            AddCommand(new OpenCommand());
        }
    }
    

    public class BoardScreen
    {
        public static void Create()
        {
            Console.WriteLine($"创建公告板");
        }
        
        public static void Open()
        {
            Console.WriteLine($"打开公告板");
        }

        public static void Edit()
        {
            Console.WriteLine($"编辑公告板");
        }
    }
            
    #endregion
}