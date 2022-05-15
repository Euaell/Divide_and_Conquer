namespace Divide_and_Conquer;

public class Karatsuba
{
    public static void PrintArr(IEnumerable<int>? arr)
    {
        if (arr == null) return;
        foreach (var va in arr)
            Console.Write($"{va} ");
        Console.WriteLine();
    }

    public static void PrintMat(int[][]? mat)
    {
        if (mat == null) return;
        foreach (var t in mat)
        {
            foreach (var s in t)
                Console.Write($" {s} ");
            Console.WriteLine();
        }
        Console.WriteLine();

    }

    public static string Multiply(string first, string second)
    {
        if (first.Length == 1 || second.Length == 1)
            return (int.Parse(first) * int.Parse(second)).ToString();
        int cutPos = GetCutPosition(first, second);
        string a = GetFirstPart(first, cutPos);
        string b = GetSecondPart(first, cutPos);
        string c = GetFirstPart(second, cutPos);
        string d = GetSecondPart(second, cutPos);
        string ac = Multiply(a, c);
        string bd = Multiply(b, d);
        string ab_cd = Multiply(StringAddition(a,b), StringAddition(c,d));
        return CalculateResult(ac, bd, ab_cd, b.Length + d.Length);
    }

    private static string CalculateResult(string ac, string bd, string ab_cd, int padding)
    {
        string term0 = StringSubtraction(StringSubtraction(ab_cd, ac), bd);
        string term1 = term0.PadRight(term0.Length + padding / 2, '0');
        string term2 = ac.PadRight(ac.Length + padding, '0');
        return StringAddition(StringAddition(term1, term2), bd);
    }

    private static string GetFirstPart(string str, int cutPos)
    {
        return str.Remove(str.Length - cutPos);
    }

    private static string GetSecondPart(string str, int cutPos)
    {
        return str[^cutPos..];
    }

    private static int GetCutPosition(string first, string second)
    {
        int min = Math.Min(first.Length, second.Length);
        if (min == 1)
            return 1;
        if (min % 2 == 0)
            return min / 2;
        return min / 2 + 1;
    }

    private static string StringAddition(string a, string b)
    {
        string result = "";
        //a is always the smallest in length
        if (a.Length > b.Length)
        {
            Swap(ref a, ref b);
        }            
        a = a.PadLeft(b.Length, '0');
        int length = a.Length;
        int carry = 0, res;
        for (int i = length-1; i >= 0; i--)
        {
            int num1 = int.Parse(a.Substring(i, 1));
            int num2 = int.Parse(b.Substring(i, 1));
            res = (num1 + num2 + carry) % 10;
            carry = (num1 + num2 + carry) / 10;
            result = result.Insert(0, res.ToString());
        }
        if (carry != 0)
            result = result.Insert(0, carry.ToString());
        return SanitizeResult(result);
    }

    private static string StringSubtraction(string a, string b)
    {
        bool resultNegative = false;
        string result = "";
        //a should be the larger number
        if (StringIsSmaller(a,b))
        {
            Swap(ref a, ref b);
            resultNegative = true;
        }
        b = b.PadLeft(a.Length, '0');
        int length = a.Length;
        int carry = 0, res;
        for (int i = length - 1; i >= 0; i--)
        {
            bool nextCarry = false;
            int num1 = int.Parse(a.Substring(i, 1));
            int num2 = int.Parse(b.Substring(i, 1));
            if(num1-carry < num2)
            {
                num1 = num1 + 10;
                nextCarry = true;
            }
            res = (num1 - num2 - carry);
            result = result.Insert(0, res.ToString());
            if (nextCarry)
                carry = 1;
            else
                carry = 0;
        }
        result = SanitizeResult(result);
        if (resultNegative)
            return result.Insert(0, "-");
        return result;
    }

    private static bool StringIsSmaller(string a, string b)
    {
        if (a.Length < b.Length)
            return true;
        if (a.Length > b.Length)
            return false;
        char[] arrayA = a.ToCharArray();
        char[] arrayB = b.ToCharArray();
        for(int i = 0; i < arrayA.Length; i++)
        {
            if (arrayA[i] < arrayB[i])
                return true;
            if (arrayA[i] > arrayB[i])
                return false;
        }
        return false;
    }

    private static void Swap(ref string a, ref string b)
    {
        (a, b) = (b, a);
    }

    private static string SanitizeResult(string result)
    {
        result = result.TrimStart(new [] { '0' });
        if (result.Length == 0)
            result = "0";
        return result;
    }
    
    public void BubbleSort(ref int[] arr, ref int v)
    {
        Console.WriteLine("Bubble Sorting ...");
        for (var i = 0; i < arr.Length; i++)
        for (var j = i; j < arr.Length; j++)
        {
            if (arr[i] > arr[j])
            {
                (arr[i], arr[j]) = (arr[j], arr[i]);
                v++;
            }
        }
    }

// "MergeSort" and "CountInversion"
    public int Inv = 0;
    private int[] Merge(int[] arr1, int[] arr2)
    {
        var n = arr1.Length + arr2.Length;
        var res = new int[n];
        for (int i = 0, j = 0, k = 0; i < n; i++)
        {
            if (j >= arr1.Length)
            {
                res[i] = arr2[k++];
            }
            else if (k >= arr2.Length)
            {
                res[i] = arr1[j++];
            }
            else if (j < arr1.Length && k < arr2.Length)
            {
                if (arr1[j] <= arr2[k])
                    res[i] = arr1[j++];
                else
                {
                    res[i] = arr2[k++];
                    // count inversion for every element in the second array that is less than the first array's elements
                    Inv += arr1.Length - j;
                    Console.Write($"res[i]: {res[i]} Inv: {Inv}");
                    
                }
            }
        }
        Console.WriteLine();
        return res;
    }

    public int[] MergeSort(int[] arr)
    {
        var n = arr.Length;
        return n <= 1 ? arr : Merge(MergeSort(arr[..(n / 2)]), MergeSort(arr[(n / 2)..]));
    }
}