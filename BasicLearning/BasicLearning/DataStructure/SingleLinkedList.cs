using System;

namespace BasicLearning
{
    internal partial class Program
    {
        public static SingleLinkedList MergeList(SingleLinkedList list1,SingleLinkedList list2)
        {
            // // 合并出一个新的list 修改了原来list的数据
            // SingleLinkedList newList = new SingleLinkedList();
            // HeroNode temp1 = list1.Head.Next;
            // while (temp1 != null)
            // {
            //     list1.Head.Next = temp1.Next;
            //     temp1.Next = null;
            //     newList.AddAndSortById(temp1);
            //     temp1 = list1.Head.Next;
            // }
            // HeroNode temp2 = list2.Head.Next;
            // while (temp2 != null)
            // {
            //     list2.Head.Next = temp2.Next;
            //     temp2.Next = null;
            //     newList.AddAndSortById(temp2);
            //     temp2 = list2.Head.Next;
            // }
            //
            // return newList;
            
            // 合并出一个新的list 不修改原来list的数据
            SingleLinkedList newList = new SingleLinkedList();
            HeroNode temp1 = list1.Head.Next;
            while (temp1 != null)
            {
                HeroNode node = new HeroNode(temp1.Id,temp1.Name,temp1.NickName);
                newList.AddAndSortById(node);
                temp1 = temp1.Next;
            }
            HeroNode temp2 = list2.Head.Next;
            while (temp2 != null)
            {
                HeroNode node = new HeroNode(temp2.Id,temp2.Name,temp2.NickName);
                newList.AddAndSortById(node);
                temp2 = temp2.Next;
            }

            return newList;
        }
    }
    
    // 单向链表
    public class SingleLinkedList
    {
        public HeroNode Head => head;

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
                if (temp.Next.Id == item.Id)
                {
                    ConsoleUtil.WriteLine($"已添加过具有相同id的元素，不可重复添加", ConsoleColor.Red);
                    return;
                }
                temp = temp.Next;
            }
            item.Next = temp.Next;
            temp.Next = item;
        }

        public void AddAndSortById(HeroNode item)
        {
            HeroNode temp = head;
            while (temp.Next != null)
            {
                if (temp.Next.Id == item.Id)
                {
                    ConsoleUtil.WriteLine($"已添加过具有相同id的元素，不可重复添加", ConsoleColor.Red);
                    return;
                }
                
                if (temp.Next.Id > item.Id)
                    break;
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
                
                temp = temp.Next;
            }

            if (flag)
            {
                HeroNode removeNode = temp.Next;
                temp.Next = removeNode.Next;
                removeNode.Next = null;
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
            HeroNode temp = head.Next;
            while (true)
            {
                if (temp == null)
                {
                    flag = false;
                    break;
                }

                if (temp.Id == newItem.Id)
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

        // 获得倒数第lastIndex个节点
        public HeroNode GetByLastIndex(int lastIndex)
        {
            int count = Count();
            if (count <= 0)
            {
                ConsoleUtil.WriteLine("链表为空", ConsoleColor.Red);
                return null;
            }
            else if (lastIndex > count)
            {
                ConsoleUtil.WriteLine("超出链表元素个数", ConsoleColor.Red);
                return null;
            }

            HeroNode temp = head.Next;
            for (int i = 0; i < count - lastIndex; i++)
            {
                temp = temp.Next;
            }

            return temp;
            
            // int index = count - lastIndex;
            // int curIndex = 0;
            // HeroNode temp = head.Next;
            // while (curIndex != index)
            // {
            //     curIndex++;
            //     temp = temp.Next;
            // }
            // return temp;
        }

        // 反转链表，反转后再使用AddAndSortById排序就不对了，不过无所谓，就是为了练习反转而已
        public void Reversal()
        {
            if (Count() <= 1)
                return;

            HeroNode tempHead = new HeroNode(0, "", "");
            HeroNode temp = head.Next;
            while (temp != null)
            {
                head.Next = temp.Next;
                temp.Next = tempHead.Next;
                tempHead.Next = temp;

                temp = head.Next;
            }
            head.Next = tempHead.Next;
        }

        public int Count()
        {
            int count = 0;
            HeroNode temp = head.Next;
            while (temp != null)
            {
                count++;
                temp = temp.Next;
            }

            return count;
        }

        public override string ToString()
        {
            string result = string.Empty;
            HeroNode temp = head.Next;
            while (true)
            {
                if (temp == null)
                    break;
                
                result += temp.ToString();
                if (temp.Next != null)
                    result += "\r\n";
                else
                    break;
                temp = temp.Next;
            }

            result += string.IsNullOrEmpty(result) ? "" : "\r\n";
            result += $"Count = {Count()}";

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

        public override string ToString()
        {
            return $"Id={Id}  名字={Name}  昵称={NickName}";
        }
    }
}