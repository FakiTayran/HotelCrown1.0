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
    public partial class EditRezervationForm : Form
    {
        private readonly HotelCrownContext db;
        private readonly Reservation reservation;
        public event EventHandler ReservationEdited;
        public EditRezervationForm(HotelCrownContext db, Reservation reservation)
        {
            this.db = db;
            this.reservation = reservation;
            InitializeComponent();
            dgvReservationInfo.AutoGenerateColumns = false;
            dgvReservationInfo.DataSource = db.Reservations.Where(x => x.Id == reservation.Id).ToList();
            ListRooms();
            cboRooms.SelectedIndex = -1;
            lstServices.DataSource = db.Services.ToList();
            lstServices.SelectedIndex = -1;
            this.Width = 1051;
            lstReservationsOldServices.DataSource = reservation.ServiceDetails.Select(x => x.ServiceAndQuantity).ToList();

        }

        private void ListRooms()
        {
            cboRooms.DataSource = db.Rooms.Where(x => x.Reservations.All(r => r.CheckOutDate <= dtpCheckInDate.Value || r.CheckInDate >= dtpCheckOutDate.Value)).ToList();
        }

        private void dtpCheckInDate_ValueChanged(object sender, EventArgs e)
        {
            ListRooms();
            cboRooms.SelectedIndex = -1;
        }

        private void dtpCheckOutDate_ValueChanged(object sender, EventArgs e)
        {
            ListRooms();
            cboRooms.SelectedIndex = -1;
        }

        private void txtSearchService_TextChanged(object sender, EventArgs e)
        {
            lstServices.DataSource = db.Services.Where(x => x.ServiceName.Contains(txtSearchService.Text)).ToList();
            lstServices.SelectedIndex = -1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboRooms.SelectedIndex >= 0)
            {
                var availablecustomers = reservation.Customers.ToList();
                foreach (var item in availablecustomers)
                {
                    item.CustomerName = item.CustomerName.Replace($"({reservation.Room.RoomName})", "");
                }
                reservation.Room.Reservations.Remove(reservation);
                Room room = cboRooms.SelectedItem as Room;
                reservation.Room = room;
                reservation.RoomName = room.RoomName;

                room.Reservations.Add(reservation);
                foreach (var item in availablecustomers)
                {
                    item.CustomerName = item.CustomerName + "(" + room.RoomName + ")";
                }
                if (reservation.Customers.Count() > room.Capacity)
                {
                    MessageBox.Show($"{room.RoomName} capacity cannot be exceeded");
                    return;
                }
            }
            var availableRooms = db.Rooms.Where(x => x.Reservations.All(r => r.CheckOutDate <= dtpCheckInDate.Value || r.CheckInDate >= dtpCheckOutDate.Value)).ToList();

            DateTime dateTimeNow = DateTime.Now;

            if (cbOpenEditCheckIn.Checked == true)
            {
                if (DateTime.Compare(dateTimeNow, dtpCheckInDate.Value) > 0 || DateTime.Compare(dateTimeNow, dtpCheckOutDate.Value) > 0)
                {
                    MessageBox.Show("CheckIn Date or CheckOut Date must be to the future");
                    return;
                }
                if (DateTime.Compare(dtpCheckInDate.Value, dtpCheckOutDate.Value) == 0)
                {
                    MessageBox.Show("CheckIn Date and Check Out date cannot be equal");
                    return;
                }
                if (DateTime.Compare(dtpCheckInDate.Value, dtpCheckOutDate.Value) > 0)
                {
                    MessageBox.Show("CheckIn Date must be earlier then Check Out Date ");
                    return;
                }
                if (availableRooms.Contains(reservation.Room))
                {
                    reservation.CheckInDate = dtpCheckInDate.Value;
                    reservation.CheckOutDate = dtpCheckOutDate.Value;
                }
            }

            if (cbCheckedIn.Checked == true)
            {
                if (DateTime.Compare(dateTimeNow, dtpCheckedInTime.Value) > 0)
                {
                    MessageBox.Show("CheckIn Date or CheckOut Date must be to the future or now");
                    return;
                }
                if (cbCheckedOut.Checked == true && DateTime.Compare(dtpCheckedInTime.Value, dtpCheckedOutTime.Value) == 0)
                {
                    MessageBox.Show("CheckIn Date and Check Out date cannot be equal");
                    return;
                }
                if (cbCheckedOut.Checked == true && DateTime.Compare(dtpCheckedInTime.Value, dtpCheckedOutTime.Value) > 0)
                {
                    MessageBox.Show("CheckIn Date must be earlier then Check Out Date ");
                    return;
                }
                reservation.CheckedInDate = dtpCheckedInTime.Value;
            }
            if (cbCheckedOut.Checked == true)
            {
                if (DateTime.Compare(dateTimeNow, dtpCheckedOutTime.Value) > 0)
                {
                    MessageBox.Show("CheckOut Date must be to the future or now");
                    return;
                }
                reservation.CheckedOutDate = dtpCheckedOutTime.Value;
            }
            if (lstServices.SelectedIndex >= 0)
            {
                Service service = lstServices.SelectedItem as Service;
                ServiceDetail serviceDetail = new ServiceDetail()
                {
                    ReservationId = reservation.Id,
                    ServiceId = service.Id,
                    ServiceName = service.ServiceName,
                    UnitPrice = service.UnitPrice,
                };
                serviceDetail.Quantity = (int)nudServiceQuantity.Value;
                serviceDetail.Reservation = reservation;
                reservation.ServiceDetails.Add(serviceDetail);
                decimal roomPrice = reservation.Room.Price;

                TimeSpan rentDate = reservation.CheckOutDate.Value.Date - reservation.CheckInDate.Value.Date;
                decimal totalRoomPrice = decimal.Parse(rentDate.Days.ToString());
                decimal totalServicePrice = 0;
                foreach (var item in reservation.ServiceDetails)
                {
                    totalServicePrice += item.TotalAmount;
                }
                totalServicePrice += totalRoomPrice;
                lblTotalAmount.Text = "Services and Room Price:" + totalServicePrice + " $";  
                db.ServiceDetails.Add(serviceDetail);
            }
            db.SaveChanges();
            WhenAnReservationIsEdit(EventArgs.Empty);
            dgvReservationInfo.DataSource = db.Reservations.Where(x => x.Id == reservation.Id).ToList();
            lstReservationsOldServices.DataSource = reservation.ServiceDetails.Select(x => x.ServiceAndQuantity).ToList();
            cboRooms.SelectedIndex = -1;

        }

        private void WhenAnReservationIsEdit(EventArgs args)
        {
            if (ReservationEdited != null)
            {
                ReservationEdited(this, args);
            }
        }

        private void lstServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reservation.ServiceDetails != null)
            {
                this.Width = 1322;
            }
            TimeSpan rentDate = reservation.CheckOutDate.Value.Date - reservation.CheckInDate.Value.Date;
            decimal totalRoomPrice = decimal.Parse(rentDate.Days.ToString());
            decimal totalServicePrice = 0; foreach (var item in reservation.ServiceDetails)
            {
                totalServicePrice += item.TotalAmount;
            }
            totalServicePrice += totalRoomPrice;
            lblTotalAmount.Text = "Services and Room Price:" + totalServicePrice + " $";
        }
    }
}
