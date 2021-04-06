using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace DicePredict
{
    class Program
    {
        static void Main(string[] args)
        {

            /***********************************************驗證序號**************************************************/

            //將要取得HTML原如碼的網頁放在WebRequest.Create(@”網址” )
            WebRequest myRequest = WebRequest.Create(@"https://whiteeyeyan.neocities.org/");

            //Method選擇GET
            myRequest.Method = "GET";

            //取得WebRequest的回覆
            WebResponse myResponse = myRequest.GetResponse();

            //Streamreader讀取回覆
            StreamReader sr = new StreamReader(myResponse.GetResponseStream());

            //將全文轉成string
            string result = sr.ReadToEnd();

            //關掉StreamReader
            sr.Close();

            //關掉WebResponse
            myResponse.Close();

            //搜尋頭尾關鍵字, 搜尋方法見後記(1)
            int first = result.IndexOf("------");
            int last = result.LastIndexOf("******");

            //減去頭尾不要的字元或數字, 並將結果轉為string. 計算方式見後記(2)
            string HTMLCut = result.Substring(first + 6, last - first - 6);

            /***********************************************驗證結尾**************************************************/


            if (HTMLCut != "123165153")
            {
                Console.WriteLine("驗證錯誤\n\n\n");
            }
            else
            {
                string password = "123";
                string input;
                Console.WriteLine("請輸入密碼");
                while ((input=Console.ReadLine()) !=password)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("密碼錯誤 請輸入正確密碼\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
           
                if (password==input)
                {
                    Console.WriteLine("密碼正確\n");
                    int i, j, k = 0, pas = 0, number1 = 0, number2, total = 0, total2 = 0, hit = 0, Miss = 0, a = 0, miss=0;
                    int[] A1 = { 0, 40, 33, 27, 38, 35, 29 };
                    int[] A2 = { 0, 30, 39, 38, 40, 41, 31 };
                    int[] A3 = { 0, 28, 35, 26, 37, 36, 23 };
                    int[] A4 = { 0, 27, 38, 45, 41, 36, 31 };
                    int[] A5 = { 0, 42, 43, 30, 34, 48, 36 };
                    int[] A6 = { 0, 131, 29, 26, 26, 41, 36 };
                    int[] C = { 0, 0, 0, 0, 0};			//判斷預測的數值是否有中


                    while (2>1)
                    {
                        int[] B = { 0, 0, 0, 0, 0, 0, 0, 0};
                        if (a != 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("*贏多了別忘了分紅給作者*\n\n");
                        }
                        if (total2 > 10 && a == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("*輸光了別怪作者*\n\n");
                        }
                        a = 0;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("*****************警告*****************");
                        Console.WriteLine("	    作者: White\n");
                        Console.WriteLine("	  免費程式 請勿販售");
                        Console.WriteLine("	  免費程式 請勿販售");
                        Console.WriteLine("	  免費程式 請勿販售\n");
                        Console.WriteLine("       此程式為作者練習用程式");
                        Console.WriteLine("	   分享於冰楓論壇");
                        Console.WriteLine("**************************************\n\n");


                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("第{0}場:", total2 + 1);
                        number2= Convert.ToInt32(Console.ReadLine());


                        if (number2 <= 6 && number2 >= 1)
                        {
                            total2++;
                            if (total2 <= 10) Console.WriteLine("\n");
                            if (total2 >= 10)
                            {
                                if (k <= 3)
                                {
                                    for (i = 0; i < k; i++)
                                    {
                                        if (C[i] == number2)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("\n結果:\n");
                                            Console.WriteLine("    hit\n");
                                            a++;
                                            hit++;
                                            miss = 0;
                                            /**/
                                        }
                                    }
                                    if (a == 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.WriteLine("\n結果:\n");
                                        Console.WriteLine("    Miss\n");
                                        Miss++;
                                        miss++;
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("\n結果:\n");
                                    Console.WriteLine("    不列入三指定預測計算\n");
                                    pas++;
                                }
                                if (k <= 3)
                                {
                                    total++;
                                    Console.WriteLine("    中獎機率:{0}%", ((double)hit / (double)total) * 100);
                                    Console.WriteLine("    總Miss次數:{0}", Miss);
                                    Console.WriteLine("    連續Miss次數:{0}", miss);
                                }
                                k = 0;
                                Console.WriteLine("    總共:{0}\n", total2, pas);
                                //Console.WriteLine("    pass:{0}\n", pas);
                            }



                            Console.ForegroundColor = ConsoleColor.Yellow;
                            /*********************Judge************************/
                            if (total2 >= 8)
                            {
                                if (number1 == 1)
                                {
                                    if (number2 == 1) A1[1]++;
                                    if (number2 == 2) A1[2]++;
                                    if (number2 == 3) A1[3]++;
                                    if (number2 == 4) A1[4]++;
                                    if (number2 == 5) A1[5]++;
                                    if (number2 == 6) A1[6]++;
                                    for (i = 1; i <= 6; i++)
                                    {
                                        for (j = 1; j <= 6; j++)
                                        {
                                            if (i != j)
                                            {
                                                if (A1[i] >= A1[j]) B[i]++;
                                            }
                                        }
                                    }
                                    //Console.WriteLine("number1:{0}\n\n",number2);
                                    Console.Write("\n\n預測第{0}場:", total2 + 1);
                                    for (i = 1; i <= 6; i++)
                                    {
                                        if (B[i] == 5)
                                        {
                                            Console.Write("{0} ", i);
                                            C[k] = i;
                                            k++;
                                        }
                                    }
                                    for (i = 1; i <= 6; i++)
                                    {
                                        if (B[i] == 4)
                                        {
                                            Console.Write("{0} ", i);
                                            C[k] = i;
                                            k++;
                                        }
                                    }
                                    for (i = 1; i <= 6; i++)
                                    {
                                        if (B[i] == 3)
                                        {
                                            Console.Write("{0} ", i);
                                            C[k] = i;
                                            k++;
                                        }
                                    }
                                    Console.WriteLine("\n\n");
                            
                                }//if

                                if (number1 == 2)
                                {
                                    if (number2 == 1) A2[1]++;
                                    if (number2 == 2) A2[2]++;
                                    if (number2 == 3) A2[3]++;
                                    if (number2 == 4) A2[4]++;
                                    if (number2 == 5) A2[5]++;
                                    if (number2 == 6) A2[6]++;
                                    for (i = 1; i <= 6; i++)
                                    {
                                        for (j = 1; j <= 6; j++)
                                        {
                                            if (i != j)
                                            {
                                                if (A2[i] >= A2[j]) B[i]++;
                                            }
                                        }
                                    }
                                    //Console.WriteLine("number1:{0}\n\n",number2);
                                    Console.Write("\n\n預測第{0}場:", total2 + 1);
                                    for (i = 1; i <= 6; i++)
                                    {
                                        if (B[i] == 5)
                                        {
                                            Console.Write("{0} ", i);
                                            C[k] = i;
                                            k++;
                                        }
                                    }
                                    for (i = 1; i <= 6; i++)
                                    {
                                        if (B[i] == 4)
                                        {
                                            Console.Write("{0} ", i);
                                            C[k] = i;
                                            k++;
                                        }
                                    }
                                    for (i = 1; i <= 6; i++)
                                    {
                                        if (B[i] == 3)
                                        {
                                            Console.Write("{0} ", i);
                                            C[k] = i;
                                            k++;
                                        }
                                    }
                                    Console.WriteLine("\n\n");
                            
                                }//if

                                if (number1 == 3)
                                {
                                    if (number2 == 1) A3[1]++;
                                    if (number2 == 2) A3[2]++;
                                    if (number2 == 3) A3[3]++;
                                    if (number2 == 4) A3[4]++;
                                    if (number2 == 5) A3[5]++;
                                    if (number2 == 6) A3[6]++;
                                    for (i = 1; i <= 6; i++)
                                    {
                                        for (j = 1; j <= 6; j++)
                                        {
                                            if (i != j)
                                            {
                                                if (A3[i] >= A3[j]) B[i]++;
                                            }
                                        }
                                    }
                                    //Console.WriteLine("number1:{0}\n\n",number2);
                                    Console.Write("\n\n預測第{0}場:", total2 + 1);
                                    for (i = 1; i <= 6; i++)
                                    {
                                        if (B[i] == 5)
                                        {
                                            Console.Write("{0} ", i);
                                            C[k] = i;
                                            k++;
                                        }
                                    }
                                    for (i = 1; i <= 6; i++)
                                    {
                                        if (B[i] == 4)
                                        {
                                            Console.Write("{0} ", i);
                                            C[k] = i;
                                            k++;
                                        }
                                    }
                                    for (i = 1; i <= 6; i++)
                                    {
                                        if (B[i] == 3)
                                        {
                                            Console.Write("{0} ", i);
                                            C[k] = i;
                                            k++;
                                        }
                                    }
                                    Console.WriteLine("\n\n");
                            
                                }//if

                                if (number1 == 4)
                                {
                                    if (number2 == 1) A4[1]++;
                                    if (number2 == 2) A4[2]++;
                                    if (number2 == 3) A4[3]++;
                                    if (number2 == 4) A4[4]++;
                                    if (number2 == 5) A4[5]++;
                                    if (number2 == 6) A4[6]++;
                                    for (i = 1; i <= 6; i++)
                                    {
                                        for (j = 1; j <= 6; j++)
                                        {
                                            if (i != j)
                                            {
                                                if (A4[i] >= A4[j]) B[i]++;
                                            }
                                        }
                                    }
                                    //Console.WriteLine("number1:{0}\n\n",number2);
                                    Console.Write("\n\n預測第{0}場:", total2 + 1);
                                    for (i = 1; i <= 6; i++)
                                    {
                                        if (B[i] == 5)
                                        {
                                            Console.Write("{0} ", i);
                                            C[k] = i;
                                            k++;
                                        }
                                    }
                                    for (i = 1; i <= 6; i++)
                                    {
                                        if (B[i] == 4)
                                        {
                                            Console.Write("{0} ", i);
                                            C[k] = i;
                                            k++;
                                        }
                                    }
                                    for (i = 1; i <= 6; i++)
                                    {
                                        if (B[i] == 3)
                                        {
                                            Console.Write("{0} ", i);
                                            C[k] = i;
                                            k++;
                                        }
                                    }
                                    Console.WriteLine("\n\n");
                            
                                }//if

                                if (number1 == 5)
                                {
                                    if (number2 == 1) A5[1]++;
                                    if (number2 == 2) A5[2]++;
                                    if (number2 == 3) A5[3]++;
                                    if (number2 == 4) A5[4]++;
                                    if (number2 == 5) A5[5]++;
                                    if (number2 == 6) A5[6]++;
                                    for (i = 1; i <= 6; i++)
                                    {
                                        for (j = 1; j <= 6; j++)
                                        {
                                            if (i != j)
                                            {
                                                if (A5[i] >= A5[j]) B[i]++;
                                            }
                                        }
                                    }
                                    //Console.WriteLine("number1:{0}\n\n",number2);
                                    Console.Write("\n\n預測第{0}場:", total2 + 1);
                                    for (i = 1; i <= 6; i++)
                                    {
                                        if (B[i] == 5)
                                        {
                                            Console.Write("{0} ", i);
                                            C[k] = i;
                                            k++;
                                        }
                                    }
                                    for (i = 1; i <= 6; i++)
                                    {
                                        if (B[i] == 4)
                                        {
                                            Console.Write("{0} ", i);
                                            C[k] = i;
                                            k++;
                                        }
                                    }
                                    for (i = 1; i <= 6; i++)
                                    {
                                        if (B[i] == 3)
                                        {
                                            Console.Write("{0} ", i);
                                            C[k] = i;
                                            k++;
                                        }
                                    }
                                    Console.WriteLine("\n\n");
                            
                                }//if

                                if (number1 == 6)
                                {
                                    if (number2 == 1) A6[1]++;
                                    if (number2 == 2) A6[2]++;
                                    if (number2 == 3) A6[3]++;
                                    if (number2 == 4) A6[4]++;
                                    if (number2 == 5) A6[5]++;
                                    if (number2 == 6) A6[6]++;
                                    for (i = 1; i <= 6; i++)
                                    {
                                        for (j = 1; j <= 6; j++)
                                        {
                                            if (i != j)
                                            {
                                                if (A6[i] >= A6[j]) B[i]++;
                                            }
                                        }
                                    }
                                    //Console.WriteLine("number1:{0}\n\n",number2);
                                    Console.Write("\n\n預測第{0}場:", total2 + 1);
                                    for (i = 1; i <= 6; i++)
                                    {
                                        if (B[i] == 5)
                                        {
                                            Console.Write("{0} ", i);
                                            C[k] = i;
                                            k++;
                                        }
                                    }
                                    for (i = 1; i <= 6; i++)
                                    {
                                        if (B[i] == 4)
                                        {
                                            Console.Write("{0} ", i);
                                            C[k] = i;
                                            k++;
                                        }
                                    }
                                    for (i = 1; i <= 6; i++)
                                    {
                                        if (B[i] == 3)
                                        {
                                            Console.Write("{0} ", i);
                                            C[k] = i;
                                            k++;
                                        }
                                    }
                                    Console.WriteLine("\n\n");
                            
                                }//if

                                number1 = number2;
                        
                            }//if Judge
                        }//if
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n請勿輸入非1~6的數\n\n\n");//判斷是否為數字
                        }

                    }//while
                }//if
            }
            
            

            

        }
    }
}
