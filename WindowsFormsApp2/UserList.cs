using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GameShark
{
    [Serializable]

    class UserList
    {
        public UserList(String user, String password, String mode)
        {
            this.User = user;
            this.Password = password;
            this.Mode = mode;
        }

        public String User { get; set; }
        public String Password { get; set; }
        public String Mode { get; set; }

        public static List<UserList> getList()
        {
            List<UserList> userList = new List<UserList>();
            return userList;
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
            List<UserList> user = UserList.getList();
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

        public static List<UserList> getUsers()
        {
            List<UserList> u = null;
            Object obj = ReadObjectFromFile("userList");
            if (obj is List<UserList>)
            {
                u = (List<UserList>)obj;
            }
            return u;
        }

        public static String encrypt(String input)
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
