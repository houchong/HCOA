using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoDbDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //mongodb连接字符串
            string connStr = ConfigurationManager.AppSettings["MongoServerSettings"];
            //实例mongo对象
            MongoClient client = new MongoClient(connStr);
            IMongoDatabase mongoDb = client.GetDatabase("hc");
            //建立collection
            var collection = mongoDb.GetCollection<UserInfo>("hcuser");
            //var document = new BsonDocument
            //{
            //    {"name","MongoDB"},
            //    {"type","Database"},
            //    {"count",1},
            //    {"info",new BsonDocument{{"x",203},{"y",102}}}
            //};
            #region
            for(int i=0;i<100;i++)
            {
                UserInfo userInfo = new UserInfo
                {
                    UserName = "hc" + i,
                    Email = "hc" + i + "@qq.com",
                    RegisTime = DateTime.Now
                };
                collection.InsertOne(userInfo);
            }
            var userinfo = collection.Find(new BsonDocument()).ToCursor();
            //foreach(var user in userinfo.ToEnumerable())
            //{
            //    Console.Write(user.ToJson());
            //}
           // var filter = Builders<UserInfo>.Filter.Eq("UserName", "hc1");
            var userone = collection.Find(c=>c.UserName=="hc1");
            Console.Write(userone.First().ToJson());
            #endregion
            //插入数据
            //collection.InsertOne(document);
           // var document1 = collection.Find(document);
            
            //更新数据
            //var filter = Builders<BsonDocument>..Eq("name", "MongoDB");
            //var update = Builders<BsonDocument>.Update.Set("name", "Ghazi");

        }
    }
}
