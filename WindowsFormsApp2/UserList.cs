using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace GameShark
{
    [Serializable]

    class Users
    {
        public String User { get; set; }
        public String Password { get; set; }
        public Boolean Mode { get; set; }

        public Users(String user, String password, Boolean mode)
        {
            this.User = user;
            this.Password = password;
            this.Mode = mode;
        }

        public static List<Users> GetList()
        {
            List<Users> usersList = new List<Users>
            {
                new Users("admin", "admin", true)
            };
            return usersList;
        }

        public static void Save(string fileName, Object objToSerialize)
        {
            FileStream fStream = File.Open(fileName, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fStream, objToSerialize);
            fStream.Close();
        }

        public static void SaveDate()
        {
            List<Users> user = GameShark.Users.GetList();
            Save("userList", user);
        }

        public static Object ReadObjectFromFile(string fileName)
        {
            Object objToSerialize = null;
            FileStream fStream = File.Open(fileName, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            objToSerialize = binaryFormatter.Deserialize(fStream);
            fStream.Close();
            return objToSerialize;
        }

        public static List<Users> GetUsers()
        {
            List<Users> u = null;
            Object obj = ReadObjectFromFile("userList");
            if (obj is List<Users>)
            {
                u = (List<Users>)obj;
            }
            return u;
        }

        public static String Encrypt(String input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}