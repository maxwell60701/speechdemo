using System;
using System.Collections.Generic;
using System.IO;
using Baidu.Aip.Speech;
using System.Configuration;

namespace Baidu.Aip.Demo
{
    public class SpeechDemo
    {
        private readonly Asr _asrClient;
        private readonly Tts _ttsClient;
        private string apikey = ConfigurationManager.AppSettings["ApiKey"].ToString();
        private string secretkey = ConfigurationManager.AppSettings["SecretKey"].ToString();
        private string recordpath = ConfigurationManager.AppSettings["recordpath"].ToString();
        private string message = ConfigurationManager.AppSettings["message"].ToString();
        public SpeechDemo()
        {
            _asrClient = new Asr(apikey, secretkey);
            _ttsClient = new Tts(apikey, secretkey);
        }

        // 识别本地文件
        public void AsrData(string path)
        {
            var data = File.ReadAllBytes(path);
            var result = _asrClient.Recognize(data, "pcm", 16000);
            Console.Write(result);
            Console.ReadKey();
        }

        // 识别URL中的语音文件
        public void AsrUrl()
        {
            var result = _asrClient.Recoginze(
                "http://xxx.com/待识别的pcm文件地址",
                "http://xxx.com/识别结果回调地址",
                "pcm",
                16000);
            Console.WriteLine(result);
        }

        // 合成
        public void Tts()
        {
            // 可选参数
            var option = new Dictionary<string, object>()
            {
                {"spd", 5}, // 语速
                {"vol", 7}, // 音量
                {"per", 4}  // 发音人，4：情感度丫丫童声
            };
            var result = _ttsClient.Synthesis(message, option);

            if (result.ErrorCode == 0)  // 或 result.Success
            {
                File.WriteAllBytes(recordpath, result.Data);
            }
        }

    }
}