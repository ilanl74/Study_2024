public class Palindrome
{
    //9. Palindrome Number
    /*
    Example 1:

    Input: x = 121
    Output: true
    Explanation: 121 reads as 121 from left to right and from right to left.
    Example 2:

    Input: x = -121
    Output: false
    Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
    Example 3:

    Input: x = 10
    Output: false
    Explanation: Reads 01 from right to left. Therefore it is not a palindrome.
    */
    public static bool IsPalindrome(int x)
    {
        if (x < 0)
            return false;
        if (x == 0)
            return true;
        var numOfDigit = LeetMath.NumOfDigits(x);
        return RecIsPalindrome(x, numOfDigit - 1, 0);
    }
    private static bool RecIsPalindrome(int x, int lPos, int rPos)
    {
        if (lPos == rPos || lPos < rPos)
            return true;




        if (LeetMath.GetDigit(x, lPos) == LeetMath.GetDigit(x, rPos))
            return RecIsPalindrome(x, lPos - 1, rPos + 1);
        else
            return false;




    }

    public bool IsPalindromeBetter(int x)
    {
        // Special cases:
        // As discussed above, when x < 0, x is not a palindrome.
        // Also if the last digit of the number is 0, in order to be a
        // palindrome, the first digit of the number also needs to be 0. Only 0
        // satisfy this property.
        if (x < 0 || (x % 10 == 0 && x != 0))
        {
            return false;
        }

        int revertedNumber = 0;
        while (x > revertedNumber)// this is the heart of the solution where x is getting smaller and reverted number is getting bigger  
        // x is the left side of the number and reverseNumber is the right side 
        {
            revertedNumber = revertedNumber * 10 + x % 10;
            x /= 10;
        }

        // When the length is an odd number, we can get rid of the middle digit
        // by revertedNumber/10 For example when the input is 12321, at the end
        // of the while loop we get x = 12, revertedNumber = 123, since the
        // middle digit doesn't matter in palidrome(it will always equal to
        // itself), we can simply get rid of it.
        return x == revertedNumber || x == revertedNumber / 10;// this /10 is for the odd digits number input 
    }

}
