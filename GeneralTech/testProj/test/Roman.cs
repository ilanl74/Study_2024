public class Roman
{
    private static Dictionary<char,int> Symbols => new Dictionary<char, int>(){{'I',1},{'V',5},{'X',10},{'L',50},{'C',100},{'D',500},{'M',1000}};
    public int RomanToInt(string s) {
        int res=0;
        int preSymbol =0;
        for (var i=s.Length-1;i>-1;i--){
            var dig = Symbols[s[i]];
            if (dig >= preSymbol || preSymbol==0){
                res+=dig;
            }
            else {
                res -= dig ; 
            }
            preSymbol = dig;
        }
        return res;
    }
}