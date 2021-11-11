namespace BasicLearning
{
    public class SingleLinkedList
    {
        private HeroNode head;

        public SingleLinkedList()
        {
            head = new HeroNode(0, "", "");
        }

        public void Add(HeroNode item)
        {
            HeroNode temp = head;
            while (true)
            {
                if (temp.Next == null)
                    break;
                if(temp.Next.Id)
            }
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