using System.Reflection.Metadata.Ecma335;

namespace Leet;

public class RemoveDouplicateInSortedArray
{
    public (int, int[]) Run(int[] input)
    {
        int currIndex = -1;
        for (var i = 0; i < input.Length; i++)
        {
            if (currIndex < 0)
            {
                currIndex = i;
                continue;
            }
            else if (input[i] == input[currIndex])
            {

                continue;
            }
            else
            {
                currIndex++;
                var tmp = input[currIndex];

                input[currIndex] = input[i];
                input[i] = tmp;
            }
        }
        return (currIndex + 1, input);
    }
    public (int, int[]) Run2(int[] input)
    {
        if (input.Length < 2)
        {
            return (input.Length, input);
        }
        int j = 1;
        for (var i = 1; i < input.Length; i++)
        {
            if (input[i] != input[i - 1])
            {
                input[j] = input[i];
                j++;
            }

        }
        return (j, input);
    }
}
