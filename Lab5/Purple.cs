using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            
            answer = new int[matrix.GetLength(1)];
            int g = 0;
            int k = 0;
            for (int i = 0; i<matrix.GetLength(1); i++)
            {
                for (int j = 0; j<matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0)
                        g++;
                }
                answer[k]=g;
                k++;
                g=0;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int minIndex = 0;
                int minValue = matrix[i, 0];

                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < minValue)
                    {
                        minValue = matrix[i, j];
                        minIndex = j;
                    }
                }

                if (minIndex == 0) continue;

                int temp = matrix[i, minIndex];

                for (int j = minIndex; j > 0; j--)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }

                matrix[i, 0] = temp;
            }

            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] result = new int[rows, cols + 1];

            for (int i = 0; i < rows; i++)
            {
                int maxIndex = 0;
                int maxValue = matrix[i, 0];

                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }

                for (int j = 0; j <= maxIndex; j++)
                {
                    result[i, j] = matrix[i, j];
                }

                result[i, maxIndex + 1] = maxValue;

                for (int j = maxIndex + 1; j < cols; j++)
                {
                    result[i, j + 1] = matrix[i, j];
                }
            }

            answer = result;  

            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here

            int n = matrix.GetLength(0);
            int k = matrix.GetLength(1);


            for (int i = 0; i < n; i++)
            {
                int mx = -100000000;
                for (int j = 0; j < k; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                    }
                }
                int index = -1;
                for (int j = 0; j < k; j++)
                {
                    if (matrix[i, j] == mx)
                    {
                        index = j;
                        break;
                    }
                }
                int sum = 0;
                int count = 0;
                for (int j = index + 1; j < k; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
                if (count > 0)
                {
                    int srzn = sum / count;
                    for (int j = 0; j < index; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = srzn;
                        }
                    }
                }
            }
            
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (k < 0 || k >= cols) return;

            int[] maxElements = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int max = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                maxElements[rows - 1 - i] = max; 
            }

            for (int i = 0; i < rows; i++)
            {
                matrix[i, k] = maxElements[i];
            }
        

            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here

            if (matrix.GetLength(1) == array.Length)
            {
                int k = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int maximum = int.MinValue;
                    int index = 0;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (matrix[i, j] > maximum)
                        {
                            maximum = matrix[i, j];
                            index = i;
                        }
                    }
                    if (array[k] > maximum)
                    {
                        matrix[index, j] = array[k];
                    }
                    k++;
                }
            }
        

            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] minElements = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int min = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
                minElements[i] = min;
            }

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - 1 - i; j++)
                {
                    if (minElements[j] < minElements[j + 1])
                    {
                        int tempMin = minElements[j];
                        minElements[j] = minElements[j + 1];
                        minElements[j + 1] = tempMin;

                        for (int k = 0; k < cols; k++)
                        {
                            int temp = matrix[j, k];
                            matrix[j, k] = matrix[j + 1, k];
                            matrix[j + 1, k] = temp;
                        }
                    }
                }
            }
        

            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here


            if (matrix == null) return null;

            int n = matrix.GetLength(0);

            if (n != matrix.GetLength(1)) return null;

            answer = new int[2 * n - 1];


            for (int d = 0; d < answer.Length; d++)
            {
                int sum = 0;


                if (d < n)
                {
                    int startRow = n - 1 - d;
                    int startCol = 0;

                    for (int i = 0; i <= d; i++)
                    {
                        int row = startRow + i;
                        int col = startCol + i;
                        if (row < n && col < n)
                        {
                            sum += matrix[row, col];
                        }
                    }
                }
                else
                {
                    int startRow = 0;
                    int startCol = d - n + 1;
                    
                    for (int i = 0; i < 2 * n - 1 - d; i++)
                    {
                        int row = startRow + i;
                        int col = startCol + i;
                        if (row < n && col < n)
                        {
                            sum += matrix[row, col];
                        }
                    }
                }

            answer[d] = sum;
            }
            
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n == m)
            {

                int mx = -10000000;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (Math.Abs(matrix[i, j]) > mx)
                        {
                            mx = Math.Abs(matrix[i, j]);
                        }
                    }
                }
                int ti = -1;
                int tj = -1;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (Math.Abs(matrix[i, j]) == mx)
                        {
                            ti = i;
                            tj = j;
                            break;
                        }
                    }
                    if (ti != -1) break;
                }
                if (ti != k)
                {

                    if (ti < k)
                    {
                        for (int i = ti; i < k; i++)
                        {
                            for (int j = 0; j < m; j++)
                            {
                                (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                            }
                        }
                    }
                    else
                    {
                        for (int i = ti; i > k; i--)
                        {
                            for (int j = 0; j < m; j++)
                            {
                                (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                            }
                        }

                    }
                }
                if (tj != k)
                {
                    if (tj < k)
                    {

                        for (int j = tj; j < k; j++)
                        {
                            for (int i = 0; i < n; i++)
                            {
                                (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                            }
                        }
                    }
                    else
                    {
                        for (int j = tj; j > k; j--)
                        {
                            for (int i = 0; i < n; i++)
                            {
                                (matrix[i, j], matrix[i, j - 1]) = (matrix[i, j - 1], matrix[i, j]);
                            }
                        }
                    }
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here

            if (A == null || B == null) 
                return null;
            
            int n1 = A.GetLength(0);
            int m1 = A.GetLength(1);
            int n2 = B.GetLength(0);
            int m2 = B.GetLength(1);

            if (m1 == n2)
            {
                answer = new int[n1, m2];
                for (int i = 0; i < n1; i++)
                {
                    for (int j = 0; j < m2; j++)
                    {
                        for (int k = 0; k < n2; k++)
                        {
                            answer[i, j] += A[i, k] * B[k, j];
                        }
                    }
                }
            }
            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new int[n][];
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] <= 0)
                    {
                        count++;
                    }
                }
                answer[i] = new int[m - count];
                int l = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][l++] = matrix[i, j];
                    }
                }
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here

            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                count += array[i].Length;
            }
            int[] vr = new int[count];
            int u = 0;
            foreach (int[] to in array)
            {
                foreach (int t in to)
                {
                    vr[u++] = t;
                }
            }
            int n = (int)Math.Ceiling(Math.Sqrt(count));
            answer = new int[n, n];
            int l = 0;
            for (int i = 0; i < n && l < count; i++)
            {
                for (int j = 0; j < n && l < count; j++)
                {
                    answer[i, j] = vr[l];
                    l++;
                }
            }

            // end

            return answer;
        }
    }

}

