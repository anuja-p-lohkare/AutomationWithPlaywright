using System.IO.Compression;

namespace PlaywrightUIAutomation.CommonUtilities
{
    public class GetPaths
    {
        public static string workingDirectory = Environment.CurrentDirectory;

        public static string GetExtentReportPath()
        {
            string path = workingDirectory + "\\index.html";
            return path;
        }

        public static string GetProjectPath()
        {
            var projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            return projectPath;
        }

        public static void SaveExtentReport(string fileName)
        {
            var extentReportFolder = Path.Combine(workingDirectory, "ExtentReports");
            var reportsfldr = Path.Combine(workingDirectory, "Reports");
            var destinationPath = Path.Combine(workingDirectory, "ExtentReports" + Path.DirectorySeparatorChar + fileName + ".html");
            var sourcePath = GetExtentReportPath();

            Directory.CreateDirectory(extentReportFolder);
            Directory.CreateDirectory(reportsfldr);

            try
            {
                File.Move(sourcePath, destinationPath);

                var sourceFolder = Path.Combine(workingDirectory, "ExtentReports");
                var destinationFolder = Path.Combine(workingDirectory, "Reports" + Path.DirectorySeparatorChar + "ExtentReports.zip");

                ZipFile.CreateFromDirectory(sourceFolder, destinationFolder);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ClearOldExtentReport()
        {
            var extentReportFolder = Path.Combine(workingDirectory, "ExtentReports");
            var reportsfldr = Path.Combine(workingDirectory, "Reports");

            ClearFolder(extentReportFolder, "ExtentReports");
            ClearFolder(reportsfldr, "Reports");
        }

        private static void ClearFolder(string folderPath, string foldername)
        {
            if (Directory.Exists(folderPath))
            {
                var files = Directory.GetFiles(folderPath);
                if(files.Length > 0)
                {
                    foreach(var file in files)
                    {
                        File.Delete(file);
                    }
                }
            }
            else
            {
                Console.WriteLine($"No old {foldername} present in {folderPath} folder.");
            }
        }
    }
}
