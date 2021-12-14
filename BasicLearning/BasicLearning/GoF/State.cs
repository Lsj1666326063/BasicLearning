using System;

namespace BasicLearning
{
    /*--
     * 练习
        Sunny软件公司欲开发一款纸牌游戏软件，
        在该游戏软件中用户角色具有入门级(Primary)、熟练级(Secondary)、高手级(Professional)和骨灰级(Final)四种等级，
        角色的等级与其积分相对应，游戏胜利将增加积分，失败则扣除积分。
        入门级具有最基本的游戏功能play() ，
        熟练级增加了游戏胜利积分加倍功能doubleScore()，
        高手级在熟练级基础上再增加换牌功能changeCards()，
        骨灰级在高手级基础上再增加偷看他人的牌功能peekCards()。
        试使用状态模式来设计该系统。
        
        https://www.cnblogs.com/studydp/p/9607641.html
        
        在不同状态下有不同实现的方法封装到状态类中
     */

    public interface IPokerPlayer : IPokerPlayerState
    {
        void UpdateScore(int score);
    }

    public class PokerPlayer : IPokerPlayer
    {
        public int Score { get; private set; }

        private IPokerPlayerState state;
        private IPokerPlayerState introductionState;
        private IPokerPlayerState proficiencyState;
        private IPokerPlayerState aceState;
        private IPokerPlayerState cremainsState;

        public PokerPlayer(int score)
        {
            introductionState = new PokerPlayerStateIntroduction();
            proficiencyState = new PokerPlayerStateProficiency();
            aceState = new PokerPlayerStateAce();
            cremainsState = new PokerPlayerStateCremains();
            
            Score = score;
            ChangeState();
        }

        public void UpdateScore(int score)
        {
            Score += score;
            Console.WriteLine($"更新积分 当前积分为：{Score}");

            ChangeState();
        }

        public void Play()
        {
            state.Play();
        }

        public int DoubleScore(int score)
        {
            return state.DoubleScore(score);
        }

        public void ChangeCards()
        {
            state.ChangeCards();
        }

        public void PeekCards()
        {
            state.PeekCards();
        }

        private void ChangeState()
        {
            if (Score < 5)
            {
                state = introductionState;
                Console.WriteLine($"等级变更为 入门");
            }
            else if (Score < 10)
            {
                state = proficiencyState;
                Console.WriteLine($"等级变更为 熟练");
            }
            else if (Score < 15)
            {
                state = aceState;
                Console.WriteLine($"等级变更为 高手");
            }
            else
            {
                state = cremainsState;
                Console.WriteLine($"等级变更为 骨灰");
            }
        }
    }


    public interface IPokerPlayerState
    {
        void Play();
        int DoubleScore(int score);
        void ChangeCards();
        void PeekCards();
    }

    public class PokerPlayerStateIntroduction : IPokerPlayerState
    {
        public void Play()
        {
            ConsoleUtil.WriteLine($"玩游戏", ConsoleColor.Green);
        }

        public int DoubleScore(int score)
        {
            ConsoleUtil.WriteLine($"当前等级不能进行积分加倍", ConsoleColor.Red);
            return score;
        }

        public void ChangeCards()
        {
            ConsoleUtil.WriteLine($"当前等级不能换牌", ConsoleColor.Red);
        }

        public void PeekCards()
        {
            ConsoleUtil.WriteLine($"当前等级不能偷看牌", ConsoleColor.Red);
        }
    }

    public class PokerPlayerStateProficiency : IPokerPlayerState
    {
        public void Play()
        {
            ConsoleUtil.WriteLine($"玩游戏", ConsoleColor.Green);
        }

        public int DoubleScore(int score)
        {
            if (score > 0)
            {
                ConsoleUtil.WriteLine($"积分加倍 增加时积分加倍", ConsoleColor.Green);
                return score * 2;
            }
            else
            {
                ConsoleUtil.WriteLine($"积分加倍 减少时积分不变", ConsoleColor.Green);
                return score;
            }
        }

        public void ChangeCards()
        {
            ConsoleUtil.WriteLine($"当前等级不能换牌", ConsoleColor.Red);
        }

        public void PeekCards()
        {
            ConsoleUtil.WriteLine($"当前等级不能偷看牌", ConsoleColor.Red);
        }
    }

    public class PokerPlayerStateAce : IPokerPlayerState
    {
        public void Play()
        {
            ConsoleUtil.WriteLine($"玩游戏", ConsoleColor.Green);
        }

        public int DoubleScore(int score)
        {
            if (score > 0)
            {
                ConsoleUtil.WriteLine($"积分加倍 增加时积分加倍", ConsoleColor.Green);
                return score * 2;
            }
            else
            {
                ConsoleUtil.WriteLine($"积分加倍 减少时积分不变", ConsoleColor.Green);
                return score;
            }
        }

        public void ChangeCards()
        {
            ConsoleUtil.WriteLine($"换牌", ConsoleColor.Green);
        }

        public void PeekCards()
        {
            ConsoleUtil.WriteLine($"当前等级不能偷看牌", ConsoleColor.Red);
        }
    }

    public class PokerPlayerStateCremains : IPokerPlayerState
    {
        public void Play()
        {
            ConsoleUtil.WriteLine($"玩游戏", ConsoleColor.Green);
        }

        public int DoubleScore(int score)
        {
            if (score > 0)
            {
                ConsoleUtil.WriteLine($"积分加倍 增加时积分加倍", ConsoleColor.Green);
                return score * 2;
            }
            else
            {
                ConsoleUtil.WriteLine($"积分加倍 减少时积分不变", ConsoleColor.Green);
                return score;
            }
        }

        public void ChangeCards()
        {
            ConsoleUtil.WriteLine($"换牌", ConsoleColor.Green);
        }

        public void PeekCards()
        {
            ConsoleUtil.WriteLine($"偷看牌", ConsoleColor.Green);
        }
    }
}