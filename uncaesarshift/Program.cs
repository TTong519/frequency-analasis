using System.Runtime.Serialization;
using System.Text;

namespace frequencyanalasis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string txt = File.ReadAllText("bible.txt");
            StringBuilder sb = new StringBuilder();
            foreach (char c in txt)
            {
                if (c < ' ' || c > 'ÿ') continue;
                sb.Append(c);
            }
            txt = sb.ToString();
            Console.WriteLine("pls type text to frequency analasis");
            int[] arr = new int[255];
            foreach(var c in txt)
            {
                arr[(int)c]++;
            }
            for(int i  = 0; i < arr.Length; i++)
            {
                Console.Write((char)(i) + "-");
                Console.WriteLine(arr[i] + "," + ((float)arr[i]/txt.Length)*100 + "%");
            }
        }
    }
}
