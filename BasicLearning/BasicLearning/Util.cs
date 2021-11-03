using System;
using System.Reflection;

namespace BasicLearning
{
    public class Util
    {
        /// <summary>
        /// 反射实例化对象
        /// </summary>
        /// <param name="objTypeName"></param>
        /// <returns></returns>
        public static object ReflectionInstance(string objTypeName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly(); // 获取当前程序集 
            object obj = assembly.CreateInstance($"BasicLearning.{objTypeName}"/*类的完全限定名(即包括命名空间)*/);
            return obj;
        }
    }
}