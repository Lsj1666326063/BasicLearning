namespace BasicLearning
{
    public class SingleLinkedList
    {
        private HeroNode head;

        public SingleLinkedList()
        {
            head = new HeroNode(-1, "", "");
        }

        public void Add(HeroNode item)
        {
            
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