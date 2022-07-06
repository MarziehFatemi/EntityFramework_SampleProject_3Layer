using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLayer.Service;
using BussinessLayer.ViewModels;
//using IronXL;
using System.Globalization;
using System.Data;
using IronXL;

namespace EF_3Layers_Hiexpert.Management
{
    public class UserManagement 
    {
        public Form  Form2 = new Form(); 
        private string RefScourceCategory;


        private void SearchClick(object sender, EventArgs e)
        {
               // FillGrid(cmd2);
  
        }


        private void Remove_Click(object sender, EventArgs e)
        {
            
                string Error = "";
            int Number = 0; 
                if (RefScourceCategory == "Physician")
                {

                DoctorService DrService = new DoctorService();
                DoctorViewModel[] SelectedDrs = Form1.GetSelectedDr();
                foreach (DoctorViewModel Dr in SelectedDrs)
                {
                   if (!DrService.RemoveDr(Dr.UserName, Error))
                    { MessageBox.Show( "Error: " + Error); }
                    else
                    { Number++;  }
                }

                }
                else if (RefScourceCategory == "Patient")
                {
                    CustomerService CustService = new CustomerService();
                List <CustomerViewModel> SelectedCustomers = Form1.GetSelectedCustomer();
                foreach (CustomerViewModel C in SelectedCustomers)
                {
                    if (!CustService.RemoveCustomer(C.UserName, Error))
                    { MessageBox.Show("Error: " + Error); }
                    else
                    { Number++;  }
                }
                MessageBox.Show("The number of " + Number + " entity is removed"); 

                }


            Form1.ShowAllData(RefScourceCategory);

        }

        private void EditClick(object sender, EventArgs e)
        {
            string Error = "";
            if (RefScourceCategory == "Patient")
            {
                CustomerService CustService = new CustomerService();
                List<CustomerViewModel> CustomerChangedParameters = Form1.GetAllCustomersChangedCell();

                foreach (var Customer in CustomerChangedParameters)
                {
                    CustService.UpdateCustomer(Customer.UserName, Customer.Name, Customer.Phone, Customer.Email, out Error);

                }


            }
            else if (RefScourceCategory == "Physician")
            {

                DoctorService DrService = new DoctorService();
                DoctorViewModel[] DrChangedParameters = Form1.GetAllDrChangedCells();

                for (int k = 0; k < DrChangedParameters.Length; k++)
                {
                    DrService.UpdateDr(DrChangedParameters[k].UserName, DrChangedParameters[k].Name,
                  DrChangedParameters[k].Phone, DrChangedParameters[k].CardNumber, DrChangedParameters[k].AccountNumber,
                  DrChangedParameters[k].CommissionPercent, DrChangedParameters[k].TotalCheckedOut, out Error);
                }
               

            }

            MessageBox.Show(Error);

            Form1.ShowAllData(RefScourceCategory); 
                }


        private int Add_EditDr(string UserName, string Name, string Phone, string CardNumber,
            string AccountNumber, int CommissionPercent, out string Error)
        {
           
            DoctorService DrService = new DoctorService();

            int Status = DrService.AddDr(UserName, Name, Phone, CardNumber, AccountNumber, CommissionPercent, out Error);

            if (Status == 0)// reapeatitive 
            {
                DialogResult DialogResult0 = MessageBox.Show("The UserName " + UserName + " Already Exist. Do you want to replace and Edit?", "", MessageBoxButtons.YesNo);
                if (DialogResult0 == DialogResult.Yes)
                {
                    DrService.UpdateDr(UserName, Name, Phone, CardNumber, AccountNumber,
          CommissionPercent, out Error);
                }
            }



            return Status;

        }
        private int  Add_EditCustomer(string UserName, string Name, string Phone, string Email, out string Error)
        {
           
            CustomerService CustService = new CustomerService();

            int Status = CustService.AddCustomer(UserName, Name, Phone, Email, out Error);

            if (Status == 0)// reapeatitive 
            {
                DialogResult DialogResult0 = MessageBox.Show("The UserName " + UserName + " Already Exist. Do you want to replace and Edit?", "", MessageBoxButtons.YesNo);
                if (DialogResult0 == DialogResult.Yes)
                {
                    CustService.UpdateCustomer(UserName, Name, Phone, Email, out Error);

                }
            }
            return Status; 

        }
        private void Add_Click(object sender, EventArgs e)
        {

            string Error= "";
            int Status = -1;
            
            if (RefScourceCategory == "Patient")
            {
                List<CustomerViewModel> CustomerChangedParameters = Form1.GetAllCustomersChangedCell();

                foreach (var Customer in CustomerChangedParameters)
                {
                    Status = Add_EditCustomer(Customer.UserName, Customer.Name, Customer.Phone, Customer.Email,out Error );

                }


            }
            else if (RefScourceCategory == "Physician")
            {

                DoctorViewModel[] DrChangedParameters = Form1.GetAllDrChangedCells();

                  foreach (DoctorViewModel Dr in DrChangedParameters)
                {
                    Status = Add_EditDr(Dr.UserName, Dr.Name,Dr.Phone, Dr.CardNumber, Dr.AccountNumber,Dr.CommissionPercent, out Error);

                }

            }

                MessageBox.Show(Error);

            Form1.ShowAllData(RefScourceCategory);

        }

        private void Import_Click(object sender, EventArgs e)
        {
            int NumberOfAdded = 0;
            int NumberOfEdited = 0;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.Filter = "*.Xlsx";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        DataTable dtExcel = ReadExcel(openFileDialog.FileName); //read excel file
                        if (RefScourceCategory == "Patient")
                        {
                           
                            string Error = "";
                            foreach (DataRow row in dtExcel.Rows)
                            {
                                string UserName = row["UserName"].ToString();
                                string Name = row["Name"].ToString();
                                string Phone = row["Phone"].ToString();
                                string Email = row["Email"].ToString();
                                int Status = -1; 
                                if ((UserName != null) && (Name != null) && (Phone != null) && (Email != null))
                                {
                                    Status = Add_EditCustomer(UserName, Name, Phone, Email,out Error);
                                    if (Status == 1)
                                    {
                                        NumberOfAdded++; 
                                    }
                                    else if (Status == 0)
                                    {
                                        NumberOfEdited++; 
                                    }
                                   

                                }
                                else
                                {
                                    MessageBox.Show("Invalid File");
                                    break;
                                }
                            }

                            MessageBox.Show("The number of " + NumberOfAdded +
                                   "users are added and the number of " + NumberOfEdited + "users are edited.");

                        }
                        else if (RefScourceCategory == "Physician")
                        {
                            
                            string Error = "";
                            foreach (DataRow row in dtExcel.Rows)
                            {
                                string UserName = row["UserName"].ToString();
                                string Name = row["Name"].ToString();
                                string Phone = row["Phone"].ToString();
                                string CardNumber = row["CardNumber"].ToString();
                                string AccountNumber = row["AccountNumber"].ToString();

                                int DrShareDefaultValue = 50; 
                                int CommisionPercent = -1;
                                if (row["CommisionPercent"].ToString()!= null )
                                {
                                    if (row["CommisionPercent"].ToString() == "")
                                    {
                                        CommisionPercent = DrShareDefaultValue; 
                                    }
                                    else
                                    {
                                        CommisionPercent = int.Parse(row["CommisionPercent"].ToString());
                                    }
                                }

                                if ((UserName != null) && (Name != null) && (Phone != null) && (AccountNumber != null)
                                 && (CardNumber != null) && (CommisionPercent != -1))
                                {
                                    int Status = -1; 
                                    Status = Add_EditDr(UserName, Name, Phone, CardNumber, AccountNumber, CommisionPercent, out Error );
                                    if (Status == 1)
                                    {
                                        NumberOfAdded++;
                                    }
                                    else if (Status == 0)
                                    {
                                        NumberOfEdited++;
                                    }
                                   

                                }

                                else
                                {
                                    MessageBox.Show("Invalid File");
                                    break;
                                }
                            }
                            MessageBox.Show("The number of " + NumberOfAdded +
                                  "doctors are added and the number of " + NumberOfEdited + "doctors are edited.");

                        }


                        Form1.ShowAllData(RefScourceCategory);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }



                }
            }
        }

        private DataTable ReadExcel(string fileName)
        {
            WorkBook workbook = WorkBook.Load(fileName);
            //// Work with a single WorkSheet.
            ////you can pass static sheet name like Sheet1 to get that sheet
            ////WorkSheet sheet = workbook.GetWorkSheet("Sheet1");
            //You can also use workbook.DefaultWorkSheet to get default in case you want to get first sheet only
            WorkSheet sheet = workbook.GetWorkSheet(RefScourceCategory);
            //Convert the worksheet to System.Data.DataTable
            //Boolean parameter sets the first row as column names of your table.
            return sheet.ToDataTable(true);
        }


        public void Remove(Form Form1)
        {
            Form1.Controls.Remove(this.groupBox4);
            Form1.Controls.Remove(ViewLabel); 


        }
        public void Show(Form Form0, string  refScourceCategory0)
        {
            Form0.Controls.Add(this.groupBox4);
            Form0.Controls.Add(ViewLabel);
            Form2 = Form0; 
            RefScourceCategory = refScourceCategory0;
            ViewLabel.Text = RefScourceCategory;
            Form1.ShowAllData(RefScourceCategory);
        }

        public void FormInitDesign()
        {
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.EditButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.Importbutton1 = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();

            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.EditButton);
            this.groupBox4.Controls.Add(this.RemoveButton);
            this.groupBox4.Controls.Add(this.AddButton);
            this.groupBox4.Controls.Add(this.Importbutton1);
            this.groupBox4.Controls.Add(this.SearchTextBox);
            this.groupBox4.Controls.Add(this.SearchButton);
            this.groupBox4.Location = new System.Drawing.Point(12, 227);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(761, 100);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "AdminActions";
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(259, 22);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 3;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
             this.EditButton.Click += new System.EventHandler(this.EditClick);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(178, 22);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 2;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
             this.RemoveButton.Click += new System.EventHandler(this.Remove_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(97, 22);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.Add_Click);
            // 
            // Importbutton1
            // 
            this.Importbutton1.Location = new System.Drawing.Point(16, 22);
            this.Importbutton1.Name = "Importbutton1";
            this.Importbutton1.Size = new System.Drawing.Size(75, 23);
            this.Importbutton1.TabIndex = 0;
            this.Importbutton1.Text = "Import";
            this.Importbutton1.UseVisualStyleBackColor = true;
             this.Importbutton1.Click += new System.EventHandler(this.Import_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(421, 22);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(75, 23);
            this.SearchTextBox.TabIndex = 4;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(340, 22);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 5;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
             this.SearchButton.Click += new System.EventHandler(this.SearchClick);
            // 

            // 
            // ViewLabel
            // 
            this.ViewLabel = new System.Windows.Forms.Label();

            this.ViewLabel.AutoSize = true;
            this.ViewLabel.Location = new System.Drawing.Point(15, 33);
            this.ViewLabel.Name = "ViewLabel";
            this.ViewLabel.Size = new System.Drawing.Size(62, 15);
            this.ViewLabel.TabIndex = 19;
            this.ViewLabel.Text = RefScourceCategory;

        }

        private GroupBox groupBox4;
        private Button EditButton;
        private Button RemoveButton;
        private Button AddButton;
        private Button Importbutton1;
        private Button SearchButton;
        private TextBox SearchTextBox;
        private Label ViewLabel;
    }
}
