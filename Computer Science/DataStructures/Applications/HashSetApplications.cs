using System.Collections.Generic;

namespace ComputerScience.DataStructures.Applications
{
    public class HashSetApplications
    {
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> set = new HashSet<int>(nums);

            return set.Count != nums.Length;
        }

        public int SingleNumber(int[] nums)
        {
            int result = 0;
            foreach (int num in nums)
            {
                result ^= num;
            }
            return result;
        }

        public int[] Intersection(int[] nums1, int[] nums2)
        {
            return nums1.Intersect(nums2).ToArray();
        }

        public bool IsHappy(int n)
        {
            HashSet<int> seenNumbers = new HashSet<int>();

            while (n != 1 && !seenNumbers.Contains(n))
            {
                seenNumbers.Add(n);
                n = GetSumOfSquares(n);
            }

            return n == 1;
        }

        private int GetSumOfSquares(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                int digit = number % 10;
                sum += digit * digit;
                number /= 10;
            }
            return sum;
        }
    }
}
