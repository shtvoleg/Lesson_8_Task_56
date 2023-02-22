// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка


int[,] FillArray(int[,] matr, int lBound, int hBound)           //  работа с матрицей - наполнение случайными целыми числами в заданном диапазоне
{
    for (int i = 0; i < matr.GetLength(0); i++)
        for (int j = 0; j < matr.GetLength(1); j++)
            matr[i, j] = new Random().Next(lBound, hBound);
    return matr;
}

int[] WorkArray(int[,] matr, int[] res)                         //  работа с матрицей - поиск строки с наименьшей суммой элементов
{
    for (int i = 0; i < matr.GetLength(0); i++)                 //  цикл по строкам
    {
        int iSum = 0;                                           //  сумма по строке
        for (int j = 0; j < matr.GetLength(1); j++)             //  цикл по столбцам
            iSum += matr[i,j];                                  //  расчет суммы по строке i
        if ( iSum < res[1] )                                    //  если сумма по строке i меньше результата, ...
            {
                res[0] = i;                                     //  ... то запомнить номер строки (i) и сумму по ней
                res[1] = iSum;
            }    
    }                
    return res;                                                //  возврат результата
}

void PrintArray(int[,] matr)                                    //  форматированный вывод матрицы в консоль с нумерацией строк
{
    for (int i = 0; i < matr.GetLength(0); i++)
        {
            Console.WriteLine();
            Console.Write($"\t{i+1})");
            for (int j = 0; j < matr.GetLength(1); j++)
                Console.Write("\t" + matr[i, j]);
        }        
}

Console.Clear();				                                //  очистка консоли
int[] result = {0,99999};                                       //  результат обработки матрицы
Console.WriteLine("Введите размерность по вертикали m: ");	    //  запрос размерности матрицы по вертикали
int m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите размерность по горизонтали n: ");	//  запрос размерности матрицы по вертикали
int n = Convert.ToInt32(Console.ReadLine());
int[,] matrix = new int[m, n];
FillArray(matrix, 1, 100);                                      //  работа с массивом - наполнение случайными целыми числами в заданном диапазоне (от 1 до 100)
PrintArray(matrix);                                             //  вывод исходной матрицы, заполненной случайным образом, в консоль
WorkArray(matrix, result);                                      //  работа с матрицей
Console.WriteLine($"\nНомер строки с наименьшей суммой элементов: {result[0]+1}. Сумма элементов в указанной строке: {result[1]}.");