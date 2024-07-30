class LeetMath
{
    public static int GetDigit(int num , int pos)
    {
        return (int)(num / Math.Pow(10,pos)) %10 ;
    }

    public static int NumOfDigits(int num)
    {
        return (int)Math.Floor(MathF.Log10(num))+1;
    }

     
}