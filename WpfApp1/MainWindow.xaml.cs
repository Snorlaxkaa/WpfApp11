using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static WpfApp1.MainWindow;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 定義表示三角形的類別
        public class Triangle
        {
            public double Side1 { set; get; }
            public double Side2 { set; get; }
            public double Side3 { set; get; }
            public bool IsValid { set; get; }
        }

        // 存儲三角形的列表
        List<Triangle> triangles = new List<Triangle>();

        // 點擊按鈕事件處理程序
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            double side1, side2, side3;
            bool success1 = double.TryParse(textbox1.Text, out side1);
            bool success2 = double.TryParse(textbox2.Text, out side2);
            bool success3 = double.TryParse(textbox3.Text, out side3);

            // 清除之前可能設置的文本框邊框顏色
            textbox1.ClearValue(TextBox.BorderBrushProperty);
            textbox2.ClearValue(TextBox.BorderBrushProperty);
            textbox3.ClearValue(TextBox.BorderBrushProperty);

            if (!success1 || !success2 || !success3)
            {
                // 如果輸入無效，顯示錯誤消息並突出顯示錯誤的文本框
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
                // 如果輸入小於1，顯示錯誤消息並突出顯示錯誤的文本框
                MessageBox.Show("請輸入有效的數值", "輸入錯誤");
                if (side1 < 1)
                    textbox1.BorderBrush = Brushes.Red;
                if (side2 < 1)
                    textbox2.BorderBrush = Brushes.Red;
                if (side3 < 1)
                    textbox3.BorderBrush = Brushes.Red;
                return;
            }

            if (side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1)
            {
                // 如果三邊長可以構成三角形，將結果設置為綠色並添加到列表
                textblock_multiple.Background = new SolidColorBrush(Colors.Green);
                textblock_multiple.Text = $"邊長 {side1}, {side2}, {side3} 可構成三角形";
                triangles.Add(new Triangle() { Side1 = side1, Side2 = side2, Side3 = side3, IsValid = true });
            }
            else
            {
                // 如果三邊長不能構成三角形，將結果設置為紅色並添加到列表
                textblock_multiple.Background = new SolidColorBrush(Colors.Red);
                textblock_multiple.Text = $"邊長 {side1}, {side2}, {side3} 不可構成三角形";
                triangles.Add(new Triangle() { Side1 = side1, Side2 = side2, Side3 = side3, IsValid = false });
            }

            // 更新結果列表
            ListResult();
        }

        // 更新結果列表的方法
        private void ListResult()
        {
            // 清除之前的結果
            textblock_multiple2.Clear();

            // 將每個三角形的信息添加到結果列表中
            foreach (Triangle tri in triangles)
            {
                textblock_multiple2.Text += $"{tri.Side1}\t{tri.Side2}\t{tri.Side3}\t{tri.IsValid}\n";
            }
        }
    }
}