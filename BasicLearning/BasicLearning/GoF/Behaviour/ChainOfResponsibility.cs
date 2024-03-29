﻿using System;

namespace BasicLearning
{
    /*--
     * 练习
        Sunny软件公司的OA系统需要提供一个假条审批模块：
        如果员工请假天数小于3天，主任可以审批该假条；
        如果员工请假天数大于等于3天，小于10天，经理可以审批；
        如果员工请假天数大于等于10天，小于30天，总经理可以审批；
        如果超过30天，总经理也不能审批，提示相应的拒绝信息。
        试用职责链模式设计该假条审批模块。
     */

    public abstract class LeaveHandler
    {
        private LeaveHandler nextHandler;

        public void SetNextHandler(LeaveHandler nextHandler)
        {
            this.nextHandler = nextHandler;
        }

        public abstract void Handler(short leaveNumOfDay);

        protected void RunNextHandler(short leaveNumOfDay)
        {
            if (nextHandler != null)
            {
                nextHandler.Handler(leaveNumOfDay);
                return;
            }

            Console.WriteLine($"无人审批 请假失败");
        }
    }

    public class Director : LeaveHandler
    {
        public override void Handler(short leaveNumOfDay)
        {
            if (leaveNumOfDay < 3)
            {
                Console.WriteLine($"主任审批 请假成功");
                return;
            }
            
            Console.WriteLine($"主任审批不了 向上级请示");
            RunNextHandler(leaveNumOfDay);
        }
    }

    public class Manager : LeaveHandler
    {
        public override void Handler(short leaveNumOfDay)
        {
            if (leaveNumOfDay >= 3 && leaveNumOfDay < 10)
            {
                Console.WriteLine($"经理审批 请假成功");
                return;
            }
            
            Console.WriteLine($"经理审批不了 向上级请示");
            RunNextHandler(leaveNumOfDay);
        }
    }

    public class GeneralManager : LeaveHandler
    {
        public override void Handler(short leaveNumOfDay)
        {
            if (leaveNumOfDay >= 10 && leaveNumOfDay < 30)
            {
                Console.WriteLine($"总经理审批 请假成功");
                return;
            }
            
            Console.WriteLine($"总经理审批不了 向上级请示");
            RunNextHandler(leaveNumOfDay);
        }
    }
}