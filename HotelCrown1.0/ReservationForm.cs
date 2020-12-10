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
    public partial class ReservationForm : Form
    {
        private readonly HotelCrownContext db;
        public event EventHandler NewReservationAdded;
        public ReservationForm(HotelCrownContext db)
        {
            this.db = db;
            InitializeComponent();
            dtpCheckInDate.Format = DateTimePickerFormat.Custom;
            dtpCheckInDate.CustomFormat = "yyyy/MM/dd hh:mm:ss";
            dtpCheckOutDate.Format = DateTimePickerFormat.Custom;
            dtpCheckOutDate.CustomFormat = "yyyy/MM/dd";
            lstCustomers.DataSource = db.Customers.Where(x => x.Reservation == null).ToList();
            lstCustomers.SelectedIndex = -1;
            lstRooms.DataSource = db.Rooms.Where(x => x.Reservations.All(r => r.CheckOutDate <= dtpCheckInDate.Value || r.CheckInDate >= dtpCheckOutDate.Value)).ToList();
            lstRooms.SelectedIndex = -1;
        }

        private void btnAddReservation_Click(object sender, EventArgs e)
        {
            Customer customer = lstCustomers.SelectedItem as Customer;
            Room room = lstRooms.SelectedItem as Room;
            if (room.Customers.Count == 0)
            {
                MessageBox.Show("You dont open empty room");
                return;
            }
            if (lstRooms.SelectedIndex < 0)
            {
                MessageBox.Show("Please select the room you want to add new reservation");
                return;
            }
            DateTime dateTimeNow = DateTime.Now;
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

            var availableRooms = db.Rooms.Where(x => x.Reservations.All(r => r.CheckOutDate <= dtpCheckInDate.Value || r.CheckInDate >= dtpCheckOutDate.Value)).ToList();
            if (room.Capacity < room.Customers.Count())
            {
                MessageBox.Show("Room Capacity is full please delete customer or customers then try again");
                return;
            }
            if (customer.CustomerName.Contains(room.RoomName) == false)
            {
                MessageBox.Show($"Your customers room is not {room.RoomName}");
                return;
            }

            Reservation reservation = new Reservation();
            var s = room.Customers.ToArray();
            for (int i = 0; i < s.Length; i++)
            {
                reservation.Customers.Add(s[i]);
                s[i].Reservation = reservation; 
            }
            reservation.CheckInDate = dtpCheckInDate.Value;
            reservation.CheckOutDate = dtpCheckOutDate.Value;
            reservation.RoomName = room.RoomName;
            room.Reservations.Add(reservation);
            if (availableRooms.Contains(room))
            {
                db.Reservations.Add(reservation);
                room.Customers.Clear();
                db.SaveChanges();
                WhenANewReservationIsAdded(EventArgs.Empty);
                int selectedIndexCustomer = lstCustomers.SelectedIndex;
                int selectedIndexRoom = lstRooms.SelectedIndex;
                lstCustomers.DataSource = db.Customers.Where(x => x.Reservation == null).ToList();
                lstRooms.DataSource = availableRooms;
                lstRooms.SelectedIndex = selectedIndexRoom;
                if (lstCustomers.Items.Count > selectedIndexCustomer)
                {
                    lstCustomers.SelectedIndex = selectedIndexCustomer;
                }
            }
            else
            {
                room.Reservations.Remove(reservation);
                MessageBox.Show("This Room is full at this dates");
                return;
            }
            MessageBox.Show("Reservation Created");
            lstRooms.DataSource = db.Rooms.Where(x => x.Reservations.All(r => r.CheckOutDate <= dtpCheckInDate.Value || r.CheckInDate >= dtpCheckOutDate.Value)).ToList();
        }

        private void WhenANewReservationIsAdded(EventArgs args)
        {
            if (NewReservationAdded != null)
            {
                NewReservationAdded(this, args);
            }
        }

        private void AddCustomerToRoom_Click(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedIndex < 0 || lstRooms.SelectedIndex < 0)
            {
                MessageBox.Show("You have to select both,Customer and Room");
                return;
            }
            Customer customer = lstCustomers.SelectedItem as Customer;
            Room room = lstRooms.SelectedItem as Room;
            if (room.Customers.Contains(customer))
            {
                MessageBox.Show("Selected customer allready in this room");
                return;
            }
            var availableRooms = db.Rooms.Where(x => x.Reservations.All(r => r.CheckOutDate <= dtpCheckInDate.Value || r.CheckInDate >= dtpCheckOutDate.Value)).ToList();
            if (room.Capacity <= room.Customers.Count())
            {
                MessageBox.Show("Capacity full");
                return;
            }
            if (availableRooms.Contains(room) == false)
            {
                MessageBox.Show("If you want to add new customer to room please do this in reservationedit screen");
                return;
            }
            
            int selectedIndexCustomer = lstCustomers.SelectedIndex;
            int selectedIndexRoom = lstRooms.SelectedIndex;
            if (customer.Room == null)
            {
                customer.Room = room;
            }
            else
            {
                MessageBox.Show("This customer allready has a room");
                return;
            }
            room.Customers.Add(customer);
            if (availableRooms.Where(x=>x.Customers.Count() != 0).Count() > 1 )
            {
                MessageBox.Show("When you have a choosen room allready,you cannot choose another room for another customer");
                customer.Room = null;
                room.Customers.Remove(customer);
                return;
            }
            MessageBox.Show(customer + " added to " + room.RoomName);
            customer.CustomerName = customer.CustomerName + "(" + room.RoomName + ")";
            lstCustomers.DataSource = db.Customers.Where(x => x.Reservation == null).ToList();
            lstRooms.SelectedIndex = selectedIndexRoom;
            lstCustomers.SelectedIndex = selectedIndexCustomer;
        }

        private void DeleteCustomerToRoom_Click(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedIndex < 0 || lstRooms.SelectedIndex < 0)
            {
                MessageBox.Show("You have to select both,Customer and Room");
                return;
            }
            int selectedIndexCustomer = lstCustomers.SelectedIndex;
            int selectedIndexRoom = lstRooms.SelectedIndex;
            Customer customer = lstCustomers.SelectedItem as Customer;
            Room room = lstRooms.SelectedItem as Room;
            var availableRooms = db.Rooms.Where(x => x.Reservations.All(r => r.CheckOutDate <= dtpCheckInDate.Value || r.CheckInDate >= dtpCheckOutDate.Value)).ToList();
            if (availableRooms.Contains(room) == false)
            {
                if (room.Customers.Contains(customer) == false)
                {
                    MessageBox.Show("This customer is not already in the selected room");
                    return;
                }
                else if (customer.Room.Reservations.Count() != 0)
                {
                    MessageBox.Show("If you want do delete customer from room please do this from edit reservation screen");
                    return;
                }
            }
            else
            {
                if (customer.CustomerName.Contains(room.RoomName) && customer.Room.Reservations.Count() == 0)
                {
                    customer.CustomerName = customer.CustomerName.Replace($"({room.RoomName})", "");
                }
            }
            if (room.Customers.Contains(customer))
            {
                room.Customers.Remove(customer);
                customer.Room = null;
                customer.CustomerName = customer.CustomerName.Replace($"({room.RoomName})", "");
                if (availableRooms.Contains(room) == false && room.Customers.Count == 0)
                {
                    customer.CustomerName = customer.CustomerName.Replace($"({room.RoomName})", "");
                }
                if (room.Customers.Count > 0)
                {
                    customer.CustomerName = customer.CustomerName.Replace($"({room.RoomName})", "");
                }

                MessageBox.Show(customer + " deleted from " + room.RoomName);
                lstCustomers.DataSource = db.Customers.Where(x => x.Reservation == null).ToList();

            }
            else
            {

                MessageBox.Show("This customer is not already in the selected room");
                return;
            }

            lstRooms.SelectedIndex = selectedIndexRoom;
            lstCustomers.SelectedIndex = selectedIndexCustomer;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lstCustomers.DataSource = db.Customers.Where(x => x.IdentityNumber.Contains(textBox1.Text)).ToList();
        }

        private void dtpCheckInDate_ValueChanged(object sender, EventArgs e)
        {
            ListAvailableRooms();
        }

        private void dtpCheckOutDate_ValueChanged(object sender, EventArgs e)
        {
            ListAvailableRooms();

        }

        private void ListAvailableRooms()
        {
            var availableRooms = db.Rooms.Where(x => x.Reservations.All(r => r.CheckOutDate <= dtpCheckInDate.Value || r.CheckInDate >= dtpCheckOutDate.Value)).ToList();
            lstRooms.DataSource = availableRooms;
        }
    }
}
