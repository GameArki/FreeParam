# FreeParam
💦 用文本替代参数的库，便于调试时不断修改参数值的情况。

# QuickStart
1. 编辑
``` C#
// MyParam.txt

// 定义方式: 类型 变量名 = 值;
int myInt = 5;

// 支持C# 基础类型:
// bool, bool[]
// byte, byte[]
// sbyte, sbyte[]
// ushort, ushort[]
// short, short[]
// int, int[]
// uint, uint[]
// long, long[]
// ulong, ulong[]
// float, float[]
// double, double[]
// char, char[]
// string, string[]
```
2. 调用
``` C#
using GameArki.FreeParam;

bool exist = FreeParamCore.TryGetInt("myInt", out int value);
Console.WriteLine(value); // 5
```
