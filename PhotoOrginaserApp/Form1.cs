using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoOrginaserApp
{
    public partial class Form1 : Form
    {
        public string folderOriginPath = @"C:\Users\nonst\Desktop\képek\2025_08_19_mindeneddigi";
        public string newfolderPath = @"C:\Users\nonst\Desktop\képek";
        public string folderPathName = null;
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        public string[] filenames;
        public string[] filenamepaths;

        public Form1()
        {
            InitializeComponent();
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            fbd.SelectedPath = folderOriginPath;
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderPathName = fbd.SelectedPath;
                setText(folderPathName);
            }
        }

        public void setText(string pathStr)
        {
            folderPathName = pathStr;
            folder_text.Text = pathStr;
        }

        private async void list_items_Click(object sender, EventArgs e)
        {

            if (folderPathName != null)
            {
                ProgressBarForm pbf = new ProgressBarForm();
                pbf.Show();
                filenamepaths = Directory.GetFiles(folderPathName, "*.*", SearchOption.AllDirectories)
                                          .Where(s => s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                                                   || s.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                                          .ToArray();

                filenames = filenamepaths.Select(path => Path.GetFileName(path)).ToArray();

                Console.WriteLine("Filenames without path lenght", filenames.Length);
                Console.WriteLine("Filenames with path lenght", filenamepaths.Length);


                int total = filenames.Length;
                pbf.SetMaximum(total);

                list_of_filenames.Items.Clear();

                await Task.Run(() =>
                {
                    for (int i = 0; i < total; i++)
                    {
                        string file = filenames[i];
                        try
                        {
                            Invoke(new Action(() =>
                            {
                                filenamepaths.Append(file);
                                list_of_filenames.Items.Add(filenames.GetValue(i));
                            }));
                            pbf.UpdateProgress(i + 1);
                        }
                        catch (Exception exp)
                        {
                            Console.WriteLine("ERROR: " + exp.Message);
                        }
                    }
                });
                countTextBox.Text = total.ToString();
                pbf.Close();
            }
            else
            {
                MessageBox.Show("You have to choose folder first!", "Choose folder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void RunAlgorithm_btn_Click(object sender, EventArgs e)
        {
            // FOLDER CREATION
            int startYear = 2019;
            int endYear = DateTime.Now.Year;
            for (int year = startYear; year <= endYear; year++)
            {
                string yearFolder = Path.Combine(newfolderPath, year.ToString());
                if (!Directory.Exists(yearFolder))
                {
                    Directory.CreateDirectory(yearFolder);
                }

                for (int month = 1; month <= 12; month++)
                {
                    string monthName = new DateTime(year, month, 1).ToString("MMMM");
                    string monthFolder = Path.Combine(yearFolder, $"{year}_{monthName}");
                    if (!Directory.Exists(monthFolder))
                    {
                        Directory.CreateDirectory(monthFolder);
                    }
                }
            }

            // Create Unidentified folder
            string unidentifiedFolder = Path.Combine(newfolderPath, "Unidentified");
            if (!Directory.Exists(unidentifiedFolder))
            {
                Directory.CreateDirectory(unidentifiedFolder);
            }

            // Progress bar setup
            ProgressBarForm pbf = new ProgressBarForm();
            pbf.SetMaximum(filenames.Length);
            pbf.Show();

            // FILE MOVEMENT with progress
            await Task.Run(() =>
            {
                for (int i = 0; i < filenames.Length; i++)
                {
                    string fileName = filenames[i];
                    string filePath = filenamepaths.FirstOrDefault(f => Path.GetFileName(f) == fileName);
                    try
                    {
                        DateTime dateTaken = GetDateTakenFromImage(filePath);
                        string destinationPath;
                        if (dateTaken.Year > 1)
                        {
                            string monthName = dateTaken.ToString("MMMM");
                            string destinationFolder = Path.Combine(newfolderPath, dateTaken.Year.ToString(), $"{dateTaken.Year}_{monthName}");
                            if (!Directory.Exists(destinationFolder))
                            {
                                Directory.CreateDirectory(destinationFolder);
                            }
                            destinationPath = Path.Combine(destinationFolder, Path.GetFileName(filePath));
                        }
                        else // unidentified
                        {
                            destinationPath = Path.Combine(unidentifiedFolder, Path.GetFileName(filePath));
                        }
                        File.Move(filePath, destinationPath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error moving file {filePath}: {ex.Message}");
                    }
                    // Update progress bar on UI thread
                    Invoke(new Action(() => pbf.UpdateProgress(i + 1)));
                }
            });

            pbf.Close();

            RefreshFileList();

            MessageBox.Show("Kész a mozgatás", "Kész", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RefreshFileList()
        {
            if (folderPathName != null)
            {
                filenamepaths = Directory.GetFiles(folderPathName, "*.*", SearchOption.AllDirectories)
                                          .Where(s => s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                                                   || s.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                                          .ToArray();

                filenames = filenamepaths.Select(path => Path.GetFileName(path)).ToArray();
                list_of_filenames.Items.Clear();
                foreach (string filename in filenames)
                {
                    list_of_filenames.Items.Add(filename);
                }
                countTextBox.Text = filenames.Length.ToString();
                if (filenames.Length == 0)
                {
                    list_of_filenames.Items.Add("(A mappa üres - minden fájl rendszerezve lett)");
                }
            }
        }

        private DateTime GetDateTakenFromImage(string filePath)
        {
            DateTime dateOfTheFile = new DateTime();

            
            string filename = Path.GetFileName(filePath);

            
            if (filename.Length >= 8 && filename.Substring(0, 8).All(char.IsDigit))
            {
                string datePart = filename.Substring(0, 8);
                if (DateTime.TryParseExact(datePart, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out dateOfTheFile))
                    return dateOfTheFile;
            }
            // IMG_yyyyMMdd
            else if (filename.Length >= 12 && filename.StartsWith("IMG_") && filename.Substring(4, 8).All(char.IsDigit))
            {
                string datePart = filename.Substring(4, 8);
                if (DateTime.TryParseExact(datePart, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out dateOfTheFile))
                    return dateOfTheFile;
            }
            // Screenshot_yyyyMMdd
            else if (filename.Length >= 19 && filename.StartsWith("Screenshot_") && filename.Substring(11, 8).All(char.IsDigit))
            {
                string datePart = filename.Substring(11, 8);
                if (DateTime.TryParseExact(datePart, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out dateOfTheFile))
                    return dateOfTheFile;
            }
            // VideoCapture_yyyyMMdd
            else if (filename.Length >= 21 && filename.StartsWith("VideoCapture_") && filename.Substring(13, 8).All(char.IsDigit))
            {
                string datePart = filename.Substring(13, 8);
                if (DateTime.TryParseExact(datePart, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out dateOfTheFile))
                    return dateOfTheFile;
            }
            // Snapchat- vagy received_ -> EXIF metaadat
            else if (filename.StartsWith("Snapchat-") || filename.StartsWith("received_"))
            {
                try
                {
                    using (var img = Image.FromFile(filePath))
                    {
                        const int PropertyTagDateTimeOriginal = 0x9003;
                        if (img.PropertyIdList.Contains(PropertyTagDateTimeOriginal))
                        {
                            var propItem = img.GetPropertyItem(PropertyTagDateTimeOriginal);
                            string dateTakenStr = System.Text.Encoding.ASCII.GetString(propItem.Value).Trim('\0');
                            if (DateTime.TryParseExact(dateTakenStr, "yyyy:MM:dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out dateOfTheFile))
                                return dateOfTheFile;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"EXIF read error for {filename}: " + ex.Message);
                }
            }
            // FB_IMG_ Unix timestamp
            else if (filename.StartsWith("FB_IMG_"))
            {
                string nameWithoutPrefix = filename.Substring(7);
                string digits = new string(nameWithoutPrefix.TakeWhile(char.IsDigit).ToArray());
                if (digits.Length == 13 || digits.Length == 10)
                {
                    long unixTime;
                    if (long.TryParse(digits, out unixTime))
                    {
                        DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        if (digits.Length == 13)
                            dateOfTheFile = epoch.AddMilliseconds(unixTime).ToLocalTime();
                        else
                            dateOfTheFile = epoch.AddSeconds(unixTime).ToLocalTime();
                        return dateOfTheFile;
                    }
                }
            }

            // EFX data
            if (dateOfTheFile.Year <= 1)
            {
                try
                {
                    using (var img = Image.FromFile(filePath))
                    {
                        const int PropertyTagDateTimeOriginal = 0x9003;
                        const int PropertyTagDateTime = 0x0132;
                        const int PropertyTagDateTimeDigitized = 0x9004;

                        int[] propertyIds = { PropertyTagDateTimeOriginal, PropertyTagDateTime, PropertyTagDateTimeDigitized };

                        foreach (int propId in propertyIds)
                        {
                            if (img.PropertyIdList.Contains(propId))
                            {
                                var propItem = img.GetPropertyItem(propId);
                                string dateTakenStr = System.Text.Encoding.ASCII.GetString(propItem.Value).Trim('\0');
                                if (DateTime.TryParseExact(dateTakenStr, "yyyy:MM:dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out dateOfTheFile))
                                {
                                    if (dateOfTheFile.Year > 1)
                                        return dateOfTheFile;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to read EXIF from {filename}: " + ex.Message);
                }
            }

            if (dateOfTheFile.Year <= 1)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    dateOfTheFile = fileInfo.CreationTime < fileInfo.LastWriteTime ? fileInfo.CreationTime : fileInfo.LastWriteTime;
                    if (dateOfTheFile.Year < 2000 || dateOfTheFile > DateTime.Now)
                    {
                        dateOfTheFile = new DateTime();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to get file date for {filename}: " + ex.Message);
                }
            }

            return dateOfTheFile;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void hideDuplicates_chkbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void video_radioBtn_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
