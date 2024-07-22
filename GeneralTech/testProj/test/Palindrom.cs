public class Palindrome
{
public static bool IsPalindrome(int x) {
        if (x < 0 )
            return false;
        if (x==0)
            return true;
        var numOfDigit = LeetMath.NumOfDigits(x);  
        return RecIsPalindrome( x,numOfDigit-1,0);
     }
     private static bool RecIsPalindrome(int x,int lPos,int rPos)
    {
        if (lPos == rPos || lPos < rPos)
            return true;
        
        
            
        
        if  ( LeetMath.GetDigit(x,lPos) == LeetMath.GetDigit(x,rPos))
            return RecIsPalindrome(x,lPos-1,rPos+1);
        else
            return false;

        
        
        
    }
}
