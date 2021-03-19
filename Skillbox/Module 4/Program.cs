using System;
using Module_4.Enums;

namespace Module_4
{
    class Program
    {
        static void Main(string[] args)
        {
            {
            /* Задание 1.
            Заказчик просит вас написать приложение по учёту финансов
            и продемонстрировать его работу.
            Суть задачи в следующем: 
            Руководство фирмы по 12 месяцам ведет учет расходов и поступлений средств. 
            За год получены два массива – расходов и поступлений.
            Определить прибыли по месяцам
            Количество месяцев с положительной прибылью.
            Добавить возможность вывода трех худших показателей по месяцам, с худшей прибылью, 
            если есть несколько месяцев, в некоторых худшая прибыль совпала - вывести их все.
            Организовать дружелюбный интерфейс взаимодействия и вывода данных на экран

            Пример
                  
            Месяц      Доход, тыс. руб.  Расход, тыс. руб.     Прибыль, тыс. руб.
                1              100 000             80 000                 20 000
                2              120 000             90 000                 30 000
                3               80 000             70 000                 10 000
                4               70 000             70 000                      0
                5              100 000             80 000                 20 000
                6              200 000            120 000                 80 000
                7              130 000            140 000                -10 000
                8              150 000             65 000                 85 000
                9              190 000             90 000                100 000
               10              110 000             70 000                 40 000
               11              150 000            120 000                 30 000
               12              100 000             80 000                 20 000
            
            Худшая прибыль в месяцах: 7, 4, 1, 5, 12
            Месяцев с положительной прибылью: 10 */
            } //Task 1 summary

            Random r = new Random();
            int[,] parametrs = new int[2,12];
            int[] profit = new int[12];
            string ouputFormat = "| {0, 8} | {1,17} | {2,17} | {3,17} |";
            Console.WriteLine(ouputFormat, "Месяц", "Доход, тыс. руб.", "Расход, тыс. руб.", "Прибыль, тыс.руб.");
            for (int i = 0; i < parametrs.GetLength(1); i++)
            {
                Month month = (Month)i;
                parametrs[0, i] = r.Next(1, 20) * 1000;
                parametrs[1, i] = r.Next(1, 20) * 1000;
                profit[i] = parametrs[0, i] - parametrs[1, i];
                Console.WriteLine(ouputFormat, FriendlyName.GetFriendlyMonthName(month), parametrs[0, i], parametrs[1, i], profit[i]);
            }
            int[] unsortedProfit = new int[profit.Length];
            Array.Copy(profit, unsortedProfit, profit.Length);
            Array.Sort(profit);
            int[] minValues = new int[3];
            int minValue = profit[0];
            minValues[0] = minValue;
            int count = 1;
            int index = 0;
            while(count != 3)
            {
                if (profit[index] != minValue)
                {
                    minValues[count] = profit[index];
                    minValue = profit[index];
                    count++;
                }
                index++;
            }
            foreach (int i in minValues)
            {
                Console.WriteLine(i);
            }
            string badMonths = "";
            foreach (int i in minValues)
            {
                for (int j = 0; j<unsortedProfit.Length; j++)
                {
                    if (i == unsortedProfit[j]) badMonths += FriendlyName.GetFriendlyMonthName((Month)j) + "; ";
                }
            }
           count = 0;
           foreach(int i in unsortedProfit)
            {
                if (i > 0) count++;
            }

            //int nextMinValue = profit[0];
            //int index = 0;
            //int count = 2;
            //string badMonths = "";
            //string goodMonths = "";
            //while(count != 0)
            //{
            //    if(profit[index] == nextMinValue)
            //    {
            //        badMonths += FriendlyName.GetFriendlyMonthName((Month)Array.IndexOf(unsortedProfit, nextMinValue)) + "; ";
            //    }
            //    else
            //    {
            //        nextMinValue = profit[index];
            //        badMonths += FriendlyName.GetFriendlyMonthName((Month)Array.IndexOf(unsortedProfit, nextMinValue)) + "; ";
            //        count--;
            //    }
            //    index++;
            //}
            //foreach (int i in unsortedProfit)
            //{
            //    if (i > 0) goodMonths += FriendlyName.GetFriendlyMonthName((Month)Array.IndexOf(unsortedProfit, i)) + "; ";
            ////}
            Console.WriteLine($"Худшая прибыль в месяцах: {badMonths}");
            Console.WriteLine($"Количество месяцев с положительной прибылью: {count}");
            {
                /* Задание 2
                Заказчику требуется приложение строящее первых N строк треугольника паскаля. N < 25

                При N = 9. Треугольник выглядит следующим образом:
                                                1
                                            1       1
                                        1       2       1
                                    1       3       3       1
                                1       4       6       4       1
                            1       5      10      10       5       1
                        1       6      15      20      15       6       1
                    1       7      21      35      35       21      7       1


                Простое решение:                                                             
                1
                1       1
                1       2       1
                1       3       3       1
                1       4       6       4       1
                1       5      10      10       5       1
                1       6      15      20      15       6       1
                1       7      21      35      35       21      7       1

                Справка: https://ru.wikipedia.org/wiki/Треугольник_Паскаля */
            } //Task 2 summary


            {
                /* Задание 3.1
                Заказчику требуется приложение позволяющщее умножать математическую матрицу на число
                Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
                Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матрицы_на_число
                Добавить возможность ввода количество строк и столцов матрицы и число,
                на которое будет производиться умножение.
                Матрицы заполняются автоматически. 
                Если по введённым пользователем данным действие произвести невозможно - сообщить об этом

                Пример

                     |  1  3  5  |   |  5  15  25  |
                 5 х |  4  5  7  | = | 20  25  35  |
                     |  5  3  1  |   | 25  15   5  |


                ** Задание 3.2
                Заказчику требуется приложение позволяющщее складывать и вычитать математические матрицы
                Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
                Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Сложение_матриц
                Добавить возможность ввода количество строк и столцов матрицы.
                Матрицы заполняются автоматически
                Если по введённым пользователем данным действие произвести невозможно - сообщить об этом

                Пример
                 |  1  3  5  |   |  1  3  4  |   |  2   6   9  |
                 |  4  5  7  | + |  2  5  6  | = |  6  10  13  |
                 |  5  3  1  |   |  3  6  7  |   |  8   9   8  |


                 |  1  3  5  |   |  1  3  4  |   |  0   0   1  |
                 |  4  5  7  | - |  2  5  6  | = |  2   0   1  |
                 |  5  3  1  |   |  3  6  7  |   |  2  -3  -6  |

                *** Задание 3.3
                Заказчику требуется приложение позволяющщее перемножать математические матрицы
                Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
                Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матриц
                Добавить возможность ввода количество строк и столцов матрицы.
                Матрицы заполняются автоматически
                Если по введённым пользователем данным действие произвести нельзя - сообщить об этом

                 |  1  3  5  |   |  1  3  4  |   | 22  48  57  |
                 |  4  5  7  | х |  2  5  6  | = | 35  79  95  |
                 |  5  3  1  |   |  3  6  7  |   | 14  36  45  |

                                 | 4 |   
                 |  1  2  3  | х | 5 | = | 32 | 
                                 | 6 |  
                 */
            } //Task 3 summary
        }
    }
}
