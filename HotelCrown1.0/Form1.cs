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
    public partial class Form1 : Form
    {
        HotelCrownContext db = new HotelCrownContext();
        public Form1()
        {
            InitializeComponent();
            dgvReservations.AutoGenerateColumns = false;
            dgvReservations.DataSource = db.Reservations.ToList();
        }

        private void tsmRooms_Click(object sender, EventArgs e)
        {
            RoomsForm frm = new RoomsForm(db);
            frm.ShowDialog();
        }

        private void tsmFeatures_Click(object sender, EventArgs e)
        {
            FeaturesForm frm = new FeaturesForm(db);
            frm.ShowDialog();
        }

        private void tsmServices_Click(object sender, EventArgs e)
        {
            ServicesForm frm = new ServicesForm(db);
            frm.ShowDialog();
        }

        private void tsmCustomers_Click(object sender, EventArgs e)
        {
            CustomersForm frm = new CustomersForm(db);
            frm.ShowDialog();
        }

        private void btnNewReservation_Click(object sender, EventArgs e)
        {
            ReservationForm frm = new ReservationForm(db);
            frm.NewReservationAdded += Frm_NewReservationAdded;
            frm.ShowDialog();
        }

        private void Frm_NewReservationAdded(object sender, EventArgs e)
        {
            dgvReservations.DataSource = db.Reservations.ToList();
        }

        private void btnDeleteReservation_Click(object sender, EventArgs e)
        {
            Reservation reservation = dgvReservations.SelectedRows[0].DataBoundItem as Reservation;
            Room room = reservation.Room;
            ICollection<Customer> customers = reservation.Customers;
            room.Customers.Clear();
            room.Reservations.Remove(reservation);
            for (int i = 0; i < customers.Count; i++)
            {
                var s = customers.ToArray();
                Customer customer = s[i];
                customer.CustomerName = customer.CustomerName.Replace($"({room.RoomName})", "");
                customer.Room = null;
            }
            db.Reservations.Remove(reservation);
            db.SaveChanges();
            dgvReservations.DataSource = db.Reservations.ToList();
        }

        private void btnEditReservation_Click(object sender, EventArgs e)
        {
            if (dgvReservations.Rows.Count == 0)
            {
                MessageBox.Show("There is not find reservations for edit");
                return;
            }
            Reservation reservation = dgvReservations.SelectedRows[0].DataBoundItem as Reservation;
            EditRezervationForm frm = new EditRezervationForm(db, reservation);
            frm.ReservationEdited += Frm_ReservationEdited;
            frm.ShowDialog();
        }

        private void Frm_ReservationEdited(object sender, EventArgs e)
        {
            dgvReservations.DataSource = db.Reservations.ToList();
        }
    }
}
