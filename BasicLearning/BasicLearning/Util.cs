using System;
using System.Globalization;
using System.Reflection;

namespace BasicLearning
{
    public static class Util
    {
        /// <summary>
        /// 反射实例化对象
        /// </summary>
        /// <param name="objTypeName"></param>
        /// <returns></returns>
        public static object ReflectionInstance(string objTypeName)
        {
            return ReflectionInstance(objTypeName, null);
        }
        
        /// <summary>
        /// 反射实例化对象
        /// </summary>
        /// <param name="objTypeName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static object ReflectionInstance(string objTypeName,params object[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly(); // 获取当前程序集 
            object obj = assembly.CreateInstance($"BasicLearning.{objTypeName}"/*类的完全限定名(即包括命名空间)*/, 
                false, BindingFlags.Instance | BindingFlags.Public, null, args, null, null);
            return obj;
        }
    }
}