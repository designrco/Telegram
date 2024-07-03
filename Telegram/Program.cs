using System;
using System.IO;
using Telegram.Bot;
using System.Threading.Tasks;

var botToken = "Token here";
var ChannelId = "telegram chanel with @"; // یا عددی: "-1001234567890"
var filePath = "C:/Users/Mammad/Desktop/musicfa/Content/img/2.jpg";
var musicFile = "Files/1.mp3";
var caption = "for test";

await SendPhotoToChannel(botToken, ChannelId, filePath, caption);
await SendFileToChannel(botToken, ChannelId, musicFile);

static async Task SendPhotoToChannel(string botToken, string channelId, string filePath, string caption = "")
{
    var fileName = System.IO.Path.GetFileName(filePath);
    var file = System.IO.File.ReadAllBytes(filePath);
    var captionParemater = !string.IsNullOrEmpty(caption) ? string.Format("&caption={0}", caption) : string.Empty;

    using (var httpClient = new System.Net.Http.HttpClient())
    {
        var api = string.Format("https://mtorgforiranserver.mohammad-bahonar1.workers.dev/bot{0}/sendPhoto?chat_id={1}{2}", botToken, channelId, captionParemater);
        using (var multipartFormDataContent = new System.Net.Http.MultipartFormDataContent())
        {
            var streamContent = new System.Net.Http.StreamContent(new System.IO.MemoryStream(file));
            streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            streamContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
            {
                FileName = fileName,
                Name = "photo"
            };

            multipartFormDataContent.Add(streamContent, "photo", fileName);
            using (var messageFile = httpClient.PostAsync(api, multipartFormDataContent))
            {
                await messageFile.Result.Content.ReadAsStringAsync();
            }
        }
    }
}

static async Task SendFileToChannel(string botToken, string channelId, string filePath)
{
    var fileName = System.IO.Path.GetFileName(filePath);
    var file = System.IO.File.ReadAllBytes(filePath);

    using (var httpClient = new System.Net.Http.HttpClient())
    {
        var api = string.Format("https://mtorgforiranserver.mohammad-bahonar1.workers.dev/bot{0}/sendDocument?chat_id={1}", botToken, channelId);
        using (var multipartFormDataContent = new System.Net.Http.MultipartFormDataContent())
        {
            var streamContent = new System.Net.Http.StreamContent(new System.IO.MemoryStream(file));
            streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            streamContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
            {
                FileName = fileName,
                Name = "document"
            };

            multipartFormDataContent.Add(streamContent, "document", fileName);
            using (var messageFile = httpClient.PostAsync(api, multipartFormDataContent))
            {
               await messageFile.Result.Content.ReadAsStringAsync();
            }
        }
    }
}

Console.WriteLine("send shod");
Console.ReadKey();