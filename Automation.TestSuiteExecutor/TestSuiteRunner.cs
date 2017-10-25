using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Reflection;
using Selenium.Automation.Accelerators;
using System.Xml;
using System.Diagnostics;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Selenium.Automation.TestSuiteExecutor
{
    public partial class form_TestSuiteRunner : Form
    {
        List<string> lst_AvailableModules = new List<string>();
        List<string> lst_AvailableSubModules = new List<string>();
        DataTable modulesSubModulesMapping;
        List<string> lst_AvailableCategories = new List<string>();
        DataView dvTestCaseDetails = null;
        DataTable dtTestCaseDetails;
        string strModuleFilterCriteria = string.Empty;
        string strSubModuleFilterCriteria = string.Empty;
        string strCategoryFilterCriteria = string.Empty;
        public static List<Object[]> testCaseToExecute = new List<object[]>();
        public static Dictionary<String, String> qualifiedNames = new Dictionary<string, string>();
        Engine reportEngine;
        DataGridViewCellStyle cellStyleExecuting = new DataGridViewCellStyle();
        DataGridViewCellStyle cellStylePassed = new DataGridViewCellStyle();
        DataGridViewCellStyle cellStyleFailed = new DataGridViewCellStyle();
        DataGridViewCellStyle cellStyleNotStarted = new DataGridViewCellStyle();
        private decimal totalPassed = 0;
        private decimal totalFailed = 0;
        XmlDocument xmlTestsExecutionDetails;

        public form_TestSuiteRunner()
        {
            InitializeComponent();
        }

        private void form_TestSuiteRunner_Load(object sender, EventArgs e)
        {
            LoadTestData();
        }

        private void btn_FilterData_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            if (lstbox_Module.SelectedIndex != -1)
                strModuleFilterCriteria = lstbox_Module.SelectedItem.ToString().Trim();
            if (lstbox_SubModule.SelectedIndex != -1)
                strSubModuleFilterCriteria = lstbox_SubModule.SelectedItem.ToString().Trim();
            if (lstbox_Criteria.SelectedIndex != -1)
                strCategoryFilterCriteria = lstbox_Criteria.SelectedItem.ToString().Trim();

            string strCondition = "ModuleName LIKE '*" + strModuleFilterCriteria + "*' AND SubModuleName LIKE '*" + strSubModuleFilterCriteria + "*'  AND ExecutionCategories LIKE '*" + strCategoryFilterCriteria + "*'";

            DataView dvFilteredTestCaseDetails = new DataView(dtTestCaseDetails);
            dvFilteredTestCaseDetails.Sort = "Sl.No";
            dvFilteredTestCaseDetails.RowFilter = strCondition;
            dataGridView1.DataSource = dvFilteredTestCaseDetails;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }

        private void chkbox_SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_SelectAll.Checked)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[0].Value = true;
                }
            }
            else if (!chkbox_SelectAll.Checked)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[0].Value = false;
                }
            }
        }

        private void btn_ExecuteTests_Click(object sender, EventArgs e)
        {
            try
            {
                ClearExecutionStatus();
                ClearGridRows();
                cellStyleExecuting.BackColor = Color.Orange;
                cellStylePassed.BackColor = Color.LightGreen;
                cellStyleFailed.BackColor = Color.Red;
                cellStyleNotStarted.BackColor = Color.White;
                reportEngine = new Engine(Util.EnvironmentSettings["ReportsPath"], Util.EnvironmentSettings["Server"]);
                if (Accelerators.Utilities.AppStore.Instance.Store.ContainsKey("ReportEngine"))
                    Accelerators.Utilities.AppStore.Instance.Store.Remove("ReportEngine");

                Accelerators.Utilities.AppStore.Instance.Store.Add("ReportEngine", reportEngine);

                testCaseToExecute.Clear();
                int selectedIndex = selectBrowser_Combobox.SelectedIndex;
                string browser = string.Empty;// selectBrowser_Combobox.SelectedItem.ToString();
                foreach (var item in chklBrowsers.CheckedItems)
                {
                    browser += item + ";";
                }
                if (browser != string.Empty)
                    browser = browser.Substring(0, browser.Length - 1);

                if (browser == string.Empty)
                {
                    MessageBox.Show("Select a browser to execute.", "Test Suite Executor");
                    return;
                }

                //if (selectedIndex==0)
                //{
                //    MessageBox.Show("Select a browser to execute.", "Test Suite Executor");
                //    return;                   
                //}

                try
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value.Equals(true))
                        {
                            string testCaseModuleName = row.Cells[2].Value.ToString().Trim();
                            string testCaseSubModuleName = row.Cells[3].Value.ToString().Trim();
                            string strBrowserName = browser;// ConfigurationManager.AppSettings.Get("DefaultBrowser").ToString();
                            string testCaseRequirementFeature = row.Cells[5].Value.ToString().Trim();
                            // string testCaseRequirementFeature = string.Concat(testCaseModuleName, " - ", testCaseSubModuleName);
                            string testCaseName = row.Cells[4].Value.ToString().Trim();
                            TestCase testCaseReporter = new TestCase(testCaseName, testCaseName, testCaseRequirementFeature);
                            testCaseReporter.Summary = reportEngine.Reporter;
                            reportEngine.Reporter.TestCases.Add(testCaseReporter);
                            string strBrowserId = string.Empty;
                            // browsers
                            foreach (String browserId in strBrowserName.ToString().Split(new char[] { ';' }))
                            {
                                strBrowserId = browserId != String.Empty ? browserId : browser;// ConfigurationManager.AppSettings.Get("DefaultBrowser").ToString();
                                Browser browserReporter = new Browser(strBrowserId);
                                browserReporter.TestCase = testCaseReporter;
                                testCaseReporter.Browsers.Add(browserReporter);

                                // Get the Test data details
                                XmlDocument xmlTestDataDoc = new XmlDocument();
                                xmlTestDataDoc.Load("TestData/" + testCaseModuleName + ".xml");
                                XmlNodeList testdataNodeList;
                                testdataNodeList = xmlTestDataDoc.DocumentElement.SelectNodes("/TestData/" + testCaseName);
                                //Iterate for each data
                                foreach (XmlNode testDataNode in testdataNodeList)
                                {
                                    Dictionary<String, String> browserConfig = Util.GetBrowserConfig(strBrowserId);
                                    string iterationId = testDataNode.SelectSingleNode("TDID").InnerText;
                                    string defectID = testDataNode.SelectSingleNode("DefectID").InnerText;
                                    Iteration iterationReporter = new Iteration(iterationId, defectID);
                                    iterationReporter.Browser = browserReporter;
                                    browserReporter.Iterations.Add(iterationReporter);
                                    //testCaseToExecute.Add(new Object[] { testCaseName,browserConfig, testCaseId, iterationId, iterationReporter, null, testDataNode, reportEngine });
                                    testCaseToExecute.Add(new Object[] { testCaseReporter, browserConfig, testDataNode, iterationReporter, reportEngine });
                                }
                            }
                        }
                    }
                    if (testCaseToExecute.Count > 0)
                    {
                        lnklbl_OverallExeStatResult.Text = "Execution Started";
                        Disable_Enable_Controls(false);
                        progressBar1.Visible = true;
                        progressBar1.Value = 1;
                        bgWrkTestExecutor.RunWorkerAsync();
                    }
                    else
                    {
                        MessageBox.Show("Please select test case(s) for execution.","Test Suite Executor");
                    }
                    //Processor(Int32.Parse(ConfigurationManager.AppSettings.Get("MaxDegreeOfParallelism")));
                    //reportEngine.Summarize();
                }
                catch
                {

                }
                //this.Activate();
                //decimal dcl_TotalTestCasesExecuted = reportEngine.Reporter.TestCases.Count;
                //decimal dcl_TotalTestCasesPassed = 0;
                //decimal dcl_TotalTestCasesFailed = 0;
                //foreach (TestCase testCase in reportEngine.Reporter.TestCases)
                //{
                //    if (testCase.IsSuccess)
                //        dcl_TotalTestCasesPassed++;
                //    else
                //        dcl_TotalTestCasesFailed++;
                //}
                //decimal dcl_PassPercentage = Math.Round((dcl_TotalTestCasesPassed / dcl_TotalTestCasesExecuted) * 100);
                //lbl_TotalTCsExecutedResult.Text = dcl_TotalTestCasesExecuted.ToString();
                //lbl_TotalTCsPassedResult.Text = dcl_TotalTestCasesPassed.ToString();
                //lbl_TotalTCsFailedResult.Text = dcl_TotalTestCasesFailed.ToString();
                //lbl_TotalTCsPassPerResult.Text = dcl_PassPercentage.ToString();


                //LinkLabel.Link link = new LinkLabel.Link();
                //String fileName = Path.Combine(reportEngine.ReportPath, "Summary.html");
                //link.LinkData = fileName;
                //lnklbl_OverallExeStatResult.Links.Clear();
                //lnklbl_OverallExeStatResult.Links.Add(link);
                //if(dcl_TotalTestCasesFailed>0)
                //lnklbl_OverallExeStatResult.Text = "FAILED " + DateTime.Now;
                //else
                //lnklbl_OverallExeStatResult.Text = "PASSED " + DateTime.Now;

                //if (ConfigurationManager.AppSettings.Get("SendEmail").ToString().Equals("Yes"))
                //{
                //    TimeSpan start = new TimeSpan(20, 0, 0); 
                //    TimeSpan end = new TimeSpan(6, 0, 0); 
                //    TimeSpan now = DateTime.Now.TimeOfDay;
                //    if ((now > start) && (now < end))
                //    {
                //        sendEMailThroughOUTLOOK(dcl_TotalTestCasesExecuted, dcl_TotalTestCasesPassed, dcl_TotalTestCasesFailed, dcl_PassPercentage, Path.Combine(reportEngine.ReportPath, "Summary.html"));
                //    }
                //}
            }
            catch
            {

            }
        }

        private void Disable_Enable_Controls(bool value)
        {
            btn_ExecuteTests.Enabled = value;
            btnClearFilters.Enabled = value;
            selectBrowser_Combobox.Enabled = value;

            lstbox_Module.Enabled = value;
            lstbox_SubModule.Enabled = value;
            lstbox_Criteria.Enabled = value;
            chkbox_SelectAll.Enabled = value;
            chklBrowsers.Enabled = value;
        }

        private void Processor(int maxDegree)
        {
            try
            {
                int progressCount = 0, totalCount = 0;
                totalCount = testCaseToExecute.Count();
                if (ConfigurationManager.AppSettings.Get("ExecutionMode").ToLower().Equals("s"))
                {
                    ///Use this loop for sequential running of the test cases
                    foreach (object[] work in testCaseToExecute)
                    {
                        ProcessEachWork(work);
                        progressCount = progressCount + 1;
                        bgWrkTestExecutor.ReportProgress(progressCount, work[0]);
                    }
                }
                else if (ConfigurationManager.AppSettings.Get("ExecutionMode").ToLower().Equals("p"))
                {
                    /*Use this loop for parellel running of the test cases*/
                    Parallel.ForEach(testCaseToExecute,
                                     new ParallelOptions { MaxDegreeOfParallelism = maxDegree },
                                     work =>
                                     {
                                         ProcessEachWork(work);
                                         progressCount = progressCount + 1;
                                         bgWrkTestExecutor.ReportProgress(progressCount, work[0]);
                                     });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ProcessEachWork(Object[] data)
        {
            try
            {
                TestCase objTestCase = (TestCase)data[0];
                string strTCName = objTestCase.Name.ToString().Trim();
                Type typeTestCase = Type.GetType(qualifiedNames[strTCName]);
                BaseTest baseCase = Activator.CreateInstance(typeTestCase) as BaseTest;
                try
                {      
                    dataGridView1.Rows[GetTestCaseRowIndex(strTCName)].Cells["ExecutionStatus"].Value = "Executing";
                    foreach(DataGridViewCell dgc in dataGridView1.Rows[GetTestCaseRowIndex(strTCName)].Cells)
                    {
                        dgc.Style = cellStyleExecuting;
                    }
                    
                    //dataGridView1.Rows[GetTestCaseRowIndex(strTCName)].Cells["ExecutionStatus"].Style = cellStyleExecuting;
                    typeTestCase.GetMethod("Execute").Invoke(baseCase, data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(strTCName + " execution has caught exception " + ex.Message);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        static void sendEMailThroughOUTLOOK(decimal _total, decimal _passed, decimal _failed, decimal _passpercent, string str_CSVFilePath)
        {
            try
            {
                // Create the Outlook application.
                Outlook.Application oApp = new Outlook.Application();
                // Create a new mail item.
                Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
                // Set HTMLBody. 
                //add the body of the email
                string str_Body = "Hello Team," + Environment.NewLine + "  Attached are the automation execution results!!" + Environment.NewLine + "  Total Test Cases= " + _total + "  Total Passed= " + _passed + "  Total Failed= " + _failed + "  Pass Percentage(%)= " + _passpercent;
                oMsg.HTMLBody = str_Body;
                //Add an attachment.
                String sDisplayName = "MyAttachment";
                int iPosition = (int)oMsg.Body.Length + 1;
                int iAttachType = (int)Outlook.OlAttachmentType.olByValue;
                //now attached the file
                Outlook.Attachment oAttach = oMsg.Attachments.Add(@str_CSVFilePath, iAttachType, iPosition, sDisplayName);
                //Subject line
                oMsg.Subject = "Execution Results (Pass%=" + _passpercent + ") in machine: " + Environment.MachineName;
                // Add a recipient.
                Outlook.Recipients oRecips = (Outlook.Recipients)oMsg.Recipients;
                // Change the recipient in the next line if necessary.
                Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(ConfigurationManager.AppSettings.Get("SendEmailTo").ToString());
                oRecip.Resolve();
                // Send.
                oMsg.Send();
                // Clean up.
                oRecip = null;
                oRecips = null;
                oMsg = null;
                oApp = null;
            }//end of try block
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }//end of catch
        }//end of Email Method

        private void lnklbl_OverallExeStatResult_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(e.Link.LinkData as string))
                    // Send the URL to the operating system.
                    Process.Start(e.Link.LinkData as string);
            }
            catch { }
        }

        private void lstbox_Module_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            strModuleFilterCriteria = "";
            strSubModuleFilterCriteria = "";
            strCategoryFilterCriteria = "";
            if (lstbox_Module.SelectedIndex != -1)
            {
                strModuleFilterCriteria = lstbox_Module.SelectedItem.ToString().Trim();
                lstbox_SubModule.Items.Clear();
                foreach(DataRow dr in modulesSubModulesMapping.Select("ModuleName='" + lstbox_Module.SelectedItem.ToString().Trim() + "'"))
                {
                    lstbox_SubModule.Items.Add(dr["SubModuleName"]);
                }                
            }

            if (lstbox_SubModule.SelectedIndex != -1)
                strSubModuleFilterCriteria = lstbox_SubModule.SelectedItem.ToString().Trim();
            if (lstbox_Criteria.SelectedIndex != -1)
                strCategoryFilterCriteria = lstbox_Criteria.SelectedItem.ToString().Trim();

            string strCondition = "ModuleName LIKE '*" + strModuleFilterCriteria + "*' AND SubModuleName LIKE '*" + strSubModuleFilterCriteria + "*'  AND ExecutionCategories LIKE '*" + strCategoryFilterCriteria + "*'";

            DataView dvFilteredTestCaseDetails = new DataView(dtTestCaseDetails);
            dvFilteredTestCaseDetails.Sort = "ModuleName";
            dvFilteredTestCaseDetails.Sort = "SubModuleName";
            dvFilteredTestCaseDetails.Sort = "TestCaseID";
            dvFilteredTestCaseDetails.Sort = "TestCaseDescription";
            dvFilteredTestCaseDetails.Sort = "ExecutionCategories";
            dvFilteredTestCaseDetails.RowFilter = strCondition;
            dataGridView1.DataSource = dvFilteredTestCaseDetails;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }

        private void lstbox_SubModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            strModuleFilterCriteria = "";
            strSubModuleFilterCriteria = "";
            strCategoryFilterCriteria = "";

            if (lstbox_Module.SelectedIndex != -1)
                strModuleFilterCriteria = lstbox_Module.SelectedItem.ToString().Trim();
            if (lstbox_SubModule.SelectedIndex != -1)
                strSubModuleFilterCriteria = lstbox_SubModule.SelectedItem.ToString().Trim();
            if (lstbox_Criteria.SelectedIndex != -1)
                strCategoryFilterCriteria = lstbox_Criteria.SelectedItem.ToString().Trim();

            string strCondition = "ModuleName LIKE '*" + strModuleFilterCriteria + "*' AND SubModuleName LIKE '*" + strSubModuleFilterCriteria + "*'  AND ExecutionCategories LIKE '*" + strCategoryFilterCriteria + "*'";

            DataView dvFilteredTestCaseDetails = new DataView(dtTestCaseDetails);
            dvFilteredTestCaseDetails.Sort = "ModuleName";
            dvFilteredTestCaseDetails.Sort = "SubModuleName";
            dvFilteredTestCaseDetails.Sort = "TestCaseID";
            dvFilteredTestCaseDetails.Sort = "TestCaseDescription";
            dvFilteredTestCaseDetails.Sort = "ExecutionCategories";
            dvFilteredTestCaseDetails.RowFilter = strCondition;
            dataGridView1.DataSource = dvFilteredTestCaseDetails;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }

        private void lstbox_Criteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            strModuleFilterCriteria = "";
            strSubModuleFilterCriteria = "";
            strCategoryFilterCriteria = "";
            if (lstbox_Module.SelectedIndex != -1)
                strModuleFilterCriteria = lstbox_Module.SelectedItem.ToString().Trim();
            if (lstbox_SubModule.SelectedIndex != -1)
                strSubModuleFilterCriteria = lstbox_SubModule.SelectedItem.ToString().Trim();
            if (lstbox_Criteria.SelectedIndex != -1)
                strCategoryFilterCriteria = lstbox_Criteria.SelectedItem.ToString().Trim();

            string strCondition = "ModuleName LIKE '*" + strModuleFilterCriteria + "*' AND SubModuleName LIKE '*" + strSubModuleFilterCriteria + "*'  AND ExecutionCategories LIKE '*" + strCategoryFilterCriteria + "*'";

            DataView dvFilteredTestCaseDetails = new DataView(dtTestCaseDetails);
            dvFilteredTestCaseDetails.Sort = "ModuleName";
            dvFilteredTestCaseDetails.Sort = "SubModuleName";
            dvFilteredTestCaseDetails.Sort = "TestCaseID";
            dvFilteredTestCaseDetails.Sort = "TestCaseDescription";
            dvFilteredTestCaseDetails.Sort = "ExecutionCategories";
            dvFilteredTestCaseDetails.RowFilter = strCondition;
            dataGridView1.DataSource = dvFilteredTestCaseDetails;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }

        private void tableLayout_Filter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearGridRows();
            ClearExecutionStatus();
        }

        private void bgWrkTestExecutor_DoWork(object sender, DoWorkEventArgs e)
        {            
            Processor(Int32.Parse(ConfigurationManager.AppSettings.Get("MaxDegreeOfParallelism")));
        }

        private void bgWrkTestExecutor_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ConvertTestResultsToXML();
            reportEngine.Summarize();
            decimal dcl_TotalTestCasesExecuted = reportEngine.Reporter.TestCases.Count;
            decimal dcl_TotalTestCasesPassed = 0;
            decimal dcl_TotalTestCasesFailed = 0;
            foreach (TestCase testCase in reportEngine.Reporter.TestCases)
            {
                if (testCase.IsSuccess)
                    dcl_TotalTestCasesPassed++;
                else
                    dcl_TotalTestCasesFailed++;
            }
            decimal dcl_PassPercentage = Math.Round((dcl_TotalTestCasesPassed / dcl_TotalTestCasesExecuted) * 100);
            lbl_TotalTCsExecutedResult.Text = dcl_TotalTestCasesExecuted.ToString();
            lbl_TotalTCsPassedResult.Text = dcl_TotalTestCasesPassed.ToString();
            lbl_TotalTCsFailedResult.Text = dcl_TotalTestCasesFailed.ToString();
            lbl_TotalTCsPassPerResult.Text = dcl_PassPercentage.ToString();


            LinkLabel.Link link = new LinkLabel.Link();
            String fileName = Path.Combine(reportEngine.ReportPath, "Summary.html");
            link.LinkData = fileName;
            lnklbl_OverallExeStatResult.Links.Clear();
            lnklbl_OverallExeStatResult.Links.Add(link);
            if (dcl_TotalTestCasesFailed > 0)
                lnklbl_OverallExeStatResult.Text = "FAILED " + DateTime.Now;
            else
                lnklbl_OverallExeStatResult.Text = "PASSED " + DateTime.Now;
            if (ConfigurationManager.AppSettings.Get("SendEmail").ToString().Equals("Yes"))
            {
                TimeSpan start = new TimeSpan(20, 0, 0);
                TimeSpan end = new TimeSpan(6, 0, 0);
                TimeSpan now = DateTime.Now.TimeOfDay;
                if ((now > start) && (now < end))
                {
                    sendEMailThroughOUTLOOK(dcl_TotalTestCasesExecuted, dcl_TotalTestCasesPassed, dcl_TotalTestCasesFailed, dcl_PassPercentage, Path.Combine(reportEngine.ReportPath, "Summary.html"));
                }
            }
            Disable_Enable_Controls(true);
            progressBar1.Value = 0;
            progressBar1.Visible = false;
            //btn_ExecuteTests.Enabled = true;
            //btnClearFilters.Enabled = true;
            //selectBrowser_Combobox.Enabled = true;
        }

        private void bgWrkTestExecutor_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SetProgress((TestCase)e.UserState,e.ProgressPercentage);            
        }

        private void SetProgress(TestCase objTestCase, int progressPercentage)
        {
            try
            {
                List<Iteration> iterationOfTests = new List<Iteration>();
                TestCase tc = null;
                for (int i = 0; i <= testCaseToExecute.Count - 1; i++)
                {
                    tc = (TestCase)testCaseToExecute[i][0];
                    if (tc.Name == objTestCase.Name)
                    {
                        iterationOfTests.Add((Iteration)testCaseToExecute[i][3]);
                    }
                }

                if (iterationOfTests != null && iterationOfTests.Count > 0)
                {
                    bool allCompleted = iterationOfTests.Any<Iteration>(a => a.IsCompleted == false);
                    if (allCompleted == false)
                    {
                        string strTCName = objTestCase.Name.ToString().Trim();
                        dataGridView1.Rows[GetTestCaseRowIndex(strTCName)].Cells["ExecutionStatus"].Value = objTestCase.IsSuccess ? "Passed" : "Failed";
                        //dataGridView1.Rows[GetTestCaseRowIndex(strTCName)].Cells["ExecutionStatus"].Style = objTestCase.IsSuccess ? cellStylePassed : cellStyleFailed;
                        foreach (DataGridViewCell dgc in dataGridView1.Rows[GetTestCaseRowIndex(strTCName)].Cells)
                        {
                            dgc.Style = objTestCase.IsSuccess ? cellStylePassed : cellStyleFailed;
                        }

                        progressBar1.Visible = true;

                        double totalCount = testCaseToExecute.Count() == 0 ? 1 : testCaseToExecute.Count();
                        double progressCount = progressPercentage;
                        int percentComplete = (int)((progressCount / totalCount) * 100);
                        progressBar1.Value = percentComplete;


                        decimal totalExecuted = 0;
                        if (objTestCase.PassedCount >= 1)
                            totalPassed = totalPassed + 1;

                        if (objTestCase.FailedCount >= 1)
                            totalFailed = totalFailed + 1;

                        totalExecuted = totalPassed + totalFailed;

                        decimal dcl_PassPercentage = Math.Round((totalPassed / (totalExecuted == 0 ? 1 : totalExecuted)) * 100);
                        lbl_TotalTCsExecutedResult.Text = (totalExecuted == 0 ? 1 : totalExecuted).ToString();
                        lbl_TotalTCsPassedResult.Text = totalPassed.ToString();
                        lbl_TotalTCsFailedResult.Text = totalFailed.ToString();
                        lbl_TotalTCsPassPerResult.Text = dcl_PassPercentage.ToString();
                    }
                }

            }
            catch (Exception ex)
            {

            }

        }

        private int GetTestCaseRowIndex(string testCaseId)
        {
            int rowIndex = -1;
            if (dataGridView1 != null && dataGridView1.Rows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.Rows
            .Cast<DataGridViewRow>()
            .Where(r => r.Cells["TestCaseID"].Value.ToString().Equals(testCaseId))
            .First();

                rowIndex = row.Index;
            }

            return rowIndex;
        }

        private void LoadTestData()
        {
            string strModuleName = "", strSubModuleName = "", strTestCaseName = "", strTestCaseDescription = "", strExecutionCategories = "";

            string assemblyFileName = ConfigurationManager.AppSettings.Get("TestsDLLName").ToString();
            string strDllPath = Directory.GetCurrentDirectory();
            string strDLLPath = string.Concat(strDllPath, "\\", assemblyFileName);

            dtTestCaseDetails = new DataTable();           
            dtTestCaseDetails.Columns.Clear();
            dtTestCaseDetails.Columns.Add("ToExecute", typeof(bool));
            dtTestCaseDetails.Columns.Add("Sl.No", typeof(int));
            dtTestCaseDetails.Columns.Add("ModuleName", typeof(string));
            dtTestCaseDetails.Columns.Add("SubModuleName", typeof(string));
            dtTestCaseDetails.Columns.Add("TestCaseID", typeof(string));
            dtTestCaseDetails.Columns.Add("TestCaseDescription", typeof(string));
            dtTestCaseDetails.Columns.Add("ExecutionCategories", typeof(string));
            dtTestCaseDetails.Columns.Add("ExecutionStatus", typeof(string));

            modulesSubModulesMapping = new DataTable();
            modulesSubModulesMapping.Columns.Clear();
            modulesSubModulesMapping.Columns.Add("ModuleName", typeof(string));
            modulesSubModulesMapping.Columns.Add("SubModuleName", typeof(string));

            ClearControls();           

            int i_Counter = 0;
            Assembly assembly = Assembly.LoadFrom(strDLLPath);
            Array.ForEach(assembly.GetTypes(), type =>
            {
                if (type.GetCustomAttributes(typeof(ScriptAttribute), true).Length > 0)
                {
                    var objTestCase = (ScriptAttribute)type.GetCustomAttribute(typeof(ScriptAttribute));
                    strExecutionCategories = GetTestExecutionCategories(type.Name);
                    if (strExecutionCategories.Trim() != "")
                    {
                        i_Counter++;
                        strModuleName = objTestCase.ModuleName.Trim();
                        strSubModuleName = objTestCase.SubModuleName.Trim();
                        strTestCaseName = type.Name;
                        qualifiedNames.Add(strTestCaseName, type.AssemblyQualifiedName);
                        strTestCaseDescription = objTestCase.TestCaseDescription.Trim();
                        //strExecutionCategories = objTestCase.ExecutionCategories.Trim();
                        dtTestCaseDetails.Rows.Add(false, i_Counter, strModuleName, strSubModuleName, strTestCaseName, strTestCaseDescription, strExecutionCategories, "Not Started");

                        if ((!lst_AvailableModules.Contains(strModuleName)) && (strModuleName.Length > 0))
                        {
                            lst_AvailableModules.Add(strModuleName);
                        }
                        lst_AvailableModules.Sort();
                       

                        if(modulesSubModulesMapping.Select("ModuleName='" + strModuleName + "' AND SubModuleName='" + strSubModuleName + "'").Length==0)
                        {
                            modulesSubModulesMapping.Rows.Add(strModuleName, strSubModuleName);
                        }

                        Array.ForEach(strExecutionCategories.Split(','), x =>
                        {
                            if ((!lst_AvailableCategories.Contains(x)) && (x.Length > 0))
                            {
                                lst_AvailableCategories.Add(x);
                            }
                        });
                        lst_AvailableCategories.Sort();
                    }
                }
            });
            lbl_TotalTCsResult.Text = i_Counter.ToString();
            lstbox_Module.Items.AddRange(lst_AvailableModules.ToArray());
            lstbox_SubModule.Items.AddRange(lst_AvailableSubModules.ToArray());
            lstbox_Criteria.Items.AddRange(lst_AvailableCategories.ToArray());
            dvTestCaseDetails = new DataView(dtTestCaseDetails);
            dvTestCaseDetails.Sort = "Sl.No";
            dataGridView1.DataSource = dvTestCaseDetails;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;                
            }
            
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            LoadTestData();
        }

        private void ClearControls()
        {
            qualifiedNames.Clear();
            lstbox_Module.Items.Clear();
            lstbox_SubModule.Items.Clear();
            lstbox_Criteria.Items.Clear();
            lnklbl_OverallExeStatResult.Text = "Not started";
            chkbox_SelectAll.Checked = false; 
            selectBrowser_Combobox.Enabled = true;
            selectBrowser_Combobox.SelectedIndex = 0;
            progressBar1.Visible = false;
            ClearExecutionStatus();
            ClearGridRows();
            chklBrowsers.ClearSelected();
        }

        private void ClearExecutionStatus()
        {
            totalFailed = 0;
            totalPassed = 0;
            lbl_TotalTCsExecutedResult.Text = "0";
            lbl_TotalTCsPassedResult.Text = "0";
            lbl_TotalTCsFailedResult.Text = "0";
            lbl_TotalTCsPassPerResult.Text = "0";
        }

        private void ClearGridRows()
        {
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = null;
            lnklbl_OverallExeStatResult.Links.Clear();
            lnklbl_OverallExeStatResult.Links.Add(link);
            lnklbl_OverallExeStatResult.Text = "Not started";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["ExecutionStatus"].Value = "Not Started";
                foreach(DataGridViewCell dgc in row.Cells)
                {
                    dgc.Style= cellStyleNotStarted;
                }
                //row.Cells["ExecutionStatus"].Style = cellStyleNotStarted;
            }
        }

        private void chklBrowsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearGridRows();
            ClearExecutionStatus();
        }

        private string GetTestExecutionCategories(string testName)
        {
            XmlNode testNode = null;
            string executionCategories = "";

            if (xmlTestsExecutionDetails == null)
            {
                xmlTestsExecutionDetails = Util.ReadXmlDocData("TestExecutionDetails.xml");
            }
            testNode = xmlTestsExecutionDetails.SelectSingleNode("TestCases/Testcase[@name='" + testName + "' and @execute='Y']");
            if (testNode != null)
            {
                var nameAttribute = testNode.Attributes["executioncategories"];
                if(nameAttribute!=null)
                {
                    executionCategories = nameAttribute.Value;
                }
            }
            return executionCategories;
        }

        private void ConvertTestResultsToXML()
        {
            try
            {
                XmlSerializer x = new XmlSerializer(typeof(List<TestCase>));
                //TextWriter writer = new StreamWriter("ExecutionResults.XML");
                //x.Serialize(writer, reportEngine.Reporter.TestCases);
                //writer.Close();
                StringWriter sw = new StringWriter();
                x.Serialize(sw, reportEngine.Reporter.TestCases);
                string xml = sw.ToString();
            }
            catch(Exception ex)
            {

            }

        }

    }
}
