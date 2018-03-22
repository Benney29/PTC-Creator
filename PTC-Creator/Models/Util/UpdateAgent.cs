using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PTC_Creator.Models.Util
{
    //Thanks to Furtif
    public class UpdateAgent
    {
        const string versionUrl = "https://raw.githubusercontent.com/ShuffleDATMT/PTC-Creator/master/PTC-Creator/Properties/AssemblyInfo.cs";
        const string releaseUrl = "https://github.com/ShuffleDATMT/PTC-Creator/releases/download/";
        public static Version RemoteVersion;

        private static WebClient _webclient = new WebClient();
        
        private async static Task<string> DownloadServerVersion()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responseContent = await client.GetAsync(versionUrl);
                return await responseContent.Content.ReadAsStringAsync();
            }
        }

        public static async Task<bool> IsLatest()
        {
            await CleanupOldFiles();
            try
            {
                Regex regex = new Regex(@"\[assembly\: AssemblyFileVersion\(""(\d{1,})\.(\d{1,})\.(\d{1,})\.(\d{1,})""\)\]");
                Match match = regex.Match(await DownloadServerVersion());

                if (!match.Success)
                    return false;

                Version gitVersion = new Version($"{match.Groups[1]}.{match.Groups[2]}.{match.Groups[3]}.{match.Groups[4]}");
                RemoteVersion = gitVersion;

                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                Version localVersion = new Version(fvi.FileVersion);

                if (gitVersion > localVersion)
                    return false;
            }
            catch (Exception)
            {
                return true; //better than just doing nothing when git server down
            }
            return true;
        }

        public static async Task<bool> Execute()
        {
            string zipName = $"PTC-Creator.zip";
            string downloadLink = $"{releaseUrl}{RemoteVersion}/{zipName}";
            string baseDir = Directory.GetCurrentDirectory();
            string downloadFilePath = Path.Combine(baseDir, zipName);
            string tempPath = Path.Combine(baseDir, "tmp");
            string extractedDir = Path.Combine(tempPath, "Update");
            string destinationDir = baseDir + Path.DirectorySeparatorChar;

            if (!DownloadFile(downloadLink, downloadFilePath))
                return false;

            if (!UnpackFile(downloadFilePath, extractedDir))
                return false;

            if (!MoveAllFiles(extractedDir, destinationDir))
                return false;

            Process.Start(Assembly.GetEntryAssembly().Location);
            Environment.Exit(-1);
            return true;
        }


        private static bool DownloadFile(string url, string dest)
        {
            try
            {
                _webclient.DownloadFile(new Uri(url), dest);
            }
            catch { return false; }
            return true;
        }

        public static bool UnpackFile(string sourceTarget, string destPath)
        {
            string source = sourceTarget;
            string dest = destPath;
            try
            {
                ZipFile.ExtractToDirectory(source, dest);
            }
            catch { return false; }
            return true;
        }

        public static bool MoveAllFiles(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);

            string[] oldfiles = Directory.GetFiles(destFolder);
            foreach (string old in oldfiles)
            {
                File.Move(old, old + ".old");
            }

            try
            {
                string[] files = Directory.GetFiles(sourceFolder);
                foreach (string file in files)
                {
                    string name = Path.GetFileName(file);
                    string dest = Path.Combine(destFolder, name);
                    try
                    {
                        File.Copy(file, dest, true);
                    }
                    catch { }
                }

                string[] folders = Directory.GetDirectories(sourceFolder);

                foreach (string folder in folders)
                {
                    string name = Path.GetFileName(folder);
                    if (name == null) continue;
                    string dest = Path.Combine(destFolder, name);
                    MoveAllFiles(folder, dest);
                }
            }
            catch { return false; }
            return true;
        }
        
        public static async Task CleanupOldFiles()
        {
            var tmpDir = Path.Combine(Directory.GetCurrentDirectory(), "tmp");

            if (Directory.Exists(tmpDir))
            {
                Directory.Delete(tmpDir, true);
            }

            var di = new DirectoryInfo(Directory.GetCurrentDirectory());
            var files = di.GetFiles("*.old", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                try
                {
                    if (file.Name.Contains("chromedriver.exe.old"))
                        continue;
                    File.Delete(file.FullName);
                }
                catch (Exception)
                {
                    //Logger.Write(e.ToString());
                }
            }
            await Task.Delay(200);
        }
    }
}
