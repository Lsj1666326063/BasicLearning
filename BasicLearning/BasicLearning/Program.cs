using System;
using System.IO;
using System.Text.RegularExpressions;
using LitJson;

namespace BasicLearning
{
    public enum Test
    {
        test = 0
    }
    internal partial class Program
    {
        private static Config config;

        public static void Main(string[] args)
        {
            config = new Config();

            // Test1();


            // DataStructure_MyArrayListTest();

            // DataStructure_SparseArrayTest();

            // DataStructure_CircleArrayQueueTest();
            
            // DataStructure_SingleLinkedListTest();

            // DataStructure_DoubleLinkedListTest();


            // GoF_Create_SimpleFactoryTest();

            // GoF_Create_FunFactoryTest();

            // GoF_Create_AbstructFactoryTest();

            // GoF_Create_ProtoTypeTest();

            // GoF_Create_BuilderTest();

            // GoF_Struct_AdapterTest();

            // GoF_Struct_BridgeTest();

            // GoF_Struct_Composite();

            // GoF_Struct_Decorator();

            // GoF_Struct_Facade();

            // GoF_Struct_Flyweight();

            // GoF_Struct_Proxy();

            // Gof_Behavior_ChainOfResponsibility();

            // Gof_Behavior_Command();

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

            // string test1 = "..1234.3.123...1.23...";
            // string test2 = "...";
            // Match match = Regex.Match(test1, @"\d+\.?\d+");
            // MatchCollection mc = Regex.Matches(test1, @"\d+\.?\d+");
            // Console.WriteLine($"{match.Value}");

            
            // double val = 34.5;
            // Console.WriteLine(val.ToString("0")); // 四舍五入
            
            
            // Console.WriteLine($"{-1%6}");
            
            
            // int a = -1;
            // Console.WriteLine($"{((Test)a).ToString()}");
            
            
            // Console.ForegroundColor = ConsoleColor.Red;
            // Console.WriteLine("111");
            // Console.WriteLine("222");
            // Console.ResetColor();
            // Console.WriteLine("333");
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

        private static void DataStructure_SingleLinkedListTest()
        {
            HeroNode node1 = new HeroNode(1,"a","A");
            HeroNode node2 = new HeroNode(2,"b","B");
            HeroNode node3 = new HeroNode(3,"c","C");
            HeroNode node4 = new HeroNode(4,"d","D");
            
            SingleLinkedList singleLinkedList = new SingleLinkedList();
            singleLinkedList.Remove(5);
            
            // singleLinkedList.Add(node1);
            // singleLinkedList.Add(node3);
            // singleLinkedList.Add(node2);
            // singleLinkedList.Add(node4);
            singleLinkedList.AddAndSortById(node1);
            singleLinkedList.AddAndSortById(node2);
            singleLinkedList.AddAndSortById(node3);
            singleLinkedList.AddAndSortById(node4);
            Console.WriteLine(singleLinkedList);
            Console.WriteLine();
            
            singleLinkedList.Remove(2);
            Console.WriteLine(singleLinkedList);
            Console.WriteLine();
            
            // singleLinkedList.Add(node2);
            singleLinkedList.AddAndSortById(node2);
            Console.WriteLine(singleLinkedList);
            Console.WriteLine();
            
            HeroNode newNode2 = new HeroNode(2,"B","b");
            singleLinkedList.Update(newNode2);
            Console.WriteLine(singleLinkedList);
            Console.WriteLine();
            
            HeroNode n3 = singleLinkedList.Get(3);
            Console.WriteLine(n3);
            Console.WriteLine();
            
            singleLinkedList.Remove(5);
            
            // singleLinkedList.Add(node2);
            singleLinkedList.AddAndSortById(node2);
            Console.WriteLine(singleLinkedList);
            Console.WriteLine();

            HeroNode last2Node = singleLinkedList.GetByLastIndex(2);
            Console.WriteLine($"倒数第2个元素" + last2Node);
            HeroNode last3Node = singleLinkedList.GetByLastIndex(3);
            Console.WriteLine($"倒数第3个元素" + last3Node);
            HeroNode last4Node = singleLinkedList.GetByLastIndex(4);
            Console.WriteLine($"倒数第4个元素" + last4Node);
            HeroNode last5Node = singleLinkedList.GetByLastIndex(5);
            Console.WriteLine($"倒数第5个元素" + last5Node);
            Console.WriteLine();
            
            singleLinkedList.Reversal();
            Console.WriteLine($"反转后的链表元素\r\n" + singleLinkedList);
            Console.WriteLine();
            
            
            SingleLinkedList mergeSingleLinkedList1 = new SingleLinkedList();
            HeroNode mergeNode1 = new HeroNode(1,"a","A");
            HeroNode mergeNode2 = new HeroNode(2,"b","B");
            HeroNode mergeNode3 = new HeroNode(3,"c","C");
            mergeSingleLinkedList1.Add(mergeNode2);
            mergeSingleLinkedList1.Add(mergeNode1);
            mergeSingleLinkedList1.Add(mergeNode3);
            SingleLinkedList mergeSingleLinkedList2 = new SingleLinkedList();
            HeroNode mergeNode4 = new HeroNode(4,"d","D");
            HeroNode mergeNode6 = new HeroNode(6,"f","F");
            HeroNode mergeNode5 = new HeroNode(5,"e","E");
            mergeSingleLinkedList2.Add(mergeNode4);
            mergeSingleLinkedList2.Add(mergeNode6);
            mergeSingleLinkedList2.Add(mergeNode5);
            SingleLinkedList mergeList = MergeList(mergeSingleLinkedList1, mergeSingleLinkedList2);
            ConsoleUtil.WriteLine($"mergeSingleLinkedList1",ConsoleColor.Green);
            Console.WriteLine(mergeSingleLinkedList1);
            ConsoleUtil.WriteLine($"mergeSingleLinkedList2",ConsoleColor.Green);
            Console.WriteLine(mergeSingleLinkedList2);
            ConsoleUtil.WriteLine($"mergeList",ConsoleColor.Green);
            Console.WriteLine(mergeList);
        }

        private static void DataStructure_DoubleLinkedListTest()
        {
            HeroNode2 node1 = new HeroNode2(1,"a","A");
            HeroNode2 node2 = new HeroNode2(2,"b","B");
            HeroNode2 node3 = new HeroNode2(3,"c","C");
            HeroNode2 node4 = new HeroNode2(4,"d","D");
            
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList();
            doubleLinkedList.Remove(5);
            
            // doubleLinkedList.Add(node1);
            // doubleLinkedList.Add(node3);
            // doubleLinkedList.Add(node2);
            // doubleLinkedList.Add(node4);
            doubleLinkedList.AddAndSortById(node1);
            doubleLinkedList.AddAndSortById(node2);
            doubleLinkedList.AddAndSortById(node3);
            doubleLinkedList.AddAndSortById(node4);
            Console.WriteLine(doubleLinkedList);
            Console.WriteLine();
            
            doubleLinkedList.Remove(2);
            Console.WriteLine(doubleLinkedList);
            Console.WriteLine();
            
            // doubleLinkedList.Add(node2);
            doubleLinkedList.AddAndSortById(node2);
            Console.WriteLine(doubleLinkedList);
            Console.WriteLine();
            
            HeroNode2 newNode2 = new HeroNode2(2,"B","b");
            doubleLinkedList.Update(newNode2);
            Console.WriteLine(doubleLinkedList);
            Console.WriteLine();
            
            HeroNode2 n3 = doubleLinkedList.Get(3);
            Console.WriteLine(n3);
            Console.WriteLine($"Pre:{n3.Pre}");
            Console.WriteLine($"Next:{n3.Next}");
            Console.WriteLine();
            
            doubleLinkedList.Remove(5);
            
            // doubleLinkedList.Add(node2);
            doubleLinkedList.AddAndSortById(node2);
            Console.WriteLine(doubleLinkedList);
            Console.WriteLine();
            
            doubleLinkedList.ReversalLog();
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

        private static void GoF_Struct_BridgeTest()
        {
            string dbDataObjTypeName = config.GetBridgeConcreteImplementor();
            DbData dbData = (DbData) Util.ReflectionInstance(dbDataObjTypeName);
            string dbDataFileObjTypeName = config.GetBridgeRefinedAbstraction();
            DbDataFile dbDataFile = (DbDataFile) Util.ReflectionInstance(dbDataFileObjTypeName);
            dbDataFile.SetDb(dbData);
            dbDataFile.DbDataToFile();
        }

        private static void GoF_Struct_Composite()
        {
            #region 透明组合
            // Widget root = new MultiWidget();
            //
            // // 创建按钮，添加到根节点
            // Widget button = new Button();
            // button.AddChild(null);
            // root.AddChild(button);
            //
            // // 创建面板 给面板添加 一个文本 一个按钮，添加到根节点
            // Widget panel = new Panel();
            // Widget panelText = new Text();
            // Widget panelButton = new Button();
            // panel.AddChild(panelText);
            // panel.AddChild(panelButton);
            // root.AddChild(panel);
            //
            // // 创建文本，添加到根节点
            // Widget text = new Text();
            // root.AddChild(text);
            //
            // // 创建窗口 给窗口添加 一个文本 一个按钮，添加到根节点
            // Widget window = new Window();
            // Widget windowText = new Text();
            // Widget windowButton = new Button();
            // window.AddChild(windowText);
            // window.AddChild(windowButton);
            // root.AddChild(window);
            //
            // ConsoleUtil.WriteLine($"显示根节点下所有节点", ConsoleColor.Green);
            // root.Show();
            //
            // ConsoleUtil.WriteLine($"隐藏窗口节点下所有节点", ConsoleColor.Green);
            // window.Hide();
            #endregion
            
            #region 安全组合
            MultiWidget root = new MultiWidget();
            
            // 创建按钮，添加到根节点
            Widget button = new Button();
            root.AddChild(button);
            
            // 创建面板 给面板添加 一个文本 一个按钮，添加到根节点
            MultiWidget panel = new Panel();
            Widget panelText = new Text();
            Widget panelButton = new Button();
            panel.AddChild(panelText);
            panel.AddChild(panelButton);
            root.AddChild(panel);
            
            // 创建文本，添加到根节点
            Widget text = new Text();
            root.AddChild(text);
            
            // 创建窗口 给窗口添加 一个文本 一个按钮，添加到根节点
            MultiWidget window = new Window();
            Widget windowText = new Text();
            Widget windowButton = new Button();
            window.AddChild(windowText);
            window.AddChild(windowButton);
            root.AddChild(window);
            
            ConsoleUtil.WriteLine($"显示根节点下所有节点", ConsoleColor.Green);
            root.Show();
            
            ConsoleUtil.WriteLine($"隐藏窗口节点下所有节点", ConsoleColor.Green);
            window.Hide();
            #endregion
        }

        private static void GoF_Struct_Decorator()
        {
            string data = "aaa";
            
            #region 透明装饰模式
            // Encrypt gressionEncrypt = new GressionEncrypt();
            // gressionEncrypt.Encryption(data);
            //
            // ConsoleUtil.WriteLine($"--------------------------------------",ConsoleColor.Green);
            //
            // Encrypt reverseOutPutEncrypt = new ReverseOutPutEncrypt(gressionEncrypt);
            // reverseOutPutEncrypt.Encryption(data);
            //
            // ConsoleUtil.WriteLine($"--------------------------------------",ConsoleColor.Green);
            //
            // Encrypt moduloEncrypt = new ModEncrypt(reverseOutPutEncrypt);
            // moduloEncrypt.Encryption(data);
            #endregion
            
            /*
             * 思考题
                为什么半透明装饰模式不能实现对同一个对象的多次装饰？
             */
            #region 半透明装饰模式
            Encrypt gressionEncrypt = new GressionEncrypt();
            gressionEncrypt.Encryption(data);
            
            ConsoleUtil.WriteLine($"--------------------------------------",ConsoleColor.Green);
            
            ReverseOutPutEncrypt reverseOutPutEncrypt = new ReverseOutPutEncrypt(gressionEncrypt);
            string result = reverseOutPutEncrypt.Encryption(data);
            reverseOutPutEncrypt.ReverseOutPutEncryption(result);
            
            ConsoleUtil.WriteLine($"--------------------------------------",ConsoleColor.Green);
            
            ModEncrypt moduloEncrypt = new ModEncrypt(reverseOutPutEncrypt);
            string result1 = moduloEncrypt.Encryption(data);
            // 只能通过reverseOutPutEncrypt.ReverseOutPutEncryption(result1);才能将对象装饰成ReverseOutPutEncrypt，才能再通过装饰后的结果装饰为ModEncrypt
            moduloEncrypt.ModEncryption(result1);
            ConsoleUtil.WriteLine($"思考题：半透明装饰模式 对一个对象进行多次装饰，通过最终装饰出来的对象是调用不到上一个具体装饰类对象中的装饰方法的",ConsoleColor.Green);
            #endregion
        }

        private static void GoF_Struct_Facade()
        {
            string facadeObjTypeName = config.GetFacade();
            AbstractOnFacade facade = (AbstractOnFacade) Util.ReflectionInstance(facadeObjTypeName);
            facade.On();
        }

        private static void GoF_Struct_Flyweight()
        {
            MultiMediaFactory pictureFactory = new PictureFactory();
            MultiMediaFactory animateFactory = new AnimateFactory();
            MultiMediaFactory videoFactory = new VideoFactory();

            MultiMediaFlyweight picture1 = pictureFactory.Create("p1");
            MultiMediaFlyweight picture2 = pictureFactory.Create("p2");
            MultiMediaFlyweight picture3 = pictureFactory.Create("p1");
            Console.WriteLine($"picture1 == picture3 ：{picture1 == picture3}");
            
            MultiMediaFlyweight animate1 = animateFactory.Create("a1");
            
            MultiMediaFlyweight video1 = videoFactory.Create("v1");
            
            Document document = new Document();
            document.InsertMultiMedia(new DocMediaTransform(5,3), picture1);
            document.InsertMultiMedia(new DocMediaTransform(7,5), picture2);
            document.InsertMultiMedia(new DocMediaTransform(2,4), picture3);
            document.InsertMultiMedia(new DocMediaTransform(0,9), animate1);
            document.InsertMultiMedia(new DocMediaTransform(9,1), video1);
        }

        private static void GoF_Struct_Proxy()
        {
            ICompany company = new GameCompanyProxy();
            company.SubmitResume("Name=qqq Age=18 Post=Programmer");
        }

        private static void Gof_Behavior_ChainOfResponsibility()
        {
            LeaveHandler directorLeaveHandler = new Director();
            LeaveHandler managerLeaveHandler = new Manager();
            LeaveHandler generalManagerLeaveHandler = new GeneralManager();
            
            directorLeaveHandler.SetNextHandler(managerLeaveHandler);
            managerLeaveHandler.SetNextHandler(generalManagerLeaveHandler);
            
            directorLeaveHandler.Handler(2);
            ConsoleUtil.WriteLine($"-------------------------------------------", ConsoleColor.Green);
            directorLeaveHandler.Handler(15);
            ConsoleUtil.WriteLine($"-------------------------------------------", ConsoleColor.Green);
            directorLeaveHandler.Handler(8);
            ConsoleUtil.WriteLine($"-------------------------------------------", ConsoleColor.Green);
            directorLeaveHandler.Handler(30);
        }

        private static void Gof_Behavior_Command()
        {
            #region 练习1
            
            // Console.WriteLine($"命令模式测试");
            // Console.WriteLine($"KeyCode：A  加一个数");
            // Console.WriteLine($"KeyCode：S  撤销");
            // Console.WriteLine($"KeyCode：D  恢复");
            // Console.WriteLine($"KeyCode：W  查看结果");
            // Console.WriteLine($"KeyCode：Q  结束测试\n");
            //
            // Calculator calculator = new Calculator();
            // calculator.SetCommand(new AddCommand());
            //
            // bool test = true;
            // while (test)
            // {
            //     switch (Console.ReadKey().Key)
            //     {
            //         case ConsoleKey.A:
            //             Console.WriteLine();
            //             ConsoleUtil.Write($"输入一个正整数 ", ConsoleColor.Green);
            //             string valueStr = Console.ReadLine();
            //             int value = int.Parse(valueStr);
            //             calculator.Compute(value);
            //             break;
            //         case ConsoleKey.S:
            //             ConsoleUtil.WriteLine($"撤销一步 ", ConsoleColor.Green);
            //             calculator.Undo();
            //             break;
            //         case ConsoleKey.D:
            //             ConsoleUtil.WriteLine($"恢复一步 ", ConsoleColor.Green);
            //             calculator.Redo();
            //             break;
            //         case ConsoleKey.W:
            //             ConsoleUtil.WriteLine($"查看结果 ", ConsoleColor.Green);
            //             Console.WriteLine(calculator.Result.ToString());
            //             break;
            //         case ConsoleKey.Q:
            //             Console.WriteLine();
            //             Console.WriteLine($"结束测试");
            //             test = false;
            //             break;
            //     }
            // }
            
            #endregion
            
            #region 练习2
            
            Menu menu = new Menu();
            menu.CreateMenu.OnClick();
            ConsoleUtil.WriteLine($"-------------------------------------------", ConsoleColor.Green);
            menu.OpenMenu.OnClick();
            ConsoleUtil.WriteLine($"-------------------------------------------", ConsoleColor.Green);
            menu.EditMenu.OnClick();
            ConsoleUtil.WriteLine($"-------------------------------------------", ConsoleColor.Green);
            menu.MacroMenu.OnClick();
            
            #endregion
        }
    }
}