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

            // Test1();
            
            
            // DataStructure_MyArrayListTest();

            DataStructure_SparseArrayTest();
            
            
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
            
            //-?(\d+)\.?(\d+)?
            // Regex regex = new Regex(@"^(\w)+(\.\w)*@(\w)+((\.\w+)+)$");
            string regexStr = @"-?(\d+)\.?(\d+)?";
            MatchCollection mc = Regex.Matches("gjhgj11-2-121sdf-1231.1231sdfs0.11 0.00df", regexStr);
        }

        private static void DataStructure_MyArrayListTest()
        {
            MyArrayList<int> mArrList = new MyArrayList<int>();
        }

        private static void DataStructure_SparseArrayTest()
        {
            // SparseArray.Test1();
            SparseArray.Test2();
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
            PictureReaderFactory pRFactory = (PictureReaderFactory)Util.ReflectionInstance(objTypeName);
            // IPictureReader pictureReader = pRFactory.Create(); // 不使用参数
            IPictureReader pictureReader = pRFactory.Create("AAA"); // 使用参数
            pictureReader.PictureReader();
        }

        private static void GoF_Create_AbstructFactoryTest()
        {
            string objTypeName = config.GetAbstructFactory();
            SystemFactory sFactory = (SystemFactory)Util.ReflectionInstance(objTypeName);
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
            Prototype prototype1 = (Prototype)prototype.DeepClone(); // 深拷贝
            prototype1.Num = 1;
            prototype1.protoTypeTestObj.Num = 2;
            Console.WriteLine($"prototype.Num:{prototype.Num}  prototype.protoTypeTestObj.Num:{prototype.protoTypeTestObj.Num}");
            Console.WriteLine($"prototype1.Num:{prototype1.Num}  prototype1.protoTypeTestObj.Num:{prototype1.protoTypeTestObj.Num}");
        }

        private static void GoF_Create_BuilderTest()
        {
            string objTypeName = config.GetBuilder();
            VideoInterfaceBuilder builder = (VideoInterfaceBuilder)Util.ReflectionInstance(objTypeName);
            VideoInterface videoInterface = builder.Builder();
            Console.WriteLine(videoInterface);
        }

        private static void GoF_Struct_AdapterTest()
        {
            string objTypeName = config.GetAdapter();
            IDES des = (IDES)Util.ReflectionInstance(objTypeName);
            DataBaseOperation dbOpt = new DataBaseOperation(des);
            string userInfo = "用户数据";
            dbOpt.SaveUserInfo(userInfo);
            dbOpt.GetUserInfo();
        }
    }
}