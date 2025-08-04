# DemoCalculatorLib
# 计算器  
计算器设计来源于：https://learn.microsoft.com/zh-cn/visualstudio/designers/walkthrough-windows-forms-designer?view=vs-2022  
计算器功能如下表  

| 方法名                        | 功能说明                    |
| -------------------------- | ----------------------- |
| `UserControl1()`           | 控件构造函数，绑定所有按钮事件         |
| `NumberButton_Click()`     | 输入数字和小数点                |
| `OperatorButton_Click()`   | 点击 + - \* / 运算符，准备下一步运算 |
| `EqualsButton_Click()`     | 执行等号运算并显示结果             |
| `ClearButton_Click()`      | 重置所有状态和清空输入框            |
| `ChangeSignButton_Click()` | 实现 +/− 功能               |
| `Calculate()`              | 根据传入的两个数和运算符执行实际计算      |
| `AddToHistory()`           | 将当前计算结果或过程添加到历史栏        |
