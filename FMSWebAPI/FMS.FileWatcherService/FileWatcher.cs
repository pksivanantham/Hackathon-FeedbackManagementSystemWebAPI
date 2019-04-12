using FMS.Helper;
using FMS.ServiceClient;
using FMSWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using ParticipationStatus = FMS.Helper.ParticipationStatus;

namespace FMS.FileWatcherService
{
    public class FileWatcher
    {
        FileSystemWatcher fileSystemWatcher;
        ServiceClient.ServiceClient serviceClient;
        public FileWatcher(string pathToWatch)
        {
            serviceClient = new ServiceClient.ServiceClient("https://localhost:44352");//todo:Read from config file 

            fileSystemWatcher = new FileSystemWatcher
            {
                Path = pathToWatch,
                Filter = "*.xlsx",
                IncludeSubdirectories = false,
                EnableRaisingEvents = true
            };
        }

        public void Start()
        {          
            fileSystemWatcher.Created += FileSystemWatcher_Created;
            //fileSystemWatcher.Changed += FileSystemWatcher_Created;
            //fileSystemWatcher.Deleted += FileSystemWatcher_Created;
        }

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {

            var fileName = e.Name;

            if (!fileName.StartsWith("~$"))
                ReadExcelContentAsync(e.FullPath, fileName);

        }        
        private async void ReadExcelContentAsync(string path,string fileName)
        {            

            var eventList = new List<EventVolunteerDetailsRequest>();

            var isFromError = false;

            var inputFileType = Utilities.GetInputFileType(Path.GetFileNameWithoutExtension(fileName));

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            try
            {

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;                               

                switch (inputFileType)
                {
                    case InputFileType.OutReachEventInformation:



                        for (int i = 2; i <= rowCount; i++)
                        {
                            if (ReadCellValue(xlRange.Cells[i, 1]) != string.Empty)
                            {

                                var outreachEvent = new OutreachEventRequest()
                                {

                                    EventId = ReadCellValue(xlRange.Cells[i, 1]),
                                    BaseLocation = ReadCellValue(xlRange.Cells[i, 2]),
                                    BeneficiaryName = ReadCellValue(xlRange.Cells[i, 3]),
                                    CouncilName = ReadCellValue(xlRange.Cells[i, 4]),
                                    EventName = ReadCellValue(xlRange.Cells[i, 5]),
                                    EventDescription = ReadCellValue(xlRange.Cells[i, 6]),
                                    EventDate = DateTime.ParseExact(ReadCellValue(xlRange.Cells[i, 7]), "dd-MM-yy", CultureInfo.InvariantCulture)

                                };                                

                                var eventVolunteerDetails = new EventVolunteerDetailsRequest()
                                {

                                    EmployeeId = Int32.Parse(ReadCellValue(xlRange.Cells[i, 8])),
                                    EmployeeName = ReadCellValue(xlRange.Cells[i, 9]),
                                    BusinessUnit = ReadCellValue(xlRange.Cells[i, 13]),
                                    Event = outreachEvent,
                                    IsMailSend = false,
                                    MailSendCount = 0,
                                    ParticipationStatusId = (int)ParticipationStatus.Participated,                                    
                                    EventId = outreachEvent.EventId,
                                    VolunteerHours = Int64.Parse(ReadCellValue(xlRange.Cells[i, 10])),
                                    TravelHours = Int64.Parse(ReadCellValue(xlRange.Cells[i, 11])),
                                    Status = ReadCellValue(xlRange.Cells[i, 14])

                                };

                                eventList.Add(eventVolunteerDetails);
                            }
                        }
                       

                        break;
                    case InputFileType.VolunteerEnrollmentDetailsNotAttend:
                    case InputFileType.VolunteerEnrollmentDetailsUnregistered:


                        for (int i = 2; i <= rowCount; i++)
                        {
                            if (ReadCellValue(xlRange.Cells[i, 1]) != string.Empty)
                            {
                                var outreachEvent = new OutreachEventRequest()
                                {

                                    EventId = ReadCellValue(xlRange.Cells[i, 1]),
                                    BaseLocation = ReadCellValue(xlRange.Cells[i, 4]),
                                    BeneficiaryName = ReadCellValue(xlRange.Cells[i, 3]),
                                    EventName = ReadCellValue(xlRange.Cells[i, 2]),
                                    EventDate = DateTime.ParseExact(ReadCellValue(xlRange.Cells[i, 5]), "dd-MM-yy", CultureInfo.InvariantCulture)

                                };                                
                                var eventVolunteerDetails = new EventVolunteerDetailsRequest()
                                {
                                    
                                    Event = outreachEvent,
                                    IsMailSend = false,
                                    MailSendCount = 0,
                                    ParticipationStatusId = inputFileType == InputFileType.VolunteerEnrollmentDetailsNotAttend ?
                                    (int)ParticipationStatus.DidNotParticipate : (int)ParticipationStatus.Unregistered,
                                    EmployeeId = Int32.Parse(ReadCellValue(xlRange.Cells[i, 6])),
                                    EventId = outreachEvent.EventId,
                                    Status = ""

                                };
                                eventList.Add(eventVolunteerDetails);
                            }
                        }
                    
                        break;
                    case InputFileType.OutreachEventsSummary:
                        break;
                    default:
                        break;
                }

                

            }
            catch (Exception ex)
            {
                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //rule of thumb for releasing com objects:
                //  never use two dots, all COM objects must be referenced and released individually
                //  ex: [somthing].[something].[something] is bad

                //release com objects to fully kill excel process from running in the background
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                isFromError = true;
            }
            finally
            {
                if (!isFromError)
                {
                    //cleanup
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    //rule of thumb for releasing com objects:
                    //  never use two dots, all COM objects must be referenced and released individually
                    //  ex: [somthing].[something].[something] is bad

                    //release com objects to fully kill excel process from running in the background
                    Marshal.ReleaseComObject(xlRange);
                    Marshal.ReleaseComObject(xlWorksheet);

                    //close and release
                    xlWorkbook.Close();
                    Marshal.ReleaseComObject(xlWorkbook);

                    //quit and release
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);
                }
            }
            if(isFromError)
            {
                MoveToErrorFile(path, fileName);
            }
           else
            {
                var result = await serviceClient.SaveFileInformation(new FileProcessRequest() { EventVolunteerDetails = eventList });

                if (result == 1)
                {
                    MoveToSuccessFile(path, fileName);

                }
                else
                {
                    MoveToErrorFile(path, fileName);
                }
            }


        }

        private string ReadCellValue(Excel.Range range )
        {

            if (range != null && range.Value2 != null)
                return range.Value2.ToString();
            return string.Empty;
        }

        private void MoveToSuccessFile(string path,string fileName)
        {
            var basePath = path.Replace(fileName, "");

            var destinationFilePath = $"{basePath}SUCCESS\\{DateTime.UtcNow.ToString("ddMMyyyy")}\\";

            if (!Directory.Exists(destinationFilePath))
                Directory.CreateDirectory(destinationFilePath);

            File.Copy(path, $"{destinationFilePath}\\{fileName}",true);

            File.Delete(path);

        }

        private void MoveToErrorFile(string path, string fileName)
        {
            var basePath = path.Replace(fileName, "");

            var destinationFilePath = $"{basePath}Failure\\{DateTime.UtcNow.ToString("ddMMyyyy")}\\";

            if (!Directory.Exists(destinationFilePath))
                Directory.CreateDirectory(destinationFilePath);

            File.Copy(path, $"{destinationFilePath}\\{fileName}", true);

            File.Delete(path);
        }
    }
}
