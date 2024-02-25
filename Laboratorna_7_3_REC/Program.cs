using System;

public class Program
{
    static void Main()
    {
        int Low = -17;
        int High = 15;

        Console.Write("rowCount = ");
        int rowCount = int.Parse(Console.ReadLine());

        Console.Write("colCount = ");
        int colCount = int.Parse(Console.ReadLine());

        int[][] a = new int[rowCount][];
        for (int i = 0; i < rowCount; i++)
            a[i] = new int[colCount];

        Input(a, rowCount, colCount, 0, 0);
        Print(a, rowCount, colCount, 0, 0);

        SortColumnsByCharacteristic(a, rowCount, colCount, 0);
        Console.WriteLine("Matrix after sorting columns by characteristic:");
        Print(a, rowCount, colCount, 0, 0);

        int sum = SumOfColumnsWithNegativeElement(a, rowCount, colCount, 0, 0);
        Console.WriteLine("Sum of elements in columns with at least one negative element: " + sum);
    }

    public static void Input(int[][] a, int rowCount, int colCount, int i, int j)
    {
        if (i < rowCount)
        {
            if (j < colCount)
            {
                Console.Write($"a[{i}][{j}] = ");
                a[i][j] = int.Parse(Console.ReadLine());
                Input(a, rowCount, colCount, i, j + 1);
            }
            else
            {
                Console.WriteLine();
                Input(a, rowCount, colCount, i + 1, 0);
            }
        }
    }

    public static void Print(int[][] a, int rowCount, int colCount, int i, int j)
    {
        if (i < rowCount)
        {
            if (j < colCount)
            {
                Console.Write($"{a[i][j],4}");
                Print(a, rowCount, colCount, i, j + 1);
            }
            else
            {
                Console.WriteLine();
                Print(a, rowCount, colCount, i + 1, 0);
            }
        }
    }

    public static void SortColumnsByCharacteristic(int[][] a, int rowCount, int colCount, int j)
{
    if (j < colCount)
    {
        int sum = CalculateSum(a, rowCount, 0, j, 0);
        int minIndex = FindMinIndex(a, rowCount, colCount, j + 1, j + 1, sum, j);

        if (minIndex < colCount)
        {
            SwapColumns(a, rowCount, j, minIndex, 0);
            SortColumnsByCharacteristic(a, rowCount, colCount, j + 1);
        }
    }
}

public static int FindMinIndex(int[][] a, int rowCount, int colCount, int i, int k, int minSum, int minIndex)
{
    if (i < rowCount)
    {
        if (k < colCount)
        {
            int currentSum = CalculateSum(a, rowCount, 0, k, 0);
            if (currentSum < minSum)
            {
                minSum = currentSum;
                minIndex = k;
            }
            return FindMinIndex(a, rowCount, colCount, i, k + 1, minSum, minIndex);
        }
        return FindMinIndex(a, rowCount, colCount, i + 1, k + 1, minSum, minIndex);
    }

    return minIndex;
}


    public static int CalculateSum(int[][] a, int rowCount, int i, int j, int currentSum)
    {
        if (i < rowCount)
        {
            currentSum += (a[i][j] < 0 && a[i][j] % 2 != 0) ? Math.Abs(a[i][j]) : 0;
            return CalculateSum(a, rowCount, i + 1, j, currentSum);
        }
        return currentSum;
    }

    public static void SwapColumns(int[][] a, int rowCount, int col1, int col2, int i)
    {
        if (i < rowCount)
        {
            (a[i][col1], a[i][col2]) = (a[i][col2], a[i][col1]);
            SwapColumns(a, rowCount, col1, col2, i + 1);
        }
    }

    public static int SumOfColumnsWithNegativeElement(int[][] a, int rowCount, int colCount, int j, int sum)
    {
        if (j < colCount)
        {
            bool hasNegativeElement = CheckForNegativeElement(a, rowCount, 0, j);
            if (hasNegativeElement)
            {
                sum += CalculateColumnSum(a, rowCount, 0, j, 0);
            }

            return SumOfColumnsWithNegativeElement(a, rowCount, colCount, j + 1, sum);
        }
        return sum;
    }

    public static bool CheckForNegativeElement(int[][] a, int rowCount, int i, int j)
    {
        if (i < rowCount)
        {
            if (a[i][j] < 0)
            {
                return true;
            }
            return CheckForNegativeElement(a, rowCount, i + 1, j);
        }
        return false;
    }

    public static int CalculateColumnSum(int[][] a, int rowCount, int i, int j, int currentSum)
    {
        if (i < rowCount)
        {
            currentSum += a[i][j];
            return CalculateColumnSum(a, rowCount, i + 1, j, currentSum);
        }
        return currentSum;
    }
}
