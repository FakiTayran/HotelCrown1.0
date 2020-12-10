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
    public partial class ServicesForm : Form
    {
        private readonly HotelCrownContext db;

        public ServicesForm(HotelCrownContext db)
        {
            this.db = db;
            InitializeComponent();
            ListServices();
            lstAvailableServices.SelectedIndex = -1;
        }

        private void ListServices()
        {
            lstAvailableServices.DataSource = db.Services.ToList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstAvailableServices.Items.Count == 0)
            {
                return;
            }
            if (lstAvailableServices.SelectedIndex < 0)
            {
                MessageBox.Show("First choose available service from list");
                return;
            }
            Service service = lstAvailableServices.SelectedItem as Service;
            int choosenIndeks = lstAvailableServices.SelectedIndex;
            db.Services.Remove(service);
            db.SaveChanges();
            ListServices();
            if (lstAvailableServices.Items.Count >= 0)
            {
                if (choosenIndeks != lstAvailableServices.Items.Count)
                {
                    lstAvailableServices.SelectedIndex = choosenIndeks;
                }
                else
                {
                    lstAvailableServices.SelectedIndex = lstAvailableServices.Items.Count - 1;
                }
            }
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (txtServiceName.Text == "")
            {
                MessageBox.Show("Please type service name");
                return;
            }
       
            Service service = new Service();
            service.ServiceName = txtServiceName.Text.Trim();
            service.UnitPrice = nudPrice.Value;

            if (db.Services.Select(x => x.ServiceName).Contains(service.ServiceName))
            {
                DialogResult dr = MessageBox.Show("Allready have service for this Service Name are you want to create new service ? ", "İnfo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    txtServiceName.Text = "";
                    nudPrice.Value = 0;
                    lstAvailableServices.SelectedIndex = -1;
                    txtServiceName.Focus();
                    return;
                }
                else
                {
                    return;
                }
            }
            db.Services.Add(service);
            db.SaveChanges();
            ListServices();
            lstAvailableServices.SelectedIndex = lstAvailableServices.Items.Count - 1;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstAvailableServices.SelectedIndex < 0)
            {
                MessageBox.Show("Please select the service want to edit from the list");
                return;
            }
            btnAddService.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtServiceName.Focus();
            btnAddService.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            if (txtServiceName.Text == "")
            {
                MessageBox.Show("Please type service name");
                return;
            }


            Service service = lstAvailableServices.SelectedItem as Service;
            int choosenIndeks = lstAvailableServices.SelectedIndex;
            service.ServiceName = txtServiceName.Text.Trim();
            service.UnitPrice = nudPrice.Value;

            db.SaveChanges();
            ListServices();
            lstAvailableServices.SelectedIndex = choosenIndeks;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAddService.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void lstAvailableServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAvailableServices.SelectedIndex >= 0)
            {
                Service service = lstAvailableServices.SelectedItem as Service;
                txtServiceName.Text = service.ServiceName;
                nudPrice.Value = service.UnitPrice;
            }
        }
    }
}
