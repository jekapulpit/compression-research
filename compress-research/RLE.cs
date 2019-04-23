using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compress_research
{
    class RLE
    {
        public string encode(string s)
        {
            StringBuilder sb = new StringBuilder();
            int count = 1;
            char current = s[0];
            for (int i = 1; i < s.Length; i++)
            {
                if (current == s[i])
                {
                    count++;
                }
                else
                {
                    sb.AppendFormat("{0}{1}", count, current);
                    count = 1;
                    current = s[i];
                }
            }
            sb.AppendFormat("{0}{1}", count, current);
            return sb.ToString();
        }
        public string decode(string s)
        {
            string a = "";
            int count = 0;
            StringBuilder sb = new StringBuilder();
            char current = char.MinValue;
            for (int i = 0; i < s.Length; i++)
            {
                current = s[i];
                if (char.IsDigit(current))
                    a += current;
                else
                {
                    count = int.Parse(a);
                    a = "";
                    for (int j = 0; j < count; j++)
                        sb.Append(current);
                }
            }
            return sb.ToString();
        }
    }
}
