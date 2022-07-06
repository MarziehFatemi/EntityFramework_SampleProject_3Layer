using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLayer.Service;
using BussinessLayer.ViewModels; 

namespace EF_3Layers_Hiexpert.Management
{
    public class BookingAppointment
    {


        private void AddAppointment_Click(object sender, EventArgs e)
        {
            string Error = ""; 
            AppointmentService AppointmentService1 = new AppointmentService();
            int Payment = int.Parse(PriceFromTextBox.Text);

            if (AppointmentService1.AddAppointment(comboBox1.Text, comboBox2.Text, monthCalendar1.SelectionRange.Start, Payment, out Error))
            {
                
                // Adding Payment to Dr 
                // find dr
                // read values

                var Dr = new DoctorService();
                var DrParam = new DoctorViewModel();
                DrParam = Dr.GetADr(comboBox1.Text);

                // update values 
                DrParam.TotalSale += Payment;
                if (DrParam.CommissionPercent == 0) DrParam.CommissionPercent = 50;
                DrParam.TotalIncome = DrParam.TotalSale * DrParam.CommissionPercent / 100;
                DrParam.Credit = DrParam.TotalIncome - DrParam.TotalCheckedOut;

               if (! Dr.UpdateDr(DrParam.UserName, DrParam.Name, DrParam.Phone, DrParam.CardNumber,
                    DrParam.AccountNumber, DrParam.CommissionPercent, DrParam.TotalCheckedOut,
                    DrParam.TotalSale, DrParam.TotalIncome, DrParam.Credit, out Error))
                {
                    MessageBox.Show("The Income of Doctor did not changed. The error is: " + Error);
                }


                // Adding Payment to User 
                // find User
                // read values

                var User = new CustomerService();
                var UserParam = new CustomerViewModel();
                UserParam = User.GetACustomer(comboBox2.Text);

                // update values 
                UserParam.TotalPayment += Payment;

                if (!User.UpdateCustomer(UserParam.UserName, UserParam.Name, UserParam.Phone, UserParam.Email,
                     out Error, UserParam.TotalPayment))
                {
                    MessageBox.Show("The user total payment did not changed. The error is: " + Error);
                  
                }
                Form1.ShowAllData("Appointment");
            }
            else
            {
                MessageBox.Show(Error);

            }
        }

        private void FilterAppointment_Click(object sender, EventArgs e)
        {     //////  cmd2.Connection = con;
        //////        cmd2.Parameters.AddWithValue("@Dr0", comboBox1.Text);
        //////        cmd2.Parameters.AddWithValue("@Cust0", comboBox2.Text);
        //////        cmd2.Parameters.AddWithValue("@PriceFrom0", PriceFromTextBox.Text);
        //////        cmd2.Parameters.AddWithValue("@PriceTo0", PriceToTextBox.Text);

        //////        cmd2.Parameters.AddWithValue("@StartDate0", monthCalendar1.SelectionRange.Start.ToString());
        //////        cmd2.Parameters.AddWithValue("@EndDate0", monthCalendar1.SelectionRange.End.ToString());

        //////        FillGrid(cmd2);
        //DrawView("Appointments", "Appointment");
        }



        public void Remove(Form Form1)
        {
            Form1.Controls.Remove(this.groupBox3);
            //Form1.Controls.Remove(DataGridView1);
            Form1.Controls.Remove(ViewLabel);

        }
        public void Show(Form Form0)
        {
            Form0.Controls.Add(this.groupBox3);
            Form0.Controls.Add(ViewLabel);
            Form1.ShowAllData("Appointment");

            //comboBox1 = new System.Windows.Forms.ComboBox();
            //comboBox2 = new System.Windows.Forms.ComboBox();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            var Dr = new DoctorService();
            List<DoctorViewModel> StrList = Dr.GetAllDrs();
            foreach (var D in StrList)
            { comboBox1.Items.Add(D.UserName); }

            var C = new CustomerService();
            List<CustomerViewModel> CList = C.GetAllCustomers();
            foreach (var V in CList)
            { comboBox2.Items.Add(V.UserName); }


        }

        public void FormInitDesign()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.PriceFromTextBox = new System.Windows.Forms.TextBox();
            this.PriceToTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            AddAppointment = new System.Windows.Forms.Button();
            FilterAppointment = new System.Windows.Forms.Button();

            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.PriceFromTextBox);
            this.groupBox3.Controls.Add(this.PriceToTextBox);
            this.groupBox3.Controls.Add(this.monthCalendar1);
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.AddAppointment);
            this.groupBox3.Controls.Add(this.FilterAppointment);
            this.groupBox3.Location = new System.Drawing.Point(10, 250);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(490, 335);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "AddAppointment";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(123, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(227, 23);
            this.comboBox1.TabIndex = 0;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(123, 51);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(227, 23);
            this.comboBox2.TabIndex = 1;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(123, 86);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 3;
            // 
            // PriceTextBox
            // 

            this.PriceFromTextBox.Location = new System.Drawing.Point(123, 260);
            this.PriceFromTextBox.Name = "comboBox3";
            this.PriceFromTextBox.Size = new System.Drawing.Size(110, 23);
            this.PriceFromTextBox.TabIndex = 4;


            // PriceTextBox
            // 

            this.PriceToTextBox.Location = new System.Drawing.Point(237, 260);
            this.PriceToTextBox.Size = new System.Drawing.Size(110, 23);
            // Add Button
            // 
            this.AddAppointment.Location = new System.Drawing.Point(123, 290);
            this.AddAppointment.Size = new System.Drawing.Size(110, 23);
            this.AddAppointment.Text = "Add";
             this.AddAppointment.Click += new System.EventHandler(this.AddAppointment_Click);

            this.FilterAppointment.Location = new System.Drawing.Point(237, 290);
            this.FilterAppointment.Size = new System.Drawing.Size(110, 23);
            this.FilterAppointment.Text = "Filter";
            this.FilterAppointment.Click += new System.EventHandler(this.FilterAppointment_Click);


            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Doctor";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Customer";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(35, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 15);
            this.label11.TabIndex = 7;
            this.label11.Text = "Date";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 268);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 15);
            this.label12.TabIndex = 8;
            this.label12.Text = "Price/Min/Max";



            // 
            // ViewLabel
            // 
            this.ViewLabel = new System.Windows.Forms.Label();

            this.ViewLabel.AutoSize = true;
            this.ViewLabel.Location = new System.Drawing.Point(15, 33);
            this.ViewLabel.Name = "ViewLabel";
            this.ViewLabel.Size = new System.Drawing.Size(62, 15);
            this.ViewLabel.TabIndex = 19;
            this.ViewLabel.Text = "Booking Appointment";

            
        }

        private Label label12;
        private Label label11;
        private Label label7;
        private Label label6;
        //private ComboBox comboBox3;
        private TextBox PriceFromTextBox;
        private TextBox PriceToTextBox;
        private MonthCalendar monthCalendar1;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private GroupBox groupBox3;
        Button AddAppointment;
        Button FilterAppointment;
        private Label ViewLabel;
    }
}
