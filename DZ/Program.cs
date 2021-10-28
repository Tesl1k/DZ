using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ
{

    class Drob2
    {
        int ch;
        int zn;
        int result;

        public delegate void ChangeDrob(Drob2 drob, int num);

        public event ChangeDrob Change1;

        public event ChangeDrob Change2;


        public int Ch
        {
            get
            {
                return ch; 
            }

            set
            {
                if (Change1 != null)
                {
                    Change1(this, value);
                }

                ch = value;                          

            }
        }

        public int Zn
        {
            get
            {
                return zn;
            }

            set
            {
                if (Change2 != null)
                {
                    Change2(this, value);
                }

                zn = value;
                
            }
        }

        public Drob2(int num)
        {
            Ch = num;
            Zn = 1;
        }

        public Drob2(int ch, int zn)
        {
            Ch = ch;
            Zn = zn;
        }

        public Drob2(int num, int ch, int zn)
        {
            Ch = zn * num + ch;
            Zn = zn;
        }

        public static Drob2 operator +(Drob2 drob1, Drob2 drob2)
        {
            int ob1 = drob1.Zn * drob2.Zn;
            int ob2 = drob1.Zn * drob2.Zn;

            int newChislitel1 = ob1 / drob1.Zn * drob1.Ch;
            int newChislitel2 = ob1 / drob2.Zn * drob2.Ch;

            int ch1 = newChislitel1 + newChislitel2;
            int ch2 = newChislitel1 + newChislitel2;

            int max;

            if (ch2 == 0)
            {
                max = ob2;
            }

            if (ch2 == ob2)
            {
                max = ch2;
            }

            else
            {
                while (ob2 != 0)
                {
                    if (ch2 > ob2)
                    {
                        ch2 -= ob2;
                    }

                    else
                    {
                        ob2 -= ch2;
                    }
                }

                max = ch2;

            }

            return new Drob2(ch1 / max, ob1 / max);
        }

        public static Drob2 operator -(Drob2 drob1, Drob2 drob2)
        {
            int ob1 = drob1.Zn * drob2.Zn;
            int ob2 = drob1.Zn * drob2.Zn;

            int newChislitel1 = ob1 / drob1.Zn * drob1.Ch;
            int newChislitel2 = ob1 / drob2.Zn * drob2.Ch;

            int ch1 = newChislitel1 - newChislitel2;
            int ch2 = newChislitel1 - newChislitel2;

            int max;

            if (ch2 == 0)
            {
                max = ob2;
            }

            if (ch2 == ob2)
            {
                max = ch2;
            }

            else
            {
                while (ob2 != 0)
                {
                    if (ch2 > ob2)
                    {
                        ch2 -= ob2;
                    }

                    else
                    {
                        ob2 -= ch2;
                    }
                }

                max = ch2;

            }

            return new Drob2(ch1 / max, ob1 / max);
        }

        public static Drob2 operator *(Drob2 drob1, Drob2 drob2)
        {
            int ch1 = drob1.Ch * drob2.Ch;
            int ch2 = drob1.Ch * drob2.Ch;

            int zn1 = drob1.Zn * drob2.Zn;
            int zn2 = drob1.Zn * drob2.Zn;

            int max;

            if (ch2 == zn2)
            {
                max = ch2;
            }

            else
            {
                while (zn2 != 0)
                {
                    if (ch2 > zn2)
                    {
                        ch2 -= zn2;
                    }

                    else
                    {
                        zn2 -= ch2;
                    }
                }

                max = ch2;

            }

            return new Drob2(ch1 / max, zn1 / max);
        }

        public static Drob2 operator /(Drob2 drob1, Drob2 drob2)
        {
            int ch1 = drob1.Ch * drob2.Zn;
            int ch2 = drob1.Ch * drob2.Zn;

            int zn1 = drob1.Zn * drob2.Ch;
            int zn2 = drob1.Zn * drob2.Ch;

            int max;

            if (ch2 == zn2)
            {
                max = ch2;
            }

            else
            {
                while (zn2 != 0)
                {
                    if (ch2 > zn2)
                    {
                        ch2 -= zn2;
                    }

                    else
                    {
                        zn2 -= ch2;
                    }
                }

                max = ch2;

            }

            return new Drob2(ch1 / max, zn1 / max);
        }

        int a;

        public int this[int index]
        {
            get
            {
                if(index == 0)
                {
                    a = ch;
                }
                if(index == 1)
                {
                    a = zn;
                }

                return a;
            }           
        }

        public double Result(Drob2 drob)
        {
            double result = (double)drob.Ch / (double)drob.Zn;
            return result;
        }

        public string Znak(Drob2 drob)
        {
            if (drob.Ch * drob.Zn > 0)
            {
                return "Дробь 3 положительна";
            }
            if (drob.Ch * drob.Zn < 0)
            {
                return "Дробь 3 отрицательна";
            }
            else
            {
                return "Дробь 3 равна нулю";
            }

        }


    }

    class Program
    {
        public static void Main(string[] args)
        {


            Drob2 drob1 = new Drob2(1, 2, 3);
            Drob2 drob2 = new Drob2(1);
            Drob2 drob3 = new Drob2(-3, 2);

            Console.WriteLine($"Дробь 1: {drob1.Ch}/{drob1.Zn}");
            Console.WriteLine($"Дробь 2: {drob2.Ch}/{drob2.Zn}");
            Console.WriteLine($"Дробь 3: {drob3.Result(drob3)}");
            Console.WriteLine(drob3.Znak(drob3));


            Drob2 result1 = drob1 + drob2;
            Drob2 result2 = drob1 - drob2;
            Drob2 result3 = drob1 * drob2;
            Drob2 result4 = drob1 / drob2;            

            Console.WriteLine($"Сумма дробей равна: {result1.Ch}/{result1.Zn}");
            Console.WriteLine($"Разность дробей равна: {result2.Ch}/{result2.Zn}");
            Console.WriteLine($"Произведение дробей равно: {result3.Ch}/{result3.Zn}");
            Console.WriteLine($"Отношение дробей равно: {result4.Ch}/{result4.Zn}");

            Console.WriteLine(drob1[0]);
            Console.WriteLine(drob1[1]);

            drob1.Change1 += ChangeDrob1;
            drob1.Change2 += ChangeDrob2;

            drob1.Ch = 1;
            drob1.Zn = 1;

            Console.ReadKey();
        }

        public static void ChangeDrob1(Drob2 drob, int num)
        {
            Console.WriteLine("Числитель изменён");
        }

        public static void ChangeDrob2(Drob2 drob, int num)
        {
            Console.WriteLine("Знаменатель изменён");
        }

    }
}
