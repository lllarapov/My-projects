using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region описание домашнего задания
// Требуется написать несколько методов // Это твой код ?
//
// Задание 1.
// Воспользовавшись решением задания 3 четвертого модуля
// 1.1. Создать метод, принимающий число и матрицу, возвращающий матрицу умноженную на число
// 1.2. Создать метод, принимающий две матрицу, возвращающий их сумму
// 1.3. Создать метод, принимающий две матрицу, возвращающий их произведение
//
// Задание 2.
// 1. Создать метод, принимающий  текст и возвращающий слово, содержащее минимальное количество букв
// 2.* Создать метод, принимающий  текст и возвращающий слово(слова) с максимальным количеством букв
// Примечание: слова в тексте могут быть разделены символами (пробелом, точкой, запятой)
// Пример: Текст: "A ББ ВВВ ГГГГ ДДДД  ДД ЕЕ ЖЖ ЗЗЗ"
// 1. Ответ: А
// 2. ГГГГ, ДДДД
//
// Задание 3. Создать метод, принимающий текст.
// Результатом работы метода должен быть новый текст, в котором
// удалены все кратные рядом стоящие символы, оставив по одному
// Пример: ПППОООГГГООООДДДААА >>> ПОГОДА
// Пример: Ххххоооорррооошшшиий деееннннь >>> хороший день
//
// Задание 4. Написать метод принимающий некоторое количесво чисел, выяснить
// является заданная последовательность элементами арифметической или геометрической прогрессии
//
// Примечание
//             http://ru.wikipedia.org/wiki/Арифметическая_прогрессия
//             http://ru.wikipedia.org/wiki/Геометрическая_прогрессия
//
// *Задание 5
// Вычислить, используя рекурсию, функцию Аккермана:
// A(2, 5), A(1, 2)
// A(n, m) = m + 1, если n = 0,
//         = A(n - 1, 1), если n <> 0, m = 0,
//         = A(n - 1, A(n, m - 1)), если n> 0, m > 0.
//
// Весь код должен быть откоммментирован
#endregion


// Задание 3. Создать метод, принимающий текст.
// Результатом работы метода должен быть новый текст, в котором
// удалены все кратные рядом стоящие символы, оставив по одному
// Пример: ПППОООГГГООООДДДААА >>> ПОГОДА
// Пример: Ххххоооорррооошшшиий деееннннь >>> хороший день

namespace Example_005
{

    class Program
    {
        public static string Word(string text)
        {
            char[] ChText = new char[text.Length];

            for (int i = 0; i <= text.Length; i++)
            {
                ChText[i] = text[i];
            }


            for(int i = 0; i <= ChText.Length; i++)
            {
                if (ChText[i] == ChText[i + 1])
                {
                    ChText[i] = ChText[i+1];
                }
            }

            return text;
        }

        #region Задание_4
        /// <summary>
        /// Метод проверяет является ли заданная последовательность чисел элементами арифметической или геометрической прогрессии
        /// </summary>
        /// <param name="numbers">последовательность чисел</param>
        /// <returns></returns>

        public static string CheckNumb(params double[] numbers)
        {
            // d - Это шаг или разность ( + или - )
            double d;

            // q - Это знаменатель прогрессии
            double q;

            bool Arithmetic_Progression = false;
            bool Geometric_Progression = false;

            string result = "1";

            //Является ли заданная последовательность чисел элементами арифметической прогрессии?
            d = numbers[0] - numbers[1];

            //Проверка на разность ( - минус)
            for (int i = 0; i < numbers.Length-1; i++)
            {
                if (d != numbers[i] - numbers[i + 1])
                {
                    Arithmetic_Progression = false;
                    break;
                }
                else
                {
                    Arithmetic_Progression = true;
                }
            }

            //Проверка на шаг (+ плюс)
            d = numbers[1] - numbers[0];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (d != numbers[i+1] - numbers[i])
                {
                    Arithmetic_Progression = false;
                    break;
                }
                else
                {
                    Arithmetic_Progression = true;
                }
            }

            //Является ли заданная последовательность чисел элементами геометрической прогрессии?

            q = numbers[1] / numbers[0];
            for(int i = 0; i < numbers.Length - 1; i++)
            {
                if(q != numbers[i+1] / numbers[i])
                {
                    Geometric_Progression = false;
                    break;
                }
                else
                {
                    Geometric_Progression = true;
                }
            }

            //Выводим результат
            string DecInc;
            if (d < 0) DecInc = "убывающая";
            else DecInc = "возрастающая";

            if (Arithmetic_Progression == false) result = "Это не арифметическая прогрессия";
            else result = $"Это {DecInc} арифметическая прогрессия с шагом {d}";
            if (Arithmetic_Progression == false && Geometric_Progression == false) result = "Это не арифметическая и не геометрическая прогрессия";
            if (Arithmetic_Progression && Geometric_Progression && d == 0 && q==1) result = $"Это стационарная арифметическая прогрессия с разностью {d} \nи стационарная геометрическая прогрессия с знаменателем {q}";
            if (Geometric_Progression == true && q < 0) result = $"Это знакочередующаяся геометрическая прогрессия \nзнаменатель = {q}";
            if (Geometric_Progression == true && Arithmetic_Progression == false) result = $"Это геометрическая прогрессия \nзнаменатель = {q}";

            return result;
        }
        #endregion


        static void Main(string[] args)
        {

            Console.WriteLine(Word("Ххххххооооооооорррррооооооооошшшшшшиииииииийййййй ддддддееееееннннььььь"));

            //#region Задание_4
            //double[] Chisla = new double[5];

            //Chisla[0] = 25;
            //Chisla[1] = 50;
            //Chisla[2] = 100;
            //Chisla[3] = 200;
            //Chisla[4] = 400;

            //Console.WriteLine("Введены числа: ");

            //for (int i=0; i < Chisla.Length; i++)
            //{
            //    Console.Write(Chisla[i] + " ");
            //}

            //Console.Write("\n");
            //Console.WriteLine(CheckNumb(Chisla));
            //Console.ReadLine();
            //#endregion
        }
    }
}
