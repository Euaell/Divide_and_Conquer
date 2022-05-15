using Divide_and_Conquer;

int[] arr1 = {9, 2, 4, 8, 5, 6, 6, 7, 3, 1, 8};
int[] x = { 2, 4, 5, 8};
int[] y = { 1, 3, 6, 7, 9};
int[] a = {1};
int[] b = { 3, 2, 1, 6, 4, 5};
var c = new[] {6, 5, 4, 3, 2, 1};
var d = new[] {1, 3, 5, 2, 4, 6};

// string[] inp = File.ReadAllLines("../../../Array.txt");
// int[] iInp = new int[inp.Length];
// for (int i = 0; i < inp.Length; i++)
//     iInp[i] = int.Parse(inp[i]);
// Karatsuba.PrintArr(iInp);

// string g = "3141592653589793238462643383279502884197169399375105820974944592";
// string h = "2718281828459045235360287471352662497757247093699959574966967627";
// Console.WriteLine(Karatsuba.Multiply(g, h));

// Karatsuba x1 = new Karatsuba();
// x1.MergeSort(c);
// Console.WriteLine(x1.Inv);

// points = [[1,3],[-2,2]], k = 1
// points = [[3,3],[5,-1],[-2,4]], k = 2
// int[][] t1 = {new[] {3, 3}, new[] {5, -1}, new[] {-2, 4}};
// int[][] t2 = {new[] {1, 3}, new[] {-2, 2}};
// Memokeria m1 = new Memokeria();
// Karatsuba.PrintMat(m1.KClosest(t1, 2));