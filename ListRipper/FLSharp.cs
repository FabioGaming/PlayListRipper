using System;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;

namespace ListRipper
{
    class FLSharp
    {
        /*
         * Disclaimer & Information about this API
         * 
         * FLSharp is a C# API provided by FoxLabs(https://foxlabs.studio/) to help you, the user, to make your coding experience faster!
         * This API version is specifically made for ConsoleApps so we dont recommend using it on WPF apps etc., please note that bugs or issues can still occur, and if you happen to find any, please contact us at https://foxlabs.studio/contact .
         * 
         * We, the FoxLabs team, do not take any responsibility if harm is caused by this API, since it is all based on what the user does with it.
         * We do not recommend downloading this Software from third parties, and do not take any responsibility if any damage happens.
         * Download this Script from third parties on your own risk!
         * 
         * How do I know that this Script wasn't given out by a third party?
         * If you didn't got this Script from https://foxlabs.studio/software/flsharp we do no recommend using it in your Project.
         * 
         * We strongly recommend joining our Discord Server(https://discord.foxlabs.studio) to get notified if a new version of FLSharp releases, or to see general updates.
         * 
         * 
         * Copyright
         * Please note that this API is completely free to use to anyone.
         * We don't force anyone to credit this API, but we would be very grateful, if you don't claim this API as your own.
         * 
         * How to use FLSharp:
         * Simply import this Script into your Project Folder and then use the functions like this: FLSharp.FunctionName(); 
         * For an easier usage of this API, rename the NameSpace to your current Project name.
         * If your Project is called "TestProgram", call the API NameSpace "TestProgram". Otherwise you need to type FoxLabsAPI.FLSharp.Function, wich makes it less efficent to use.
         * 
         * API: FLSharp | FoxLabs, version: 1.0
         * 
         * And with all that said, have a good time using our Software & more!
         */







        //Creates a File in the System.
        //Example Usage: FLSharp.CreateFile("C:\Users\name\", "test.txt");
        public static void CreateFile(string path, string name)
        {
            if (path.EndsWith("\\"))
            {
                if (Directory.Exists(path))
                {
                    File.CreateText(path + name);
                }
                else
                {
                    Console.WriteLine($@"Could not locate Path: {path}.");
                }
            }
            else
            {

                path = path + "\\";
                if (Directory.Exists(path))
                {
                    File.CreateText(path + name);
                }
                else
                {
                    Console.WriteLine($@"Could not locate Path: {path}.");
                }

            }
        }

        //Creates a Folder in the system.
        //Example Usage: FLSharp.CreateFolder("C:\Users\name\", "test");
        public static void CreateFolder(string path, string name)
        {
            if(path.EndsWith("\\"))
            {
                if (Directory.Exists(path))
                {
                    Directory.CreateDirectory(path + name);
                }
                else
                {
                    Console.WriteLine($@"Could not locate Path: {path}.");
                }
            } else
            {

                path = path + "\\";
                if (Directory.Exists(path))
                {
                    Directory.CreateDirectory(path + name);
                }
                else
                {
                    Console.WriteLine($@"Could not locate Path: {path}.");
                }

            }
        }


        //Returns the System username. Format: string. 
        //Example usage: string name = FLSharp.SystemUserName();
        public static string GetSystemUserName()
        {
            return Environment.UserName;
        }


        //Returns the current Time. Format: string.
        //Example usage: string time = FLSharp.GetTime();
        public static string GetTime()
        {
            var time = DateTime.Now.ToShortTimeString();
            return time;
        }

        //Returns the current Date. Format: string.
        //Example usage: string date = FLSharp.GetDate();
        public static string GetDate()
        {
            var date = DateTime.Now.ToShortDateString();
            return date;
        }

        //Returns the current Date and Time. Format: string.
        //Example usage: string datetime = FLSharp.GetDateTime();
        public static string GetDateTime()
        {
            return DateTime.Now.ToString();
        }

        //Returns current path the File is running in. Format: string
        //Example usage: string currentpath = FLSharp.GetCurrentPath();
        public static string GetCurrentPath()
        {
            //string path = AppDomain.CurrentDomain.BaseDirectory;
            string path = Directory.GetCurrentDirectory();
            path = path + "\\";
            return path;
        }

        //Returns name of the File. Format: string.
        //Example usage: string AppName = FLSharp.GetAppName();
        //Example File: FoxLabsAPI.exe, will return FoxLabsAPI as string.
        public static string GetAppName()
        {
            string name = AppDomain.CurrentDomain.FriendlyName;
            return name;
        }

        //Returns current App Version. Format: string.
        //Example usage: string version = FLSharp.GetVersion();
        //Example version: 1.0.0.0, will return 1.0.0.0 as string.
        public static string GetVersion()
        {
            var versionobj = Assembly.GetExecutingAssembly().GetName().Version;
            string version = versionobj.ToString();
            return version;
        }

        //Checks if Network connection is available. Format: boolean.
        //Example usage: if(FLSharp.CheckForConnection == true)...
        public static bool CheckForConnection()
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send("google.com");
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;

        }

        //Checks if a file already exists. Format: bool.
        //Example usage: if(FLSharp.CheckForFile("C:\Users\username\desktop\testfile.txt"))...
        public static bool CheckForFile(string path)
        {
            if(File.Exists(path))
            {
                return true;
            } else
            {
                return false;
            }

        }

        //Checks if a folder already exists. Format: bool.
        //Example usage: if(FLSharp.CheckForFolder("C:\Users\username\Desktop\testfolder\"))
        public static bool CheckForFolder(string path)
        {
            if(path.EndsWith("\\"))
            {
                if(Directory.Exists(path))
                {
                    return true;
                } else
                {
                    return false;
                }
            } else
            {
                path = path + "\\";
                if (Directory.Exists(path))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        //Downloads a File to the directory the Program was opened in.
        //Example usage: FLSharp.DownloadFile("https://foxlabs.studio/", "home.html");
        //Will download the Homepage of FoxLabs.
        public static void DownloadFile(string URL, string FileName)
        {
            if(URL == null || FileName == null)
            {
                Console.WriteLine("Invalid URL or FileName");
            } else
            {
                if (!URL.EndsWith("/"))
                {
                    URL = URL + "/";
                }
                WebClient downloadFile = new WebClient();
                string DownloadResource = URL + FileName;
                downloadFile.DownloadFile(DownloadResource, FileName);
            }
        }

        //Deletes a File, use at your own risk!
        //Example usage: FLSharp.DeleteFile("C:\Users\username\testfile.txt");
        public static void DeleteFile(string FilePath)
        {
            if(File.Exists(FilePath))
            {
                File.Delete(FilePath);    
            } else
            {
                Console.WriteLine("cannot locate File: " + FilePath);
            }
        }

        //Creates a File with Text.
        //Example usage: FLSharp.CreateFilledFile("C:\Users\username\Desktop\", "test.txt", "this is a test");
        //If you want multiple lines you can use \n , example: "this is a test\nthis is also a test"
        public static void CreateFilledFile(string Path, string Name, string Content)
        {
            if(!Path.EndsWith("\\"))
            {
                Path = Path + "\\";
            }
            if(Directory.Exists(Path))
            {
                using (StreamWriter sw = File.CreateText(Path + Name))
                {
                    sw.WriteLine(Content);
                }
            } else
            {
                Console.WriteLine("Cannot locate directory: " + Path);
            }
        }

        //Just in case you don't want to use Console.WriteLine(); all the time.
        public static void Print(string Message)
        {
            Console.WriteLine(Message);
        }

        //Allows you to Print colored text.
        //Example usage: FLSharp.Printcolor("this is green text", "green");
        /* Color List
         * black
         * blue
         * cyan
         * darkblue (or dark_blue)
         * darkcyan (or dark_cyan)
         * darkgray (or dark_gray)
         * darkgreen (or dark_green)
         * darkmagenta (or dark_magenta)
         * darkred (or dark_red)
         * darkyellow (or dark_yellow)
         * gray
         * green
         * magenta
         * red
         * white
         * yellow
         */
        public static void PrintColor(string message, string color)
        {
            color = color.ToLower();

            switch(color)
            {
                case "black":
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "darkblue":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case "dark_blue":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case "darkcyan":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case "dark_cyan":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case "darkgray":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case "dark_gray":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case "darkgreen":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case "dark_green":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case "darkmagenta":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case "dark_magenta":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case "darkred":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case "dark_red":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case "darkyellow":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case "dark_yellow":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case "gray":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "magenta":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "white":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }


            Console.WriteLine(message);
            Console.ResetColor();
        }

        //Opens full documentation about this API
        public static void Documentation()
        {
            Process webstart = new Process();
            webstart.StartInfo.UseShellExecute = true;
            webstart.StartInfo.FileName = "https://www.foxlabs.studio/software/flsharp";
            webstart.Start();
        }

        //If you want to do us a favor you can set this into your code somewhere to give credit for the API.
        //We really appreciate your Support!
        public static void Credits()
        {
            PrintColor("FoxLabs | FLSharp API", "green");
            PrintColor("Provided for free use by FoxLabs", "green");
            PrintColor("This software was made with the help of the official FoxLabs API!", "green");
            PrintColor("Check out https://www.foxlabs.studio/ and https://www.foxlabs.studio/software/flsharp to see more about us and this API.", "green");
        }




        /*
         * Please note that the following Functions require FFMPEG
         * If you don't have it installed Properly it won't work.
         * 
         * How to check if FFMPEG is installed properly?
         * 1. Press Windows + R 
         * 2. Type "CMD"
         * 3. type "ffmpeg"
         * 
         * If you don't see Information about FFMPEG it is not installed Properly.
         */


        //Converts a Video into its frames
        //Output will be the same as your chosen path, in a folder called like the target File.
        //Please note that this process can take some time, and will automatically continue the C# code after it's finished.
        public static void ImgConvert(string path)
        {
            if(File.Exists(path))
            {
                if(Path.GetExtension(path) == ".mp4")
                {
                    int index = path.LastIndexOf("\\");
                    string FileName = Path.GetFileName(path);
                    string FolderPath = path.Substring(0, index) + "\\";
                    string FolderName = Path.GetFileNameWithoutExtension(FileName);
                    Directory.CreateDirectory($@"{FolderPath}{FolderName}");
                    var p = new Process
                    {
                        StartInfo =
                    {
                     FileName = "cmd",
                     WindowStyle = ProcessWindowStyle.Hidden,
                     WorkingDirectory = $@"C:\Users\{GetSystemUserName()}\",
                     Arguments = $@"/C cd /d """"{FolderPath}"""" & ffmpeg -i """"{path}"""" """"{FolderPath}{FolderName}\%04d.jpg"""""
                    }
                    }.Start();
                } else
                {
                    Console.WriteLine($@"Could not Convert {path}, please make sure the target file is in MP4 format.");
                }
            } else
            {
                Console.WriteLine("Could not locate File: " + path);
            }    
        }

        public static void ExtractAudio(string path)
        {
            if(File.Exists(path))
            {
                if(Path.GetExtension(path) == ".mp4")
                {
                    int index = path.LastIndexOf("\\");
                    string FileName = Path.GetFileName(path);
                    string FolderPath = path.Substring(0, index) + "\\";
                    string FolderName = Path.GetFileNameWithoutExtension(FileName);
                    Directory.CreateDirectory($@"{FolderPath}{FolderName}audio");
                    var p = new Process
                    {
                        StartInfo =
                        {
                            FileName = "cmd",
                            WindowStyle = ProcessWindowStyle.Hidden,
                            Arguments = $@"/C cd /d ""{FolderPath}"" & ffmpeg -i ""{FileName}"" -vn -acodec copy ""{FolderPath}{FolderName}audio\{FolderName}.aac"""
                        }
                    }.Start();
                } else
                {
                    Console.WriteLine("Invalid file format, please make sure the target file is MP4.");
                }



            } else
            {
                Console.WriteLine("Cannot locate File: " + path);
            }

        }

    }
}
