namespace Divide_and_Conquer;

public class MatMul
{
    public int[,]? Cubic(int[][] x, int[][] y)
    {
        int l = y.Length;
        if (l != x[0].Length) return null;
        
        int n = x.Length;
        int m = y[0].Length;
        
        int[,] ret = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int t = 0;
                for (int k = 0; k < l; k++)
                    t += x[i][k] * y[k][j];

                ret[i, j] = t;
            }
        }

        return ret;
    }

    public int[][]? Strassen(int[][] x, int[][] y)
    {
        
        return new int[x.Length][];
    }
}