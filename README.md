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

// 初始化
FreeParamCore.Initialize("MyParam.txt");

// 调用
bool exist = FreeParamCore.TryGetInt("myInt", out int value);
Console.WriteLine(value); // 5
```

# 语法
```
bool b = true;
bool[] barr = [true, false, true];

byte u8 = 5;
byte[] u8arr = [5, 6, 7];

sbyte i8 = -5;
sbyte[] i8arr = [-5, -6, -7];

ushort u16 = 6;
ushort[] u16arr = [6, 7, 8];

short i16 = -6;
short[] i16arr = [-6, -7, -8];

uint u32 = 7;
uint[] u32arr = [7, 8, 9];

int i32 = -7;
int[] i32arr = [-7, -8, -9];

ulong u64 = 8;
ulong[] u64arr = [8, 9, 10];

long i64 = -8;
long[] i64arr = [-8, -9, -10];

float f32 = 9.0;
float[] f32arr = [9.0, 10.0, 11.0];

double f64 = 10.0;
double[] f64arr = [10.0, 11.0, 12.0];

char c = 'a';
char[] carr = ['a', 'b', 'c'];

string str = "Hello 世界";
string[] strarr = ["Hello", "世界"];
```
