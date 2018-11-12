using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// #1数串问题
/// </summary>

// 核心是比较两个字符串的大小，然后对字符串进行一个排序即可，注意最后输出的不是整型！

// 1： 一维数组的三种初始化
// string[] S = {"1", "2"};
// string[] S; S = new string[2]{"1", "2"};         注意该方法只能在方法里赋值
// string[] S = new string[2]; S[0]="1"; S[1]="2";  注意该方法只能在方法里赋值

// 2:  二维数组的初始化
// int[,] A = new int[2,2] {{1,2},{3,4}};
// int[,] A = new int[,] {{1,2},{3,4}};
// int[,] A =     int[,] {{1,2},{3,4}};
// int[,] A =        [,] {{1,2},{3,4}};

// 3:  三种强制类型转换的区别
// (int)默认整型是Int32、 int(4.6)=4
// int.Parse() 括号内一定是string类型
// Convert.ToInt32() 可以提供多种类型的转换 Convert.ToInt32(4.6)=4 Convert.ToInt32(5.6)=6  返回的是二者之间的偶数

// 4:  Read、ReadLine的区别
// Read只能读取一个字符、输出结果是ASCII、接收任意键盘输入
// ReadLine读取一个字符串、输出字符串、只接收回车

// 5:  Split分割字符串
// string.Split('char') 表示以单个字符进行分割
// string.Split(new char[2]{'char','char'}) 可以用多个字符进行分割
// string.Split(str, "string", RegexOption.Ingorecase) 更可以用字符串进行分割  RegexOption是枚举类型

// 6:  三种字符串拼接方法
// str = "a" + "b"; string是引用类型，保留在堆上，不是栈上。所以每次修改会重新创建新的string对象，浪费性能
// string str = String.Format("{0}{1}{2}","a","b","c"); 
// StringBulider str = new StringBuilder();  str.Append("a");    注意是最高效的
// str=$"{"a"}{"b"}{"c"}";  $用于C#{}变量的包含，是String.Format的简化

namespace ShuChuan
{
    //数串
    class Program
    {
        private Tuple<int, int> Swap(int a, int b)        //交换
        {
            Tuple<int, int> tup = new Tuple<int, int>(b, a);
            return tup;
        }

        static void Main(string[] args)
        {
            string str1;
            int N;
            int[] A, B, C; //A放所有整数、 B放整数的位数、 C放整数的顺序

            str1 = Console.ReadLine();
            N = Convert.ToInt32(str1);
            string str2 = Console.ReadLine();
            string[] STR = str2.Split(' ');

            A = new int[N];
            B = new int[N];
            C = new int[N];
            int weishu = 0; //记录整数的最大位数
            int flag = 1;
            for (int i = 0; i < N; i++)
            {
                A[i] = Convert.ToInt32(STR[i]);
                B[i] = A[i];
                while ((int)(B[i] / 10) > 0)
                {
                    flag++;
                    B[i] = (int)(B[i] / 10);
                }
                B[i] = flag;

                C[i] = i;

                if (flag > weishu)   //找到最大位数
                {
                    weishu = flag;
                }
                flag = 1;
            }

            Program pro = new Program();   // 对象引用的解决办法：对类实例化（static都是在类初始化的时候加载的，而非静态的变量都是在对象初始化的时候加载）

            //对A数组进行排序，然后得到排序的顺序
            for (int i = 0; i < N; i++)
            {
                for (int j = N - 1; j > i; j--)
                {
                    if (A[j - 1] * Math.Pow(10, B[j]) + A[j] < A[j] * Math.Pow(10, B[j - 1]) + A[j - 1])
                    {
                        int swap;
                        swap = B[j - 1]; //替换顺序
                        B[j - 1] = B[j];
                        B[j] = swap;
                        swap = A[j - 1]; //替换顺序
                        A[j - 1] = A[j];
                        A[j] = swap;

                    }
                }
            }

        string str = "";
            for (int i = 0; i < N; i++)  
            {
                str = str + Convert.ToString(A[i]);
            }

            //将整数进行组合输出数串
            Console.WriteLine("{0}", str);
            Console.ReadKey();
        }
     }
}

