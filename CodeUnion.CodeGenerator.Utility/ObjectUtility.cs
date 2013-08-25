using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace CodeUnion.CodeGenerator.Utility
{
    public static class ObjectUtility
    {
        public static O Clone<O>(O o) where O: class
        {
            MemoryStream serializationStream = new MemoryStream();
            serializationStream.Seek(0, SeekOrigin.Begin);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(serializationStream, o);
            serializationStream.Seek(0, SeekOrigin.Begin);
            return (O) formatter.Deserialize(serializationStream);
        }

        public static O DeserializeFromXml<O>(string s)
        {
            O local = default(O);
            try
            {
                StringReader textReader = new StringReader(s);
                XmlSerializer serializer = new XmlSerializer(typeof(O));
                local = (O) serializer.Deserialize(textReader);
            }
            catch
            {
            }
            return local;
        }

        public static string Duplicate(this string s, int n)
        {
            char[] src = s.ToCharArray();
            char[] dst = new char[src.Length * n];
            for (int i = 0; i < n; i++)
            {
                Buffer.BlockCopy(src, 0, dst, (i * src.Length) * 2, src.Length * 2);
            }
            return new string(dst);
        }

        public static object Parse(this Type type, string s)
        {
            object obj2 = null;
            try
            {
                if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(Nullable<>)))
                {
                    return Convert.ChangeType(s, Nullable.GetUnderlyingType(type));
                }
                obj2 = Convert.ChangeType(s, type);
            }
            catch
            {
            }
            return obj2;
        }

        public static string SerializeToXml<O>(O o)
        {
            string str = "";
            try
            {
                StringWriter writer = new StringWriter();
                new XmlSerializer(typeof(O)).Serialize((TextWriter) writer, o);
                str = writer.ToString();
            }
            catch
            {
            }
            return str;
        }

        public static string ToCamel(this string s)
        {
            StringBuilder builder = new StringBuilder();
            bool flag = true;
            foreach (char ch in s)
            {
                if (flag & char.IsUpper(ch))
                {
                    builder.Append(char.ToLower(ch));
                }
                else
                {
                    builder.Append(ch);
                }
            }
            return builder.ToString();
        }

        public static string ToPascal(this string s)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (i == 0)
                {
                    builder.Append(char.ToUpper(c));
                }
                else
                {
                    builder.Append(c);
                }
            }
            return builder.ToString();
        }
    }
}

