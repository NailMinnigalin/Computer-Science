﻿namespace ComputerScience.DataStructures.Applications
{
    public static class HashSetApplications
    {
        public static bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> set = new HashSet<int>(nums);

            return set.Count != nums.Length;
        }


    }
}