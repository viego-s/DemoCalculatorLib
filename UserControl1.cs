using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCalculatorLib
{
    public partial class UserControl1: UserControl
    {   //计算当前结果
        private double result = 0;
        //当前运算符
        private string currentOperator = "";
        //标记是否为新的输入
        private bool isNewInput = true;
        public UserControl1()
        {
            InitializeComponent();

            // 数字和小数点按钮
            zeroButton.Click += NumberButton_Click;
            oneButton.Click += NumberButton_Click;
            twoButton.Click += NumberButton_Click;
            threeButton.Click += NumberButton_Click;
            fourButton.Click += NumberButton_Click;
            fiveButton.Click += NumberButton_Click;
            sixButton.Click += NumberButton_Click;
            sevenButton.Click += NumberButton_Click;
            eightButton.Click += NumberButton_Click;
            nineButton.Click += NumberButton_Click;
            decimalButton.Click += NumberButton_Click;

            // 运算按钮
            additionButton.Click += OperatorButton_Click;
            subtractionButton.Click += OperatorButton_Click;
            multiplicationButton.Click += OperatorButton_Click;
            divisionButton.Click += OperatorButton_Click;

            // 其他按钮
            equalsButton.Click += EqualsButton_Click;
            clearButton.Click += ClearButton_Click;
            changeSignButton.Click += ChangeSignButton_Click;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            // 可用于初始化加载时的设置
        }
        /// <summary>
        /// 处理数字和小数点输入
        /// </summary>
        private void NumberButton_Click(object sender, EventArgs e)
        {   
            Button btn = sender as Button;
            //若是新的输入，则清空文本框
            if (isNewInput)
            {
                textBox1.Text = "";
                isNewInput = false;
            }
            //防止输入多个小数点
            if (btn.Text == "." && textBox1.Text.Contains(".")) return;
            //在末尾追加输入字符
            textBox1.Text += btn.Text;
        }
        /// <summary>
        /// 处理加减乘除按钮
        /// </summary>
        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (double.TryParse(textBox1.Text, out double value))
            {   // 第一次点击运算符，记录当前值为 result
                if (string.IsNullOrEmpty(currentOperator))
                {
                    result = value;
                }
                // 若已有运算符，则先执行上一步计算，再保存新运算符
                else
                {
                    result = Calculate(result, value, currentOperator);
                    AddToHistory($"{result}");
                }
            }
            // 保存当前点击的运算符（用于下一次计算）
            currentOperator = btn.Text;
            // 标记为新输入（下次数字输入前先清空）
            isNewInput = true;
        }
        /// <summary>
        /// 处理等于按钮
        /// </summary>
        private void EqualsButton_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double value))
            {   // 根据当前运算符和 result 执行计算
                result = Calculate(result, value, currentOperator);
                // 显示结果
                textBox1.Text = result.ToString();
                // 添加一条等式结果记录
                AddToHistory($"= {result}");
                // 运算符清空（下一次输入相当于新运算）
                currentOperator = "";
                isNewInput = true;
            }
        }
        /// <summary>
        /// 处理清除按钮，重置状态
        /// </summary>
        private void ClearButton_Click(object sender, EventArgs e)
        {   // 清空输入框和所有运算状态
            textBox1.Text = "";
            result = 0;
            currentOperator = "";
            isNewInput = true;

            // 清空历史记录
            listView1.Items.Clear();
        }
        /// <summary>
        /// 处理正负号切换
        /// </summary>
        private void ChangeSignButton_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double value))
            {
                value = -value;
                textBox1.Text = value.ToString();
            }
        }
        /// <summary>
        /// 计算逻辑函数
        /// </summary>

        private double Calculate(double left, double right, string op)
        {
            switch (op)
            {
                case "+": return left + right;
                case "-": return left - right;
                case "*": return left * right;
                case "/": return right != 0 ? left / right : double.NaN;
                default: return right;
            }
        }
        /// <summary>
        /// 添加一条记录到历史栏
        /// </summary>
        private void AddToHistory(string entry)
        {
            listView1.Items.Add(new ListViewItem(entry));
        }
    }
}
