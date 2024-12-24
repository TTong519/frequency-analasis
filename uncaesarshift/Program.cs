using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;

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
            float[,] counts = new float[26, 255];
            int[] matches = new int[26];
            string plaintext = File.ReadAllText("J. K. Rowling - Harry Potter 1 - Sorcerer's Stone.txt");
            StringBuilder sb = new StringBuilder();
            foreach (char c in plaintext)
            {
                if (c < ' ' || c > 'z') continue;
                sb.Append(c);
            }
            plaintext = sb.ToString();
            plaintext = "The late afternoon sun hung low in the sky as Harry and Hagrid made their way back down Diagon Alley, back through the wall, back through the Leaky Cauldron, now empty. Harry didn't speak at all as they walked down the road; he didn't even notice how much people were gawking at them on the Underground, laden as they were with all their funny-shaped packages, with the snowy owl asleep in its cage on Harry's lap. Up another escalator, out into Paddington station; Harry only realized where they were when Hagrid tapped him on the shoulder.".ToUpper();
            string txt1 = File.ReadAllText("words_alpha.txt");
            plaintext = Sad(plaintext);
            HashSet<string> dictionary = new HashSet<string>();
            string[] strings = txt1.Split((char)13);
            foreach(string s in strings)
            {
                dictionary.Add(s);
            }
            string ciphertext = "";
            for (int i = 0; i < plaintext.Length; i++)
            {
                if (plaintext[i] == ' ')
                {
                    ciphertext += plaintext[i];
                    continue;
                }
                int num = plaintext[i] - 'A';
                num += 5;
                num %= 26;
                ciphertext += (char)(num + 65);
            }
            Console.WriteLine(ciphertext);
            int N = 0;
            for (; N < 26; N++)
            {
                string daf = "";
                for (int i = 0; i < plaintext.Length; i++)
                {
                    if (plaintext[i] == ' ')
                    {
                        daf += plaintext[i];
                        continue;
                    }
                    int num = plaintext[i] - 'A';
                    num += N;
                    num %= 26;
                    daf += (char)(num + 65);
                }
                string[] words = daf.Split(' ');
                foreach (string word in words)
                {
                    if(dictionary.Contains(word))
                    {
                        matches[N]++;
                    }
                }
            }
            int max = matches.Max();
            for(int i = 0; i < matches.Length; i++)
            {
                if (matches[i] == max)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}
