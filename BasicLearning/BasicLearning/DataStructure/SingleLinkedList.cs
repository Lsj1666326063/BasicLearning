using System;

namespace BasicLearning
{
    public class SingleLinkedList
    {
        private HeroNode head = new HeroNode(0, "", "");

        public bool IsEmpty()
        {
            return head.Next == null;
        }

        public void Add(HeroNode item)
        {
            HeroNode temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            item.Next = temp.Next;
            temp.Next = item;
        }

        public void Remove(int id)
        {
            if (IsEmpty())
            {
                ConsoleUtil.WriteLine("链表为空", ConsoleColor.Red);
                return;
            }

            bool flag = true;
            HeroNode temp = head;
            while (true)
            {
                if (temp.Next == null)
                {
                    flag = false;
                    break;
                }

                if (temp.Next.Id == id)
                    break;
            }

            if (flag)
            {
                temp.Next = temp.Next.Next;
            }
            else
            {
                ConsoleUtil.WriteLine("未找到要移除的元素", ConsoleColor.Red);
            }
        }

        public void Update(HeroNode newItem)
        {
            if (IsEmpty())
            {
                ConsoleUtil.WriteLine("链表为空", ConsoleColor.Red);
                return;
            }

            bool flag = true;
            HeroNode temp = head;
            while (true)
            {
                if (temp.Next == null)
                {
                    flag = false;
                    break;
                }

                if (temp.Next.Id == newItem.Id)
                    break;
                
                temp = temp.Next;
            }

            if (flag)
            {
                temp.Name = newItem.Name;
                temp.NickName = newItem.NickName;
            }
            else
            {
                ConsoleUtil.WriteLine("未找到要修改的元素", ConsoleColor.Red);
            }
        }

        public HeroNode Get(int id)
        {
            HeroNode temp = head.Next;
            while (temp != null && temp.Id != id)
            {
                temp = temp.Next;
            }
            return temp;
        }

        public override string ToString()
        {
            if (IsEmpty())
                return string.Empty;
            
            string result = string.Empty;
            HeroNode temp = head.Next;
            while (true)
            {
                result += $"Id={temp.Id}  名字={temp.Name}  昵称={temp.NickName}";
                if (temp.Next != null)
                    result += "\r\n";
                else
                    break;
                temp = temp.Next;
            }

            return result;
        }
    }

    public class HeroNode
    {
        public int Id;
        public string Name;
        public string NickName;
        public HeroNode Next;

        public HeroNode(int id, string name, string nickName)
        {
            Id = id;
            Name = name;
            NickName = nickName;
        }
    }
}