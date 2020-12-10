using HotelCrown1._0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelCrown1._0
{
    public partial class CustomersForm : Form
    {
        private readonly HotelCrownContext db;
        public CustomersForm(HotelCrownContext db)
        {
            this.db = db;
            InitializeComponent();
            ListCustomer();
        }

        private void ListCustomer()
        {
            lstAvailableCustomer.DataSource = db.Customers.ToList();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text == "")
            {
                MessageBox.Show("Plase type Customer name");
                return;
            }
            if (txtPhoneNumber.Text != "")
            {
                if (txtPhoneNumber.Text.Length > 15)
                {
                    MessageBox.Show("Phone Number max length must be 15");
                    return;
                }
            }
            if (txtIdentityNumber.Text != "")
            {
                if (txtIdentityNumber.Text.Length > 11)
                {
                    MessageBox.Show("Identity Number  max length must be 11");
                    return;
                }
            }
            Customer customer = new Customer();
            customer.CustomerName = txtCustomerName.Text.Trim();
            customer.PhoneNumber = txtPhoneNumber.Text.Trim();
            customer.IdentityNumber = txtIdentityNumber.Text.Trim();
            customer.Description = txtDescription.Text.Trim();
            if (rbMale.Checked == true)
            {
                customer.Gender = GenderResult.Erkek;
            }
            else if (rbFemale.Checked == true)
            {
                customer.Gender = GenderResult.Kadın;
            }
            DateTime dateTimeNow = DateTime.Now;
            if (DateTime.Compare(dateTimeNow, dtpBirthDate.Value) <= 0)
            {
                MessageBox.Show("Customer birth date cannot be entered beyond the current time");
                return;
            }
            else
            {
                customer.BirthDate = dtpBirthDate.Value;
            }
            if (db.Customers.Select(x => x.IdentityNumber).Contains(customer.IdentityNumber))
            {
                DialogResult dr = MessageBox.Show("Allready have customer for this Customer Identity are you want to create new Customer ? ", "İnfo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    txtCustomerName.Text = "";
                    txtIdentityNumber.Text = "";
                    txtPhoneNumber.Text = "";
                    dtpBirthDate.Value = dateTimeNow;
                    rbMale.Checked = false;
                    rbFemale.Checked = false;
                    lstAvailableCustomer.SelectedIndex = -1;
                    txtCustomerName.Focus();
                    return;
                }
                else
                {
                    return;
                }

            }
            db.Customers.Add(customer);
            db.SaveChanges();
            ListCustomer();
            lstAvailableCustomer.SelectedIndex = lstAvailableCustomer.Items.Count - 1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstAvailableCustomer.Items.Count == 0)
            {
                return;
            }
            if (lstAvailableCustomer.SelectedIndex < 0)
            {
                MessageBox.Show("First choose available customer from list");
                return;
            }
            Customer customer = lstAvailableCustomer.SelectedItem as Customer;
            int choosenIndeks = lstAvailableCustomer.SelectedIndex;
            db.Customers.Remove(customer);
            db.SaveChanges();
            ListCustomer();
            if (lstAvailableCustomer.Items.Count >= 0)
            {
                if (choosenIndeks != lstAvailableCustomer.Items.Count)
                {
                    lstAvailableCustomer.SelectedIndex = choosenIndeks;
                }
                else
                {
                    lstAvailableCustomer.SelectedIndex = lstAvailableCustomer.Items.Count - 1;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstAvailableCustomer.SelectedIndex < 0)
            {
                MessageBox.Show("Please select the customer  want to edit from the list");
                return;
            }
            btnAddCustomer.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtCustomerName.Focus();
            btnAddCustomer.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            if (txtCustomerName.Text == "")
            {
                MessageBox.Show("Plase type Customer name");
                return;
            }
            if (txtPhoneNumber.Text != "")
            {
                if (txtPhoneNumber.Text.Length > 15)
                {
                    MessageBox.Show("Phone Number max length must be 15");
                    return;
                }
            }
            if (txtIdentityNumber.Text != "")
            {
                if (txtIdentityNumber.Text.Length > 11)
                {
                    MessageBox.Show("Identity Number  max length must be 11");
                    return;
                }
            }
            Customer customer = lstAvailableCustomer.SelectedItem as Customer;
            int choosenIndeks = lstAvailableCustomer.SelectedIndex;
            customer.CustomerName = txtCustomerName.Text.Trim();
            customer.PhoneNumber = txtPhoneNumber.Text.Trim();
            customer.IdentityNumber = txtIdentityNumber.Text.Trim();
            
            customer.Description = txtDescription.Text.Trim();
            if (rbMale.Checked == true)
            {
                customer.Gender = GenderResult.Erkek;
            }
            else if (rbFemale.Checked == true)
            {
                customer.Gender = GenderResult.Kadın;
            }
            DateTime dateTimeNow = DateTime.Now;
            if (DateTime.Compare(dateTimeNow, dtpBirthDate.Value) <= 0)
            {
                MessageBox.Show("Customer birth date cannot be entered beyond the current time");
                return;
            }
            else
            {
                customer.BirthDate = dtpBirthDate.Value;
            }

            db.SaveChanges();
            if (db.Customers.Count(x=>x.IdentityNumber==customer.IdentityNumber) == 2)
            {
                Random rnd = new Random();
                long randomNIdentity = rnd.Next(100000000, 999999999);
                customer.IdentityNumber = randomNIdentity.ToString() + "rd";
                db.SaveChanges();
                MessageBox.Show($"Your last identity number was same other customer identity and we are give random identity to {customer.CustomerName.ToUpper()} dont forgot to change this identity","Info");
            }
            ListCustomer();
            lstAvailableCustomer.SelectedIndex = choosenIndeks;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAddCustomer.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void lstAvailableCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAvailableCustomer.SelectedIndex >= 0)
            {
                Customer customer = lstAvailableCustomer.SelectedItem as Customer;
                txtCustomerName.Text = customer.CustomerName;
                if (customer.BirthDate != null)
                {
                    dtpBirthDate.Value = customer.BirthDate.Value;
                }
                txtPhoneNumber.Text = customer.PhoneNumber;
                txtIdentityNumber.Text = customer.IdentityNumber;
                txtDescription.Text = customer.Description;
                if (customer.Gender == GenderResult.Erkek)
                {
                    rbMale.Checked = true;
                }
                else if (customer.Gender == GenderResult.Kadın)
                {
                    rbFemale.Checked = true;
                }
                else
                {
                    rbMale.Checked = false;
                    rbFemale.Checked = false;
                }
            }
        }
    }
}
