namespace Divide_and_Conquer;

public class Memokeria
{
    public int Search(int[] nums, int target) // works
    {
        int left = 0;
        int right = nums.Length;
        int index = 0;
        while(right >= left){
            index = ((right + left) / 2);
            if (index >= nums.Length) break;
            if (nums[index] == target)
                return index;
            if (nums[index] > target)
                right = index - 1;
            if (nums[index] < target)
                left = index + 1;
        }
        return -1;
    }
    
    public bool DivisorGame(int n) //??
    {
        if (n < 2)
            return false;

        bool[] dp = new bool[n + 1];
        dp[0] = false;
        dp[1] = false;

        for (int i = 2; i <= n; i++)
            for (int x = i - 1; x > 0; x--)
                    if (i % x == 0)
                    {
                        dp[i] = !dp[i - x];
                        if (dp[i]) break;
                    }

        return dp[n];
    }
    
    public long MaxPoints(int[][] points)
    {
        return 0;
    }
    
    Dictionary<int, int> FibDP = new Dictionary<int, int>();
    public int Fib(int n) // works
    {
        switch (n)
        {
            case 0:
                return 0;
            case 1:
                return 1;
        }

        if (!FibDP.ContainsKey(n - 1))
            FibDP.Add(n - 1, Fib(n - 1));
        if (!FibDP.ContainsKey(n - 2))
            FibDP.Add(n - 1, Fib(n - 2));
        return FibDP[n - 1] + FibDP[n - 2];
    }
    
    public int MinCostClimbingStairs(int[] cost) //works
    {
        int[] dp = new int[cost.Length + 1];
        dp[0] = 0;
        dp[1] = 0;
        
        for (int i = 2; i <= cost.Length; i++)
            dp[i] = Math.Min(cost[i - 1] + dp[i - 1], cost[i - 2] + dp[i - 2]);

        return dp[cost.Length];
    }
    
    public int NumRescueBoats(int[] people, int limit) // works
    {
        Array.Sort(people);

        int boatCounter = 0;
        int counter = 0;

        int left = 0;
        int right = people.Length - 1;

        while (right >= left)
        {
            boatCounter++;
            if (people[left] + people[right] <= limit)
                left++;
            right--;
        }
        return boatCounter;
    }
    
    public bool JudgeSquareSum(int c) // works
    {
        for (long i = 0; i * i <= c; i++)
        {
            double b = Math.Sqrt(c - (i * i));
            if (b %1 == 0)
                return true;
        }

        return false;
    }
    
    public bool IsPerfectSquare(int num) // works
    {
        long sum = 0;
        long i = 1;
        while (sum < num)
        {
            sum += i;
            i += 2;
        }
        
        return sum == num;
    }
    
    private Dictionary<(int, int), int> DPStoneGame = new Dictionary<(int, int), int>();
    public int DiffStoneGame(int[] piles, int start, int end)
    {
        if (start == end)
            return piles[start];
        
        if (!DPStoneGame.ContainsKey((start + 1, end)))
            DPStoneGame.Add((start + 1, end), DiffStoneGame(piles, start + 1, end));
        
        if (!DPStoneGame.ContainsKey((start, end - 1)))
            DPStoneGame.Add((start, end - 1), DiffStoneGame(piles, start, end - 1));
        
        return Math.Max(piles[start] - DPStoneGame[(start + 1, end)],
            piles[end] - DPStoneGame[(start, end - 1)]);
    }
    public bool StoneGame(int[] piles) // works
    {
        return DiffStoneGame(piles, 0, piles.Length - 1) > 0;
    }
    
    public int SearchInsert(int[] nums, int target) // works
    {
        int left = 0;
        int right = nums.Length - 1;
        int mid = 0;
        while (left < right)
        {
            mid = left + (right - left) / 2;

            if (nums[mid] == target)
                return mid;
            if (nums[mid] > target)
                right = mid - 1;
            if (nums[mid] < target)
                left = mid + 1;
        }

        return nums[left] > target ? left : left + 1;
    }
    
    public int PeakIndexInMountainArray(int[] arr) // works
    {
        int left = 0;
        int right = arr.Length - 1;
        while (left < right)
        {
            int mid = (right + left) / 2;
            if (arr[mid] < arr[mid + 1])
                left = mid + 1;
            else
                right = mid;
        }

        return left;
        
        // int left = 0;
        // int right = arr.Length - 1;
        // int mid = left;
        // while (left < right)
        // {
        //     mid = (right + left) / 2;
        //
        //     if (arr[mid - 1] < arr[mid] && arr[mid] > arr[mid + 1])
        //         return mid;
        //     if (arr[mid - 1] < arr[mid] && arr[mid] < arr[mid + 1])
        //         left = mid + 1;
        //     if (arr[mid - 1] > arr[mid] && arr[mid] > arr[mid + 1])
        //         right = mid + 1;
        // }
        //
        // return mid;
    }
    
    public int FindPeakElement(int[] nums) //works
    {
        int left = 0;
        int right = nums.Length - 1;
        
        while (left < right)
        {
            int mid = (right + left) / 2;
            if (nums[mid] < nums[mid + 1])
                left = mid + 1;
            else
                right = mid;
        }

        return left;
    }
    
    public int[] FindPeakGrid(int[][] mat)
    {

        int top = 0;
        int bottom = mat.Length - 1;
        
        return new int[] {0, 0};
    }
    
    public int CountPrimes(int n) // TLE
    {
        int[] x = new int[n];
        for (int i = 2; i < n; i++)
            x[i] = i;

        int count = 0;
        
        for (int i = 2; i < n; i++)
        {
            if (x[i] == 0) continue;
            count++;
            for (int j = i + 1; j < n; j++)
            {
                if (x[j] % x[i] == 0)
                    x[j] = 0;
            }
        }

        return count;
    }
}

