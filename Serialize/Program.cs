using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialize
{
    class Program
    {
        static void Main(string[] args)
        {
            //保存先のファイル名
            string fileName = "test.xml";

            //保存するクラス(SampleClass)のインスタンスを作成
            targetClass obj = new targetClass(1,2);

            SaveToBinaryFile(obj, "test");
            Console.WriteLine(obj.ToString());



            //オブジェクトの内容をファイルから読み込み復元する
            targetClass obj2 = (targetClass)LoadFromBinaryFile("test");

            //読み込んだオブジェクトの内容を表示
            Console.WriteLine(obj2.ToString());


            Console.ReadLine();
        }



        /// <summary>
        /// オブジェクトの内容をファイルに保存する
        /// </summary>
        /// <param name="obj">保存するオブジェクト</param>
        /// <param name="path">保存先のファイル名</param>
        public static void SaveToBinaryFile(object obj, string path)
        {
            FileStream fs = new FileStream(path,
                FileMode.Create,
                FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            //シリアル化して書き込む
            bf.Serialize(fs, obj);
            fs.Close();
        }


        /// <summary>
        /// オブジェクトの内容をファイルから読み込み復元する
        /// </summary>
        /// <param name="path">読み込むファイル名</param>
        /// <returns>復元されたオブジェクト</returns>
        public static object LoadFromBinaryFile(string path)
        {
            FileStream fs = new FileStream(path,
                FileMode.Open,
                FileAccess.Read);
            BinaryFormatter f = new BinaryFormatter();
            //読み込んで逆シリアル化する
            object obj = f.Deserialize(fs);
            fs.Close();

            return obj;
        }
    }
}
