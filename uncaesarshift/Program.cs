using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;

namespace frequencyanalasis
{
    internal class Program
    {
        
        private static string Sad(string txt)
        {
            string cry = "";
            foreach (char c in txt)
            {
                if (c < 'A' || c > 'Z') continue;
                cry += c;
            }
            return cry;
        }
        static void Main(string[] args)
        {
            float[,] counts = new float[25, 255];
            int[] matches = new int[25];
            string txt = File.ReadAllText("J. K. Rowling - Harry Potter 1 - Sorcerer's Stone.txt");
            StringBuilder sb = new StringBuilder();
            foreach (char c in txt)
            {
                if (c < ' ' || c > 'ÿ') continue;
                sb.Append(c);
            }
            txt = sb.ToString();
            txt = "The late afternoon sun hung low in the sky as Harry and Hagrid made their way back down Diagon Alley, back through the wall, back through the Leaky Cauldron, now empty. Harry didn't speak at all as they walked down the road; he didn't even notice how much people were gawking at them on the Underground, laden as they were with all their funny-shaped packages, with the snowy owl asleep in its cage on Harry's lap. Up another escalator, out into Paddington station; Harry only realized where they were when Hagrid tapped him on the shoulder.";
            string txt1 = File.ReadAllText("J. K. Rowling - Harry Potter 1 - Sorcerer's Stone.txt");
            StringBuilder sb1 = new StringBuilder();
            foreach (char c in txt1)
            {
                if (c < ' ' || c > 'ÿ') continue;
                sb.Append(c);
            }

            txt1 = sb1.ToString();
            Random rand = new Random();
            int N = 5;
            string ciphertext = "";
            for (int i = 0; i < txt.Length; i++)
            {
                if (txt[i] == ' ')
                {
                    ciphertext += txt[i];
                    continue;
                }
                int num = txt[i] - 'A';
                num += N;
                num %= 26;
                ciphertext += (char)(num + 65);
            }
            int[] arr = new int[255];
            float[] arr1 = new float[255];
            foreach(var c in txt1)
            {
                arr[(int)c]++;
            }
            for(int i  = 0; i < arr.Length; i++)
            {
                Console.Write((char)(i) + "-");
                Console.WriteLine(arr[i] + "," + ((float)arr[i]/txt1.Length)*100 + "%");
                arr1[i] = ((float)arr[i] / txt1.Length) * 100;
            }
            for (int i = 0; i < 25; i++)
            {
                string pt = "";
                for (int j = 0; j < txt.Length; j++)
                {
                    if (ciphertext[i] == ' ')
                    {
                        pt += ciphertext[i];
                        continue;
                    }
                    int num = txt[i] - 'A';
                    num -= i+1;
                    num %= 26;
                    pt += (char)(num + 65);
                }
                foreach (var c in pt)
                {
                    counts[i,(int)c]+=1;
                }
                for (int j = 0; j < 25; j++)
                {
                    for(int k = 0; k < 255; k++)
                    {
                        counts[j,k] = ((float)counts[j,k] / txt.Length) * 100;
                    }
                }
            }
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 255; j++)
                {
                    if (counts[i, j] > arr1[64] - 1 && counts[i, j] < arr1[j] + 1)
                    {
                        matches[i]++;
                    }
                }
            }
            int correctval = matches.Max();
            string plaintext = string.Empty;
            for (int j = 0; j < ciphertext.Length; j++)
            {
                if (ciphertext[j] == ' ')
                {
                    plaintext += ' ';
                    continue;
                }
                int num = ciphertext[j] - 'A';
                num -= correctval;
                num %= 26;
                plaintext += (char)(num + 65);
            }
            Console.WriteLine(plaintext);
        }
    }
}
