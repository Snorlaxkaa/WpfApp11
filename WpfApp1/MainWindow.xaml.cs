using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static WpfApp1.MainWindow;

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
        public class Triangle
        {
            public double Side1 { set;  get; }
            public double Side2 { set;  get; }
            public double Side3 { set; get; }
            public bool IsValid { set; get; }
        }
        List<Triangle> triangles=new List<Triangle>();
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            double side1, side2, side3;
            bool success1 = double.TryParse(textbox1.Text, out side1);
            bool success2 = double.TryParse(textbox2.Text, out side2);
            bool success3 = double.TryParse(textbox3.Text, out side3);

            // 清除之前可能设置的边框颜色
            textbox1.ClearValue(TextBox.BorderBrushProperty);
            textbox2.ClearValue(TextBox.BorderBrushProperty);
            textbox3.ClearValue(TextBox.BorderBrushProperty);

            if (!success1 || !success2 || !success3)
            {
                MessageBox.Show("請輸入有效的數值", "輸入錯誤");
                if (!success1)
                    textbox1.BorderBrush = Brushes.Red;
                if (!success2)
                    textbox2.BorderBrush = Brushes.Red;
                if (!success3)
                    textbox3.BorderBrush = Brushes.Red;
                return;
            }
            if (side1 < 1 || side2 < 1 || side3 < 1)
            {
                MessageBox.Show("請輸入有效的數值", "輸入錯誤");
                if (side1<1)
                    textbox1.BorderBrush = Brushes.Red;
                if (side2 < 1)
                    textbox2.BorderBrush = Brushes.Red;
                if (side3 < 1)
                    textbox3.BorderBrush = Brushes.Red;
                return;
            }
                if (side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1)
            {
                textblock_multiple.Background = new SolidColorBrush(Colors.Green);
                textblock_multiple.Text = $"邊長 {side1}, {side2}, {side3} 可構成三角形";
                triangles.Add(new Triangle() { Side1=side1,Side2=side2,Side3=side3,IsValid=true});
            }
            else
            {
                textblock_multiple.Background = new SolidColorBrush(Colors.Red);
                textblock_multiple.Text = $"邊長 {side1}, {side2}, {side3} 不可構成三角形";
                triangles.Add(new Triangle() { Side1 = side1, Side2 = side2, Side3 = side3, IsValid = false });
            }
            ListResult();
        }

        private void ListResult()
        {
            textblock_multiple2.Clear();
            foreach(Triangle tri in triangles) {
                textblock_multiple2.Text += $"{tri.Side1}\t{tri.Side2}\t{tri.Side3}\t{tri.IsValid}\n";
            }
        }
    }
}
