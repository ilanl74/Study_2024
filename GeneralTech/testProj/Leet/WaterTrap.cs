using System.Diagnostics;
using System.Globalization;

namespace Leet;
//Leet 42  Trapping Rain Water
public class WaterTrap
{
    public int Trap1(int[] height)
    {//need to cuver case where height[0]==0
        int rTop = -1;
        int lTop = 0;
        int calcPoint = 1;
        int currVal = 0;
        int[] complementry = new int[height.Length];
        for (var i = 1; i < height.Length; i++)
        {

            if (height[i - 1] < height[i])
            {
                if (i - lTop > 1)
                    calcPoint++;
                if (calcPoint % 2 == 0)
                {
                    rTop = i;
                }
                else
                {
                    rTop = i;

                }
                if (rTop < 0)
                    continue;
                if (height[rTop] >= height[lTop])
                {
                    FillWater(height, complementry, lTop, rTop, height[lTop]);
                    lTop = rTop;
                    rTop = -1;

                }
                else
                {
                    FillWater(height, complementry, lTop, rTop, height[rTop]);
                    rTop = -1;
                }
                currVal = height[i];

            }





        }
        int ans = 0;
        for (var i = 1; i < complementry.Length; i++)
        {
            ans += complementry[i];

        }
        return ans;
    }

    private void FillWater(int[] height, int[] complementry, int lTop, int rTop, int v)
    {
        for (var i = lTop + 1; i < rTop; i++)
        {
            if (height[i] < v)
            {
                complementry[i] += v - height[i];
                height[i] = v;

            }

        }
    }

    public int Trap(int[] height)
    {
        int len = height.Length;
        int[] lMax = new int[len];
        int[] rMax = new int[len];
        lMax[0] = height[0];
        int ans = 0;
        for (var i = 1; i < len; i++)
        {
            lMax[i] = Math.Max(lMax[i - 1], height[i]);
        }
        rMax[len - 1] = height[len - 1];
        for (var i = len - 2; i >= 0; i--)
        {
            rMax[i] = Math.Max(rMax[i + 1], height[i]);
        }
        for (var i = 1; i < len; i++)
        {
            ans += Math.Min(rMax[i], lMax[i]) - height[i];
        }
        return ans;
    }
}
