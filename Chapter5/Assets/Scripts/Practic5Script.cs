using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;
using System.Linq;
using System.Reflection;
using UnityEditor;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class Practic5Script : MonoBehaviour
{
    public void OnSumEvenNumbersInRange()
    {
        ClearLog();
        int minRangeIndex = 7;
        int maxRangeIndex = 21;
        var want = 98;
        int got = SumEvenNumbersInRange(minRangeIndex, maxRangeIndex);
        string massage = want == got ? "Результат верный" : $"Результат неверный. Ожидается {want}";
        Debug.Log($"Сумма четных числе в диапазоне от {minRangeIndex} до {maxRangeIndex} включительно: {got} - {massage}");
    }

    private int SumEvenNumbersInRange(int minRangeIndex, int maxRangeIndex)
    {
        int summNumbers = 0;
        int numberInRange;

        for (int i = minRangeIndex; i < maxRangeIndex + 1; i++)
        {
            numberInRange = i;
            if (numberInRange % 2 == 0)
            {
                summNumbers = summNumbers + numberInRange;
            }
        }
        if (summNumbers > 0)
        {
            return summNumbers;
        }
        else
        {
            return 0;
        }
    }

    public void OnSumEvenNumbersInArray()
    {
        ClearLog();
        int[] numbers = { 81, 22, 13, 54, 10, 34, 15, 26, 71, 68 };
        var want = 214;
        int got = SumEvenNumbersInArray(numbers);
        string massage = want == got ? "Результат верный" : $"Результат неверный. Ожидается {want}";
        Debug.LogFormat("Задан массив {0}", "[" + string.Join(",", numbers) + "]");
        Debug.Log($"Сумма четных чисел в заданном массива = {got} - {massage}");
    }

    private int SumEvenNumbersInArray(int[] numbers)
    {
        int sumEvenNumbers = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] % 2 == 0)
            {
                sumEvenNumbers = sumEvenNumbers + numbers[i];
            }
        }
        if (sumEvenNumbers > 0)
        {
            return sumEvenNumbers;
        }
        else
        {
            return 0;
        }

    }

    public void OnSearchFirstOccurrence()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        ClearLog();
        int deciredNumber = 81;
        int[] arrayOfSearch = new int[10000];
        Random rand = new Random();
        for (int i = 0; i < arrayOfSearch.Length; i++)
        {
            arrayOfSearch[i] = rand.Next(100);
        }
        int want = 3;
        Debug.LogFormat("Задан массив {0}", "[" + string.Join(",", arrayOfSearch) + "]");
        int got = SearchFirstOccurrence(arrayOfSearch, deciredNumber);
        if (got != -1)
        {
            Debug.Log($"Индекс первого вхождения числа {deciredNumber} в массив: {got}");
        }
        else
        {
            Debug.Log($"Индекс первого вхождения числа {deciredNumber} в массив: {got}. Число отсутствует в заданном массиве!");
        }
        stopwatch.Stop();
        Debug.Log(stopwatch.ElapsedMilliseconds);
    }

    private int SearchFirstOccurrence(int[] array, int deciredNumber)
    {
        int deciredIndex = -1;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == deciredNumber)
            {
                deciredIndex = i;
                //break;
            }
        }
        if (deciredIndex != -1)
        {
            return deciredIndex;
        }
        else
        {
            return -1;
        }



    }

    public void OnSelectionSort()
    {
        ClearLog();
        int[] unsortedArray = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        Debug.LogFormat("Исходный массив {0}", "[" + string.Join(",", unsortedArray) + "]");
        int[] sortedArray = SelectionSort((int[])unsortedArray.Clone());
        Debug.LogFormat("Отсортированный массив {0}", "[" + string.Join(",", sortedArray) + "]");
        int[] expectedArray = { 10, 13, 15, 22, 26, 34, 34, 68, 71, 81 };
        Debug.Log(sortedArray.SequenceEqual(expectedArray) ? "Результат верный" : "Результат не верный");
    }

    private int[] SelectionSort(int[] unsortedArray)
    {
        int min, temp; // i, j - индексы массива и подмассива, min - индекс минимального значения в массиве, temp - временная переменная для перестановки значений в массиве местами
        int[] sortArray = unsortedArray;
        for (int i = 0; i < unsortedArray.Length - 1; i++)
        {
            min = i;
            for (int j = i + 1; j < sortArray.Length; j++)
            {
                if(sortArray[j] < sortArray[min])
                {
                    min = j;
                }
            }
            temp = sortArray[i];
            sortArray[i] = sortArray[min];
            sortArray[min] = temp;
        }
        return sortArray;
    }

    public static void ClearLog()
    {
        Assembly assembly = Assembly.GetAssembly(typeof(SceneView));
        Type type = assembly.GetType("UnityEditor.LogEntries");
        MethodInfo method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }

}
