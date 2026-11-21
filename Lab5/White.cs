using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class White
    {
        public double Task1(int[,] matrix)
        {
            double average = 0;

            // code here
            int sum = 0, count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > 0) { sum += matrix[i, j]; count++; }
            average = count == 0 ? 0 : (double)sum / count;
            // end

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;

            // code here
            int min = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] < min) { min = matrix[i, j]; row = i; col = j; }
            // end

            return (row, col);
        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            if (k < 0 || k >= matrix.GetLength(1)) return;
            int maxRow = 0;
            for (int i = 1; i < matrix.GetLength(0); i++)
                if (matrix[i, k] > matrix[maxRow, k]) maxRow = i;
            if (maxRow == 0) return;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int t = matrix[0, j];
                matrix[0, j] = matrix[maxRow, j];
                matrix[maxRow, j] = t;
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            int minRow = 0;
            for (int i = 1; i < rows; i++)
                if (matrix[i, 0] < matrix[minRow, 0]) minRow = i;
            answer = new int[rows - 1, cols];
            int r = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i == minRow) continue;
                for (int j = 0; j < cols; j++)
                    answer[r, j] = matrix[i, j];
                r++;
            }
            // end

            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                sum += matrix[i, i];
            // end

            return sum;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int firstNeg = -1, lastNeg = -1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] < 0)
                    {
                        if (firstNeg == -1) firstNeg = j;
                        lastNeg = j;
                    }
                if (firstNeg == -1 || firstNeg == 0) continue;
                int maxIdx = 0;
                for (int j = 1; j < firstNeg; j++)
                    if (matrix[i, j] > matrix[i, maxIdx]) maxIdx = j;
                int t = matrix[i, maxIdx];
                matrix[i, maxIdx] = matrix[i, lastNeg];
                matrix[i, lastNeg] = t;
            }
            // end

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] < 0) count++;
            if (count == 0) return null;
            negatives = new int[count];
            int idx = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] < 0) negatives[idx++] = matrix[i, j];
            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int len = matrix.GetLength(1);
                if (len == 1) continue;
                int maxIdx = 0;
                for (int j = 1; j < len; j++)
                    if (matrix[i, j] > matrix[i, maxIdx]) maxIdx = j;
                if (maxIdx == 0) matrix[i, 1] *= 2;
                else if (maxIdx == len - 1) matrix[i, len - 2] *= 2;
                else
                {
                    int left = matrix[i, maxIdx - 1], right = matrix[i, maxIdx + 1];
                    if (left <= right) matrix[i, maxIdx - 1] *= 2;
                    else matrix[i, maxIdx + 1] *= 2;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int cols = matrix.GetLength(1);
                for (int j = 0; j < cols / 2; j++)
                {
                    int t = matrix[i, j];
                    matrix[i, j] = matrix[i, cols - 1 - j];
                    matrix[i, cols - 1 - j] = t;
                }
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1)) return;
            for (int i = n / 2; i < n; i++)
                for (int j = 0; j <= i; j++)
                    matrix[i, j] = 1;
            // end

        }
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            int keep = 0;
            for (int i = 0; i < rows; i++)
            {
                bool hasZero = false;
                for (int j = 0; j < cols; j++)
                    if (matrix[i, j] == 0) { hasZero = true; break; }
                if (!hasZero) keep++;
            }
            answer = new int[keep, cols];
            int r = 0;
            for (int i = 0; i < rows; i++)
            {
                bool hasZero = false;
                for (int j = 0; j < cols; j++)
                    if (matrix[i, j] == 0) { hasZero = true; break; }
                if (hasZero) continue;
                for (int j = 0; j < cols; j++)
                    answer[r, j] = matrix[i, j];
                r++;
            }
            // end

            return answer;
        }
        public void Task12(int[][] array)
        {

            // code here
            for (int i = 1; i < array.Length; i++)
            {
                int[] cur = array[i];
                int curSum = 0;
                for (int k = 0; k < cur.Length; k++) curSum += cur[k];
                int j = i - 1;
                while (j >= 0)
                {
                    int prevSum = 0;
                    for (int k = 0; k < array[j].Length; k++) prevSum += array[j][k];
                    if (prevSum <= curSum) break;
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = cur;
            }
            // end

        }
    }
}
