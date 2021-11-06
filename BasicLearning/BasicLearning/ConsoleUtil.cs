using System;

namespace BasicLearning
{
    public static class ConsoleUtil
    {

        /// <summary>
        /// 输出带颜色的信息
        /// </summary>
        /// <param name="s"></param>
        /// <param name="foregroundColor">信息颜色</param>
        public static void Write(string s, ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.Write(s);
            Console.ResetColor();
        }

        /// <summary>
        /// 输出带颜色的信息
        /// </summary>
        /// <param name="s"></param>
        /// <param name="foregroundColor">信息颜色</param>
        /// <param name="backgroundColor">信息背景颜色</param>
        public static void Write(string s, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(s);
            Console.ResetColor();
        }

        /// <summary>
        /// 输出带颜色的信息 换行
        /// </summary>
        /// <param name="s"></param>
        /// <param name="foregroundColor">信息颜色</param>
        public static void WriteLine(string s, ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /// <summary>
        /// 输出带颜色的信息 换行
        /// </summary>
        /// <param name="s"></param>
        /// <param name="foregroundColor">信息颜色</param>
        /// <param name="backgroundColor">信息背景颜色</param>
        public static void WriteLine(string s, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(s);
            Console.ResetColor();
        }
    }
}