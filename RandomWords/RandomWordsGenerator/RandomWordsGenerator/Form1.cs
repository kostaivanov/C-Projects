using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace RandomWordsGenerator
{
    public partial class RandomWordsForm : Form
    {

        public RandomWordsForm()
        {
            InitializeComponent();
        }
        List<string> result = new List<string>();

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            List<string> listWords = InputField.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            GenerateField.Clear();
            for (int i = 0; i < 5; i++)
            {
                var idx = new Random().Next(0, listWords.Count);


                if (result.Count != result.Distinct().Count())
                {
                    MessageBox.Show("Contains duplicates");
                    continue;
                }
                string word = listWords[idx];
                result.Add(word);
                this.GenerateField.Text += $"Hello World!" + result[i];
                //GenerateField.Text = result[i];
                GenerateField.AppendText(Environment.NewLine);
                word = String.Empty;
            }

        }
        //public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        //{
        //    T[] elements = source.ToArray();
        //    for (int i = elements.Length - 1; i >= 0; i--)
        //    {
        //        // Swap element "i" with a random earlier element it (or itself)
        //        // ... except we don't really need to swap it fully, as we can
        //        // return it immediately, and afterwards it's irrelevant.
        //        int swapIndex = rng.Next(i + 1);
        //        yield return elements[swapIndex];
        //        elements[swapIndex] = elements[i];
        //    }
        //}
    }
}
