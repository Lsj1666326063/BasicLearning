using System;
using System.Collections.Generic;

namespace BasicLearning
{
    /*--
     * 练习
        Sunny软件公司欲为某高校开发一套奖励审批系统，该系统可以实现教师奖励和学生奖励的审批(Award Check)，
        如果教师发表论文数超过10篇或者学生论文超过2篇可以评选科研奖，
        如果教师教学反馈分大于等于90分或者学生平均成绩大于等于90分可以评选成绩优秀奖。
        试使用访问者模式设计该系统，以判断候选人集合中的教师或学生是否符合某种获奖要求。
     */
    
    /*--
     * luohaowang320:
     *     你好，看了你的文章让我很清楚这个模式，但是同时也有一个疑惑，
     *     为何在 数据集合中 不直接调用 mVistor.visit(mElement),而要使用mElement.accept(mVIstor) 来分派？？
     *     直接调用 还可以去掉双向依赖，为何不这样处理？
     * LoveLion回复:
     *     (1) 因为在accept()方法中可能还需要调用具体元素类的其他业务方法，而不仅仅是visit()方法。
     *     (2) 如果具体元素是容器对象，在容器的accept()中可以递归调用成员的accept()，而不需要逐一调用每一个元素的accept()
     */

    public abstract class AbCandidate
    {
        public string Name { get; private set; }
        public int ThesisCount { get; private set; }

        public AbCandidate(string name, int thesisCount)
        {
            Name = name;
            ThesisCount = thesisCount;
        }

        public abstract void AcceptAwardCheck(IAwardExaminer examiner);
    }

    public class TeacharCandidate : AbCandidate
    {
        public int TeachingScore { get; private set; }

        public TeacharCandidate(string name, int thesisCount, int teachingScore) : base(name, thesisCount)
        {
            TeachingScore = teachingScore;
        }

        public override void AcceptAwardCheck(IAwardExaminer examiner)
        {
            examiner.AwardCheck(this);
        }
    }

    public class StudentCandidate : AbCandidate
    {
        public int LearningScore { get; private set; }

        public StudentCandidate(string name, int thesisCount, int learningScore) : base(name, thesisCount)
        {
            LearningScore = learningScore;
        }

        public override void AcceptAwardCheck(IAwardExaminer examiner)
        {
            examiner.AwardCheck(this);
        }
    }

    public class CandidateCenter
    {
        private List<AbCandidate> candidates;

        public CandidateCenter(List<AbCandidate> candidates)
        {
            this.candidates = candidates;
        }

        public void StartCheck(IAwardExaminer examiner)
        {
            for (int i = 0; i < candidates.Count; i++)
            {
                candidates[i].AcceptAwardCheck(examiner);
            }
        }
    }

    public interface IAwardExaminer
    {
        void AwardCheck(TeacharCandidate candidate);
        void AwardCheck(StudentCandidate candidate);
    }

    public class ResearchAwardExaminer : IAwardExaminer
    {
        public void AwardCheck(TeacharCandidate candidate)
        {
            if (candidate.ThesisCount > 10)
                ConsoleUtil.WriteLine($"教师{candidate.Name} 获得科研奖", ConsoleColor.Green);
            else
                ConsoleUtil.WriteLine($"教师{candidate.Name} 未获得科研奖", ConsoleColor.Red);
        }

        public void AwardCheck(StudentCandidate candidate)
        {
            if (candidate.ThesisCount > 2)
                ConsoleUtil.WriteLine($"学生{candidate.Name} 获得科研奖", ConsoleColor.Green);
            else
                ConsoleUtil.WriteLine($"学生{candidate.Name} 未获得科研奖", ConsoleColor.Red);
        }
    }

    public class ScoreIllustriousnessAwardExaminer : IAwardExaminer
    {
        public void AwardCheck(TeacharCandidate candidate)
        {
            if (candidate.TeachingScore >= 90)
                ConsoleUtil.WriteLine($"教师{candidate.Name} 获得成绩优秀奖", ConsoleColor.Green);
            else
                ConsoleUtil.WriteLine($"教师{candidate.Name} 未获得成绩优秀奖", ConsoleColor.Red);
        }

        public void AwardCheck(StudentCandidate candidate)
        {
            if (candidate.LearningScore >= 90)
                ConsoleUtil.WriteLine($"学生{candidate.Name} 获得成绩优秀奖", ConsoleColor.Green);
            else
                ConsoleUtil.WriteLine($"学生{candidate.Name} 未获得成绩优秀奖", ConsoleColor.Red);
        }
    }
}