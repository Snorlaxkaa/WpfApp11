using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp1
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int number;
            List<int> primes = new List<int>();
            bool success = int.TryParse(textbox1.Text, out number);

            if (!success)
            {
                MessageBox.Show("請輸入整數", "輸入錯誤");
            }
            else if (number < 2)
            {
                MessageBox.Show($"輸入數值為{number}，小於2，請重新輸入", "輸入錯誤");
            }
            else
            {
                //MessageBox.Show($"輸入數值為{number}", "輸入正確");
                for (int i = 2; i <= number; i++)
                {
                    if (IsPrime(i))
                    {
                        primes.Add(i);
                    }
                }
            }

            //列印所有的質數與倍數
            ListResult(primes, number);
        }

        private void ListResult(List<int> myPrimes, int n)
        {
            string primeList = $"小於{n}的質數為：";
            string primeMultiple = "";
            foreach (int p in myPrimes)
            {
                primeList += $"{p}  ";
                primeMultiple += $"{p}的倍數為： ";
                int i = 1;
                while (p*i <= n)
                {
                    primeMultiple += $"{p * i}  ";
                    i++;
                }
                primeMultiple += "\n";
            }
            textblock_prime.Text = primeList;
            textblock_multiple.Text = primeMultiple;
        }

        private bool IsPrime(int p)
        {
            //判斷p是否為質數
            for (int i = 2; i < p; i++)
            {
                if (p % i == 0) return false;
            }
            return true;
        }
    }
}
