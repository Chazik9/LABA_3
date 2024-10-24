using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_Z1
{
    internal class Number_1
    {
        static void Main(string[] args)
        {
            double a = 0.2;//Начало диапазона x
            double b = 1.0;//Конец диапазона x
            const int n = 10;//Количество членов ряда
            const double e = 0.0001;//Заданная точность
            double step = (b - a) / 10;//Шаг x

            double An;//n элемент послед-ти
            double Sn;//сумма ряда с n членами
            double Se;//сумма ряда с точность e

            Console.WriteLine($"X\t\tSn(n={n})\tSe(e = {e})\tY");
            //Подсчёт суммы для заданного кол-во элементов
            for (double x = a; x < b; x += step)//Перебор элементов с заданным шагом
            {
                An = (x - 1) / (x + 1);//0 элемент послед-ти
                Sn = An;//начинаем подсчёт суммы
                for (int i = 0; i < n; i++)//Подсчёт суммы при n членах ряда
                {
                    An *= (Math.Pow((x - 1) / (x + 1), 2)) * ((2.0 * i + 1) / (2.0 * i + 3));//рекуррентное соотношение
                    Sn += An;
                }
                //Подсчёт суммы для заданной точности
                An = (x - 1) / (x + 1);//0 элемент послед-ти
                Se = An; ;//начинаем подсчёт суммы 
                int j = 0;
                do
                {
                    An *= (Math.Pow((x - 1) / (x + 1), 2)) * ((2.0 * j + 1) / (2.0 * j + 3));//рекуррентное соотношение
                    Se += An;
                    j++;
                } while (Math.Abs(An) > e);//условия цикла
                double Y = Math.Log(x) * 1 / 2;//Подсчёт точного значения
                Console.WriteLine($"X = {x:F2}\tSn = {Sn:F5}\tSe = {Se:F5}\tY = {Y:F5}");
            }
        }
    }
}
