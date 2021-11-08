using System;
using System.IO;
using System.Text.RegularExpressions;
using LitJson;

namespace BasicLearning
{
    internal class Program
    {
        private static Config config;

        public static void Main(string[] args)
        {
            config = new Config();

            Test1();


            // DataStructure_MyArrayListTest();

            // DataStructure_SparseArrayTest();

            // DataStructure_CircleArrayQueueTest();


            // GoF_Create_SimpleFactoryTest();

            // GoF_Create_FunFactoryTest();

            // GoF_Create_AbstructFactoryTest();

            // GoF_Create_ProtoTypeTest();

            // GoF_Create_BuilderTest();

            // GoF_Struct_AdapterTest();

            Console.ReadLine();
        }

        private static void Test1()
        {
            // int[,] a = new int [4, 5]
            // {
            //     {1, 2, 3, 4, 5},
            //     {1, 2, 3, 4, 5},
            //     {1, 2, 3, 4, 5},
            //     {1, 2, 3, 4, 5}
            // };
            // Console.WriteLine($"a.GetLength(0) = {a.GetLength(0)} , a.GetLength(1) = {a.GetLength(1)}");
            

            // Console.WriteLine($"{Directory.GetCurrentDirectory()}  ");
            

            // //-?(\d+)\.?(\d+)?
            // // Regex regex = new Regex(@"^(\w)+(\.\w)*@(\w)+((\.\w+)+)$");
            // string regexStr = @"(-?(\d+)(\.\d+)?)";
            // string regexStr1 = @"-?(0|[1-9]\d*)(\.\d+)?";
            // string test1 = "gjhgj11-2-121sdf-1231.1231sdfs0.11 0.00df";
            // string test2 = "";
            // string test3 = "sdfsdf";
            // string test4 = "-sdfsdf";
            // string test5 = "sd-fsdf";
            // string test6 = ".sdfsdf";
            // string test7 = "sd.fsdf";
            // string test8 = "s-d.fsdf";
            // string test9 = "s-d.5fsdf";
            // string test10 = "s-d5.fsdf";
            // string test11 = "s-5d.fsdf";
            // string test12 = "s5-d.fsdf";
            // MatchCollection mc = Regex.Matches(test10, regexStr);
            // Console.WriteLine($"{mc[0].Value}");


            // double val = 34.5;
            // Console.WriteLine(val.ToString("0")); // 四舍五入
        }

        private static void DataStructure_MyArrayListTest()
        {
            MyArrayList<int> mArrList = new MyArrayList<int>();
        }

        private static void DataStructure_SparseArrayTest()
        {
            // SparseArray.Test1();
            SparseArray.Test2();

            // TODO: 练习中需要用到流进行数组文件的创建/读取/写入，对流不是太了解，所以等数据结构学完后学习一下流(IO)，再来完善该练习
        }

        private static void DataStructure_CircleArrayQueueTest()
        {
            Console.WriteLine($"环形数组队列测试");
            Console.WriteLine($"KeyCode：A  入队(Enqueue)");
            Console.WriteLine($"KeyCode：S  出队(Dequeue)");
            Console.WriteLine($"KeyCode：D  查看队头(Peek)");
            Console.WriteLine($"KeyCode：F  查看容量(Capacity)");
            Console.WriteLine($"KeyCode：G  修改容量(SetCapacity)");
            Console.WriteLine($"KeyCode：W  查看队列信息(ToString)");
            Console.WriteLine($"KeyCode：Q  结束测试 End While\n");

            CircleArrayQueue circleArrayQueue = new CircleArrayQueue(/*3*/);
            bool test = true;
            while (test)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                        Console.WriteLine();
                        ConsoleUtil.Write($"输入一个正整数 ", ConsoleColor.Green);
                        string valueStr = Console.ReadLine();
                        int value = int.Parse(valueStr);
                        circleArrayQueue.Enqueue(value);
                        break;
                    case ConsoleKey.S:
                        Console.WriteLine();
                        try
                        {
                            ConsoleUtil.WriteLine($"出队 {circleArrayQueue.Dequeue()}", ConsoleColor.Green);
                        }
                        catch (Exception e)
                        {
                            ConsoleUtil.WriteLine(e.Message, ConsoleColor.Red);
                        }

                        break;
                    case ConsoleKey.D:
                        Console.WriteLine();
                        try
                        {
                            ConsoleUtil.WriteLine($"查看队头 {circleArrayQueue.Peek()}", ConsoleColor.Green);
                        }
                        catch (Exception e)
                        {
                            ConsoleUtil.WriteLine(e.Message, ConsoleColor.Red);
                        }

                        break;
                    case ConsoleKey.F:
                        Console.WriteLine();
                        ConsoleUtil.WriteLine($"查看容量 {circleArrayQueue.Capacity()}", ConsoleColor.Green);
                        break;
                    case ConsoleKey.G:
                        Console.WriteLine();
                        ConsoleUtil.Write($"输入新的容量 ", ConsoleColor.Green);
                        string capacityStr = Console.ReadLine();
                        int capacity = int.Parse(capacityStr);
                        circleArrayQueue.SetCapacity(capacity);
                        break;
                    case ConsoleKey.W:
                        Console.WriteLine();
                        ConsoleUtil.WriteLine(circleArrayQueue.ToString(), ConsoleColor.Green);
                        break;
                    case ConsoleKey.Q:
                        Console.WriteLine();
                        Console.WriteLine($"结束测试");
                        test = false;
                        break;
                }
            }
        }

        private static void GoF_Create_SimpleFactoryTest()
        {
            string type = config.GetSimpleFactory();
            Product product = SimpleFactory.CreateProduct(type);
            product.AbstractFun();
        }

        private static void GoF_Create_FunFactoryTest()
        {
            string objTypeName = config.GetFunFactory();
            PictureReaderFactory pRFactory = (PictureReaderFactory) Util.ReflectionInstance(objTypeName);
            // IPictureReader pictureReader = pRFactory.Create(); // 不使用参数
            IPictureReader pictureReader = pRFactory.Create("AAA"); // 使用参数
            pictureReader.PictureReader();
        }

        private static void GoF_Create_AbstructFactoryTest()
        {
            string objTypeName = config.GetAbstructFactory();
            SystemFactory sFactory = (SystemFactory) Util.ReflectionInstance(objTypeName);
            IOperationController oc = sFactory.CreateOperationController();
            oc.Move();
            oc.Attack();
            IInterfaceController ic = sFactory.CreateIInterfaceController();
            ic.Show();
            ic.Close();
        }

        private static void GoF_Create_ProtoTypeTest()
        {
            Prototype prototype = new Prototype();
            prototype.protoTypeTestObj = new PrototypeTestObj();
            Console.WriteLine($"prototype.Num:{prototype.Num}  prototype.protoTypeTestObj.Num:{prototype.protoTypeTestObj.Num}");

            // Prototype prototype1 = (Prototype)prototype.Clone(); // 浅拷贝
            Prototype prototype1 = (Prototype) prototype.DeepClone(); // 深拷贝
            prototype1.Num = 1;
            prototype1.protoTypeTestObj.Num = 2;
            Console.WriteLine($"prototype.Num:{prototype.Num}  prototype.protoTypeTestObj.Num:{prototype.protoTypeTestObj.Num}");
            Console.WriteLine($"prototype1.Num:{prototype1.Num}  prototype1.protoTypeTestObj.Num:{prototype1.protoTypeTestObj.Num}");
        }

        private static void GoF_Create_BuilderTest()
        {
            string objTypeName = config.GetBuilder();
            VideoInterfaceBuilder builder = (VideoInterfaceBuilder) Util.ReflectionInstance(objTypeName);
            VideoInterface videoInterface = builder.Builder();
            Console.WriteLine(videoInterface);
        }

        private static void GoF_Struct_AdapterTest()
        {
            string objTypeName = config.GetAdapter();
            IDES des = (IDES) Util.ReflectionInstance(objTypeName);
            DataBaseOperation dbOpt = new DataBaseOperation(des);
            string userInfo = "用户数据";
            dbOpt.SaveUserInfo(userInfo);
            dbOpt.GetUserInfo();
        }
    }
}