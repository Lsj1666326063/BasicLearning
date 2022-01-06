namespace BasicLearning
{
    /*--
     * 练习
        Sunny软件公司欲开发一款飞机模拟系统，该系统主要模拟不同种类飞机的飞行特征与起飞特征，需要模拟的飞机种类及其特征如表24-1所示：
        表24-1 飞机种类及特征一览表
        飞机种类                起飞特征                         飞行特征
        直升机(Helicopter)      垂直起飞(VerticalTakeOff)        亚音速飞行(SubSonicFly)
        客机(AirPlane)          长距离起飞(LongDistanceTakeOff)  亚音速飞行(SubSonicFly)
        歼击机(Fighter)         长距离起飞(LongDistanceTakeOff)   超音速飞行(SuperSonicFly)
        鹞式战斗机(Harrier)      垂直起飞(VerticalTakeOff)        超音速飞行(SuperSonicFly)
        
        为将来能够模拟更多种类的飞机，试采用策略模式设计该飞机模拟系统。
     */

    public abstract class AbPlane
    {
        public string Name { get; protected set; }

        protected ITakeOffStrategy takeOffStrategy;
        protected IFlyStrategy flyStrategy;

        public AbPlane(string name)
        {
            Name = name;
        }

        public string TakeOff()
        {
            return takeOffStrategy.TakeOff();
        }

        public string Fly()
        {
            return flyStrategy.Fly();
        }
    }

    public class Helicopter : AbPlane
    {
        public Helicopter(string name) : base(name)
        {
            takeOffStrategy = new VerticalTakeOff();
            flyStrategy = new SubSonicFly();
        }
    }

    public class AirPlane : AbPlane
    {
        public AirPlane(string name) : base(name)
        {
            takeOffStrategy = new LongDistanceTakeOff();
            flyStrategy = new SubSonicFly();
        }
    }

    public class Fighter : AbPlane
    {
        public Fighter(string name) : base(name)
        {
            takeOffStrategy = new LongDistanceTakeOff();
            flyStrategy = new SuperSonicFly();
        }
    }

    public class Harrier : AbPlane
    {
        public Harrier(string name) : base(name)
        {
            takeOffStrategy = new VerticalTakeOff();
            flyStrategy = new SuperSonicFly();
        }
    }
    
    
    public interface ITakeOffStrategy
    {
        string TakeOff();
    }

    public class VerticalTakeOff : ITakeOffStrategy
    {
        public string TakeOff()
        {
            return "垂直起飞";
        }
    }

    public class LongDistanceTakeOff : ITakeOffStrategy
    {
        public string TakeOff()
        {
            return "长距离起飞";
        }
    }
    

    public interface IFlyStrategy
    {
        string Fly();
    }

    public class SubSonicFly : IFlyStrategy
    {
        public string Fly()
        {
            return "亚音速飞行";
        }
    }

    public class SuperSonicFly : IFlyStrategy
    {
        public string Fly()
        {
            return "超音速飞行";
        }
    }
}