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
    internal class SignUpPage
    {
        private void SignUP_Cust_Click(object sender, EventArgs e)
        {
            string Error = "";

            CustomerService CustService = new CustomerService();

            if (CustService.AddCustomer(Cus_UserName_txt.Text, Cust_Name_txt.Text, Cust_Phone_txt.Text, "", out Error) == 1)
            {
                Cus_UserName_txt.ResetText();
                Cust_Name_txt.ResetText();
                Cust_Phone_txt.ResetText();
            }
            MessageBox.Show(Error);

        }
        private void SignUP_Doc_Click(object sender, EventArgs e)
        {

            string Error = ""; 
            
            DoctorService DrService = new DoctorService();

            if (DrService.AddDr( Doc_UserName_txt.Text, Doctor_Name_txt.Text, Doctor_Phone_txt.Text, Doc_Kard_txt.Text, Doc_Account_txt.Text, 50, out Error)==1)
            {
                Doc_UserName_txt.ResetText();
                Doctor_Name_txt.ResetText();
                Doctor_Phone_txt.ResetText();
                Doc_Kard_txt.ResetText();
                Doc_Account_txt.ResetText();
            }

            MessageBox.Show(Error); 
        }


        public void Remove(Form Form1)
        {
            Form1.Controls.Remove(this.groupBox2);
            Form1.Controls.Remove(this.groupBox1);
        }
        public void Show(Form Form1)
        {
            Form1.Controls.Add(this.groupBox2);
            Form1.Controls.Add(this.groupBox1);
        }
        public void FormInitDesign()
        {
            // 
            // Cus_UserName_txt
            // 
            this.Cus_UserName_txt.Location = new System.Drawing.Point(113, 22);
            this.Cus_UserName_txt.Name = "Cus_UserName_txt";
            this.Cus_UserName_txt.Size = new System.Drawing.Size(100, 23);
            this.Cus_UserName_txt.TabIndex = 0;
            // 
            // Cust_Name_txt
            // 
            this.Cust_Name_txt.Location = new System.Drawing.Point(113, 51);
            this.Cust_Name_txt.Name = "Cust_Name_txt";
            this.Cust_Name_txt.Size = new System.Drawing.Size(100, 23);
            this.Cust_Name_txt.TabIndex = 1;
            // 
            // Cust_Phone_txt
            // 
            this.Cust_Phone_txt.Location = new System.Drawing.Point(113, 80);
            this.Cust_Phone_txt.Name = "Cust_Phone_txt";
            this.Cust_Phone_txt.Size = new System.Drawing.Size(100, 23);
            this.Cust_Phone_txt.TabIndex = 2;
            // 
            // Doc_Kard_txt
            // 
            this.Doc_Kard_txt.Location = new System.Drawing.Point(342, 38);
            this.Doc_Kard_txt.Name = "Doc_Kard_txt";
            this.Doc_Kard_txt.Size = new System.Drawing.Size(100, 23);
            this.Doc_Kard_txt.TabIndex = 9;
            // 
            // Doc_Account_txt
            // 
            this.Doc_Account_txt.Location = new System.Drawing.Point(342, 11);
            this.Doc_Account_txt.Name = "Doc_Account_txt";
            this.Doc_Account_txt.Size = new System.Drawing.Size(100, 23);
            this.Doc_Account_txt.TabIndex = 8;
            // 
            // Doctor_Phone_txt
            // 
            this.Doctor_Phone_txt.Location = new System.Drawing.Point(130, 70);
            this.Doctor_Phone_txt.Name = "Doctor_Phone_txt";
            this.Doctor_Phone_txt.Size = new System.Drawing.Size(100, 23);
            this.Doctor_Phone_txt.TabIndex = 7;
            // 
            // Doctor_Name_txt
            // 
            this.Doctor_Name_txt.Location = new System.Drawing.Point(130, 41);
            this.Doctor_Name_txt.Name = "Doctor_Name_txt";
            this.Doctor_Name_txt.Size = new System.Drawing.Size(100, 23);
            this.Doctor_Name_txt.TabIndex = 6;
            // 
            // Doc_UserName_txt
            // 
            this.Doc_UserName_txt.Location = new System.Drawing.Point(130, 12);
            this.Doc_UserName_txt.Name = "Doc_UserName_txt";
            this.Doc_UserName_txt.Size = new System.Drawing.Size(100, 23);
            this.Doc_UserName_txt.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "UserName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "PhoneNumber";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Acount Number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Kard Number";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "PhoneNumber";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 15);
            this.label10.TabIndex = 15;
            this.label10.Text = "UserName";
            // 
            // SignUP_cust
            // 
            this.SignUP_cust.Location = new System.Drawing.Point(113, 109);
            this.SignUP_cust.Name = "SignUP_cust";
            this.SignUP_cust.Size = new System.Drawing.Size(100, 23);
            this.SignUP_cust.TabIndex = 4;
            this.SignUP_cust.Text = "SignUp";
            this.SignUP_cust.UseVisualStyleBackColor = true;
            this.SignUP_cust.Click += new System.EventHandler(this.SignUP_Cust_Click);
            // 
            // Import_Cust
            // 
            this.Import_Cust.Location = new System.Drawing.Point(113, 137);
            this.Import_Cust.Name = "Import_Cust";
            this.Import_Cust.Size = new System.Drawing.Size(100, 23);
            this.Import_Cust.TabIndex = 18;
            this.Import_Cust.Text = "Import";
            this.Import_Cust.UseVisualStyleBackColor = true;

            // 
            // Import_Doc
            // 
            this.Import_Doc.Location = new System.Drawing.Point(130, 137);
            this.Import_Doc.Name = "Import_Doc";
            this.Import_Doc.Size = new System.Drawing.Size(100, 23);
            this.Import_Doc.TabIndex = 20;
            this.Import_Doc.Text = "Import";
            this.Import_Doc.UseVisualStyleBackColor = true;
            // 
            // SignUp_Doc
            // 
            this.SignUp_Doc.Location = new System.Drawing.Point(130, 109);
            this.SignUp_Doc.Name = "SignUp_Doc";
            this.SignUp_Doc.Size = new System.Drawing.Size(100, 23);
            this.SignUp_Doc.TabIndex = 19;
            this.SignUp_Doc.Text = "SignUp";
            this.SignUp_Doc.UseVisualStyleBackColor = true;
            this.SignUp_Doc.Click += new System.EventHandler(this.SignUP_Doc_Click);


            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();

            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Import_Cust);
            this.groupBox1.Controls.Add(this.SignUP_cust);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.Cust_Phone_txt);
            this.groupBox1.Controls.Add(this.Cust_Name_txt);
            this.groupBox1.Controls.Add(this.Cus_UserName_txt);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 170);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customers";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Import_Doc);
            this.groupBox2.Controls.Add(this.SignUp_Doc);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Doc_Kard_txt);
            this.groupBox2.Controls.Add(this.Doc_Account_txt);
            this.groupBox2.Controls.Add(this.Doctor_Phone_txt);
            this.groupBox2.Controls.Add(this.Doctor_Name_txt);
            this.groupBox2.Controls.Add(this.Doc_UserName_txt);
            this.groupBox2.Location = new System.Drawing.Point(314, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 170);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Doctors";

            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();



        }

        GroupBox groupBox1 = new System.Windows.Forms.GroupBox();
        GroupBox groupBox2 = new System.Windows.Forms.GroupBox();
        TextBox Cus_UserName_txt = new System.Windows.Forms.TextBox();
        TextBox Cust_Name_txt = new System.Windows.Forms.TextBox();
        TextBox Cust_Phone_txt = new System.Windows.Forms.TextBox();
        TextBox Doc_Kard_txt = new System.Windows.Forms.TextBox();
        TextBox Doc_Account_txt = new System.Windows.Forms.TextBox();
        TextBox Doctor_Phone_txt = new System.Windows.Forms.TextBox();
        TextBox Doctor_Name_txt = new System.Windows.Forms.TextBox();
        TextBox Doc_UserName_txt = new System.Windows.Forms.TextBox();
        Label label1 = new System.Windows.Forms.Label();
        Label label2 = new System.Windows.Forms.Label();
        Label label3 = new System.Windows.Forms.Label();
        Label label4 = new System.Windows.Forms.Label();
        Label label5 = new System.Windows.Forms.Label();
        Label label8 = new System.Windows.Forms.Label();
        Label label9 = new System.Windows.Forms.Label();
        Label label10 = new System.Windows.Forms.Label();
        Button SignUP_cust = new System.Windows.Forms.Button();
        Button Import_Cust = new System.Windows.Forms.Button();
        Button Import_Doc = new System.Windows.Forms.Button();
        Button SignUp_Doc = new System.Windows.Forms.Button();



    }
}
