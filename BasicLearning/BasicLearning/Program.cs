using System;
using System.Collections;
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

            // Gof_Behavior_Interpreter();

            // Gof_Behavior_Iterator();

            // Gof_Behavior_Mediator();

            // Gof_Behavior_Memento();

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


            if (int.TryParse("-1", out int result))
                ConsoleUtil.WriteLine($"{result}", ConsoleColor.Green);
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

            CircleArrayQueue circleArrayQueue = new CircleArrayQueue( /*3*/);
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
            HeroNode node1 = new HeroNode(1, "a", "A");
            HeroNode node2 = new HeroNode(2, "b", "B");
            HeroNode node3 = new HeroNode(3, "c", "C");
            HeroNode node4 = new HeroNode(4, "d", "D");

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

            HeroNode newNode2 = new HeroNode(2, "B", "b");
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
            HeroNode mergeNode1 = new HeroNode(1, "a", "A");
            HeroNode mergeNode2 = new HeroNode(2, "b", "B");
            HeroNode mergeNode3 = new HeroNode(3, "c", "C");
            mergeSingleLinkedList1.Add(mergeNode2);
            mergeSingleLinkedList1.Add(mergeNode1);
            mergeSingleLinkedList1.Add(mergeNode3);
            SingleLinkedList mergeSingleLinkedList2 = new SingleLinkedList();
            HeroNode mergeNode4 = new HeroNode(4, "d", "D");
            HeroNode mergeNode6 = new HeroNode(6, "f", "F");
            HeroNode mergeNode5 = new HeroNode(5, "e", "E");
            mergeSingleLinkedList2.Add(mergeNode4);
            mergeSingleLinkedList2.Add(mergeNode6);
            mergeSingleLinkedList2.Add(mergeNode5);
            SingleLinkedList mergeList = MergeList(mergeSingleLinkedList1, mergeSingleLinkedList2);
            ConsoleUtil.WriteLine($"mergeSingleLinkedList1", ConsoleColor.Green);
            Console.WriteLine(mergeSingleLinkedList1);
            ConsoleUtil.WriteLine($"mergeSingleLinkedList2", ConsoleColor.Green);
            Console.WriteLine(mergeSingleLinkedList2);
            ConsoleUtil.WriteLine($"mergeList", ConsoleColor.Green);
            Console.WriteLine(mergeList);
        }

        private static void DataStructure_DoubleLinkedListTest()
        {
            HeroNode2 node1 = new HeroNode2(1, "a", "A");
            HeroNode2 node2 = new HeroNode2(2, "b", "B");
            HeroNode2 node3 = new HeroNode2(3, "c", "C");
            HeroNode2 node4 = new HeroNode2(4, "d", "D");

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

            HeroNode2 newNode2 = new HeroNode2(2, "B", "b");
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

            ConsoleUtil.WriteLine($"--------------------------------------", ConsoleColor.Green);

            ReverseOutPutEncrypt reverseOutPutEncrypt = new ReverseOutPutEncrypt(gressionEncrypt);
            string result = reverseOutPutEncrypt.Encryption(data);
            reverseOutPutEncrypt.ReverseOutPutEncryption(result);

            ConsoleUtil.WriteLine($"--------------------------------------", ConsoleColor.Green);

            ModEncrypt moduloEncrypt = new ModEncrypt(reverseOutPutEncrypt);
            string result1 = moduloEncrypt.Encryption(data);
            // 只能通过reverseOutPutEncrypt.ReverseOutPutEncryption(result1);才能将对象装饰成ReverseOutPutEncrypt，才能再通过装饰后的结果装饰为ModEncrypt
            moduloEncrypt.ModEncryption(result1);
            ConsoleUtil.WriteLine($"思考题：半透明装饰模式 对一个对象进行多次装饰，通过最终装饰出来的对象是调用不到上一个具体装饰类对象中的装饰方法的", ConsoleColor.Green);

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
            document.InsertMultiMedia(new DocMediaTransform(5, 3), picture1);
            document.InsertMultiMedia(new DocMediaTransform(7, 5), picture2);
            document.InsertMultiMedia(new DocMediaTransform(2, 4), picture3);
            document.InsertMultiMedia(new DocMediaTransform(0, 9), animate1);
            document.InsertMultiMedia(new DocMediaTransform(9, 1), video1);
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

        private static void Gof_Behavior_Interpreter()
        {
            MathExpressionParse mathExpressionParse = new MathExpressionParse();
            IMathExpression mathExpression = mathExpressionParse.Parse("1 + 20 + 3 - 4 + 1");
            ConsoleUtil.WriteLine($"1 + 20 + 3 - 4 + 1 = {mathExpression.Result()}", ConsoleColor.Green);

            DBExpressionParse dbExpressionParse = new DBExpressionParse();
            IDBExpression dbExpression = dbExpressionParse.Parse("COPY VIEW FROM srcDB TO desDB AND MOVE TABLE Student FROM srcDB TO desDB");
            ConsoleUtil.WriteLine($"COPY VIEW FROM srcDB TO desDB AND MOVE TABLE Student FROM srcDB TO desDB = {dbExpression.Interpreter()}", ConsoleColor.Green);
        }

        private static void Gof_Behavior_Iterator()
        {
            Student[] students = new Student[7];
            students[0] = new Student("小红", 5, ConsoleColor.Red);
            students[1] = new Student("小橙", 7, ConsoleColor.Yellow);
            students[2] = new Student("小黄", 7, ConsoleColor.DarkYellow);
            students[3] = new Student("小绿", 4, ConsoleColor.Green);
            students[4] = new Student("小青", 4, ConsoleColor.Cyan);
            students[5] = new Student("小蓝", 3, ConsoleColor.Blue);
            students[6] = new Student("小紫", 4, ConsoleColor.Magenta);


            IEnumerable classInSchool = new ClassInSchool2(students);
            foreach (Student student in classInSchool)
            {
                ConsoleUtil.WriteLine($"{student}", student.Color);
            }
            Console.WriteLine();


            string[] data = {"1", "2", "3", "4", "5", "6", "7", "8"};
            IAggregate<string> myAggregate = new MyAggregate<string>(data, 3);
            IIterator<string> myAggregateIterator = myAggregate.CreateIterator();
            int index = 0;
            while (myAggregateIterator.MoveNext())
            {
                ConsoleUtil.WriteLine($"第{++index}页", ConsoleColor.Green);
                foreach (var element in myAggregateIterator.Current)
                {
                    ConsoleUtil.WriteLine($"{element}", ConsoleColor.White);
                }
            }
            Console.WriteLine();


            IAggregate<Student> myAggregate1 = new MyAggregate<Student>(students, 3);
            IIterator<Student> myAggregateIterator1 = myAggregate1.CreateIterator();
            int index1 = 0;
            while (myAggregateIterator1.MoveNext())
            {
                ConsoleUtil.WriteLine($"第{++index1}页", ConsoleColor.White);
                foreach (var element in myAggregateIterator1.Current)
                {
                    ConsoleUtil.WriteLine($"{element}", element.Color);
                }
            }
        }

        private static void Gof_Behavior_Mediator()
        {
            AbMediator mediator = new MediatorWindow();
            TextPane textPane = new TextPane(mediator);
            ListPane listPane = new ListPane(mediator);
            GraphicPane graphicPane = new GraphicPane(mediator);
            mediator.Text = textPane;
            mediator.List = listPane;
            mediator.Graphic = graphicPane;
            
            listPane.Select();
        }

        private static void Gof_Behavior_Memento()
        {
            GameMementoCaretaker gameMementoCaretaker = new GameMementoCaretaker();
            GameInfo gameInfo = new GameInfo();
            gameInfo.Scene = "场景2";
            gameInfo.Player = new GamePlayer() {Name = "Lsj", Lv = 3};
            
            gameMementoCaretaker.Memento = gameInfo.Save();
            
            gameInfo.Scene = "场景3";
            gameInfo.Player.Lv = 5;
            
            gameInfo.Restore(gameMementoCaretaker.Memento);

            Console.WriteLine($"回到存档：{gameInfo.Scene} {gameInfo.Player.Name} Lv.{gameInfo.Player.Lv}");
        }
        
        /*
         * https://www.cnblogs.com/jiyuqi/p/4571543.html
         * UML中类与类，已经类与接口，接口与接口的关系有：泛化（generalization），关联（association），依赖（dependency），实现（realization）这几种。
         
            泛化（generalization）关系时指一个类（子类、子接口）继承另外一个类（称为父类、父接口）的功能，并可以增加它自己新功能的能力，
            继承是类与类或者接口与接口最常见的关系，在Java中通过关键字extends来表示。 

            实现（realization）是指一个class实现interface接口（一个或者多个），表示类具备了某种能力，实现是类与接口中最常见的关系，在Java中通过implements关键字来表示。

            依赖（dependency）关系也是表示类与类之间的连接，表示一个类依赖于另外一个类的定义，依赖关系时是单向的。
            简单理解就是类A使用到了类B，这种依赖具有偶然性、临时性，是非常弱的关系。但是类B的变化会影响到类A。
            举个例子，如某人要过河，则人与船的关系就是依赖，人过河之后，与船的关系就解除了，因此是一种弱的连接。在代码层面，为类B作为参数被类A在某个方法中使用。
            在java中，依赖表现为：局部变量，方法中的参数和对静态方法的调用。

            关联（association）关系表示类与类之间的连接，它使得一个类知道另外一个类的属性和方法。
            关联可以使用单箭头表示单向关联，使用双箭头或者不适用箭头表示双向关联，不建议使用双向关联，关联有两个端点，每个端点可以有一个基数，表示这个关联的类可以有几个实例。
            0..1 表示可以有0个或者1个实例
            0..* 表示对实例的数目没有限制
            1     表示只能有一个实例
            1..* 表示至少有一个实例
            关联关系体现的是两个类，或者类与接口之间的强依赖关系，这种关系很强烈，比依赖更强，不是偶然性的，也不是临时性的，而是一种长期性，相对平等的关系，
            表现在代码层面，为被关联的类B以类属性的形式出现在类A中，也可能是关联类A引用了被关联类B的全局变量。
            在Java中，关联关系是使用实例变量来实现的

            聚合（aggregation）是关联关系的特例，是强的关联关系，聚合是整个与个体的关系，即has-a关系，
            此时整体和部分是可以分离的，他们具有各自的生命周期，部分可以属于多个对象，也可以被多个对象共享；
            比如计算机和CPU，公司与员工的关系；在代码层面聚合与关联是一致的，只能从语义上来区分。
            聚合关系也是使用实例变量来实现的，在java语法上区分不出关联和聚合，关联关系中类出于一个层次，而聚合则明显的在两个不同的层次。

            组合（compostion）也是关联关系的一种特例，体现的是一种contain-a关系，比聚合更强，是一种强聚合关系。
            它同样体现整体与部分的关系，但此时整体与部分是不可分的，整体生命周期的结束也意味着部分生命周期的结束，反之亦然。如大脑和人类。
            体现在代码层面与关联时一致的，只能从语义来区分。
            组合与聚合几乎完全相同，唯一区别就是对于组合，“部分”不同脱离“整体”单独存在，其生命周期应该是一致的。

            主要是关联关系的细化需要注意强弱，由若到强分别是 【依赖(虚线箭头) < 关联(实线箭头) < 聚合(空心菱形实线箭头) < 组合(实心菱形实线箭头)】
         */
    }
}