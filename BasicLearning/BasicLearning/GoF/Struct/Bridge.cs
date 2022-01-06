using System;

namespace BasicLearning
{
    /*
     * 练习
        Sunny软件公司欲开发一个数据转换工具，可以将数据库中的数据转换成多种文件格式，例如txt、xml、pdf等格式，
        同时该工具需要支持多种不同的数据库。试使用桥接模式对其进行设计。
     */

    /*
     * https://blog.csdn.net/lovelion/article/details/7464204
     * 博主LoveLion:通常将更容易分离出、重用可能性更大的维度作为Implementor，有时候可以分离出多个Implementor，在有些情况下确实可以对调。
     * 我个人的做法，如果一个维度对成员变量有更多的依赖，则作为Abstraction维度，如果对成员变量的依赖很少，较为独立，则作为Implementor。供参考。
     *
     */
    
    /*
     * 参考了 https://blog.csdn.net/Phoegel/article/details/109585002?spm=1001.2014.3001.5502
     */

    /*
     * 这个模式理解的不是很透彻，感觉练习的这个例子不是很待发
     */
    
    // 实现接口
    public interface DbData
    {
        void GetData();
    }
    // 具体实现类
    public class MySqlDbData : DbData
    {
        public void GetData()
        {
            Console.WriteLine($"获得MySql数据库数据");
        }
    }
    // 具体实现类
    public class MongoDbData : DbData
    {
        public void GetData()
        {
            Console.WriteLine($"获得Mongo数据库数据");
        }
    }
    
    // 抽象类
    public abstract class DbDataFile
    {
        protected DbData dbData;
        
        public void SetDb(DbData dbData)
        {
            this.dbData = dbData;
        }

        public abstract void DbDataToFile();
    }
    // 扩展抽象类
    public class TxtDbDataFile : DbDataFile
    {
        public override void DbDataToFile()
        {
            dbData.GetData();
            Console.WriteLine($"转换为Txt文件");
        }
    }
    // 扩展抽象类
    public class XmlDbDataFile : DbDataFile
    {
        public override void DbDataToFile()
        {
            dbData.GetData();
            Console.WriteLine($"转换为Xml文件");
        }
    }
    // 扩展抽象类
    public class PdfDbDataFile : DbDataFile
    {
        public override void DbDataToFile()
        {
            dbData.GetData();
            Console.WriteLine($"转换为Pdf文件");
        }
    }
}