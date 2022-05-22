using System;
using System.Threading.Tasks;
using System.Net;
using System.IO.Compression;
using System.IO;
using System.Threading;

namespace ListRipper
{
    class FFMPEGManager
    {
        private static bool isDownloaded = false;

        public static Task setupFFMPEG()
        {
            
            bool hasAgreed = false;
                Console.Clear();
                FLSharp.PrintColor("FFMPEG has not been installed.", "yellow");
                FLSharp.PrintColor("Do you want to get it set up? (not having FFMPEG setup will result in the Program not working properly)", "yellow");
                FLSharp.PrintColor("Y | N", "yellow");
                Console.WriteLine("");
                string selection = Console.ReadLine();
                switch(selection.ToLower())
                {
                case "y":
                    hasAgreed = true;
                    break;
                case "yes":
                    hasAgreed = true;
                    break;
                    case "n":
                        return Task.CompletedTask;
                    case "no":
                        return Task.CompletedTask;
                default:
                    setupFFMPEG();
                    break;

                }
            if(!hasAgreed)
            {
                setupFFMPEG();
            }
            Logging.LogSystem("Downloading FFMPEG, this might take a while.");
            WebClient client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgress);
            Uri url = new Uri("https://github.com/FabioGaming/PlayListRipper/releases/download/v1.1/ffmpeg.zip");

            try
            {
                client.DownloadFileAsync(url, $"C:/Users/{Environment.UserName}/ffmpeg.zip");
            }
            catch 
            {
                Logging.LogError("Something went wrong while trying to Download ffmpeg.");
                Task.Delay(3000);
                return Task.CompletedTask;
            }
            while(!isDownloaded) {}
            
            Logging.LogSuccess("Downloaded FFMPEG!");
            Logging.LogSystem("Creating Folder...");
            try
            {
                Directory.CreateDirectory("C:/ffmpeg/");
                Logging.LogSuccess("Created Folder: C:/ffmpeg/");
            }catch
            {
                Logging.LogError("Something went wrong.");
                Thread.Sleep(3000);
                return Task.CompletedTask;
            }
            Logging.LogSystem("Extracting...");
            try
            {
                ZipFile.ExtractToDirectory($"C:/Users/{Environment.UserName}/ffmpeg.zip", "C:/ffmpeg/");
                Logging.LogSuccess("Extracted ffmpeg into: C:/ffmpeg/");
            } catch
            {
                Logging.LogError("Something went wrong.");
                Thread.Sleep(3000);
                return Task.CompletedTask;
            }
            Logging.LogSystem("Cleaning up...");
            try
            {
                File.Delete($"C:/Users/{Environment.UserName}/ffmpeg.zip");
                Logging.LogSuccess("Cleaned up data.");
            }catch
            {
                Logging.LogError("Something went wrong.");
                Thread.Sleep(3000);
                return Task.CompletedTask;
            }
            Logging.LogSystem("Adding ffmpeg to system variables...");
            try
            {
                var name = "PATH";
                var scope = EnvironmentVariableTarget.Machine;
                var oldValues = Environment.GetEnvironmentVariable(name, scope);
                var newValues = oldValues + @";C:\ffmpeg";
                Environment.SetEnvironmentVariable(name, newValues, scope);
                Logging.LogSuccess("Added ffmpeg.");
                
            } catch
            {
                Logging.LogError("Something went wrong.");
                Thread.Sleep(3000);
                return Task.CompletedTask;
            }
            Console.WriteLine("");
            Logging.LogSuccess("FFMPEG has been successfully downloaded and installed to the system.");
            FLSharp.PrintColor("Press any key to continue.", "yellow");
            Console.ReadKey();

            return Task.CompletedTask;
        }


        private static void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            string progress = null;
            string progressmessage = null;

            for (int i = 0; i != e.ProgressPercentage; i++) {
                progress = progress + "=";
                progressmessage = $"[{progress}".PadRight(100) + "]";

            }
            Console.Write("\r{0}", $"Downloading: {e.ProgressPercentage}% | {progressmessage}");
            if(e.ProgressPercentage == 100) { isDownloaded = true; }
        }
    }
}
