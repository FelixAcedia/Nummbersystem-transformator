using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Nummbersystem_transformator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                char[] input;
                Array.Reverse(input = inputTXT.Text.ToCharArray());
                
                string wrd = "Error";
                long sum = long.Parse(inputTXT.Text);
                if (long.Parse(inNUMSYS.Text) != 10)
                {
                    wrd = multiply(input);
                    sum = long.Parse(wrd);
                }
                if (long.Parse(outNUMSYS.Text) != 10)
                    wrd = restWert(sum);
                outputTXT.Text = wrd;
            }
        }

        public string multiply(char[] input)
        {
            try
            {
                long sum = 0;
                long multi = 1;
                long multifac = long.Parse(inNUMSYS.Text);
                foreach (char c in input)
                {
                    if ((long)c - 48 >= multifac)
                        return String.Empty;
                    sum += ((long)c - 48) * multi;
                    multi *= multifac;
                    return sum.ToString();
                }
            } catch
            {
                MessageBox.Show("To high for Long-numbers");
            }
            return null;
        }
        public string restWert(long sum)
        {
            string sen = "";
            List<string> wrd = new List<string>();
            while(sum > 0)
            {
                wrd.Add((sum % long.Parse(outNUMSYS.Text))>9? $"({sum % long.Parse(outNUMSYS.Text)})" : (sum % long.Parse(outNUMSYS.Text)).ToString());
                sum /= int.Parse(outNUMSYS.Text);
            }
            wrd.Reverse();
            wrd.ForEach(x => sen += x);
            return sen;

        }
    }
}
