using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace Pr.handlers
{
    public class DataBaseHandler
    {

        private static string path = "databases/users.json";
        private static string motorcycles = "databases/motorcycles.json";

        public static void addNewUser(string name, string lastName, string username, string phone, string email, string password, string token){
            List<Dictionary<string, object>> db;
            using (StreamReader sr = new StreamReader(path))
            {
                db = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(sr.ReadToEnd());
                sr.Close();
            }

            Dictionary<string, object> user = new Dictionary<string, object>();
            user["id"] = db.Count;
            user["name"] = name;
            user["last_name"] = lastName;
            user["username"] = username;
            user["phone"] = phone;
            user["email"] = email;
            user["token"] = token;
            user["role"] = "base";
            user["basket"] = new string[]{};
            user["password"] = md5(password);

            db.Add(user);

            using (StreamWriter sw = new StreamWriter(path)){
                sw.Write(JsonConvert.SerializeObject(db));
                sw.Close();
            }
        }

        public static string getToken(string email, string password){
            List<Dictionary<string, object>> db;
            using (StreamReader sr = new StreamReader(path))
            {
                db = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(sr.ReadToEnd());
                sr.Close();
            }

            foreach (Dictionary<string, object> user in db){
                if (((string)user["email"]).ToLower().Equals(email.ToLower()) && md5(password).Equals((string) user["password"])){
                    return (string)user["token"];
                }
            }

            return null;  // Если такой пользователь не найден

        }

        public static bool addItemToBasket(string token, string itemId){
            List<Dictionary<string, object>> db;
            using (StreamReader sr = new StreamReader(path))
            {
                db = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(sr.ReadToEnd());
                sr.Close();
            }

            foreach (Dictionary<string, object> user in db)
            {
                if (((string)user["token"]).Equals(token))
                {
                    List<string> basket = JsonConvert.DeserializeObject<List<string>>(user["basket"].ToString());  // Получаем корзину пользователя
                    basket.Add(itemId);
                    user["basket"] = JsonConvert.SerializeObject(basket);
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.Write(JsonConvert.SerializeObject(db));
                        sw.Close();
                    }
                    return true;
                }
            }
            return false;
        }

        public static void deleteItem(string id){
            List<Dictionary<string, object>> db;
            using (StreamReader sr = new StreamReader(motorcycles))
            {
                db = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(sr.ReadToEnd());
                sr.Close();
            }

            foreach (Dictionary<string, object> moto in db)
            {
                if (((string)moto["id"]).Equals(id)){  // Если мы нашли мотоцикл, подлежащий удалению
                    db.Remove(moto);  // Удаляем мотоцикл из базы данных
                    using (StreamWriter sw = new StreamWriter(motorcycles))
                    {
                        sw.Write(JsonConvert.SerializeObject(db));
                        sw.Close();
                    }
                    return;
                }
            }
        }

        public static void deleteBasketItem(string token, string id){
            List<Dictionary<string, object>> db;
            using (StreamReader sr = new StreamReader(path))
            {
                db = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(sr.ReadToEnd());
                sr.Close();
            }

            foreach (Dictionary<string, object> user in db){
                if (((string) user["token"]).Equals(token)){
                    List<string> basket = JsonConvert.DeserializeObject<List<string>>(user["basket"].ToString());
                    basket.Remove(id);

                    user["basket"] = JsonConvert.SerializeObject(basket);
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.Write(JsonConvert.SerializeObject(db));
                        sw.Close();
                    }
                    return;
                }
            }

        }

        public static void addItem(string title, string description, string price, string[] pictures){

            List<Dictionary<string, object>> db;
            using (StreamReader sr = new StreamReader(motorcycles))
            {
                db = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(sr.ReadToEnd());
                sr.Close();
            }

            int newId = Int32.Parse((string)db[db.Count - 1]["id"]);

            Dictionary<string, object> motorcycle = new Dictionary<string, object>();

            motorcycle["id"] = (newId + 1).ToString();
            motorcycle["title"] = title;
            motorcycle["description"] = description;
            motorcycle["price"] = price;
            motorcycle["pictures"] = JsonConvert.SerializeObject(pictures);

            db.Add(motorcycle);

            using (StreamWriter sw = new StreamWriter(motorcycles))
            {
                sw.Write(JsonConvert.SerializeObject(db));
                sw.Close();
            }
        }

        public static List<string> getBasket(string token){
            List<Dictionary<string, object>> db;
            using (StreamReader sr = new StreamReader(path))
            {
                db = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(sr.ReadToEnd());
                sr.Close();
            }

            foreach (Dictionary<string, object> user in db)
            {
                if (((string)user["token"]).Equals(token))
                {
                    List<string> basket = JsonConvert.DeserializeObject<List<string>>(user["basket"].ToString());  // Получаем корзину пользователя
                    return basket;
                }
            }

            return null;  // Если пользователь не найден
        }

        public static Dictionary<string, object> getUser(string token){
            List<Dictionary<string, object>> db;
            using (StreamReader sr = new StreamReader(path))
            {
                db = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(sr.ReadToEnd());
                sr.Close();
            }

            foreach (Dictionary<string, object> user in db)
            {
                if (((string) user["token"]).Equals(token)){
                    return user;
                }
            }

            return null;  // Если пользователь не найден

        }

        public static string role(string token){
            List<Dictionary<string, object>> db;
            using (StreamReader sr = new StreamReader(path))
            {
                db = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(sr.ReadToEnd());
                sr.Close();
            }

            foreach (Dictionary<string, object> user in db)
            {
                if (((string)user["token"]).Equals(token))
                {
                    return (string)user["role"];
                }
            }

            return null;  // Если пользователь не найден
        }

        private static string md5(string data){
            byte[] hash = Encoding.ASCII.GetBytes(data);
            MD5 md = new MD5CryptoServiceProvider();
            byte[] hashenc = md.ComputeHash(hash);
            string result = "";
            foreach (var b in hashenc)
            {
                result += b.ToString("x2");
            }
            return result;
        }

    }
}
