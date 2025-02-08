using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace laba3
{
    public static class CurrentLab
    {
        public static string ConvertToBase64(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                return Convert.ToBase64String(Encoding.Unicode.GetBytes(content));
            }
        }

        public static void GenerateBase64Document()
        {
            using (FileStream fileStream = new FileStream("base64.txt", FileMode.OpenOrCreate))
            {
                string base64Content = ConvertToBase64("datch.txt");
                byte[] bytes = Encoding.Unicode.GetBytes(base64Content);
                fileStream.Write(bytes, 0, bytes.Length);
            }
        }

        public static string GenerateReport()
        {
            double base64Entropy = PreviousLab.CalculateEntropy(PreviousLab.AlphabetList.Base64);
            double latinEntropy = PreviousLab.CalculateEntropy(PreviousLab.AlphabetList.Danish);
            double base64Capacity = Math.Log("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/".Length, 2);
            double latinCapacity = Math.Log("qwertyuiopasdfghjklzxcvbnm".Length, 2);

            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine($"Base64 энтропия (Шеннон): {base64Entropy}");
            reportBuilder.AppendLine($"Latin энтропия (Шеннон): {latinEntropy}");
            reportBuilder.AppendLine($"Base64 энтропия (Чартли): {base64Capacity}");
            reportBuilder.AppendLine($"Latin энтропия (Чартли): {latinCapacity}");
            reportBuilder.AppendLine($"Резервирование base64: {(base64Capacity - base64Entropy) / base64Capacity * 100}%");
            reportBuilder.AppendLine($"Резервирование latin: {(latinCapacity - latinEntropy) / latinCapacity * 100}%");

            return reportBuilder.ToString();
        }

        public static byte[] XOR(byte[] buffer1, byte[] buffer2)
        {
            if (buffer1.Length != buffer2.Length) return null;

            byte[] result = new byte[buffer1.Length];
            for (int i = 0; i < buffer1.Length; i++)
            {
                result[i] = (byte)(buffer1[i] ^ buffer2[i]);
            }
            return result;
        }

        public static byte[] CustomXOR(byte[] buffer1, byte[] buffer2)
        {
            if (buffer1.Length != buffer2.Length) return null;

            byte[] result = new byte[buffer1.Length];
            for (int i = 0; i < buffer1.Length; i++)
            {
                string buf1Binary = Convert.ToString(buffer1[i], 2).PadLeft(8, '0');
                string buf2Binary = Convert.ToString(buffer2[i], 2).PadLeft(8, '0');
                string xorResult = "";

                for (int j = 0; j < buf1Binary.Length; j++)
                {
                    xorResult += buf1Binary[j] == buf2Binary[j] ? '0' : '1';
                }

                result[i] = Convert.ToByte(xorResult, 2);
            }
            return result;
        }
    }
}
