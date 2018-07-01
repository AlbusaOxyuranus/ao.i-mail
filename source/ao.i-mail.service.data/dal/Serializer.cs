using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;

namespace ao.i_mail.service.data.dal
{
    /// <remarks>Класс помощник позволяющий сохранять данные классов</remarks>
    public static class Serializer
    {
        /// <summary>
        /// 
        /// </summary>
        public const string JsonExtension = ".json";

        /// <summary>
        /// 
        /// </summary>
        public static readonly List<Type> KnownTypes = new List<Type>
        {
            typeof(Type),
            typeof(Dictionary<string, string>),
            typeof(List<Type>),
        };

        public static string SerializeDataContract(this object item, Type type = null)
        {
            type = type ?? item.GetType();
            var serializer = new DataContractJsonSerializer(type, KnownTypes);

            using (var stream = new MemoryStream())
            {
                var currentCulture = Thread.CurrentThread.CurrentCulture;
                Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                serializer.WriteObject(stream, item);
                Thread.CurrentThread.CurrentCulture = currentCulture;
                return Encoding.UTF8.GetString((stream.ToArray()));
            }
        }

        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static TItem DeserializeDataContract<TItem>(string str)
        {
            try
            {
                var serializer = new DataContractJsonSerializer(typeof(TItem), KnownTypes);
                using (var stream = GenerateStreamFromString(str))
                {
                    var currentCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                    var item = (TItem)serializer.ReadObject(stream);
                    Thread.CurrentThread.CurrentCulture = currentCulture;
                    return item;
                }
            }
            catch (Exception exception)
            {
                //throw new Exception(exception.Message);
                return default(TItem);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="file"></param>
        /// <param name="type"></param>
        public static void SerializeDataContractFile(this object item, string file = null, Type type = null)
        {
            try
            {
                type = type ?? item.GetType();
                if (string.IsNullOrEmpty(file))
                    file = type.Name + JsonExtension;
                var serializer = new DataContractJsonSerializer(type, KnownTypes);
                using (var stream = File.Create(file))
                {
                    var currentCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                    serializer.WriteObject(stream, item);
                    Thread.CurrentThread.CurrentCulture = currentCulture;
                }
            }
            catch (Exception exception) //Отбработать ошибку как следует
            {
                Debug.WriteLine("Ошибка серилизации срочно обработать!\r\n" + exception.Message +
                                "\r\n" + exception.Source + "\r\n" + exception.StackTrace);
                //throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="file"></param>
        /// <returns></returns>
        public static TItem DeserializeDataContractFile<TItem>(string file = null)
        {
            try
            {
                if (string.IsNullOrEmpty(file))
                    file = typeof(TItem).Name + JsonExtension;
                var serializer = new DataContractJsonSerializer(typeof(TItem), KnownTypes);
                using (var stream = File.OpenRead(file))
                {
                    var currentCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                    var item = (TItem)serializer.ReadObject(stream);
                    Thread.CurrentThread.CurrentCulture = currentCulture;

                    return item;
                }
            }
            catch (Exception exception)
            {
                //throw new Exception(exception.Message);
                return default(TItem);
            }
        }
    }
}
