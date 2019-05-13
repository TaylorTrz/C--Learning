using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Tip1：冒泡排序是先进行一次整体排序，找出最大（小）值，然后每次比较次数少一次，提高效率O(n2)
/// Tip2：循环输入，需要增加while,try,catch，并且判断首次输入是否为空
/// Tip3：结构体数组的定义方式，Line15 && Line38。
/// Tip4：结构体与类的异同（都可将不同类型的数据整合到一个集体中，但是结构体是值类型，传递值，类是引用类型，传递的是地址）
/// </summary>

namespace ChengJiPaiXu
{
    struct AllList
    {
        public string name;
        public int score;
    };

    class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {
                try
                {
                    string s = Console.ReadLine();
                    if (s.CompareTo("") == 0) { break; }  //判断是否输出结束
                    int num = Convert.ToInt32(s);
                    s = Console.ReadLine();
                    int key = Convert.ToInt32(s);
                    int tran = 0;
                    string[] S;

                    AllList[] AL = new AllList[num];
                    for (int i = 0; i < num; i++)
                    {
                        s = Console.ReadLine();
                        S = s.Split(' ');
                        AL[i].name = S[0];
                        AL[i].score = Convert.ToInt32(S[1]);
                    }

                    for (int i = 0; i < num; i++)
                        for (int j = 0; j < num-i-1; j++)
                        {
                            if (key == 0 && AL[j].score < AL[j + 1].score)
                            {
                                tran = AL[j].score;
                                AL[j].score = AL[j + 1].score;
                                AL[j + 1].score = tran;

                                s = AL[j].name;
                                AL[j].name = AL[j + 1].name;
                                AL[j + 1].name = s;
                            }
                            if (key == 1 && AL[j].score > AL[j + 1].score)
                            {
                                tran = AL[j].score;
                                AL[j].score = AL[j + 1].score;
                                AL[j + 1].score = tran;

                                s = AL[j].name;
                                AL[j].name = AL[j + 1].name;
                                AL[j + 1].name = s;
                            }
                        }

                    for (int i = 0; i < num; i++)
                    {
                        Console.WriteLine(AL[i].name + " " + AL[i].score);
                    }


                }
                catch (Exception e)
                {
                    break;
                }
            }

        }
    }
}
