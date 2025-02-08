//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.ComponentModel;
//using System.IO;
//using CourseProject.Vinyl;
//using Newtonsoft.Json;


//namespace CourseProject.Services
//{
//    public class FileIOService
//    {
//        private readonly string PATH;

//        public FileIOService(string path)
//        {
//            PATH = path;
//        }

//        public BindingList<Record> LoadDate()
//        {
//            var fileExists = File.Exists(PATH);
//            if (!fileExists)
//            {
//                File.CreateText(PATH).Dispose();
//                return new BindingList<Record>();
//            }
//            using (var reader = File.OpenText(PATH))
//            {
//                var fileText = reader.ReadToEnd();
//                return JsonConvert.DeserializeObject<BindingList<Record>>(fileText);
//            }
//        }
//        public void SaveData(object RecordsList)
//        {
//            using (StreamWriter writer = File.CreateText(PATH))
//            {
//                string output = JsonConvert.SerializeObject(RecordsList);
//                writer.Write(output);
//            }
//        }
//    }
//}
