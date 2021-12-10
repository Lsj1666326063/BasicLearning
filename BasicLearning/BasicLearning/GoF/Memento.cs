using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BasicLearning
{
    /*--
     * 练习
        Sunny软件公司正在开发一款RPG网游，为了给玩家提供更多方便，在游戏过程中可以设置一个恢复点，
        用于保存当前的游戏场景，如果在后续游戏过程中玩家角色“不幸牺牲”，可以返回到先前保存的场景，
        从所设恢复点开始重新游戏。试使用备忘录模式设计该功能。
     */

    /*
     * https://blog.csdn.net/lovelion/article/details/7526756
     * 扩展
        本实例只能实现最简单的Undo和Redo操作，并未考虑对象状态在操作过程中出现分支的情况。
        如果在撤销到某个历史状态之后，用户再修改对象状态，此后执行Undo操作时可能会发生对象状态错误，大家可以思考其产生原因。TODO:【注：可将对象状态的改变绘制成一张树状图进行分析。】 实现分支备忘录
        在实际开发中，可以使用链表或者堆栈来处理有分支的对象状态改变，大家可通过链表或者堆栈对上述实例进行改进。
     */

    public class GameInfo
    {
        public string Scene { get; set; }
        public GamePlayer Player { get; set; }

        public GameMemento Save()
        {
            GameMemento memento = new GameMemento();
            memento.Scene = Scene;
            memento.Player = Player.DeepCopy();
            return memento;
        }

        public void Restore(GameMemento memento)
        {
            Scene = memento.Scene;
            Player = memento.Player.DeepCopy();
        }
    }

    [Serializable]
    public class GamePlayer
    {
        public string Name { get; set; }
        public int Lv { get; set; }

        public GamePlayer DeepCopy()
        {
            // 使用流进行深拷贝 相关类必须添加属性标记 [Serializable]
            using (Stream stream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin);
                return (GamePlayer) formatter.Deserialize(stream);
            }
        }
    }

    public class GameMemento
    {
        public string Scene { get; set; }
        public GamePlayer Player { get; set; }
    }

    public class GameMementoCaretaker
    {
        public GameMemento Memento { get; set; }
    }
}