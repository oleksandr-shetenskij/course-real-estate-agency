namespace Course
{
    partial class AddOfferForm
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
            txtDistrict = new TextBox();
            txtAddress = new TextBox();
            txtPrice = new TextBox();
            txtOwner = new TextBox();
            txtPhone = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            btnLoadPhoto = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            comboBoxHouseDesc = new ComboBox();
            comboBoxFlatDesc = new ComboBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnClearPhotos = new Button();
            SuspendLayout();
            // 
            // txtDistrict
            // 
            txtDistrict.Location = new Point(144, 23);
            txtDistrict.Name = "txtDistrict";
            txtDistrict.Size = new Size(121, 23);
            txtDistrict.TabIndex = 0;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(144, 63);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(121, 23);
            txtAddress.TabIndex = 1;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(144, 188);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(121, 23);
            txtPrice.TabIndex = 4;
            // 
            // txtOwner
            // 
            txtOwner.Location = new Point(144, 230);
            txtOwner.Name = "txtOwner";
            txtOwner.Size = new Size(121, 23);
            txtOwner.TabIndex = 5;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(144, 268);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(121, 23);
            txtPhone.TabIndex = 6;
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.LightGreen;
            btnOK.Location = new Point(12, 415);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(109, 23);
            btnOK.TabIndex = 7;
            btnOK.Text = "Зберегти";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.Location = new Point(156, 415);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(109, 23);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Відмінити";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnLoadPhoto
            // 
            btnLoadPhoto.Location = new Point(334, 287);
            btnLoadPhoto.Name = "btnLoadPhoto";
            btnLoadPhoto.Size = new Size(140, 23);
            btnLoadPhoto.TabIndex = 9;
            btnLoadPhoto.Text = "Завантажити фото";
            btnLoadPhoto.UseVisualStyleBackColor = true;
            btnLoadPhoto.Click += btnLoadPhoto_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 26);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 11;
            label1.Text = "Район:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 66);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 12;
            label2.Text = "Адреса:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 107);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 13;
            label3.Text = "Опис будинку:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 149);
            label4.Name = "label4";
            label4.Size = new Size(93, 15);
            label4.TabIndex = 14;
            label4.Text = "Опис квартири:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 191);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 15;
            label5.Text = "Ціна:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 233);
            label6.Name = "label6";
            label6.Size = new Size(85, 15);
            label6.TabIndex = 16;
            label6.Text = "Ім`я власника:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(22, 271);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 17;
            label7.Text = "Телефон:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(334, 26);
            label8.Name = "label8";
            label8.Size = new Size(92, 15);
            label8.TabIndex = 18;
            label8.Text = "Фото квартири:";
            // 
            // comboBoxHouseDesc
            // 
            comboBoxHouseDesc.FormattingEnabled = true;
            comboBoxHouseDesc.Items.AddRange(new object[] { "Цегляний", "Панельний", "Моноліт" });
            comboBoxHouseDesc.Location = new Point(144, 104);
            comboBoxHouseDesc.Name = "comboBoxHouseDesc";
            comboBoxHouseDesc.Size = new Size(121, 23);
            comboBoxHouseDesc.TabIndex = 19;
            // 
            // comboBoxFlatDesc
            // 
            comboBoxFlatDesc.FormattingEnabled = true;
            comboBoxFlatDesc.Items.AddRange(new object[] { "1-кімнатна", " 2-кімнатна", " 3-кімнатна", " 4-кімнатна", "Студія" });
            comboBoxFlatDesc.Location = new Point(144, 149);
            comboBoxFlatDesc.Name = "comboBoxFlatDesc";
            comboBoxFlatDesc.Size = new Size(121, 23);
            comboBoxFlatDesc.TabIndex = 20;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = SystemColors.ControlLight;
            flowLayoutPanel1.Location = new Point(334, 44);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(443, 222);
            flowLayoutPanel1.TabIndex = 21;
            // 
            // btnClearPhotos
            // 
            btnClearPhotos.Location = new Point(702, 287);
            btnClearPhotos.Name = "btnClearPhotos";
            btnClearPhotos.Size = new Size(75, 23);
            btnClearPhotos.TabIndex = 22;
            btnClearPhotos.Text = "Очистити";
            btnClearPhotos.UseVisualStyleBackColor = true;
            btnClearPhotos.Click += btnClearPhotos_Click;
            // 
            // AddOfferForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClearPhotos);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(comboBoxFlatDesc);
            Controls.Add(comboBoxHouseDesc);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLoadPhoto);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtPhone);
            Controls.Add(txtOwner);
            Controls.Add(txtPrice);
            Controls.Add(txtAddress);
            Controls.Add(txtDistrict);
            Name = "AddOfferForm";
            Text = "Формування пропозиції.";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDistrict;
        private TextBox txtAddress;
        private TextBox txtPrice;
        private TextBox txtOwner;
        private TextBox txtPhone;
        private Button btnOK;
        private Button btnCancel;
        private Button btnLoadPhoto;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private ComboBox comboBoxHouseDesc;
        private ComboBox comboBoxFlatDesc;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnClearPhotos;
    }
}