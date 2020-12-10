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
    public partial class RoomsForm : Form
    {
        private readonly HotelCrownContext db;
        public RoomsForm(HotelCrownContext db)
        {
            this.db = db;
            InitializeComponent();
            ListRooms();
            lstAvailableRooms.SelectedIndex = -1;
            this.Height = 341;
            cboFeatures.DataSource = db.Features.ToList();
            cboFeatures.SelectedIndex = -1;
        }

        private void ListRooms()
        {
            lstAvailableRooms.DataSource = db.Rooms.ToList();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (txtRoomName.Text == "")
            {
                MessageBox.Show("Plase type room name");
                return;
            }
            if (nudPrice.Value == 0)
            {
                MessageBox.Show("Price must over Zero");
                return;
            }
            Room room = new Room();
            room.RoomName = txtRoomName.Text.Trim();
            room.Price = nudPrice.Value;
            room.Capacity = (int)nudCapacity.Value;

            if (cboFeatures.SelectedIndex >= 0)
            {
                Feature feature = cboFeatures.SelectedItem as Feature;
                room.Features.Add(feature);
            }
            if (db.Rooms.Select(x => x.RoomName).Contains(room.RoomName))
            {
                DialogResult dr = MessageBox.Show("Allready have room for this Room Name are you want to create new room ? ", "İnfo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    txtRoomName.Text = "";
                    nudPrice.Value = 0;
                    nudCapacity.Value = 1;
                    cboFeatures.SelectedIndex = -1;
                    lstAvailableRooms.SelectedIndex = -1;
                    this.Height = 341;
                    txtRoomName.Focus();
                    return;
                }
                else
                {
                    return;
                }
            }
            db.Rooms.Add(room);
            db.SaveChanges();
            ListRooms();
            lstAvailableRooms.SelectedIndex = lstAvailableRooms.Items.Count - 1;
            cboFeatures.SelectedIndex = -1;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstAvailableRooms.Items.Count == 0)
            {
                return;
            }
            if (lstAvailableRooms.SelectedIndex < 0)
            {
                MessageBox.Show("First choose available room from list");
                return;
            }
            Room room = lstAvailableRooms.SelectedItem as Room;
            int choosenIndeks = lstAvailableRooms.SelectedIndex;
            db.Rooms.Remove(room);
            db.SaveChanges();
            ListRooms();
            if (lstAvailableRooms.Items.Count >= 0)
            {
                if (choosenIndeks != lstAvailableRooms.Items.Count)
                {
                    lstAvailableRooms.SelectedIndex = choosenIndeks;
                }
                else
                {
                    lstAvailableRooms.SelectedIndex = lstAvailableRooms.Items.Count - 1;
                }
            }
            cboFeatures.SelectedIndex = -1;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstAvailableRooms.SelectedIndex < 0)
            {
                MessageBox.Show("Please select the room  want to edit from the list");
                return;
            }
            btnAddRoom.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtRoomName.Focus();
            btnAddRoom.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            if (txtRoomName.Text == "")
            {
                MessageBox.Show("Please type room name");
                return;
            }
            if (nudPrice.Value == 0)
            {
                MessageBox.Show("Price must over Zero");
                return;
            }

            Room room = lstAvailableRooms.SelectedItem as Room;
            int choosenIndeks = lstAvailableRooms.SelectedIndex;
            room.RoomName = txtRoomName.Text.Trim();
            room.Price = nudPrice.Value;
            room.Capacity = (int)nudCapacity.Value;
            if (cboFeatures.SelectedIndex >= 0)
            {
                Feature feature = cboFeatures.SelectedItem as Feature;
                room.Features.Add(feature);
            }

            db.SaveChanges();
            ListRooms();
            lstAvailableRooms.SelectedIndex = choosenIndeks;
            cboFeatures.SelectedIndex = -1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAddRoom.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void lstAvailableRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAvailableRooms.SelectedIndex >= 0)
            {
                Room room = lstAvailableRooms.SelectedItem as Room;
                txtRoomName.Text = room.RoomName;
                nudCapacity.Value = room.Capacity;
                nudPrice.Value = room.Price;
                this.Height = 512;
                panel1.Controls.Clear();
                Label label = new Label();
                panel1.Controls.Add(label);
                label.Width = 605;
                label.Height = 158;
                label.AutoSize = false;
                label.BackColor = Color.DarkGreen;
                label.ForeColor = Color.White;
                label.Text = room.FeaturesNames;
            }
            else
            {
                lstAvailableRooms.SelectedIndex = -1;
                this.Height = 512;
            }
        }
    }
}
