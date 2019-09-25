using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Find Characters count in Array of strings
            //ReadArrayValues();

            //find object keys
            findkeyvalues();

            //Reverse String
            //ReverseStringSplit();
            //ReverseStringWithoutSplit();

            // Remove Duplicate strings in array
            //ReadDuplicateArrayValues();

            Console.ReadLine();

        }

        #region Find Characters count in Array of strings
        static void ReadArrayValues()
        {
            Console.WriteLine("Enter array length");
            int arraycount = Convert.ToInt32(Console.ReadLine());
            string[] arrvals = new string[arraycount];
            Console.WriteLine("Enter values");
            for (int i = 0; i < arraycount; i++)
            {
                string s = Console.ReadLine();
                arrvals[i] = s;
            }
            Dictionary<char, int> result = FindCharsCount(arrvals);
            foreach (var item in result)
            {
                Console.WriteLine(item.Key+" : "+ item.Value);
            }
        }

        static Dictionary<char, int> FindCharsCount(string[] arr)
        {
            Dictionary<char,int> dictChars= new Dictionary<char, int>();
            
            foreach (string item in arr)
            {
                string s = item;
                while (s.Length > 0)
                {
                    int count = 0;
                    for (int j = 0; j < s.Length; j++)
                    {
                        if (s[0] == s[j])
                        {
                            count++;
                        }
                    }
                    
                    if (dictChars.ContainsKey(s[0]))
                    {
                        int charcount = dictChars[s[0]] + count;
                        dictChars[s[0]] = charcount;
                    }
                    else
                    {
                        dictChars.Add(s[0], count);
                    }


                    s = s.Replace(s[0].ToString(), string.Empty);
                }
            }
            return dictChars;
        }

        #endregion

        #region All the keys present in an object

        static void findkeyvalues()
        {
            Console.WriteLine("Enter object values");
            object obj = (object) Console.ReadLine();
            Console.WriteLine(obj);

            var properties = GetProperties(obj);

            foreach (var p in properties)
            {
                string name = p.Name;
                var value = p.GetValue(obj);
            }

        }

        private static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }

        #endregion

        #region  Reverse every word of a string.

        static void ReverseStringSplit()
        {
            Console.WriteLine("Enter reverse string");
            string s = Console.ReadLine();
            char splitword = ' ';
            string strReverse = "";
            string[] strArr = s.Split(splitword);
            for(int i = 0; i < strArr.Length; i++)
            {
                char[] strword = strArr[i].ToCharArray();
                Array.Reverse(strword);
                if (strReverse == "")
                    strReverse = new string(strword);
                else
                    strReverse = strReverse+" "+ new string(strword);
            }
            Console.WriteLine("Reverse strings is:- "+ strReverse);
        }

        static void ReverseStringWithoutSplit()
        {
            Console.WriteLine("Enter reverse string");
            string s = Console.ReadLine();            
            string strReverse = "";

            string strtemp = "";
            for(int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (c == ' ')
                {
                    for(int j = strtemp.Length - 1; j >= 0; j--)
                    {
                        strReverse = strReverse + strtemp[j];
                    }
                    strReverse = strReverse + " ";
                    strtemp = "";
                }

                strtemp = strtemp + c.ToString();

                if (i == s.Length - 1)
                {
                    for (int j = strtemp.Length - 1; j >= 0; j--)
                    {
                        strReverse = strReverse + strtemp[j];
                    }
                    strtemp = "";
                }           
            }

            Console.WriteLine("Reverse strings is:- " + strReverse);
        }

        #endregion

        #region Remove Duplicate strings from Array

        static void ReadDuplicateArrayValues()
        {
            Console.WriteLine("Enter array length");
            int arraycount = Convert.ToInt32(Console.ReadLine());
            string[] dupsarr = new string[arraycount];
            Console.WriteLine("Enter values");
            for (int i = 0; i < arraycount; i++)
            {
                string s = Console.ReadLine();
                dupsarr[i] = s;
            }
            List<string> duparr = RemoveDuplicates(dupsarr);
            Console.WriteLine("Final Array Values");
            for (int i = 0; i < duparr.Count; i++)
            {
                Console.WriteLine(duparr[i]);
            }
        }

        static List<string> RemoveDuplicates(string[] arr)
        {
            List<string> DuplicateArray = new List<string>();

            for(int i = 0; i < arr.Length; i++)
            {
                string s = arr[i];
                int dupscount = 0;
                for(int j = 0; j < arr.Length; j++)
                {
                    if(s == arr[j])
                    {
                        dupscount++;
                    }
                    if(j== arr.Length - 1)
                    {
                        if (dupscount == 1)
                        {
                            DuplicateArray.Add(s);                            
                        }
                    }
                }
            }

            return DuplicateArray;
        }

        #endregion
    }
}
