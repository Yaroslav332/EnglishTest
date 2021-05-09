using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YandexDisk.Client;
using YandexDisk.Client.Clients;
using YandexDisk.Client.Http;
using YandexDisk.Client.Protocol;

namespace EnglishTest.CompletingTasks
{
    static class DiscWriter
    {
        public static string AccessToken { get; } = "AQAAAABUqfVvAAcb0PLnGhVG80x7uHoHoWthQYA";

        public static string SavePath {
            get
            {
                return savePath;
            }
            set
            {
                if (!Task.Run(() => CheckUserPassed(value)).Result)
                {
                    savePath = value;
                    Task.Run(() => CreateDir());
                }
            }
        }
        private static string savePath = "/Audio";
        private static IDiskApi diskApi = null;

        public async static Task<bool> CheckUserPassed(string path)
        {
            if (diskApi == null) diskApi = new DiskHttpApi(AccessToken);
            try
            {
                Resource res = await diskApi.MetaInfo.GetInfoAsync(new ResourceRequest
                {
                    Path = path
                }, CancellationToken.None);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private async static Task CreateDir()
        {
            await diskApi.Commands.CreateDictionaryAsync(SavePath);
        }
        public async static Task UploadFile(string filePath, string fileName){
            await diskApi.Files.UploadFileAsync(path: SavePath+"/"+fileName,
                                                overwrite: false,
                                                localFile: filePath,
                                                cancellationToken: CancellationToken.None);
            
        }
    }
}
