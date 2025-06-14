namespace Course
{
    partial class AddDemandForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            checkedListHouseTypes = new CheckedListBox();
            txtDistricts = new TextBox();
            checkedListFlatTypes = new CheckedListBox();
            txtMinPrice = new TextBox();
            txtMaxPrice = new TextBox();
            txtName = new TextBox();
            txtPhone = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(124, 15);
            label1.TabIndex = 0;
            label1.Text = "Райони (через кому):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 54);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 1;
            label2.Text = "Тип будинку:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 152);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 2;
            label3.Text = "Тип квартири:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 256);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 3;
            label4.Text = "Мінімальна ціна:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 298);
            label5.Name = "label5";
            label5.Size = new Size(113, 15);
            label5.TabIndex = 4;
            label5.Text = "Максимальна ціна:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 340);
            label6.Name = "label6";
            label6.Size = new Size(80, 15);
            label6.TabIndex = 5;
            label6.Text = "Ім’я покупця:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 379);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 6;
            label7.Text = "Телефон:";
            // 
            // checkedListHouseTypes
            // 
            checkedListHouseTypes.FormattingEnabled = true;
            checkedListHouseTypes.Items.AddRange(new object[] { "Цегляний", "Панельний", "Моноліт" });
            checkedListHouseTypes.Location = new Point(140, 54);
            checkedListHouseTypes.Name = "checkedListHouseTypes";
            checkedListHouseTypes.Size = new Size(173, 76);
            checkedListHouseTypes.TabIndex = 7;
            // 
            // txtDistricts
            // 
            txtDistricts.Location = new Point(140, 17);
            txtDistricts.Name = "txtDistricts";
            txtDistricts.Size = new Size(173, 23);
            txtDistricts.TabIndex = 8;
            // 
            // checkedListFlatTypes
            // 
            checkedListFlatTypes.FormattingEnabled = true;
            checkedListFlatTypes.Items.AddRange(new object[] { "1-кімнатна", " 2-кімнатна", " 3-кімнатна", " 4-кімнатна", "Студія" });
            checkedListFlatTypes.Location = new Point(140, 152);
            checkedListFlatTypes.Name = "checkedListFlatTypes";
            checkedListFlatTypes.Size = new Size(173, 94);
            checkedListFlatTypes.TabIndex = 9;
            // 
            // txtMinPrice
            // 
            txtMinPrice.Location = new Point(140, 256);
            txtMinPrice.Name = "txtMinPrice";
            txtMinPrice.Size = new Size(173, 23);
            txtMinPrice.TabIndex = 10;
            // 
            // txtMaxPrice
            // 
            txtMaxPrice.Location = new Point(140, 295);
            txtMaxPrice.Name = "txtMaxPrice";
            txtMaxPrice.Size = new Size(173, 23);
            txtMaxPrice.TabIndex = 11;
            // 
            // txtName
            // 
            txtName.Location = new Point(140, 337);
            txtName.Name = "txtName";
            txtName.Size = new Size(173, 23);
            txtName.TabIndex = 12;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(140, 376);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(173, 23);
            txtPhone.TabIndex = 13;
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.LightGreen;
            btnOK.Location = new Point(29, 424);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(107, 23);
            btnOK.TabIndex = 14;
            btnOK.Text = "Зберегти";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.Location = new Point(172, 424);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(108, 23);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Відмінити";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddDemandForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(335, 508);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            Controls.Add(txtMaxPrice);
            Controls.Add(txtMinPrice);
            Controls.Add(checkedListFlatTypes);
            Controls.Add(txtDistricts);
            Controls.Add(checkedListHouseTypes);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddDemandForm";
            Text = "Формування попиту.";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private CheckedListBox checkedListHouseTypes;
        private TextBox txtDistricts;
        private CheckedListBox checkedListFlatTypes;
        private TextBox txtMinPrice;
        private TextBox txtMaxPrice;
        private TextBox txtName;
        private TextBox txtPhone;
        private Button btnOK;
        private Button btnCancel;
    }
}