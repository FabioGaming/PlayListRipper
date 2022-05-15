using System;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using System.Threading.Tasks;
using YoutubeExplode.Converter;
using System.IO;
using YoutubeExplode.Common;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ListRipper
{
    class Program
    {

        public static YoutubeClient YTClient = new YoutubeClient();
        static List<Task> tasks = new List<Task>();

        static async Task Main(string[] args)
        {
            Console.Title = "PlayListRipper";
            Logging.LogSystem("starting PlayListRipper...");
            Logging.LogSuccess("PLR: ONLINE");
            await MainUIAsync();

        }
        static async Task MainUIAsync()
        {


            Console.Clear();
            FLSharp.PrintColor("1: Download Video", "yellow");
            FLSharp.PrintColor("2: Download PlayList", "yellow");
            FLSharp.PrintColor("3: Download Video (AUDIO)", "yellow");
            FLSharp.PrintColor("4: Download PlayList (AUDIO)", "yellow");
            FLSharp.PrintColor("quit: Exit", "blue");
            string input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "1":
                    await VideoDownloader();
                    break;
                case "2":
                    await ListLoader(true);
                    break;
                case "3":
                    await AudioDownloader();
                    break;
                case "4":
                    await ListLoader(false);
                    break;
                case "quit":
                    Environment.Exit(0);
                    break;
                default:
                    FLSharp.PrintColor("INVALID INPUT.", "red");
                    await MainUIAsync();
                    break;
            }
            await MainUIAsync();
        }
        static async Task AudioDownloader()
        {
            string URL;
            while (true)
            {
                Console.Clear();
                FLSharp.PrintColor("Please enter a Video link.", "yellow");
                URL = Console.ReadLine();
                if (URL.StartsWith("http://") || URL.StartsWith("https://"))
                {
                    break;
                }
            }
            Logging.LogSystem("Trying to get " + URL + "...");
            try
            {


                var video = await YTClient.Videos.GetAsync(URL);
                FLSharp.PrintColor("Video Link: " + URL, "blue");
                FLSharp.PrintColor("Video Title: " + video.Title, "blue");
                FLSharp.PrintColor("Video Creator: " + video.Author.ChannelTitle, "blue");
                FLSharp.PrintColor("Video Duration: " + video.Duration, "blue");
                Console.WriteLine("");
                FLSharp.PrintColor("Download? Y / N", "yellow");
                string choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "y":
                        await VideoDownloadHandler(URL, false);
                        break;
                    case "yes":
                        await VideoDownloadHandler(URL, false);
                        break;
                    case "n":
                        await MainUIAsync();
                        break;
                    case "no":
                        await MainUIAsync();
                        break;
                    default:
                        await MainUIAsync();
                        break;
                }
            }
            catch (Exception e)
            {
                FLSharp.PrintColor("ERROR.", "red");
                await Task.Delay(3000);
                await AudioDownloader();
            }
        }
        //Handles Video Downloads
        static async Task VideoDownloadHandler(string URL, bool isVideo)
        {
            string path = $"C:/Users/{Environment.UserName}/Desktop/PlayListRipper/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var video = await YTClient.Videos.GetAsync(URL);
            Logging.LogSystem("Starting Download of: " + video.Title);
            if (isVideo)
            {
                string filename;
                Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                filename = rgx.Replace(video.Title, "");
                await YTClient.Videos.DownloadAsync(URL, path + filename + ".mp4");
            }
            else
            {
                string filename;
                Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                filename = rgx.Replace(video.Title, "");
                await YTClient.Videos.DownloadAsync(URL, path + filename + ".mp3");
            }
            Logging.LogSuccess("Successfully Downloaded: " + video.Title);
            Console.ReadKey();
        }
        //Downloads Video
        static async Task VideoDownloader()
        {
            string URL;
            while (true)
            {
                Console.Clear();
                FLSharp.PrintColor("Please enter a Video link.", "yellow");
                URL = Console.ReadLine();
                if (URL.StartsWith("http://") || URL.StartsWith("https://"))
                {
                    break;
                }
            }
            Logging.LogSystem("Trying to get " + URL + "...");
            try
            {


                var video = await YTClient.Videos.GetAsync(URL);
                FLSharp.PrintColor("Video Link: " + URL, "blue");
                FLSharp.PrintColor("Video Title: " + video.Title, "blue");
                FLSharp.PrintColor("Video Creator: " + video.Author.ChannelTitle, "blue");
                FLSharp.PrintColor("Video Duration: " + video.Duration, "blue");
                Console.WriteLine("");
                FLSharp.PrintColor("Download? Y / N", "yellow");
                string choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "y":
                        await VideoDownloadHandler(URL, true);
                        break;
                    case "yes":
                        await VideoDownloadHandler(URL, true);
                        break;
                    case "n":
                        await MainUIAsync();
                        break;
                    case "no":
                        await MainUIAsync();
                        break;
                    default:
                        await MainUIAsync();
                        break;
                }
            }
            catch (Exception e)
            {
                FLSharp.PrintColor("ERROR.", "red");
                await Task.Delay(3000);
                await VideoDownloader();
            }
        }

        static async Task ListLoader(bool isVideo)
        {
            string URL;
            while (true)
            {
                Console.Clear();
                FLSharp.PrintColor("Please enter a PlayList link.", "yellow");
                URL = Console.ReadLine();
                if (URL.StartsWith("http://") || URL.StartsWith("https://"))
                {
                    break;
                }
            }
            Logging.LogSystem("Trying to get " + URL + "...");
            try
            {


                var video = await YTClient.Playlists.GetAsync(URL);
                FLSharp.PrintColor("PlayList Link: " + URL, "blue");
                FLSharp.PrintColor("PlayList Title: " + video.Title, "blue");
                FLSharp.PrintColor("Playlist Creator: " + video.Author.ChannelTitle, "blue");
                Console.WriteLine("");
                FLSharp.PrintColor("Download? Y / N", "yellow");
                string choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "y":
                        await PlayListDownloader(URL, isVideo);
                        break;
                    case "yes":
                        await PlayListDownloader(URL, isVideo);
                        break;
                    case "n":
                        await MainUIAsync();
                        break;
                    case "no":
                        await MainUIAsync();
                        break;
                    default:
                        await MainUIAsync();
                        break;
                }
            }
            catch (Exception e)
            {
                FLSharp.PrintColor("ERROR.", "red");
                await Task.Delay(3000);
                await ListLoader(isVideo);
            }
        }

        static async Task PlayListDownloader(string URL, bool isVideoStream)
        {
            var playlist = await YTClient.Playlists.GetVideosAsync(URL);
            var playListInfo = await YTClient.Playlists.GetAsync(URL);
            string path = $"C:/Users/{Environment.UserName}/Desktop/PlayListRipper/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            string foldername = rgx.Replace(playListInfo.Title, "");
            path = $"C:/Users/{Environment.UserName}/Desktop/PlayListRipper/{foldername}/";
            Directory.CreateDirectory(path);
            foreach(var video in playlist)
            {

                await Task.Delay(500);
                Task t = Task.Run(async () =>
                {

                    try
                    {
                        Logging.LogSystem("Downloading: " + video.Title);
                        if (isVideoStream)
                        {
                            string filename;
                            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                            filename = rgx.Replace(video.Title, "");
                            await YTClient.Videos.DownloadAsync(video.Url, path + filename + ".mp4");

                        }
                        else
                        {

                            string filename;
                            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                            filename = rgx.Replace(video.Title, "");

                            var streamManifest = await YTClient.Videos.Streams.GetManifestAsync(video.Id);
                            var audioStreamInfo = streamManifest.GetAudioStreams().GetWithHighestBitrate();
                            var streamInfos = new IStreamInfo[] { audioStreamInfo };

                            await YTClient.Videos.DownloadAsync(video.Url, path + filename + ".mp3");
                            //await YTClient.Videos.DownloadAsync(streamInfos, new ConversionRequestBuilder(path + filename + ".mp3").Build());
                        }
                        Logging.LogSuccess("Downloaded: " + video.Title);
                    }
                    catch (Exception e) 
                    {
                        Logging.LogError("Couldn't Download: " + video.Title);
                    
                    }


                });
                tasks.Add(t);
                
            }
            await Task.WhenAll(tasks.ToArray());
            Console.WriteLine("");
            Logging.LogSuccess("Downloaded all Videos from: " + playListInfo.Title);
            Console.ReadKey();

        }
    }
}
