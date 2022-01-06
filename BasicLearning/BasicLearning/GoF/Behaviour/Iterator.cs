using System;
using System.Collections;

namespace BasicLearning
{
    /*--
     * 练习
        在Sunny软件公司开发的某教务管理系统中，一个班级(Class in    School)包含多个学生(Student)，
        使用Java内置迭代器实现对学生信息的遍历，要求按学生年龄由大到小的次序输出学生信息。
        
        练习
        设计一个逐页迭代器，每次可返回指定个数（一页）元素，并将该迭代器用于对数据进行分页处理。
     */

    #region 方式1

    public class ClassInSchool1 : IEnumerable
    {
        public Student[] Students;

        public ClassInSchool1(Student[] students)
        {
            Students = students;
        }

        public IEnumerator GetEnumerator()
        {
            return new ClassInSchoolIterator(this);
        }

        private class ClassInSchoolIterator : IEnumerator
        {
            private ClassInSchool1 cis;
            private Student[] students;
            private int index;

            public ClassInSchoolIterator(ClassInSchool1 classInSchool)
            {
                cis = classInSchool;
                students = new Student[cis.Students.Length];
                cis.Students.CopyTo(students, 0);
                index = -1;

                OrderByAge();
            }

            public object Current => students[index];

            public bool MoveNext()
            {
                index++;
                return index < students.Length;
            }

            public void Reset()
            {
                index = -1;
            }

            private void OrderByAge()
            {
                for (int i = 0; i < students.Length - 1; i++)
                {
                    for (int j = i + 1; j < students.Length; j++)
                    {
                        if (students[j].Age > students[i].Age)
                        {
                            Student student = students[j];
                            students[j] = students[i];
                            students[i] = student;
                        }
                    }
                }
            }
        }
    }

    #endregion

    #region 方式2

    public class ClassInSchool2 : IEnumerable
    {
        public Student[] Students;

        public ClassInSchool2(Student[] students)
        {
            Students = students;
        }

        public IEnumerator GetEnumerator() // c#编译时会自动生成一个方式1中类似 ClassInSchoolIterator的类
        {
            Student[] temp = new Student[Students.Length];
            Students.CopyTo(temp, 0);
            OrderByAge(temp);

            for (int i = 0; i < temp.Length; i++)
            {
                yield return temp[i];
            }
        }

        private void OrderByAge(Student[] students)
        {
            for (int i = 0; i < students.Length - 1; i++)
            {
                for (int j = i + 1; j < students.Length; j++)
                {
                    if (students[j].Age > students[i].Age)
                    {
                        Student student = students[j];
                        students[j] = students[i];
                        students[i] = student;
                    }
                }
            }
        }
    }

    #endregion

    public class Student
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public ConsoleColor Color { get; private set; }

        public Student(string name, int age, ConsoleColor color)
        {
            Name = name;
            Age = age;
            Color = color;
        }

        public override string ToString()
        {
            return $"{Name} {Age}岁";
        }
    }


    
    public interface IAggregate<T>
    {
        IIterator<T> CreateIterator();
    }

    public interface IIterator<T>
    {
        bool MoveNext();
        T[] Current { get; }
    }

    public class MyAggregate<T> : IAggregate<T>
    {
        public T[] Data { get; private set; }
        public int PageNum { get; private set; }

        public MyAggregate(T[] data, int pageNum)
        {
            Data = data;
            PageNum = pageNum;
        }

        public IIterator<T> CreateIterator()
        {
            return new MyAggregateIterator<T>(this);
        }

        private class MyAggregateIterator<T> : IIterator<T>
        {
            private MyAggregate<T> aggregate;
            private T[] current;
            private int index;

            public MyAggregateIterator(MyAggregate<T> aggregate)
            {
                this.aggregate = aggregate;
                current = new T[aggregate.PageNum];
                index = 0;
            }

            public bool MoveNext()
            {
                if (index >= aggregate.Data.Length)
                    return false;

                int targetIndex = index + aggregate.PageNum;
                targetIndex = targetIndex > aggregate.Data.Length ? aggregate.Data.Length : targetIndex;
                for (int i = 0; i < aggregate.PageNum; i++)
                {
                    if (index + i >= aggregate.Data.Length)
                        current[i] = default(T);
                    else
                        current[i] = aggregate.Data[index + i];
                }

                index = targetIndex;

                return true;
            }

            public T[] Current => current;
        }
    }
}