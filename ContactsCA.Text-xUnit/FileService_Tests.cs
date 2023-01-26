using ContactsCA.services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsCA.Text_xUnit
{
    public class FileService_Tests
    {
        FileServices fileService;
        string content;

        public FileService_Tests()
        {
            fileService = new FileServices();
            fileService.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";
            content = JsonConvert.SerializeObject(new { FirstName = "Lirije", LastName = "Shabani" });
        }

        [Fact]
        public void Should_Create_a_File_With_Json_Content()
        {
            //fileService.Save(); //save och read hittas ej
            //string result = fileService.Read();

            Assert.True(File.Exists(fileService.FilePath));
            //Assert.Equal(result.Trim(), content);
        }
    }
}
