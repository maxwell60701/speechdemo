using Baidu.Aip.Demo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = ConfigurationManager.AppSettings["path"].ToString();
            SpeechDemo speechdemo = new SpeechDemo();
           // speechdemo.AsrData(path);
            speechdemo.Tts();
        }
    }
}
