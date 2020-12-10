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
    public partial class FeaturesForm : Form
    {
        private readonly HotelCrownContext db;
        public FeaturesForm(HotelCrownContext db)
        {
            this.db = db;
            InitializeComponent();
            ListFeature();
            lstAvailableFeatures.DataSource = db.Features.ToList();
        }

        private void ListFeature()
        {
            lstAvailableFeatures.DataSource = db.Features.ToList();
        }

        private void btnAddFeature_Click(object sender, EventArgs e)
        {
            if (txtFeatureName.Text == "")
            {
                MessageBox.Show("Plase type Feature name");
                return;
            }
            
            Feature feature = new Feature();
            feature.FeatureName = txtFeatureName.Text.Trim();
            
            if (db.Features.Select(x => x.FeatureName).Contains(feature.FeatureName))
            {
                DialogResult dr = MessageBox.Show("Allready have feature for this Feature Name are you want to create new feature ? ", "İnfo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    txtFeatureName.Text = "";
                    lstAvailableFeatures.SelectedIndex = -1;
                    txtFeatureName.Focus();
                    return;
                }
                else
                {
                    return;
                }
            }
            db.Features.Add(feature);
            db.SaveChanges();
            ListFeature();
            lstAvailableFeatures.SelectedIndex = lstAvailableFeatures.Items.Count - 1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstAvailableFeatures.Items.Count == 0)
            {
                return;
            }
            if (lstAvailableFeatures.SelectedIndex < 0)
            {
                MessageBox.Show("First choose available Feature from list");
                return;
            }
            Feature feature = lstAvailableFeatures.SelectedItem as Feature;
            int choosenIndeks = lstAvailableFeatures.SelectedIndex;
            db.Features.Remove(feature);
            db.SaveChanges();
            ListFeature();
            if (lstAvailableFeatures.Items.Count >= 0)
            {
                if (choosenIndeks != lstAvailableFeatures.Items.Count)
                {
                    lstAvailableFeatures.SelectedIndex = choosenIndeks;
                }
                else
                {
                    lstAvailableFeatures.SelectedIndex = lstAvailableFeatures.Items.Count - 1;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstAvailableFeatures.SelectedIndex < 0)
            {
                MessageBox.Show("Please select the Feature you  to edit from the list");
                return;
            }
            btnAddFeature.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtFeatureName.Focus();
            btnAddFeature.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            if (txtFeatureName.Text == "")
            {
                MessageBox.Show("Plase type Feature name");
                return;
            }
            Feature feature = lstAvailableFeatures.SelectedItem as Feature;
            feature.FeatureName = txtFeatureName.Text.Trim();
            db.SaveChanges();
            ListFeature();
            lstAvailableFeatures.SelectedIndex = lstAvailableFeatures.Items.Count - 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAddFeature.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void lstAvailableFeatures_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstAvailableFeatures.SelectedIndex >= 0)
            {
                Feature feature = lstAvailableFeatures.SelectedItem as Feature;
                txtFeatureName.Text = feature.FeatureName;
            }
        }
    }
}
