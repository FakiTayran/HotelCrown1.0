namespace HotelCrown1._0
{
    partial class EditRezervationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvReservationInfo = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboRooms = new System.Windows.Forms.ComboBox();
            this.dtpCheckedInTime = new System.Windows.Forms.DateTimePicker();
            this.dtpCheckedOutTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpCheckInDate = new System.Windows.Forms.DateTimePicker();
            this.dtpCheckOutDate = new System.Windows.Forms.DateTimePicker();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lstServices = new System.Windows.Forms.ListBox();
            this.txtSearchService = new System.Windows.Forms.TextBox();
            this.nudServiceQuantity = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbCheckedIn = new System.Windows.Forms.CheckBox();
            this.cbCheckedOut = new System.Windows.Forms.CheckBox();
            this.cbOpenEditCheckIn = new System.Windows.Forms.CheckBox();
            this.lstReservationsOldServices = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservationInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudServiceQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReservationInfo
            // 
            this.dgvReservationInfo.AllowUserToAddRows = false;
            this.dgvReservationInfo.AllowUserToDeleteRows = false;
            this.dgvReservationInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReservationInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvReservationInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservationInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgvReservationInfo.Location = new System.Drawing.Point(20, 18);
            this.dgvReservationInfo.Margin = new System.Windows.Forms.Padding(5);
            this.dgvReservationInfo.Name = "dgvReservationInfo";
            this.dgvReservationInfo.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReservationInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReservationInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservationInfo.Size = new System.Drawing.Size(1007, 79);
            this.dgvReservationInfo.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.FillWeight = 30F;
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "RoomName";
            this.Column2.FillWeight = 80F;
            this.Column2.HeaderText = "Room";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "CheckInDate";
            this.Column3.FillWeight = 120F;
            this.Column3.HeaderText = "Check-In Date";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "CheckOutDate";
            this.Column4.FillWeight = 120F;
            this.Column4.HeaderText = "Check-Out Date";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "CheckedInDate";
            this.Column5.FillWeight = 120F;
            this.Column5.HeaderText = "Checked-In Date";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "CheckedOutDate";
            this.Column6.FillWeight = 120F;
            this.Column6.HeaderText = "Checked-Out Date";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "CustomersName";
            this.Column7.FillWeight = 200F;
            this.Column7.HeaderText = "Customers";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // cboRooms
            // 
            this.cboRooms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRooms.FormattingEnabled = true;
            this.cboRooms.Location = new System.Drawing.Point(19, 143);
            this.cboRooms.Margin = new System.Windows.Forms.Padding(5);
            this.cboRooms.Name = "cboRooms";
            this.cboRooms.Size = new System.Drawing.Size(377, 28);
            this.cboRooms.TabIndex = 1;
            // 
            // dtpCheckedInTime
            // 
            this.dtpCheckedInTime.Location = new System.Drawing.Point(406, 145);
            this.dtpCheckedInTime.Margin = new System.Windows.Forms.Padding(5);
            this.dtpCheckedInTime.Name = "dtpCheckedInTime";
            this.dtpCheckedInTime.Size = new System.Drawing.Size(303, 26);
            this.dtpCheckedInTime.TabIndex = 2;
            // 
            // dtpCheckedOutTime
            // 
            this.dtpCheckedOutTime.Location = new System.Drawing.Point(719, 145);
            this.dtpCheckedOutTime.Margin = new System.Windows.Forms.Padding(5);
            this.dtpCheckedOutTime.Name = "dtpCheckedOutTime";
            this.dtpCheckedOutTime.Size = new System.Drawing.Size(305, 26);
            this.dtpCheckedOutTime.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(13, 117);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Avaiable Rooms";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(402, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Checked In Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(715, 117);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Checked Out Date";
            // 
            // dtpCheckInDate
            // 
            this.dtpCheckInDate.Location = new System.Drawing.Point(20, 207);
            this.dtpCheckInDate.Margin = new System.Windows.Forms.Padding(5);
            this.dtpCheckInDate.Name = "dtpCheckInDate";
            this.dtpCheckInDate.Size = new System.Drawing.Size(377, 26);
            this.dtpCheckInDate.TabIndex = 2;
            this.dtpCheckInDate.ValueChanged += new System.EventHandler(this.dtpCheckInDate_ValueChanged);
            // 
            // dtpCheckOutDate
            // 
            this.dtpCheckOutDate.Location = new System.Drawing.Point(20, 266);
            this.dtpCheckOutDate.Margin = new System.Windows.Forms.Padding(5);
            this.dtpCheckOutDate.Name = "dtpCheckOutDate";
            this.dtpCheckOutDate.Size = new System.Drawing.Size(377, 26);
            this.dtpCheckOutDate.TabIndex = 2;
            this.dtpCheckOutDate.ValueChanged += new System.EventHandler(this.dtpCheckOutDate_ValueChanged);
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(16, 182);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Check In Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(16, 241);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Check Out Date";
            // 
            // lstServices
            // 
            this.lstServices.FormattingEnabled = true;
            this.lstServices.ItemHeight = 20;
            this.lstServices.Location = new System.Drawing.Point(407, 208);
            this.lstServices.Name = "lstServices";
            this.lstServices.Size = new System.Drawing.Size(303, 84);
            this.lstServices.TabIndex = 4;
            this.lstServices.SelectedIndexChanged += new System.EventHandler(this.lstServices_SelectedIndexChanged);
            // 
            // txtSearchService
            // 
            this.txtSearchService.Location = new System.Drawing.Point(842, 208);
            this.txtSearchService.Name = "txtSearchService";
            this.txtSearchService.Size = new System.Drawing.Size(185, 26);
            this.txtSearchService.TabIndex = 5;
            this.txtSearchService.TextChanged += new System.EventHandler(this.txtSearchService_TextChanged);
            // 
            // nudServiceQuantity
            // 
            this.nudServiceQuantity.Location = new System.Drawing.Point(842, 262);
            this.nudServiceQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudServiceQuantity.Name = "nudServiceQuantity";
            this.nudServiceQuantity.Size = new System.Drawing.Size(185, 26);
            this.nudServiceQuantity.TabIndex = 6;
            this.nudServiceQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(716, 214);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Search Service ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label7.Location = new System.Drawing.Point(715, 264);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Service Quantity";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(22, 373);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(1005, 69);
            this.lblTotalAmount.TabIndex = 7;
            this.lblTotalAmount.Text = "0:00 $";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(16, 392);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(191, 23);
            this.label9.TabIndex = 8;
            this.label9.Text = "Total Amount";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Purple;
            this.label10.Location = new System.Drawing.Point(404, 185);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 16);
            this.label10.TabIndex = 3;
            this.label10.Text = "Services";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(21, 311);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(526, 52);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(553, 311);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(472, 52);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbCheckedIn
            // 
            this.cbCheckedIn.AutoSize = true;
            this.cbCheckedIn.Location = new System.Drawing.Point(572, 116);
            this.cbCheckedIn.Name = "cbCheckedIn";
            this.cbCheckedIn.Size = new System.Drawing.Size(135, 24);
            this.cbCheckedIn.TabIndex = 11;
            this.cbCheckedIn.Text = "Checked-In ?";
            this.cbCheckedIn.UseVisualStyleBackColor = true;
            // 
            // cbCheckedOut
            // 
            this.cbCheckedOut.AutoSize = true;
            this.cbCheckedOut.Location = new System.Drawing.Point(880, 116);
            this.cbCheckedOut.Name = "cbCheckedOut";
            this.cbCheckedOut.Size = new System.Drawing.Size(148, 24);
            this.cbCheckedOut.TabIndex = 11;
            this.cbCheckedOut.Text = "Checked-Out ?";
            this.cbCheckedOut.UseVisualStyleBackColor = true;
            // 
            // cbOpenEditCheckIn
            // 
            this.cbOpenEditCheckIn.AutoSize = true;
            this.cbOpenEditCheckIn.Location = new System.Drawing.Point(259, 182);
            this.cbOpenEditCheckIn.Name = "cbOpenEditCheckIn";
            this.cbOpenEditCheckIn.Size = new System.Drawing.Size(137, 24);
            this.cbOpenEditCheckIn.TabIndex = 12;
            this.cbOpenEditCheckIn.Text = "Edit Check-In";
            this.cbOpenEditCheckIn.UseVisualStyleBackColor = true;
            // 
            // lstReservationsOldServices
            // 
            this.lstReservationsOldServices.BackColor = System.Drawing.SystemColors.Info;
            this.lstReservationsOldServices.DisplayMember = "ServiceName";
            this.lstReservationsOldServices.ForeColor = System.Drawing.Color.Black;
            this.lstReservationsOldServices.FormattingEnabled = true;
            this.lstReservationsOldServices.ItemHeight = 20;
            this.lstReservationsOldServices.Location = new System.Drawing.Point(1035, 38);
            this.lstReservationsOldServices.Name = "lstReservationsOldServices";
            this.lstReservationsOldServices.Size = new System.Drawing.Size(258, 404);
            this.lstReservationsOldServices.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Tomato;
            this.label8.Location = new System.Drawing.Point(1035, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(167, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Purchased Services";
            // 
            // EditRezervationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 458);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lstReservationsOldServices);
            this.Controls.Add(this.cbOpenEditCheckIn);
            this.Controls.Add(this.cbCheckedOut);
            this.Controls.Add(this.cbCheckedIn);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.nudServiceQuantity);
            this.Controls.Add(this.txtSearchService);
            this.Controls.Add(this.lstServices);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpCheckOutDate);
            this.Controls.Add(this.dtpCheckedOutTime);
            this.Controls.Add(this.dtpCheckInDate);
            this.Controls.Add(this.dtpCheckedInTime);
            this.Controls.Add(this.cboRooms);
            this.Controls.Add(this.dgvReservationInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "EditRezervationForm";
            this.Text = "EditRezervationForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservationInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudServiceQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReservationInfo;
        private System.Windows.Forms.ComboBox cboRooms;
        private System.Windows.Forms.DateTimePicker dtpCheckedInTime;
        private System.Windows.Forms.DateTimePicker dtpCheckedOutTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpCheckInDate;
        private System.Windows.Forms.DateTimePicker dtpCheckOutDate;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstServices;
        private System.Windows.Forms.TextBox txtSearchService;
        private System.Windows.Forms.NumericUpDown nudServiceQuantity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.CheckBox cbCheckedIn;
        private System.Windows.Forms.CheckBox cbCheckedOut;
        private System.Windows.Forms.CheckBox cbOpenEditCheckIn;
        private System.Windows.Forms.ListBox lstReservationsOldServices;
        private System.Windows.Forms.Label label8;
    }
}