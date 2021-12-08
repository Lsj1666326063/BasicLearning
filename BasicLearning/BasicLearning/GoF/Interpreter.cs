using System.Collections.Generic;

namespace BasicLearning
{
    /*--
     * 思考
        绘制加法/减法解释器的类图并编写核心实现代码。
        
        expression
        
        练习
        Sunny软件公司欲为数据库备份和同步开发一套简单的数据库同步指令，通过指令可以对数据库中的数据和结构进行备份，
        例如，
            输入指令“COPY VIEW FROM srcDB TO desDB”表示将数据库srcDB中的所有视图(View)对象都拷贝至数据库desDB；
            输入指令“MOVE TABLE Student FROM srcDB TO desDB”表示将数据库srcDB中的Student表移动至数据库desDB。
        试使用解释器模式来设计并实现该数据库同步指令。
     */
    
    /*--
     * 
        语法树(组合模式?) 解析字符串
        
        【注：高效的解释器通常不是通过直接解释抽象语法树来实现的，而是需要将它们转换成其他形式，使用解释器模式的执行效率并不高。】
     */
    
    /*
     *  expression ::= value | operation
        operation ::= expression '+' expression | expression '-'  expression
        value ::= an integer //一个整数值
        
        1+2-3+4
        
     */
    
    /*
     *  expression ::= direction action distance | composite //表达式
        composite ::= expression 'and' expression //复合表达式
        direction ::= 'up' | 'down' | 'left' | 'right' //移动方向
        action ::= 'move' | 'run' //移动方式
        distance ::= an integer //移动距离
     */
    
    /*
     *  expression ::= OptType OptObj OptTarget | Composite
        Composite ::= expression 'AND' expression
        OptType ::= 'COPY' | 'MOVE'
        OptObj ::= 'VIEW' | 'TABLE' an string
        OptTarget ::= 'FROM' an string 'TO' an string
        
        COPY VIEW FROM srcDB TO desDB
        MOVE TABLE Student FROM srcDB TO desDB
     */
    

    // 抽象数学表达式
    public interface IMathExpression
    {
        int Result();
    }

    // 加法计算规则表达式
    public class AddOperation : IMathExpression
    {
        private IMathExpression me1;
        private IMathExpression me2;

        public AddOperation(IMathExpression mathExpression1,IMathExpression mathExpression2)
        {
            me1 = mathExpression1;
            me2 = mathExpression2;
        }
        
        public int Result()
        {
            return me1.Result() + me2.Result();
        }
    }

    // 减法计算规则表达式
    public class SubtractOperation : IMathExpression
    {
        private IMathExpression me1;
        private IMathExpression me2;

        public SubtractOperation(IMathExpression mathExpression1,IMathExpression mathExpression2)
        {
            me1 = mathExpression1;
            me2 = mathExpression2;
        }
        
        public int Result()
        {
            return me1.Result() - me2.Result();
        }
    }

    // 值表达式
    public class ValueME : IMathExpression
    {
        private int val;

        public ValueME(int value)
        {
            val = value;
        }
        
        public int Result()
        {
            return val;
        }
    }

    // 数学语法解析类
    public class MathExpressionParse
    {
        public IMathExpression Parse(string expressionStr)
        {
            string[] expressions = expressionStr.Split(' ');
            
            Stack<IMathExpression> lastExpressions = new Stack<IMathExpression>();
            for (int i = 0; i < expressions.Length; i++)
            {
                string expression = expressions[i];
                if (int.TryParse(expression, out int value))
                {
                    // 压入表达式
                    lastExpressions.Push(MathExpressionFactory.Create(value));
                }
                else
                {
                    if (i == 0)
                        return null;
                    
                    // 获得上一个表达式
                    IMathExpression lastExpression = lastExpressions.Pop();
                    
                    // 获得下一个表达式
                    string nextExpressionStr = expressions[++i];
                    if (!int.TryParse(nextExpressionStr, out int nextValue))
                        return null;
                    IMathExpression nextExpression = MathExpressionFactory.Create(nextValue);
                    
                    // 压入表达式 
                    lastExpressions.Push(MathExpressionFactory.Create(expression, lastExpression, nextExpression));
                }
            }

            return lastExpressions.Pop();
        }
    }

    // 数学表达式工厂
    public static class MathExpressionFactory
    {
        public static IMathExpression Create(int value)
        {
            return new ValueME(value);
        }
        public static IMathExpression Create(string operation,IMathExpression expression1,IMathExpression expression2)
        {
            switch (operation)
            {
                case "+":
                    return new AddOperation(expression1, expression2);
                case "-":
                    return new SubtractOperation(expression1, expression2);
            }

            return null;
        }
    }

    
    
    
    // 抽象数据库同步表达式
    public interface IDBExpression
    {
        string Interpreter();
    }

    // 组合表达式
    public class Composite : IDBExpression
    {
        private IDBExpression dbe1;
        private IDBExpression dbe2;

        public Composite(IDBExpression dbExpression1,IDBExpression dbExpression2)
        {
            dbe1 = dbExpression1;
            dbe2 = dbExpression2;
        }
        
        public string Interpreter()
        {
            return dbe1.Interpreter() + "再" + dbe2.Interpreter();
        }
    }

    // 一次操作表达式
    public class OnceOpt : IDBExpression
    {
        private IDBExpression optType;
        private IDBExpression optObj;
        private IDBExpression optTarget;

        public OnceOpt(IDBExpression optType,IDBExpression optObj,IDBExpression optTarget)
        {
            this.optType = optType;
            this.optObj = optObj;
            this.optTarget = optTarget;
        }
        
        public string Interpreter()
        {
            return optType.Interpreter() + optObj.Interpreter() + optTarget.Interpreter();
        }
    }

    // 操作类型表达式
    public class OptType : IDBExpression
    {
        private string type;

        public OptType(string type)
        {
            this.type = type;
        }

        public string Interpreter()
        {
            switch (type)
            {
                case "COPY":
                    return "拷贝";
                case "MOVE":
                    return "移动";
            }

            return "未知操作类型";
        }
    }

    // 视图操作对象表达式
    public class ViewOptObj : IDBExpression
    {
        public string Interpreter()
        {
            return "视图对象";
        }
    }

    // 表操作对象表达式
    public class TableOptObj : IDBExpression
    {
        private string tbName;

        public TableOptObj(string tbName)
        {
            this.tbName = tbName;
        }

        public string Interpreter()
        {
            return $"{tbName}表";
        }
    }

    // 操作目标表达式
    public class OptTarget : IDBExpression
    {
        private string fromDbName;
        private string toDbName;

        public OptTarget(string fromDbName,string toDbName)
        {
            this.fromDbName = fromDbName;
            this.toDbName = toDbName;
        }

        public string Interpreter()
        {
            return $"从{fromDbName}库到{toDbName}库";
        }
    }

    // 数据库同步语法解析类
    public class DBExpressionParse
    {
        public IDBExpression Parse(string expressionStr)
        {
            string[] expressions = expressionStr.Split(' ');
            
            Stack<IDBExpression> lastExpressions = new Stack<IDBExpression>();
            for (int i = 0; i < expressions.Length; i++)
            {
                if (!expressions[i].Equals("AND"))
                {
                    IDBExpression optType = new OptType(expressions[i]);
                    IDBExpression optObj = (expressions[++i].Equals("VIEW") ? (IDBExpression) new ViewOptObj() : new TableOptObj(expressions[++i]));
                    i += 2;
                    string optTargetFrom = expressions[i];
                    i += 2;
                    string optTargetTo = expressions[i];
                    IDBExpression optTarget = new OptTarget(optTargetFrom, optTargetTo);
                    IDBExpression onceOpt = new OnceOpt(optType, optObj, optTarget);
                    // 压入表达式
                    lastExpressions.Push(onceOpt);
                }
                else
                {
                    // 获得上一个表达式
                    IDBExpression lastExpression = lastExpressions.Pop();
                    
                    // 获得下一个表达式
                    IDBExpression optType = new OptType(expressions[++i]);
                    IDBExpression optObj = (expressions[++i].Equals("VIEW") ? (IDBExpression) new ViewOptObj() : new TableOptObj(expressions[++i]));
                    i += 2;
                    string optTargetFrom = expressions[i];
                    i += 2;
                    string optTargetTo = expressions[i];
                    IDBExpression optTarget = new OptTarget(optTargetFrom, optTargetTo);
                    IDBExpression onceOpt = new OnceOpt(optType, optObj, optTarget);
                    
                    // 压入表达式 
                    lastExpressions.Push(new Composite(lastExpression, onceOpt));
                }
            }

            return lastExpressions.Pop();
        }
    }
}