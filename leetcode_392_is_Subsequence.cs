bool IsSubsequence(string s, string t)
{
     int ind = 0;
     for (int i = 0; i < t.Length && ind < s.Length; i++)
     {
          if (t[i] == s[ind])
          {
               ++ind;
          }
     }
     return ind == s.Length;
}