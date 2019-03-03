namespace Mallos.Serialization
{
    using System;

    public abstract class SerializationStream
    {
        public bool GetBoolean(string name) => GetValue<bool>(name);
        public byte GetByte(string name) => GetValue<byte>(name);
        public char GetChar(string name) => GetValue<char>(name);
        public DateTime GetDateTime(string name) => GetValue<DateTime>(name);
        public decimal GetDecimal(string name) => GetValue<decimal>(name);
        public double GetDouble(string name) => GetValue<double>(name);
        public short GetInt16(string name) => GetValue<short>(name);
        public int GetInt32(string name) => GetValue<int>(name);
        public long GetInt64(string name) => GetValue<long>(name);
        public sbyte GetSByte(string name) => GetValue<sbyte>(name);
        public float GetSingle(string name) => GetValue<float>(name);
        public string GetString(string name) => GetValue<string>(name);
        public ushort GetUInt16(string name) => GetValue<ushort>(name);
        public uint GetUInt32(string name) => GetValue<uint>(name);
        public ulong GetUInt64(string name) => GetValue<ulong>(name);

        public T GetValue<T>(string name) => (T)GetValue(name, typeof(T));
        public abstract object GetValue(string name, Type type);

        public void AddBoolean(string name, bool value) => AddValue(name, value);
        public void AddByte(string name, byte value) => AddValue(name, value);
        public void AddChar(string name, char value) => AddValue(name, value);
        public void AddDateTime(string name, DateTime value) => AddValue(name, value);
        public void AddDecimal(string name, decimal value) => AddValue(name, value);
        public void AddDouble(string name, double value) => AddValue(name, value);
        public void AddInt16(string name, short value) => AddValue(name, value);
        public void AddInt32(string name, int value) => AddValue(name, value);
        public void AddInt64(string name, long value) => AddValue(name, value);
        public void AddSByte(string name, sbyte value) => AddValue(name, value);
        public void AddSingle(string name, float value) => AddValue(name, value);
        public void AddString(string name, string value) => AddValue(name, value);
        public void AddUInt16(string name, ushort value) => AddValue(name, value);
        public void AddUInt32(string name, uint value) => AddValue(name, value);
        public void AddUInt64(string name, ulong value) => AddValue(name, value);

        public void AddValue<T>(string name, T value) => AddValue(name, value, typeof(T));
        public abstract void AddValue(string name, object value, Type type);
    }
}
