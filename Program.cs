using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 有依赖的0-1背包问题，参考 https://blog.csdn.net/qq_39670434/article/details/79476928  https://blog.csdn.net/liang5630/article/details/8030108
/// </summary>
/// 仍有问题，用简单测试用例可以运行，但是复杂的测试用例未通过
//用例:
//751 41
//230 1 0
//110 3 0
//30 3 0
//60 2 0
//140 2 0
//150 4 0
//300 4 0
//80 3 0
//80 3 0
//260 4 0
//180 3 0
//60 3 0
//210 2 0
//50 5 0
//170 3 0
//250 2 0
//210 5 0
//310 2 0
//280 1 0
//60 1 0
//30 2 0
//150 5 0
//230 3 0
//200 1 0
//310 3 0
//260 5 0
//160 3 0
//250 1 0
//130 5 0
//130 5 0
//240 5 0
//140 5 0
//120 1 0
//80 4 0
//160 5 0
//100 4 0
//170 4 0
//30 1 0
//150 4 0
//130 5 0
//90 5 0

//对应输出应该为:

//3750

namespace GouWu
{
    class GouWuDan
    {
        //获得输入参数
        public Tuple<int[], int[,]> Info()
        {
            int[] sumInfo = new int[2];
            string str = Console.ReadLine();
            string[] STR = str.Split(' ');
            for (int i = 0; i < 2; i++)
            {
                sumInfo[i] = Convert.ToInt32(STR[i]);
            }

            int[,] divInfo = new int[sumInfo[1], 3];
            for (int i = 0; i < sumInfo[1]; i++)
            {
                str = Console.ReadLine();
                STR = str.Split(' ');
                for (int j = 0; j < 3; j++)
                {
                    divInfo[i, j] = Convert.ToInt32(STR[j]);
                }
            }

            Tuple<int[], int[,]> tup = new Tuple<int[], int[,]>(sumInfo, divInfo);
            return tup;
        }

        public int funValue(int num, int value, int[,] a, int[,] b) //递归调用，求取最大值
        {
           
            int maxValue = 0;
            if (num < 0 || value <= 0)
            { 
                maxValue = 0;
            }
            else
            {
                //循环调用
                maxValue = funValue(num - 1, value, a, b);
                if (value - a[num, 0] > 0 && maxValue < funValue(num - 1, value - a[num, 0], a, b) + a[num, 0] * b[num, 0])
                {
                    maxValue = funValue(num - 1, value - a[num, 0], a, b) + a[num, 0] * b[num, 0];
                }
                if (value - a[num, 0] - a[num, 1] > 0 && maxValue < funValue(num - 1, value - a[num, 0] - a[num, 1], a, b) + a[num, 0] * b[num, 0] + a[num, 1] * b[num, 1])
                {
                    maxValue = funValue(num - 1, value - a[num, 0] - a[num, 1], a, b) + a[num, 0] * b[num, 0] + a[num, 1] * b[num, 1];
                }
                if (value - a[num, 0] - a[num, 2] > 0 && maxValue < funValue(num - 1, value - a[num, 0] - a[num, 2], a, b) + a[num, 0] * b[num, 0] + a[num, 2] * b[num, 2])
                {
                    maxValue = funValue(num - 1, value - a[num, 0] - a[num, 2], a, b) + a[num, 0] * b[num, 0] + a[num, 2] * b[num, 2];
                }
                if (value - a[num, 0] - a[num, 1] - a[num, 2] > 0 && maxValue < funValue(num - 1, value - a[num, 0] - a[num, 1] - a[num, 2], a, b) + a[num, 0] * b[num, 0] + a[num, 1] * b[num, 1] + a[num, 2] * b[num, 2])
                {
                    maxValue = funValue(num - 1, value - a[num, 0] - a[num, 1] - a[num, 2], a, b) + a[num, 0] * b[num, 0] + a[num, 1] * b[num, 1] + a[num, 2] * b[num, 2];
                }
            }


            return maxValue;
        }

        static void Main(string[] args)
        {
            //输入参数
            int[] sumInfo = { };  //总参数
            int[,] divInfo = { }; //子参数
            Tuple<int[], int[,]> tup = new Tuple<int[], int[,]>(sumInfo, divInfo);
            GouWuDan GWD = new GouWuDan();
            tup = GWD.Info();
            sumInfo = tup.Item1;
            divInfo = tup.Item2;

            //以主件为基础，进行物品划分
            int[,] a = new int[sumInfo[1], 3]; //第i类物品主件与附件的价格
            int[,] b = new int[sumInfo[1], 3]; //第i类物品主件与附件的重要度
            int queue = 0; //主件的总个数
            for (int i = 0; i < sumInfo[1]; i++)
            {
                if (divInfo[i, 2] == 0)   //若主件
                {
                    a[queue, 0] = divInfo[i, 0];
                    b[queue, 0] = divInfo[i, 1];
                    queue++;
                }
                else                     //若附件
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (a[queue-1,j] == 0)
                        {
                            a[queue-1, j] = divInfo[i, 0];
                            b[queue-1, j] = divInfo[i, 1];
                            break;
                        }
                    }
                }
            }

            //输出最大值（有依赖的0-1背包问题，明确控制条件（共有4种方式）。每步都需取最优，因此考虑进行递归）
            int weightValue = 0;
            weightValue = GWD.funValue(queue-1, sumInfo[0], a, b);  //用所有钱能买到的物资的最大价值
            Console.WriteLine("{0}", weightValue);
            Console.ReadKey();
        }

    }
}
