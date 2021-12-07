using System;

namespace BasicLearning
{
    // 双向链表，由单向链表简单改进，
    public class DoubleLinkedList
    { 
        private HeroNode2 head = new HeroNode2(0, "", "");

        public bool IsEmpty()
        {
            return head.Next == null;
        }

        public void Add(HeroNode2 item)
        {
            HeroNode2 temp = head;
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
            item.Pre = temp;
            temp.Next = item;
        }

        public void AddAndSortById(HeroNode2 item)
        {
            HeroNode2 temp = head;
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
            item.Pre = temp;
            if(temp.Next != null)
                temp.Next.Pre = item;
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
            HeroNode2 temp = head.Next;
            while (true)
            {
                if (temp == null)
                {
                    flag = false;
                    break;
                }

                if (temp.Id == id)
                    break;
                
                temp = temp.Next;
            }

            if (flag)
            {
                temp.Pre.Next = temp.Next;
                if(temp.Next != null)
                    temp.Next.Pre = temp.Pre;
                temp.Next = null;
                temp.Pre = null;
            }
            else
            {
                ConsoleUtil.WriteLine("未找到要移除的元素", ConsoleColor.Red);
            }
        }

        public void Update(HeroNode2 newItem)
        {
            if (IsEmpty())
            {
                ConsoleUtil.WriteLine("链表为空", ConsoleColor.Red);
                return;
            }

            bool flag = true;
            HeroNode2 temp = head.Next;
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

        public HeroNode2 Get(int id)
        {
            HeroNode2 temp = head.Next;
            while (temp != null && temp.Id != id)
            {
                temp = temp.Next;
            }
            return temp;
        }

        public int Count()
        {
            int count = 0;
            HeroNode2 temp = head.Next;
            while (temp != null)
            {
                count++;
                temp = temp.Next;
            }

            return count;
        }
        
        public void ReversalLog()
        {
            if (IsEmpty())
                return;
            
            HeroNode2 temp = head.Next;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            
            while (temp.Pre != null)
            {
                Console.WriteLine(temp);
                temp = temp.Pre;
            }
        }

        public override string ToString()
        {
            string result = string.Empty;
            HeroNode2 temp = head.Next;
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

    public class HeroNode2
    {
        public int Id;
        public string Name;
        public string NickName;
        public HeroNode2 Next;
        public HeroNode2 Pre;

        public HeroNode2(int id, string name, string nickName)
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