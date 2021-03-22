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
            {
                Console.WriteLine("Задание №1 - Учет финансов.");
                Random r = new Random();
                int[,] parametrs = new int[2, 12];
                int[] profit = new int[12];
                string ouputFormat = "| {0, 8} | {1,17} | {2,17} | {3,17} |";
                Console.WriteLine(ouputFormat, "Месяц", "Доход, тыс. руб.", "Расход, тыс. руб.", "Прибыль, тыс.руб.");
                for (int i = 0; i < 12; i++)
                {
                    Month month = (Month)i;
                    parametrs[0, i] = r.Next(1, 20) * 1000;
                    parametrs[1, i] = r.Next(1, 20) * 1000;
                    profit[i] = parametrs[0, i] - parametrs[1, i];
                    Console.WriteLine(ouputFormat, FriendlyName.GetFriendlyMonthName(month), parametrs[0, i], parametrs[1, i], profit[i]);
                }
                int[] unsortedProfit = new int[12];
                Array.Copy(profit, unsortedProfit, 12);
                Array.Sort(profit);
                int[] minValues = new int[3];
                int minValue = profit[0];
                minValues[0] = minValue;
                int count = 1;
                int index = 0;
                while (count != 3)
                {
                    if (profit[index] != minValue)
                    {
                        minValues[count] = profit[index];
                        minValue = profit[index];
                        count++;
                    }
                    index++;
                }
                string badMonths = "";
                foreach (int i in minValues)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        if (i == unsortedProfit[j]) badMonths += FriendlyName.GetFriendlyMonthName((Month)j) + "; ";
                    }
                }
                count = 0;
                foreach (int i in unsortedProfit)
                {
                    if (i > 0) count++;
                }

                Console.WriteLine($"Худшая прибыль в месяцах: {badMonths}");
                Console.WriteLine($"Количество месяцев с положительной прибылью: {count}");
                Console.WriteLine("Нажмите любую клавишу..");
                Console.ReadLine();
                Console.Clear();
            } //Task 1:
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
                Console.WriteLine("Задание №2 - Треугольник Паскаля.");
                Console.WriteLine("Введите число для формирования треугольника Паскаля");
                int number = Convert.ToInt32(Console.ReadLine());
                int[] prevArray = new int[] { 1 };
                for (int i = 0; i < number; i++)
                {
                    int[] array = new int[i + 1];
                    for (int j = 0; j < i + 1; j++)
                    {
                        if (j == 0) array[j] = 1;
                        else if (j == i + 1) array[j] = 1;
                        else if (j == i) array[j] = 1;
                        else
                        {
                            array[j] = prevArray[j - 1] + prevArray[j];
                        }
                    }
                    foreach (int k in array)
                    {
                        Console.Write(k + " ");
                    }
                    Console.WriteLine();
                    prevArray = array;
                }
                Console.WriteLine("Нажмите любую клавишу..");
                Console.ReadLine();
                Console.Clear();
            } //Task 2:
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
            {
                {
                    Console.WriteLine("Задание №3.1 - Умножение матрицы на число.");
                    Console.WriteLine("Введите количество строк для формирования матрицы");
                    int row = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите количество столбцов для формирования матрицы");
                    int column = Convert.ToInt32(Console.ReadLine());
                    Random r = new Random();
                    int[,] matrix = new int[row, column];
                    Console.WriteLine("Матрица до преобразования:");
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < column; j++)
                        {
                            matrix[i, j] = r.Next(0, 10);
                            Console.Write("{0,3}", matrix[i, j]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("Введите множитель для матрицы");
                    int multiplier = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Матрица поcле преобразования:");
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < column; j++)
                        {
                            matrix[i, j] *= multiplier;
                            Console.Write("{0,3}", matrix[i, j]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("Нажмите любую клавишу..");
                    Console.ReadLine();
                    Console.Clear();
                }//Task 3.1:
                {
                    Console.WriteLine("Задание №3.2 - Сложение и разность двух матриц.");
                    Console.WriteLine("Сложение и разность двух матриц возможно только при одинаковой размерности матриц.");
                    Console.WriteLine("Введите количество строк для формирования матриц");
                    int row = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите количество столбцов для формирования матриц");
                    int column = Convert.ToInt32(Console.ReadLine());
                    if (column > 0 && row > 0)
                    {
                        Random r = new Random();
                        int[,] matrix1 = new int[row, column];
                        int[,] matrix2 = new int[row, column];
                        int[,] sumMatrix = new int[row, column];
                        int[,] diffMatrix = new int[row, column];
                        Console.WriteLine("Матрица A:");
                        for (int i = 0; i < row; i++)
                        {
                            for (int j = 0; j < column; j++)
                            {
                                matrix1[i, j] = r.Next(0, 10);
                                Console.Write("{0,3}", matrix1[i, j]);
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("Матрица B:");
                        for (int i = 0; i < row; i++)
                        {
                            for (int j = 0; j < column; j++)
                            {
                                matrix2[i, j] = r.Next(0, 10);
                                Console.Write("{0,3}", matrix2[i, j]);
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("Матрица суммы:");
                        for (int i = 0; i < row; i++)
                        {
                            for (int j = 0; j < column; j++)
                            {
                                sumMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                                Console.Write("{0,3}", sumMatrix[i, j]);
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("Матрица разности:");
                        for (int i = 0; i < row; i++)
                        {
                            for (int j = 0; j < column; j++)
                            {
                                diffMatrix[i, j] = matrix1[i, j] - matrix2[i, j];
                                Console.Write("{0,3}", diffMatrix[i, j]);
                            }
                            Console.WriteLine();
                        }

                        Console.WriteLine("Нажмите любую клавишу..");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Введенные данные не соответсвуют требованию мат. операции, работа вычислений завершена.");
                    }

                }//Task 3.2:
                {
                    Console.WriteLine("Задание №3.3 - Произведение двух матрицы.");
                    Console.WriteLine("Матрицы A и B могут быть перемножены, если они совместимы в том смысле, что число столбцов матрицы A равно числу строк B.");
                    Console.WriteLine("Введите количество строк для формирования матрицы A");
                    int rowA = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите количество столбцов для формирования матрицы А");
                    int columnA = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите количество строк для формирования матрицы B");
                    int rowB = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите количество столбцов для формирования матрицы B");
                    int columnB = Convert.ToInt32(Console.ReadLine());
                    if (columnA == rowB)
                    {
                        Random r = new Random();
                        int[,] matrix1 = new int[rowA, columnA];
                        int[,] matrix2 = new int[rowB, columnB];
                        int[,] multipliedMatrix = new int[rowA, columnB];
                        Console.WriteLine("Матрица A:");
                        for (int i = 0; i < rowA; i++)
                        {
                            for (int j = 0; j < columnA; j++)
                            {
                                matrix1[i, j] = r.Next(0, 10);
                                Console.Write("{0,3}", matrix1[i, j]);
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("Матрица B:");
                        for (int i = 0; i < rowB; i++)
                        {
                            for (int j = 0; j < columnB; j++)
                            {
                                matrix2[i, j] = r.Next(0, 10);
                                Console.Write("{0,3}", matrix2[i, j]);
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("Матрица произведения:");
                        for (int i = 0; i < rowA; i++)
                        {
                            for (int j = 0; j < columnB; j++)
                            {
                                for (int n = 0; n < columnA; n++)
                                {
                                    multipliedMatrix[i, j] += matrix1[i, n] * matrix2[n, j];
                                }
                                Console.Write("{0,3}", multipliedMatrix[i, j]);
                            }
                            Console.WriteLine();
                        }

                        Console.WriteLine("Нажмите любую клавишу..");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Введенные данные не соответсвуют требованию мат. операции, работа вычислений завершена.");
                    }
                }//Task 3.3:
            } //Task 3
        }
    }
}
