using System;
using System.Collections.Generic;

namespace BasicLearning
{
    /*--
     * 练习
        Sunny软件公司欲开发一款实时在线股票软件，该软件需提供如下功能：
        当股票购买者所购买的某支股票价格变化幅度达到5%时，系统将自动发送通知（包括新价格）给购买该股票的所有股民。
        试使用观察者模式设计并实现该系统。
     */

    // 观察目标
    public class Stock
    {
        public string Name { get; private set; }
        public float Price { get; private set; }

        private List<AbInvestor> investors;
        
        public Stock(string name,float initPrice)
        {
            Name = name;
            Price = initPrice;
            investors = new List<AbInvestor>();
        }

        public void PriceFloating(float floatingNum)
        {
            Console.WriteLine($"{Name}股票 {(floatingNum > 0?"涨价":"降价")} {floatingNum}");
            
            bool isNotify = Math.Abs(floatingNum) >= (Price * 0.05f);
            
            Price += floatingNum;

            if (isNotify)
            {
                Console.WriteLine($"{Name}股票浮动超过%5，通知股民");
                NotifyInvestor(floatingNum);
            }
        }

        public void Watch(AbInvestor investor)
        {
            Console.WriteLine($"{investor.Name}关注 {Name}股票");
            investors.Add(investor);
        }

        public void UnWatch(AbInvestor investor)
        {
            Console.WriteLine($"{investor.Name}取消关注 {Name}股票");
            investors.Remove(investor);
        }

        private void NotifyInvestor(float floatingNum)
        {
            for (int i = 0; i < investors.Count; i++)
            {
                investors[i].ReceiverNotify(this, floatingNum);
            }
        }
    }
    
    // 抽象观察者
    public abstract class AbInvestor
    {
        public string Name { get; private set; }

        public AbInvestor(string name)
        {
            Name = name;
        }
        
        public abstract void ReceiverNotify(Stock stock,float floatingNum);
    }

    // 具体观察者
    public class NormalInvestor : AbInvestor
    {
        public NormalInvestor(string name) : base(name)
        {
        }
        
        public override void ReceiverNotify(Stock stock,float floatingNum)
        {
            Console.WriteLine($"{Name}收到 {stock.Name}的{(floatingNum > 0?"涨价":"降价")}通知");
        }
    }
}