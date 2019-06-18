﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Сахаров Иван
Переделать программу Пример использования коллекций для решения следующих задач:
а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (*частотный
массив);
в) отсортировать список по возрасту студента;
г) *отсортировать список по курсу и возрасту студента;*/

namespace HW6_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int bakalavr = 0;
            int magistr = 0;
            int[] courses = {0,0,0,0,0,0};
            // Создадим необобщенный список
            ArrayList list = new ArrayList();
            // Запомним время в начале обработки данных
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader(@"C:\students.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    // Console.WriteLine("{0}", s[0], s[1], s[2], s[3], s[4]);
                    list.Add(s[1] + " " + s[0]);// Добавляем склееные имя и фамилию
                    if(int.Parse(s[2])>=18 && int.Parse(s[2]) <= 20)
                    {   int course = int.Parse(s[3]);
                        switch (course)
                        {
                            case 1:
                                courses[course - 1] += 1;
                                break;
                            case 2:
                                courses[course - 1] += 1;
                                break;
                            case 3:
                                courses[course - 1] += 1;
                                break;
                            case 4:
                                courses[course - 1] += 1;
                                break;
                            case 5:
                                courses[course - 1] += 1;
                                break;
                            case 6:
                                courses[course - 1] += 1;
                                break;
                        }


                    }
                    if (int.Parse(s[3]) < 5) bakalavr++; else magistr++;
                }
                catch

                {
                }
            }
            sr.Close();
            list.Sort();
            Console.WriteLine("Всего студентов:{0}", list.Count);
            Console.WriteLine("Магистров:{0}", magistr);
            Console.WriteLine("Бакалавров:{0}", bakalavr);
            Console.WriteLine("Студентов учащихся на 5 и 6 курсах:{0}", magistr);
            Console.WriteLine("Количество студентов в ворзарсте от 18 до 20 по курсам:");
            for (int i = 0; i < courses.Length; i++)
            {
                if(courses[i] != 0)
                {
                    Console.WriteLine($"Куср {i+1}: {courses[i]}");
                }

            }
            //foreach (var v in list) Console.WriteLine(v);
            // Вычислим время обработки данных
            Console.WriteLine(DateTime.Now - dt);
            Console.ReadKey();
        }
    }
}
