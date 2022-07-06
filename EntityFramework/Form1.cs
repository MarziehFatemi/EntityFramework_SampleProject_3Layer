using BussinessLayer.ViewModels;
using EF_3Layers_Hiexpert.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLayer.Service; 

namespace EF_3Layers_Hiexpert
{
    
    public partial class Form1 : Form
    {

        SignUpPage SignUp1;
        BookingAppointment BookingAppointmentPage;
        UserManagement UserManagementPage;
        public static DataGridView DataGridView1;
        public  static int[] ChangedRows = new int[1];



        public Form1()
        {
            InitializeComponent();
            SignUp1 = new SignUpPage();
            SignUp1.FormInitDesign();
            BookingAppointmentPage = new BookingAppointment();
            BookingAppointmentPage.FormInitDesign();
            UserManagementPage = new UserManagement();
            UserManagementPage.FormInitDesign();
        } 

        
         private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool IsReapeted = false;
            for (int m = 0; (ChangedRows.Length > 1 && m < ChangedRows.Length - 1); m++)
            {
                if (e.RowIndex == ChangedRows[m])
                {
                    IsReapeted = true;
                    break;
                }
            }
            if (!IsReapeted)
            {
                ChangedRows[ChangedRows.Length - 1] = e.RowIndex;
                Array.Resize(ref ChangedRows, ChangedRows.Length + 1);
            }
        }

        public static void ShowAllData(string Category)
        {

            if (Category == "Patient")
            {
                var Customer = new CustomerService();
                DataGridView1.DataSource = Customer.GetAllCustomers();
                DataGridView1.Columns["UserName"].ReadOnly = true;
                DataGridView1.Columns["TotalPayment"].ReadOnly = true;


            }
            else if (Category == "Physician")
            {
                var Drr = new DoctorService();
                DataGridView1.DataSource = Drr.GetAllDrs();
                DataGridView1.Columns["UserName"].ReadOnly = true;
                DataGridView1.Columns["TotalSale"].ReadOnly = true;
                DataGridView1.Columns["TotalIncome"].ReadOnly = true;
               // DataGridView1.Columns["TotalCheckedOut"].ReadOnly = true;
                DataGridView1.Columns["Credit"].ReadOnly = true;

            }
            else if (Category == "Appointment")
            {
                var Order = new AppointmentService();
                DataGridView1.DataSource = Order.GetAllAppointments();
            }
        }
        public static DoctorViewModel[] GetAllDrChangedCells()
        {
            DoctorViewModel [] DrChangedParameters = new DoctorViewModel[ChangedRows.Length - 1];
            for (int k = 0; k < ChangedRows.Length - 1; k++)
            {
                DrChangedParameters[k] = new DoctorViewModel();
                DrChangedParameters[k].UserName = DataGridView1.Rows[ChangedRows[k]].Cells["UserName"].Value.ToString();
                DrChangedParameters[k].Name = DataGridView1.Rows[ChangedRows[k]].Cells["Name"].Value.ToString();
                DrChangedParameters[k].Phone = DataGridView1.Rows[ChangedRows[k]].Cells["Phone"].Value.ToString();
                DrChangedParameters[k].CardNumber = DataGridView1.Rows[ChangedRows[k]].Cells["CardNumber"].Value.ToString();
                try
                {
                    DrChangedParameters[k].AccountNumber = DataGridView1.Rows[ChangedRows[k]].Cells["AccountNumber"].Value.ToString();
                }
                catch
                {
                    DrChangedParameters[k].AccountNumber = ""; 
                }
                DrChangedParameters[k].CommissionPercent = int.Parse (DataGridView1.Rows[ChangedRows[k]].Cells["CommissionPercent"].Value.ToString());
                DrChangedParameters[k].TotalCheckedOut = int.Parse(DataGridView1.Rows[ChangedRows[k]].Cells["TotalCheckedOut"].Value.ToString());

            }
            return DrChangedParameters; 
        }

        public static DoctorViewModel[] GetSelectedDr()
        {
            DoctorViewModel[] DrSelectedParameters = new DoctorViewModel[DataGridView1.SelectedRows.Count];
            for (int k = 0; k < DataGridView1.SelectedRows.Count; k++)
            {
                DrSelectedParameters[k] = new DoctorViewModel();
                DrSelectedParameters[k].UserName = DataGridView1.SelectedRows[k].Cells["UserName"].Value.ToString();
                DrSelectedParameters[k].Name = DataGridView1.SelectedRows[k].Cells["Name"].Value.ToString();
                DrSelectedParameters[k].Phone = DataGridView1.SelectedRows[k].Cells["Phone"].Value.ToString();
                DrSelectedParameters[k].CardNumber = DataGridView1.SelectedRows[k].Cells["CardNumber"].Value.ToString();
                try
                {
                    DrSelectedParameters[k].AccountNumber = DataGridView1.Rows[ChangedRows[k]].Cells["AccountNumber"].Value.ToString();
                }
                catch
                {
                    DrSelectedParameters[k].AccountNumber = "";
                }

            }
            return DrSelectedParameters;
        }

        public static List<CustomerViewModel> GetSelectedCustomer()
        {
            List<CustomerViewModel> SelectedCustomer = new List<CustomerViewModel>();

            for (int k = 0;k< DataGridView1.SelectedRows.Count; k++)
            
            {
                SelectedCustomer.Add(new CustomerViewModel()
                {
                    UserName = DataGridView1.SelectedRows[k].Cells["UserName"].Value.ToString(),
                    Name = DataGridView1.SelectedRows[k].Cells["Name"].Value.ToString(),
                    Phone = DataGridView1.SelectedRows[k].Cells["Email"].Value.ToString(),
                    Email = DataGridView1.SelectedRows[k].Cells["Phone"].Value.ToString()


                });
            }
            return SelectedCustomer;


        }


        public static List<CustomerViewModel> GetAllCustomersChangedCell()
        {
            List<CustomerViewModel> CustomersChangedCell = new List <CustomerViewModel>();

            for (int k = 0; k < ChangedRows.Length - 1; k++)
            {
                CustomersChangedCell.Add(new CustomerViewModel()
                {
                    UserName =DataGridView1.Rows[ChangedRows[k]].Cells["UserName"].Value.ToString(),
                    Name = DataGridView1.Rows[ChangedRows[k]].Cells["Name"].Value.ToString(),
                    Email= DataGridView1.Rows[ChangedRows[k]].Cells["Email"].Value.ToString(),
                    Phone = DataGridView1.Rows[ChangedRows[k]].Cells["Phone"].Value.ToString() 

                 
                });
            }
            return CustomersChangedCell;
                
            
        }





        private void signUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManagementPage.Remove(this);
            BookingAppointmentPage.Remove(this);
            this.Controls.Remove(DataGridView1);

            SignUp1.Show(this);
        }

        private void bookingAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManagementPage.Remove(this);
            SignUp1.Remove(this);
            BookingAppointmentPage.Show(this);
            this.Controls.Add(DataGridView1);


        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SignUp1.Remove(this);
            BookingAppointmentPage.Remove(this);
            this.Controls.Add(DataGridView1);

            UserManagementPage.Show(this,"Patient");


        }

        private void doctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SignUp1.Remove(this);
            this.Controls.Add(DataGridView1);

            BookingAppointmentPage.Remove(this);
            UserManagementPage.Show(this,"Physician");

        }
    }
}
