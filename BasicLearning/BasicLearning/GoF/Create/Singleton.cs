﻿namespace BasicLearning
{
    
    // 饿汉式单例类
    /*
     * 饿汉式单例类在类被加载时就将自己实例化，它的优点在于无须考虑多线程访问问题，可以确保实例的唯一性；
     * 从调用速度和反应时间角度来讲，由于单例对象一开始就得以创建，因此要优于懒汉式单例。但是无论系统在运行时是否需要使用该单例对象，
     * 由于在类加载时该对象就需要创建，因此从资源利用效率角度来讲，饿汉式单例不及懒汉式单例，而且在系统加载时由于需要创建饿汉式单例对象，加载时间可能会比较长。
     */
    public class EagerSingleton
    {
        private static EagerSingleton instance = new EagerSingleton();

        public static EagerSingleton Instance => instance;

        private EagerSingleton(){}
    }


    // 懒汉式单例类
    /*
     * 懒汉式单例类在第一次使用时创建，无须一直占用系统资源，实现了延迟加载，但是必须处理好多个线程同时访问的问题，
     * 特别是当单例类作为资源控制器，在实例化时必然涉及资源初始化，而资源初始化很有可能耗费大量时间，
     * 这意味着出现多线程同时首次引用此类的机率变得较大，需要通过双重检查锁定等机制进行控制，这将导致系统性能受到一定影响。
     */
    public class LazySingleton
    {
        private static LazySingleton instance;
        private static object lockObject = new object();

        public static LazySingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if(instance == null)
                            instance = new LazySingleton();   
                    }
                }

                return instance;
            }
        }
    }
    
    
    // 一种更好的单例实现方法 Initialization Demand Holder (IoDH)
    /*
     * 在IoDH中，我们在单例类中增加一个静态(static)内部类，在该内部类中创建单例对象，再将该单例对象通过getInstance()方法返回给外部使用
     * https://blog.csdn.net/lovelion/article/details/7420888
     */
    
    // 静态构造函数实现单例模式
    /*
     * https://blog.csdn.net/Yao_2333/article/details/81203878
     */
    
    // 多例模式
}