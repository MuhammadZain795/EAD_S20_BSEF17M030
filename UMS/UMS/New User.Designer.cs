namespace UMS
{
    partial class New_User
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
            this.nameText = new System.Windows.Forms.TextBox();
            this.loginText = new System.Windows.Forms.TextBox();
            this.passText = new System.Windows.Forms.TextBox();
            this.emailText = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.Label();
            this.pass = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.Label();
            this.gender = new System.Windows.Forms.Label();
            this.genderBox = new System.Windows.Forms.ComboBox();
            this.address = new System.Windows.Forms.Label();
            this.age = new System.Windows.Forms.Label();
            this.ageCount = new System.Windows.Forms.NumericUpDown();
            this.nic = new System.Windows.Forms.Label();
            this.nicBox = new System.Windows.Forms.MaskedTextBox();
            this.dob = new System.Windows.Forms.Label();
            this.dobPicker = new System.Windows.Forms.DateTimePicker();
            this.sports = new System.Windows.Forms.Label();
            this.cricket = new System.Windows.Forms.CheckBox();
            this.chess = new System.Windows.Forms.CheckBox();
            this.hockey = new System.Windows.Forms.CheckBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.uploadFile = new System.Windows.Forms.OpenFileDialog();
            this.addressBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ageCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(248, 32);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(180, 26);
            this.nameText.TabIndex = 0;
            this.nameText.TextChanged += new System.EventHandler(this.nameText_TextChanged);
            this.nameText.Validating += new System.ComponentModel.CancelEventHandler(this.nameVal);
            // 
            // loginText
            // 
            this.loginText.Location = new System.Drawing.Point(248, 73);
            this.loginText.Name = "loginText";
            this.loginText.Size = new System.Drawing.Size(180, 26);
            this.loginText.TabIndex = 1;
            this.loginText.TextChanged += new System.EventHandler(this.loginText_TextChanged);
            // 
            // passText
            // 
            this.passText.Location = new System.Drawing.Point(248, 117);
            this.passText.Name = "passText";
            this.passText.Size = new System.Drawing.Size(180, 26);
            this.passText.TabIndex = 2;
            this.passText.TextChanged += new System.EventHandler(this.passText_TextChanged);
            // 
            // emailText
            // 
            this.emailText.Location = new System.Drawing.Point(248, 161);
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(180, 26);
            this.emailText.TabIndex = 3;
            this.emailText.TextChanged += new System.EventHandler(this.emailText_TextChanged);
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(149, 32);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(51, 20);
            this.name.TabIndex = 4;
            this.name.Text = "Name";
            // 
            // login
            // 
            this.login.AutoSize = true;
            this.login.Location = new System.Drawing.Point(149, 79);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(48, 20);
            this.login.TabIndex = 5;
            this.login.Text = "Login";
            // 
            // pass
            // 
            this.pass.AutoSize = true;
            this.pass.Location = new System.Drawing.Point(149, 123);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(78, 20);
            this.pass.TabIndex = 6;
            this.pass.Text = "Password";
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.Location = new System.Drawing.Point(149, 167);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(48, 20);
            this.email.TabIndex = 7;
            this.email.Text = "Email";
            // 
            // gender
            // 
            this.gender.AutoSize = true;
            this.gender.Location = new System.Drawing.Point(149, 207);
            this.gender.Name = "gender";
            this.gender.Size = new System.Drawing.Size(63, 20);
            this.gender.TabIndex = 8;
            this.gender.Text = "Gender";
            // 
            // genderBox
            // 
            this.genderBox.FormattingEnabled = true;
            this.genderBox.Location = new System.Drawing.Point(248, 207);
            this.genderBox.Name = "genderBox";
            this.genderBox.Size = new System.Drawing.Size(180, 28);
            this.genderBox.TabIndex = 9;
            // 
            // address
            // 
            this.address.AutoSize = true;
            this.address.Location = new System.Drawing.Point(153, 272);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(68, 20);
            this.address.TabIndex = 12;
            this.address.Text = "Address";
            // 
            // age
            // 
            this.age.AutoSize = true;
            this.age.Location = new System.Drawing.Point(153, 366);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(38, 20);
            this.age.TabIndex = 13;
            this.age.Text = "Age";
            // 
            // ageCount
            // 
            this.ageCount.Location = new System.Drawing.Point(248, 366);
            this.ageCount.Name = "ageCount";
            this.ageCount.Size = new System.Drawing.Size(184, 26);
            this.ageCount.TabIndex = 14;
            // 
            // nic
            // 
            this.nic.AutoSize = true;
            this.nic.Location = new System.Drawing.Point(153, 413);
            this.nic.Name = "nic";
            this.nic.Size = new System.Drawing.Size(44, 20);
            this.nic.TabIndex = 15;
            this.nic.Text = "N.I.C";
            // 
            // nicBox
            // 
            this.nicBox.Location = new System.Drawing.Point(248, 413);
            this.nicBox.Mask = "00000-0000000-0";
            this.nicBox.Name = "nicBox";
            this.nicBox.Size = new System.Drawing.Size(184, 26);
            this.nicBox.TabIndex = 16;
            // 
            // dob
            // 
            this.dob.AutoSize = true;
            this.dob.Location = new System.Drawing.Point(149, 474);
            this.dob.Name = "dob";
            this.dob.Size = new System.Drawing.Size(52, 20);
            this.dob.TabIndex = 17;
            this.dob.Text = "D.O.B";
            // 
            // dobPicker
            // 
            this.dobPicker.Location = new System.Drawing.Point(248, 474);
            this.dobPicker.Name = "dobPicker";
            this.dobPicker.Size = new System.Drawing.Size(200, 26);
            this.dobPicker.TabIndex = 18;
            // 
            // sports
            // 
            this.sports.AutoSize = true;
            this.sports.Location = new System.Drawing.Point(144, 538);
            this.sports.Name = "sports";
            this.sports.Size = new System.Drawing.Size(56, 20);
            this.sports.TabIndex = 22;
            this.sports.Text = "Sports";
            // 
            // cricket
            // 
            this.cricket.AutoSize = true;
            this.cricket.Location = new System.Drawing.Point(248, 533);
            this.cricket.Name = "cricket";
            this.cricket.Size = new System.Drawing.Size(84, 24);
            this.cricket.TabIndex = 23;
            this.cricket.Text = "Cricket";
            this.cricket.UseVisualStyleBackColor = true;
            // 
            // chess
            // 
            this.chess.AutoSize = true;
            this.chess.Location = new System.Drawing.Point(481, 533);
            this.chess.Name = "chess";
            this.chess.Size = new System.Drawing.Size(80, 24);
            this.chess.TabIndex = 24;
            this.chess.Text = "Chess";
            this.chess.UseVisualStyleBackColor = true;
            // 
            // hockey
            // 
            this.hockey.AutoSize = true;
            this.hockey.Location = new System.Drawing.Point(360, 533);
            this.hockey.Name = "hockey";
            this.hockey.Size = new System.Drawing.Size(88, 24);
            this.hockey.TabIndex = 25;
            this.hockey.Text = "Hockey";
            this.hockey.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(346, 615);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 31);
            this.btnCreate.TabIndex = 26;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(481, 615);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(764, 244);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 33);
            this.btnUpload.TabIndex = 28;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(714, 33);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(168, 172);
            this.pictureBox.TabIndex = 29;
            this.pictureBox.TabStop = false;
            // 
            // uploadFile
            // 
            this.uploadFile.FileName = "uploadFile";
            // 
            // addressBox
            // 
            this.addressBox.Location = new System.Drawing.Point(248, 272);
            this.addressBox.Multiline = true;
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(180, 70);
            this.addressBox.TabIndex = 30;
            // 
            // New_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 686);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.hockey);
            this.Controls.Add(this.chess);
            this.Controls.Add(this.cricket);
            this.Controls.Add(this.sports);
            this.Controls.Add(this.dobPicker);
            this.Controls.Add(this.dob);
            this.Controls.Add(this.nicBox);
            this.Controls.Add(this.nic);
            this.Controls.Add(this.ageCount);
            this.Controls.Add(this.age);
            this.Controls.Add(this.address);
            this.Controls.Add(this.genderBox);
            this.Controls.Add(this.gender);
            this.Controls.Add(this.email);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.login);
            this.Controls.Add(this.name);
            this.Controls.Add(this.emailText);
            this.Controls.Add(this.passText);
            this.Controls.Add(this.loginText);
            this.Controls.Add(this.nameText);
            this.Name = "New_User";
            this.Text = "New_User";
            this.Load += new System.EventHandler(this.New_User_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ageCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.TextBox loginText;
        private System.Windows.Forms.TextBox passText;
        private System.Windows.Forms.TextBox emailText;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label login;
        private System.Windows.Forms.Label pass;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.Label gender;
        private System.Windows.Forms.ComboBox genderBox;
        private System.Windows.Forms.Label address;
        private System.Windows.Forms.Label age;
        private System.Windows.Forms.NumericUpDown ageCount;
        private System.Windows.Forms.Label nic;
        private System.Windows.Forms.MaskedTextBox nicBox;
        private System.Windows.Forms.Label dob;
        private System.Windows.Forms.DateTimePicker dobPicker;
        private System.Windows.Forms.Label sports;
        private System.Windows.Forms.CheckBox cricket;
        private System.Windows.Forms.CheckBox chess;
        private System.Windows.Forms.CheckBox hockey;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.OpenFileDialog uploadFile;
        private System.Windows.Forms.TextBox addressBox;
    }
}