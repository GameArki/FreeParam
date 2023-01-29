using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameArki.FreeParam {

    public static class FreeParamCore {

        // ==== External ====
        // Initialize
        public static void Initialize(string path = null) {

            // 提示需创建文件: param.fp
            if (path == null) {
                path = Path.Combine(Application.dataPath, "FreeParam.txt");
                if (!File.Exists(path)) {
                    Debug.LogError("Please create file: FreeParam.txt, in Assets folder.");
                    return;
                }
            } else {
                if (!File.Exists(path)) {
                    Debug.LogError("File not found: " + path);
                    return;
                }
            }

            // 读取文件
            DeserializeAll(path);

        }

        // Get
        public static bool TryGet<T>(string key, out T value) {
            bool has = objValues.TryGetValue(key, out object obj);
            if (has) {
                value = (T)obj;
            } else {
                value = default;
            }
            return has;
        }
        public static bool TryGetObject(string key, out object value) => objValues.TryGetValue(key, out value);
        public static bool TryGetBool(string key, out bool value) => boolValues.TryGetValue(key, out value);
        public static bool TryGetBoolArray(string key, out bool[] value) => boolArrValues.TryGetValue(key, out value);
        public static bool TryGetByte(string key, out byte value) => byteValues.TryGetValue(key, out value);
        public static bool TryGetByteArray(string key, out byte[] value) => byteArrValues.TryGetValue(key, out value);
        public static bool TryGetSByte(string key, out sbyte value) => sbyteValues.TryGetValue(key, out value);
        public static bool TryGetSByteArray(string key, out sbyte[] value) => sbyteArrValues.TryGetValue(key, out value);
        public static bool TryGetUShort(string key, out ushort value) => ushortValues.TryGetValue(key, out value);
        public static bool TryGetUShortArray(string key, out ushort[] value) => ushortArrValues.TryGetValue(key, out value);
        public static bool TryGetShort(string key, out short value) => shortValues.TryGetValue(key, out value);
        public static bool TryGetShortArray(string key, out short[] value) => shortArrValues.TryGetValue(key, out value);
        public static bool TryGetUInt(string key, out uint value) => uintValues.TryGetValue(key, out value);
        public static bool TryGetUIntArray(string key, out uint[] value) => uintArrValues.TryGetValue(key, out value);
        public static bool TryGetInt(string key, out int value) => intValues.TryGetValue(key, out value);
        public static bool TryGetIntArray(string key, out int[] value) => intArrValues.TryGetValue(key, out value);
        public static bool TryGetULong(string key, out ulong value) => ulongValues.TryGetValue(key, out value);
        public static bool TryGetULongArray(string key, out ulong[] value) => ulongArrValues.TryGetValue(key, out value);
        public static bool TryGetLong(string key, out long value) => longValues.TryGetValue(key, out value);
        public static bool TryGetLongArray(string key, out long[] value) => longArrValues.TryGetValue(key, out value);
        public static bool TryGetFloat(string key, out float value) => floatValues.TryGetValue(key, out value);
        public static bool TryGetFloatArray(string key, out float[] value) => floatArrValues.TryGetValue(key, out value);
        public static bool TryGetDouble(string key, out double value) => doubleValues.TryGetValue(key, out value);
        public static bool TryGetDoubleArray(string key, out double[] value) => doubleArrValues.TryGetValue(key, out value);
        public static bool TryGetChar(string key, out char value) => charValues.TryGetValue(key, out value);
        public static bool TryGetCharArray(string key, out char[] value) => charArrValues.TryGetValue(key, out value);
        public static bool TryGetString(string key, out string value) => stringValues.TryGetValue(key, out value);
        public static bool TryGetStringArray(string key, out string[] value) => stringArrValues.TryGetValue(key, out value);

        // ==== Private ====
        // Values
        static Dictionary<string, object> objValues = new Dictionary<string, object>();
        static Dictionary<string, bool> boolValues = new Dictionary<string, bool>();
        static Dictionary<string, bool[]> boolArrValues = new Dictionary<string, bool[]>();
        static Dictionary<string, byte> byteValues = new Dictionary<string, byte>();
        static Dictionary<string, byte[]> byteArrValues = new Dictionary<string, byte[]>();
        static Dictionary<string, sbyte> sbyteValues = new Dictionary<string, sbyte>();
        static Dictionary<string, sbyte[]> sbyteArrValues = new Dictionary<string, sbyte[]>();
        static Dictionary<string, ushort> ushortValues = new Dictionary<string, ushort>();
        static Dictionary<string, ushort[]> ushortArrValues = new Dictionary<string, ushort[]>();
        static Dictionary<string, short> shortValues = new Dictionary<string, short>();
        static Dictionary<string, short[]> shortArrValues = new Dictionary<string, short[]>();
        static Dictionary<string, uint> uintValues = new Dictionary<string, uint>();
        static Dictionary<string, uint[]> uintArrValues = new Dictionary<string, uint[]>();
        static Dictionary<string, int> intValues = new Dictionary<string, int>();
        static Dictionary<string, int[]> intArrValues = new Dictionary<string, int[]>();
        static Dictionary<string, ulong> ulongValues = new Dictionary<string, ulong>();
        static Dictionary<string, ulong[]> ulongArrValues = new Dictionary<string, ulong[]>();
        static Dictionary<string, long> longValues = new Dictionary<string, long>();
        static Dictionary<string, long[]> longArrValues = new Dictionary<string, long[]>();
        static Dictionary<string, float> floatValues = new Dictionary<string, float>();
        static Dictionary<string, float[]> floatArrValues = new Dictionary<string, float[]>();
        static Dictionary<string, double> doubleValues = new Dictionary<string, double>();
        static Dictionary<string, double[]> doubleArrValues = new Dictionary<string, double[]>();
        static Dictionary<string, char> charValues = new Dictionary<string, char>();
        static Dictionary<string, char[]> charArrValues = new Dictionary<string, char[]>();
        static Dictionary<string, string> stringValues = new Dictionary<string, string>();
        static Dictionary<string, string[]> stringArrValues = new Dictionary<string, string[]>();

        // Types (26)
        static HashSet<string> types = new HashSet<string> {
            "bool", "bool[]",
            "byte", "byte[]",
            "sbyte", "sbyte[]",
            "ushort", "ushort[]",
            "short", "short[]",
            "uint", "uint[]",
            "int", "int[]",
            "ulong", "ulong[]",
            "long", "long[]",
            "float", "float[]",
            "double", "double[]",
            "char", "char[]",
            "string", "string[]",
        };

        static HashSet<char> ignores = new HashSet<char> {
            '\r', '\n',
        };

        static HashSet<char> splits = new HashSet<char> {
            ' ', '\t',
        };

        // Serialize
        enum Status { None, Type, Key, Value, }

        static void DeserializeAll(string path) {

            string text = File.ReadAllText(path);
            int index = 0;
            Status status = Status.Type;

            string tmpType = string.Empty;
            string tmpKey = string.Empty;
            for (int i = 0; i < text.Length; i += 1) {
                char cur = text[i];
                if (status == Status.Type) {
                    // ---- Type ----
                    if (ignores.Contains(cur)) {
                        index = i + 1;
                        continue;
                    }

                    // 遇到 split 时, 读取 type, 并切换到 key
                    if (splits.Contains(cur)) {
                        tmpType = text.Substring(index, i - index);
                        if (types.Contains(tmpType)) {
                            status = Status.Key;
                            index = i + 1;
                        } else {
                            Debug.LogError($"FreeParam: Invalid type: {tmpType}");
                            return;
                        }
                    }
                } else if (status == Status.Key) {
                    // ---- Key ----
                    // 遇到 splits 跳过
                    if (splits.Contains(cur)) {
                        continue;
                    }
                    // 遇到 = 时, 读取 key, 并切换到 value
                    if (cur == '=') {
                        tmpKey = text.Substring(index, i - index);
                        tmpKey = tmpKey.Trim();
                        status = Status.Value;
                        index = i + 1;
                    }
                } else if (status == Status.Value) {
                    // ---- Value ----
                    // 遇到 splits 跳过
                    if (splits.Contains(cur)) {
                        continue;
                    }
                    // 遇到 ; 时, 读取 value, 并切换到 type
                    if (cur == ';') {
                        string tmpValue = text.Substring(index, i - index);
                        bool succ = D_OneType(tmpType, tmpKey, tmpValue);
                        if (succ) {
                            status = Status.Type;
                        } else {
                            Debug.LogError($"FreeParam: Deserialize failed: {tmpType} {tmpKey} {tmpValue}");
                            return;
                        }
                        index = i + 1;
                    }
                }
            }
        }

        static bool D_OneType(string type, string key, string inputValue) {

            bool succ = false;
            switch (type) {
                case "bool": succ = D_Bool(key, inputValue); break;
                case "bool[]": succ = D_BoolArray(key, inputValue); break;
                case "byte": succ = D_Byte(key, inputValue); break;
                case "byte[]": succ = D_ByteArray(key, inputValue); break;
                case "sbyte": succ = D_SByte(key, inputValue); break;
                case "sbyte[]": succ = D_SByteArray(key, inputValue); break;
                case "ushort": succ = D_UShort(key, inputValue); break;
                case "ushort[]": succ = D_UShortArray(key, inputValue); break;
                case "short": succ = D_Short(key, inputValue); break;
                case "short[]": succ = D_ShortArray(key, inputValue); break;
                case "uint": succ = D_UInt(key, inputValue); break;
                case "uint[]": succ = D_UIntArray(key, inputValue); break;
                case "int": succ = D_Int(key, inputValue); break;
                case "int[]": succ = D_IntArray(key, inputValue); break;
                case "ulong": succ = D_ULong(key, inputValue); break;
                case "ulong[]": succ = D_ULongArray(key, inputValue); break;
                case "long": succ = D_Long(key, inputValue); break;
                case "long[]": succ = D_LongArray(key, inputValue); break;
                case "float": succ = D_Float(key, inputValue); break;
                case "float[]": succ = D_FloatArray(key, inputValue); break;
                case "double": succ = D_Double(key, inputValue); break;
                case "double[]": succ = D_DoubleArray(key, inputValue); break;
                case "char": succ = D_Char(key, inputValue); break;
                case "char[]": succ = D_CharArray(key, inputValue); break;
                case "string": succ = D_String(key, inputValue); break;
                case "string[]": succ = D_StringArray(key, inputValue); break;
                default: Debug.LogError($"FreeParam: Invalid type: {type}"); break;
            }

            return succ;

        }

        static bool D_Bool(string key, string inputValue) {
            bool succ = bool.TryParse(inputValue, out bool value);
            if (succ) {
                bool added = boolValues.TryAdd(key, value);
                if (!added) {
                    boolValues[key] = value;
                }

                added = objValues.TryAdd(key, value);
                if (!added) {
                    objValues[key] = value;
                }
            } else {
                Debug.LogError($"FreeParam: Invalid bool key: {key} value: {inputValue}");
                return false;
            }
            return succ;
        }

        static bool D_BoolArray(string key, string inputValue) {

            inputValue = inputValue.Trim();

            if (!IsValidateArray(inputValue)) {
                Debug.LogError($"FreeParam: Invalid boolArray key: {key} value: {inputValue}");
                return false;
            }

            // 去掉首尾的 []
            inputValue = SubArray(inputValue);

            string[] values = inputValue.Split(',');
            bool[] array = new bool[values.Length];
            for (int j = 0; j < values.Length; j += 1) {
                string cur = values[j];
                cur = cur.Trim();
                bool succ = bool.TryParse(cur, out bool value);
                if (succ) {
                    array[j] = value;
                } else {
                    Debug.LogError($"FreeParam: Invalid boolArray value: {cur}");
                    return false;
                }
            }

            // 添加到泛字典
            bool added = objValues.TryAdd(key, array);
            if (!added) {
                objValues[key] = array;
            }

            // 添加到 bool 数组字典
            added = boolArrValues.TryAdd(key, array);
            if (!added) {
                boolArrValues[key] = array;
            }
            return true;
        }

        static bool D_Byte(string key, string inputValue) {
            bool succ = byte.TryParse(inputValue, out byte value);
            if (succ) {
                bool added = byteValues.TryAdd(key, value);
                if (!added) {
                    byteValues[key] = value;
                }

                added = objValues.TryAdd(key, value);
                if (!added) {
                    objValues[key] = value;
                }
            } else {
                Debug.LogError($"FreeParam: Invalid byte value: {inputValue}");
                return false;
            }
            return succ;
        }

        static bool D_ByteArray(string key, string inputValue) {

            inputValue = inputValue.Trim();

            if (!IsValidateArray(inputValue)) {
                return false;
            }

            // 去掉首尾的 []
            inputValue = SubArray(inputValue);

            string[] values = inputValue.Split(',');
            byte[] array = new byte[values.Length];
            for (int j = 0; j < values.Length; j += 1) {
                bool succ = byte.TryParse(values[j], out byte value);
                if (succ) {
                    array[j] = value;
                } else {
                    Debug.LogError($"FreeParam: Invalid byteArray value: {values[j]}");
                    return false;
                }
            }

            // 添加到泛字典
            bool added = objValues.TryAdd(key, array);
            if (!added) {
                objValues[key] = array;
            }

            // 添加到 byte 数组字典
            added = byteArrValues.TryAdd(key, array);
            if (!added) {
                byteArrValues[key] = array;
            }
            return true;
        }

        static bool D_SByte(string key, string inputValue) {
            bool succ = sbyte.TryParse(inputValue, out sbyte value);
            if (succ) {
                bool added = sbyteValues.TryAdd(key, value);
                if (!added) {
                    sbyteValues[key] = value;
                }

                added = objValues.TryAdd(key, value);
                if (!added) {
                    objValues[key] = value;
                }
            } else {
                Debug.LogError($"FreeParam: Invalid sbyte value: {inputValue}");
                return false;
            }
            return succ;
        }

        static bool D_SByteArray(string key, string inputValue) {

            inputValue = inputValue.Trim();
            if (!IsValidateArray(inputValue)) {
                return false;
            }

            // 去掉首尾的 []
            inputValue = SubArray(inputValue);

            string[] values = inputValue.Split(',');
            sbyte[] array = new sbyte[values.Length];
            for (int j = 0; j < values.Length; j += 1) {
                bool succ = sbyte.TryParse(values[j], out sbyte value);
                if (succ) {
                    array[j] = value;
                } else {
                    Debug.LogError($"FreeParam: Invalid sbyteArray value: {values[j]}");
                    return false;
                }
            }

            // 添加到泛字典
            bool added = objValues.TryAdd(key, array);
            if (!added) {
                objValues[key] = array;
            }

            // 添加到 sbyte 数组字典
            added = sbyteArrValues.TryAdd(key, array);
            if (!added) {
                sbyteArrValues[key] = array;
            }
            return true;
        }

        static bool D_Short(string key, string inputValue) {
            bool succ = short.TryParse(inputValue, out short value);
            if (succ) {
                bool added = shortValues.TryAdd(key, value);
                if (!added) {
                    shortValues[key] = value;
                }
                added = objValues.TryAdd(key, value);
                if (!added) {
                    objValues[key] = value;
                }
            } else {
                Debug.LogError($"FreeParam: Invalid short value: {inputValue}");
                return false;
            }
            return succ;
        }

        static bool D_ShortArray(string key, string inputValue) {

            inputValue = inputValue.Trim();
            if (!IsValidateArray(inputValue)) {
                return false;
            }

            // 去掉首尾的 []
            inputValue = SubArray(inputValue);

            string[] values = inputValue.Split(',');
            short[] array = new short[values.Length];
            for (int j = 0; j < values.Length; j += 1) {
                bool succ = short.TryParse(values[j], out short value);
                if (succ) {
                    array[j] = value;
                } else {
                    Debug.LogError($"FreeParam: Invalid shortArray value: {values[j]}");
                    return false;
                }
            }

            // 添加到泛字典
            bool added = objValues.TryAdd(key, array);
            if (!added) {
                objValues[key] = array;
            }

            // 添加到 short 数组字典
            added = shortArrValues.TryAdd(key, array);
            if (!added) {
                shortArrValues[key] = array;
            }
            return true;
        }

        static bool D_UShort(string key, string inputValue) {
            bool succ = ushort.TryParse(inputValue, out ushort value);
            if (succ) {
                bool added = ushortValues.TryAdd(key, value);
                if (!added) {
                    ushortValues[key] = value;
                }
                added = objValues.TryAdd(key, value);
                if (!added) {
                    objValues[key] = value;
                }
            } else {
                Debug.LogError($"FreeParam: Invalid ushort value: {inputValue}");
                return false;
            }
            return succ;
        }

        static bool D_UShortArray(string key, string inputValue) {
            inputValue = inputValue.Trim();

            if (!IsValidateArray(inputValue)) {
                return false;
            }

            // 去掉首尾的 []
            inputValue = SubArray(inputValue);

            string[] values = inputValue.Split(',');
            ushort[] array = new ushort[values.Length];
            for (int j = 0; j < values.Length; j += 1) {
                bool succ = ushort.TryParse(values[j], out ushort value);
                if (succ) {
                    array[j] = value;
                } else {
                    Debug.LogError($"FreeParam: Invalid ushortArray value: {values[j]}");
                    return false;
                }
            }

            // 添加到泛字典
            bool added = objValues.TryAdd(key, array);
            if (!added) {
                objValues[key] = array;
            }

            // 添加到 ushort 数组字典
            added = ushortArrValues.TryAdd(key, array);
            if (!added) {
                ushortArrValues[key] = array;
            }
            return true;
        }

        static bool D_Int(string key, string inputValue) {
            bool succ = int.TryParse(inputValue, out int value);
            if (succ) {
                bool added = intValues.TryAdd(key, value);
                if (!added) {
                    intValues[key] = value;
                }
                added = objValues.TryAdd(key, value);
                if (!added) {
                    objValues[key] = value;
                }
            } else {
                Debug.LogError($"FreeParam: Invalid int value: {inputValue}");
                return false;
            }
            return succ;
        }

        static bool D_IntArray(string key, string inputValue) {
            inputValue = inputValue.Trim();

            if (!IsValidateArray(inputValue)) {
                return false;
            }

            // 去掉首尾的 []
            inputValue = SubArray(inputValue);

            string[] values = inputValue.Split(',');
            int[] array = new int[values.Length];
            for (int j = 0; j < values.Length; j += 1) {
                bool succ = int.TryParse(values[j], out int value);
                if (succ) {
                    array[j] = value;
                } else {
                    Debug.LogError($"FreeParam: Invalid intArray value: {values[j]}");
                    return false;
                }
            }

            // 添加到泛字典
            bool added = objValues.TryAdd(key, array);
            if (!added) {
                objValues[key] = array;
            }

            // 添加到 int 数组字典
            added = intArrValues.TryAdd(key, array);
            if (!added) {
                intArrValues[key] = array;
            }
            return true;
        }

        static bool D_UInt(string key, string inputValue) {
            bool succ = uint.TryParse(inputValue, out uint value);
            if (succ) {
                bool added = uintValues.TryAdd(key, value);
                if (!added) {
                    uintValues[key] = value;
                }
                added = objValues.TryAdd(key, value);
                if (!added) {
                    objValues[key] = value;
                }
            } else {
                Debug.LogError($"FreeParam: Invalid uint value: {inputValue}");
                return false;
            }
            return succ;
        }

        static bool D_UIntArray(string key, string inputValue) {
            inputValue = inputValue.Trim();

            if (!IsValidateArray(inputValue)) {
                return false;
            }

            // 去掉首尾的 []
            inputValue = SubArray(inputValue);

            string[] values = inputValue.Split(',');
            uint[] array = new uint[values.Length];
            for (int j = 0; j < values.Length; j += 1) {
                bool succ = uint.TryParse(values[j], out uint value);
                if (succ) {
                    array[j] = value;
                } else {
                    Debug.LogError($"FreeParam: Invalid uintArray value: {values[j]}");
                    return false;
                }
            }

            // 添加到泛字典
            bool added = objValues.TryAdd(key, array);
            if (!added) {
                objValues[key] = array;
            }

            // 添加到 uint 数组字典
            added = uintArrValues.TryAdd(key, array);
            if (!added) {
                uintArrValues[key] = array;
            }
            return true;
        }

        static bool D_Long(string key, string inputValue) {
            bool succ = long.TryParse(inputValue, out long value);
            if (succ) {
                bool added = longValues.TryAdd(key, value);
                if (!added) {
                    longValues[key] = value;
                }
                added = objValues.TryAdd(key, value);
                if (!added) {
                    objValues[key] = value;
                }
            } else {
                Debug.LogError($"FreeParam: Invalid long value: {inputValue}");
                return false;
            }
            return succ;
        }

        static bool D_LongArray(string key, string inputValue) {
            inputValue = inputValue.Trim();

            if (!IsValidateArray(inputValue)) {
                return false;
            }

            // 去掉首尾的 []
            inputValue = SubArray(inputValue);

            string[] values = inputValue.Split(',');
            long[] array = new long[values.Length];
            for (int j = 0; j < values.Length; j += 1) {
                bool succ = long.TryParse(values[j], out long value);
                if (succ) {
                    array[j] = value;
                } else {
                    Debug.LogError($"FreeParam: Invalid longArray value: {values[j]}");
                    return false;
                }
            }

            // 添加到泛字典
            bool added = objValues.TryAdd(key, array);
            if (!added) {
                objValues[key] = array;
            }

            // 添加到 long 数组字典
            added = longArrValues.TryAdd(key, array);
            if (!added) {
                longArrValues[key] = array;
            }
            return true;
        }

        static bool D_ULong(string key, string inputValue) {
            bool succ = ulong.TryParse(inputValue, out ulong value);
            if (succ) {
                bool added = ulongValues.TryAdd(key, value);
                if (!added) {
                    ulongValues[key] = value;
                }
                added = objValues.TryAdd(key, value);
                if (!added) {
                    objValues[key] = value;
                }
            } else {
                Debug.LogError($"FreeParam: Invalid ulong value: {inputValue}");
                return false;
            }
            return succ;
        }

        static bool D_ULongArray(string key, string inputValue) {
            inputValue = inputValue.Trim();

            if (!IsValidateArray(inputValue)) {
                return false;
            }

            // 去掉首尾的 []
            inputValue = SubArray(inputValue);

            string[] values = inputValue.Split(',');
            ulong[] array = new ulong[values.Length];
            for (int j = 0; j < values.Length; j += 1) {
                bool succ = ulong.TryParse(values[j], out ulong value);
                if (succ) {
                    array[j] = value;
                } else {
                    Debug.LogError($"FreeParam: Invalid ulongArray value: {values[j]}");
                    return false;
                }
            }

            // 添加到泛字典
            bool added = objValues.TryAdd(key, array);
            if (!added) {
                objValues[key] = array;
            }

            // 添加到 ulong 数组字典
            added = ulongArrValues.TryAdd(key, array);
            if (!added) {
                ulongArrValues[key] = array;
            }
            return true;
        }

        static bool D_Float(string key, string inputValue) {
            bool succ = float.TryParse(inputValue, out float value);
            if (succ) {
                bool added = floatValues.TryAdd(key, value);
                if (!added) {
                    floatValues[key] = value;
                }
                added = objValues.TryAdd(key, value);
                if (!added) {
                    objValues[key] = value;
                }
            } else {
                Debug.LogError($"FreeParam: Invalid float value: {inputValue}");
                return false;
            }
            return succ;
        }

        static bool D_FloatArray(string key, string inputValue) {
            inputValue = inputValue.Trim();

            if (!IsValidateArray(inputValue)) {
                return false;
            }

            // 去掉首尾的 []
            inputValue = SubArray(inputValue);

            string[] values = inputValue.Split(',');
            float[] array = new float[values.Length];
            for (int j = 0; j < values.Length; j += 1) {
                bool succ = float.TryParse(values[j], out float value);
                if (succ) {
                    array[j] = value;
                } else {
                    Debug.LogError($"FreeParam: Invalid floatArray value: {values[j]}");
                    return false;
                }
            }

            // 添加到泛字典
            bool added = objValues.TryAdd(key, array);
            if (!added) {
                objValues[key] = array;
            }

            // 添加到 float 数组字典
            added = floatArrValues.TryAdd(key, array);
            if (!added) {
                floatArrValues[key] = array;
            }
            return true;
        }

        static bool D_Double(string key, string inputValue) {
            bool succ = double.TryParse(inputValue, out double value);
            if (succ) {
                bool added = doubleValues.TryAdd(key, value);
                if (!added) {
                    doubleValues[key] = value;
                }
                added = objValues.TryAdd(key, value);
                if (!added) {
                    objValues[key] = value;
                }
            } else {
                Debug.LogError($"FreeParam: Invalid double value: {inputValue}");
                return false;
            }
            return succ;
        }

        static bool D_DoubleArray(string key, string inputValue) {
            inputValue = inputValue.Trim();

            if (!IsValidateArray(inputValue)) {
                return false;
            }

            // 去掉首尾的 []
            inputValue = SubArray(inputValue);

            string[] values = inputValue.Split(',');
            double[] array = new double[values.Length];
            for (int j = 0; j < values.Length; j += 1) {
                bool succ = double.TryParse(values[j], out double value);
                if (succ) {
                    array[j] = value;
                } else {
                    Debug.LogError($"FreeParam: Invalid doubleArray value: {values[j]}");
                    return false;
                }
            }

            // 添加到泛字典
            bool added = objValues.TryAdd(key, array);
            if (!added) {
                objValues[key] = array;
            }

            // 添加到 double 数组字典
            added = doubleArrValues.TryAdd(key, array);
            if (!added) {
                doubleArrValues[key] = array;
            }
            return true;
        }

        static bool D_Char(string key, string inputValue) {
            inputValue = ReplaceChar(inputValue);
            bool succ = char.TryParse(inputValue, out char value);
            if (succ) {
                bool added = charValues.TryAdd(key, value);
                if (!added) {
                    charValues[key] = value;
                }
                added = objValues.TryAdd(key, value);
                if (!added) {
                    objValues[key] = value;
                }
            } else {
                Debug.LogError($"FreeParam: Invalid char value: {inputValue}");
                return false;
            }
            return succ;
        }

        static bool D_CharArray(string key, string inputValue) {
            inputValue = inputValue.Trim();

            if (!IsValidateArray(inputValue)) {
                return false;
            }

            // 去掉首尾的 []
            inputValue = SubArray(inputValue);

            string[] values = inputValue.Split(',');
            char[] array = new char[values.Length];
            for (int j = 0; j < values.Length; j += 1) {
                string cur = values[j];
                cur = ReplaceChar(cur);
                bool succ = char.TryParse(cur, out char value);
                if (succ) {
                    array[j] = value;
                } else {
                    Debug.LogError($"FreeParam: Invalid charArray value: {cur}");
                    return false;
                }
            }

            // 添加到泛字典
            bool added = objValues.TryAdd(key, array);
            if (!added) {
                objValues[key] = array;
            }

            // 添加到 char 数组字典
            added = charArrValues.TryAdd(key, array);
            if (!added) {
                charArrValues[key] = array;
            }
            return true;
        }

        static bool D_String(string key, string inputValue) {
            inputValue = ReplaceString(inputValue);
            bool added = stringValues.TryAdd(key, inputValue);
            if (!added) {
                stringValues[key] = inputValue;
            }
            added = objValues.TryAdd(key, inputValue);
            if (!added) {
                objValues[key] = inputValue;
            }
            return true;
        }

        static bool D_StringArray(string key, string inputValue) {
            inputValue = inputValue.Trim();

            if (!IsValidateArray(inputValue)) {
                return false;
            }

            // 去掉首尾的 []
            inputValue = SubArray(inputValue);

            string[] values = inputValue.Split(',');
            string[] array = new string[values.Length];
            for (int j = 0; j < values.Length; j += 1) {
                string cur = values[j];
                cur = ReplaceString(cur);
                array[j] = cur;
            }

            // 添加到泛字典
            bool added = objValues.TryAdd(key, array);
            if (!added) {
                objValues[key] = array;
            }

            // 添加到 string 数组字典
            added = stringArrValues.TryAdd(key, array);
            if (!added) {
                stringArrValues[key] = array;
            }
            return true;
        }

        static bool IsValidateArray(string inputValue) {
            if (!inputValue.StartsWith("[") || !inputValue.EndsWith("]")) {
                return false;
            }
            return true;
        }

        static string SubArray(string inputValue) {
            return inputValue.Substring(1, inputValue.Length - 2);
        }

        static string ReplaceChar(string inputValue) {
            inputValue = inputValue.Trim();
            return inputValue.Replace("'", "");
        }

        static string ReplaceString(string inputValue) {
            inputValue = inputValue.Trim();
            return inputValue.Replace("\"", "");
        }

    }

}