using System;
using System.Collections.Generic;

namespace Assignment
{
    public class StudentSolution : IAssignment
    {
        #region Lecture

        public int LCT01_SequentialSearch1DArray()
        {
            int[] array = new int[] { 34, 21, 56, 12, 78, 90, 11, 23 };
            int target = 90;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public int[] LCT02_SequentialSearch2DArray()
        {
            int[,] array = new int[,]
            {
                { 34, 21, 56 },
                { 12, 78, 90 },
                { 11, 23, 45 }
            };
            int target = 23;
            int row = -1;
            int col = -1;

            for (int r = 0; r < array.GetLength(0); r++)
            {
                for (int c = 0; c < array.GetLength(1); c++)
                {
                    if (array[r, c] == target)
                    {
                        row = r;
                        col = c;
                    }
                }
            }

            return new int[] { row, col };
        }

        public int LCT03_BinarySearch()
        {
            int[] array = new int[] { 11, 12, 21, 23, 34, 45, 56, 78, 90 };
            int target = 23;
            int index = -1;

            int start = 0;
            int end = array.Length - 1;

            while (start <= end)
            {
                int middle = (start + end) / 2;

                if (array[middle] == target)
                {
                    index = middle;
                    break;
                }

                if (array[middle] < target)
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }

            return index;
        }

        #endregion

        #region Assignment

        public int[] AS01_FindFirstAndLastElementOfArray(int[] array, int target)
        {
            int firstIndex = -1;
            int lastIndex = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    if (firstIndex == -1)
                    {
                        firstIndex = i;
                    }

                    lastIndex = i;
                }
            }

            if (firstIndex == -1)
            {
                return new int[] { -1 };
            }

            return new int[] { firstIndex, lastIndex };
        }

        public int AS02_FindMaxLessThan(int[] array, int target)
        {
            int result = -1;
            bool found = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < target)
                {
                    if (!found || array[i] > result)
                    {
                        result = array[i];
                        found = true;
                    }
                }
            }

            return found ? result : -1;
        }

        public int[] AS03_FindRange(int[] array, int min, int max)
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= min && array[i] <= max)
                {
                    numbers.Add(array[i]);
                }
            }

            return numbers.ToArray();
        }

        #endregion

        #region Extra

        public int[] EX01_FindTargetEnemies(int[] enemyHPs, int mana)
        {
            int[] hpList = (int[])enemyHPs.Clone();

            for (int i = 0; i < hpList.Length - 1; i++)
            {
                for (int j = 0; j < hpList.Length - 1 - i; j++)
                {
                    if (hpList[j] > hpList[j + 1])
                    {
                        int temp = hpList[j];
                        hpList[j] = hpList[j + 1];
                        hpList[j + 1] = temp;
                    }
                }
            }

            List<int> targets = new List<int>();
            int usedMana = 0;

            for (int i = 0; i < hpList.Length; i++)
            {
                if (hpList[i] >= 0 && usedMana + hpList[i] <= mana)
                {
                    usedMana += hpList[i];
                    targets.Add(hpList[i]);
                }
            }

            return targets.ToArray();
        }

        #endregion
    }
}
