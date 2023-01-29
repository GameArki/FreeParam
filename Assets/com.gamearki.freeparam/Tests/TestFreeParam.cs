using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

namespace GameArki.FreeParam.Tests {

    public class TestFreeParam {

        [Test]
        public void Test() {

            string path = Path.Combine(Application.dataPath, "TestFreeParam.txt");
            FreeParamCore.Initialize();

            object obj;

            // Following tests are based on the content of TestFreeParam.txt file.

            // - bool
            FreeParamCore.TryGetBool("b", out bool b);
            Assert.AreEqual(b, true);

            FreeParamCore.TryGetObject("b", out obj);
            Assert.AreEqual((bool)obj, true);

            FreeParamCore.TryGet<bool>("b", out b);
            Assert.AreEqual(b, true);

            // - bool array
            FreeParamCore.TryGetBoolArray("barr", out bool[] barr);
            Assert.AreEqual(barr.Length, 3);
            Assert.AreEqual(barr[0], true);
            Assert.AreEqual(barr[1], false);
            Assert.AreEqual(barr[2], true);

            FreeParamCore.TryGetObject("barr", out obj);
            Assert.AreEqual(((bool[])obj).Length, 3);
            Assert.AreEqual(((bool[])obj)[0], true);
            Assert.AreEqual(((bool[])obj)[1], false);
            Assert.AreEqual(((bool[])obj)[2], true);

            FreeParamCore.TryGet<bool[]>("barr", out barr);
            Assert.AreEqual(barr.Length, 3);
            Assert.AreEqual(barr[0], true);
            Assert.AreEqual(barr[1], false);
            Assert.AreEqual(barr[2], true);

            // - byte
            FreeParamCore.TryGetByte("u8", out byte u8);
            Assert.AreEqual(u8, 5);

            FreeParamCore.TryGetObject("u8", out obj);
            Assert.AreEqual((byte)obj, 5);

            FreeParamCore.TryGet<byte>("u8", out u8);
            Assert.AreEqual(u8, 5);

            // - byte array
            FreeParamCore.TryGetByteArray("u8arr", out byte[] u8arr);
            Assert.AreEqual(u8arr.Length, 3);
            Assert.AreEqual(u8arr[0], 5);
            Assert.AreEqual(u8arr[1], 6);
            Assert.AreEqual(u8arr[2], 7);

            FreeParamCore.TryGetObject("u8arr", out obj);
            Assert.AreEqual(((byte[])obj).Length, 3);
            Assert.AreEqual(((byte[])obj)[0], 5);
            Assert.AreEqual(((byte[])obj)[1], 6);
            Assert.AreEqual(((byte[])obj)[2], 7);

            FreeParamCore.TryGet<byte[]>("u8arr", out u8arr);
            Assert.AreEqual(u8arr.Length, 3);
            Assert.AreEqual(u8arr[0], 5);
            Assert.AreEqual(u8arr[1], 6);
            Assert.AreEqual(u8arr[2], 7);

            // - sbyte
            FreeParamCore.TryGetSByte("i8", out sbyte i8);
            Assert.AreEqual(i8, -5);

            FreeParamCore.TryGetObject("i8", out obj);
            Assert.AreEqual((sbyte)obj, -5);

            FreeParamCore.TryGet<sbyte>("i8", out i8);
            Assert.AreEqual(i8, -5);

            // - sbyte array
            FreeParamCore.TryGetSByteArray("i8arr", out sbyte[] i8arr);
            Assert.AreEqual(i8arr.Length, 3);
            Assert.AreEqual(i8arr[0], -5);
            Assert.AreEqual(i8arr[1], -6);
            Assert.AreEqual(i8arr[2], -7);

            FreeParamCore.TryGetObject("i8arr", out obj);
            Assert.AreEqual(((sbyte[])obj).Length, 3);
            Assert.AreEqual(((sbyte[])obj)[0], -5);
            Assert.AreEqual(((sbyte[])obj)[1], -6);
            Assert.AreEqual(((sbyte[])obj)[2], -7);

            FreeParamCore.TryGet<sbyte[]>("i8arr", out i8arr);
            Assert.AreEqual(i8arr.Length, 3);
            Assert.AreEqual(i8arr[0], -5);
            Assert.AreEqual(i8arr[1], -6);
            Assert.AreEqual(i8arr[2], -7);

            // - ushort
            FreeParamCore.TryGetUShort("u16", out ushort u16);
            Assert.AreEqual(u16, 6);

            FreeParamCore.TryGetObject("u16", out obj);
            Assert.AreEqual((ushort)obj, 6);

            FreeParamCore.TryGet<ushort>("u16", out u16);
            Assert.AreEqual(u16, 6);

            // - ushort array
            FreeParamCore.TryGetUShortArray("u16arr", out ushort[] u16arr);
            Assert.AreEqual(u16arr.Length, 3);
            Assert.AreEqual(u16arr[0], 6);
            Assert.AreEqual(u16arr[1], 7);
            Assert.AreEqual(u16arr[2], 8);

            FreeParamCore.TryGetObject("u16arr", out obj);
            Assert.AreEqual(((ushort[])obj).Length, 3);
            Assert.AreEqual(((ushort[])obj)[0], 6);
            Assert.AreEqual(((ushort[])obj)[1], 7);
            Assert.AreEqual(((ushort[])obj)[2], 8);

            FreeParamCore.TryGet<ushort[]>("u16arr", out u16arr);
            Assert.AreEqual(u16arr.Length, 3);
            Assert.AreEqual(u16arr[0], 6);
            Assert.AreEqual(u16arr[1], 7);
            Assert.AreEqual(u16arr[2], 8);

            // - short
            FreeParamCore.TryGetShort("i16", out short i16);
            Assert.AreEqual(i16, -6);

            FreeParamCore.TryGetObject("i16", out obj);
            Assert.AreEqual((short)obj, -6);

            FreeParamCore.TryGet<short>("i16", out i16);
            Assert.AreEqual(i16, -6);

            // - short array
            FreeParamCore.TryGetShortArray("i16arr", out short[] i16arr);
            Assert.AreEqual(i16arr.Length, 3);
            Assert.AreEqual(i16arr[0], -6);
            Assert.AreEqual(i16arr[1], -7);
            Assert.AreEqual(i16arr[2], -8);

            FreeParamCore.TryGetObject("i16arr", out obj);
            Assert.AreEqual(((short[])obj).Length, 3);
            Assert.AreEqual(((short[])obj)[0], -6);
            Assert.AreEqual(((short[])obj)[1], -7);
            Assert.AreEqual(((short[])obj)[2], -8);

            FreeParamCore.TryGet<short[]>("i16arr", out i16arr);
            Assert.AreEqual(i16arr.Length, 3);
            Assert.AreEqual(i16arr[0], -6);
            Assert.AreEqual(i16arr[1], -7);
            Assert.AreEqual(i16arr[2], -8);

            // - uint
            FreeParamCore.TryGetUInt("u32", out uint u32);
            Assert.AreEqual(u32, 7);

            FreeParamCore.TryGetObject("u32", out obj);
            Assert.AreEqual((uint)obj, 7);

            FreeParamCore.TryGet<uint>("u32", out u32);
            Assert.AreEqual(u32, 7);

            // - uint array
            FreeParamCore.TryGetUIntArray("u32arr", out uint[] u32arr);
            Assert.AreEqual(u32arr.Length, 3);
            Assert.AreEqual(u32arr[0], 7);
            Assert.AreEqual(u32arr[1], 8);
            Assert.AreEqual(u32arr[2], 9);

            FreeParamCore.TryGetObject("u32arr", out obj);
            Assert.AreEqual(((uint[])obj).Length, 3);
            Assert.AreEqual(((uint[])obj)[0], 7);
            Assert.AreEqual(((uint[])obj)[1], 8);
            Assert.AreEqual(((uint[])obj)[2], 9);

            FreeParamCore.TryGet<uint[]>("u32arr", out u32arr);
            Assert.AreEqual(u32arr.Length, 3);
            Assert.AreEqual(u32arr[0], 7);
            Assert.AreEqual(u32arr[1], 8);
            Assert.AreEqual(u32arr[2], 9);

            // - int
            FreeParamCore.TryGetInt("i32", out int i32);
            Assert.AreEqual(i32, -7);

            FreeParamCore.TryGetObject("i32", out obj);
            Assert.AreEqual((int)obj, -7);

            FreeParamCore.TryGet<int>("i32", out i32);
            Assert.AreEqual(i32, -7);

            // - int array
            FreeParamCore.TryGetIntArray("i32arr", out int[] i32arr);
            Assert.AreEqual(i32arr.Length, 3);
            Assert.AreEqual(i32arr[0], -7);
            Assert.AreEqual(i32arr[1], -8);
            Assert.AreEqual(i32arr[2], -9);

            FreeParamCore.TryGetObject("i32arr", out obj);
            Assert.AreEqual(((int[])obj).Length, 3);
            Assert.AreEqual(((int[])obj)[0], -7);
            Assert.AreEqual(((int[])obj)[1], -8);
            Assert.AreEqual(((int[])obj)[2], -9);

            FreeParamCore.TryGet<int[]>("i32arr", out i32arr);
            Assert.AreEqual(i32arr.Length, 3);
            Assert.AreEqual(i32arr[0], -7);
            Assert.AreEqual(i32arr[1], -8);
            Assert.AreEqual(i32arr[2], -9);

            // - ulong
            FreeParamCore.TryGetULong("u64", out ulong u64);
            Assert.AreEqual(u64, 8);

            FreeParamCore.TryGetObject("u64", out obj);
            Assert.AreEqual((ulong)obj, 8);

            FreeParamCore.TryGet<ulong>("u64", out u64);
            Assert.AreEqual(u64, 8);

            // - ulong array
            FreeParamCore.TryGetULongArray("u64arr", out ulong[] u64arr);
            Assert.AreEqual(u64arr.Length, 3);
            Assert.AreEqual(u64arr[0], 8);
            Assert.AreEqual(u64arr[1], 9);
            Assert.AreEqual(u64arr[2], 10);

            FreeParamCore.TryGetObject("u64arr", out obj);
            Assert.AreEqual(((ulong[])obj).Length, 3);
            Assert.AreEqual(((ulong[])obj)[0], 8);
            Assert.AreEqual(((ulong[])obj)[1], 9);
            Assert.AreEqual(((ulong[])obj)[2], 10);

            FreeParamCore.TryGet<ulong[]>("u64arr", out u64arr);
            Assert.AreEqual(u64arr.Length, 3);
            Assert.AreEqual(u64arr[0], 8);
            Assert.AreEqual(u64arr[1], 9);
            Assert.AreEqual(u64arr[2], 10);

            // - long
            FreeParamCore.TryGetLong("i64", out long i64);
            Assert.AreEqual(i64, -8);

            FreeParamCore.TryGetObject("i64", out obj);
            Assert.AreEqual((long)obj, -8);

            FreeParamCore.TryGet<long>("i64", out i64);
            Assert.AreEqual(i64, -8);

            // - long array
            FreeParamCore.TryGetLongArray("i64arr", out long[] i64arr);
            Assert.AreEqual(i64arr.Length, 3);
            Assert.AreEqual(i64arr[0], -8);
            Assert.AreEqual(i64arr[1], -9);
            Assert.AreEqual(i64arr[2], -10);

            FreeParamCore.TryGetObject("i64arr", out obj);
            Assert.AreEqual(((long[])obj).Length, 3);
            Assert.AreEqual(((long[])obj)[0], -8);
            Assert.AreEqual(((long[])obj)[1], -9);
            Assert.AreEqual(((long[])obj)[2], -10);

            FreeParamCore.TryGet<long[]>("i64arr", out i64arr);
            Assert.AreEqual(i64arr.Length, 3);
            Assert.AreEqual(i64arr[0], -8);
            Assert.AreEqual(i64arr[1], -9);
            Assert.AreEqual(i64arr[2], -10);

            // - float
            FreeParamCore.TryGetFloat("f32", out float f32);
            Assert.AreEqual(f32, 9.0f);

            FreeParamCore.TryGetObject("f32", out obj);
            Assert.AreEqual((float)obj, 9.0f);

            FreeParamCore.TryGet<float>("f32", out f32);
            Assert.AreEqual(f32, 9.0f);

            // - float array
            FreeParamCore.TryGetFloatArray("f32arr", out float[] f32arr);
            Assert.AreEqual(f32arr.Length, 3);
            Assert.AreEqual(f32arr[0], 9.0f);
            Assert.AreEqual(f32arr[1], 10.0f);
            Assert.AreEqual(f32arr[2], 11.0f);

            FreeParamCore.TryGetObject("f32arr", out obj);
            Assert.AreEqual(((float[])obj).Length, 3);
            Assert.AreEqual(((float[])obj)[0], 9.0f);
            Assert.AreEqual(((float[])obj)[1], 10.0f);
            Assert.AreEqual(((float[])obj)[2], 11.0f);

            FreeParamCore.TryGet<float[]>("f32arr", out f32arr);
            Assert.AreEqual(f32arr.Length, 3);
            Assert.AreEqual(f32arr[0], 9.0f);
            Assert.AreEqual(f32arr[1], 10.0f);
            Assert.AreEqual(f32arr[2], 11.0f);

            // - double
            FreeParamCore.TryGetDouble("f64", out double f64);
            Assert.AreEqual(f64, 10.0);

            FreeParamCore.TryGetObject("f64", out obj);
            Assert.AreEqual((double)obj, 10.0);

            FreeParamCore.TryGet<double>("f64", out f64);
            Assert.AreEqual(f64, 10.0);

            // - double array
            FreeParamCore.TryGetDoubleArray("f64arr", out double[] f64arr);
            Assert.AreEqual(f64arr.Length, 3);
            Assert.AreEqual(f64arr[0], 10.0);
            Assert.AreEqual(f64arr[1], 11.0);
            Assert.AreEqual(f64arr[2], 12.0);

            FreeParamCore.TryGetObject("f64arr", out obj);
            Assert.AreEqual(((double[])obj).Length, 3);
            Assert.AreEqual(((double[])obj)[0], 10.0);
            Assert.AreEqual(((double[])obj)[1], 11.0);
            Assert.AreEqual(((double[])obj)[2], 12.0);

            FreeParamCore.TryGet<double[]>("f64arr", out f64arr);
            Assert.AreEqual(f64arr.Length, 3);
            Assert.AreEqual(f64arr[0], 10.0);
            Assert.AreEqual(f64arr[1], 11.0);
            Assert.AreEqual(f64arr[2], 12.0);

            // - char
            FreeParamCore.TryGetChar("c", out char c);
            Assert.AreEqual(c, 'a');

            FreeParamCore.TryGetObject("c", out obj);
            Assert.AreEqual((char)obj, 'a');

            FreeParamCore.TryGet<char>("c", out c);
            Assert.AreEqual(c, 'a');

            // - char array
            FreeParamCore.TryGetCharArray("carr", out char[] carr);
            Assert.AreEqual(carr.Length, 3);
            Assert.AreEqual(carr[0], 'a');
            Assert.AreEqual(carr[1], 'b');
            Assert.AreEqual(carr[2], 'c');

            FreeParamCore.TryGetObject("carr", out obj);
            Assert.AreEqual(((char[])obj).Length, 3);
            Assert.AreEqual(((char[])obj)[0], 'a');
            Assert.AreEqual(((char[])obj)[1], 'b');
            Assert.AreEqual(((char[])obj)[2], 'c');

            FreeParamCore.TryGet<char[]>("carr", out carr);
            Assert.AreEqual(carr.Length, 3);
            Assert.AreEqual(carr[0], 'a');
            Assert.AreEqual(carr[1], 'b');
            Assert.AreEqual(carr[2], 'c');

            // - string
            FreeParamCore.TryGetString("str", out string str);
            Assert.AreEqual(str, "Hello 世界");

            FreeParamCore.TryGetObject("str", out obj);
            Assert.AreEqual((string)obj, "Hello 世界");

            FreeParamCore.TryGet<string>("str", out str);
            Assert.AreEqual(str, "Hello 世界");

            // - string array
            FreeParamCore.TryGetStringArray("strarr", out string[] strarr);
            Assert.AreEqual(strarr.Length, 2);
            Assert.AreEqual(strarr[0], "Hello");
            Assert.AreEqual(strarr[1], "世界");

            FreeParamCore.TryGetObject("strarr", out obj);
            Assert.AreEqual(((string[])obj).Length, 2);
            Assert.AreEqual(((string[])obj)[0], "Hello");
            Assert.AreEqual(((string[])obj)[1], "世界");

            FreeParamCore.TryGet<string[]>("strarr", out strarr);
            Assert.AreEqual(strarr.Length, 2);
            Assert.AreEqual(strarr[0], "Hello");
            Assert.AreEqual(strarr[1], "世界");

        }

    }

}
