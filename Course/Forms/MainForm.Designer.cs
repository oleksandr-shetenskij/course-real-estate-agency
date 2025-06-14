namespace Course
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnSaveSearchResults1 = new Button();
            btnSearchOffers = new Button();
            txtSearchOffers = new TextBox();
            btnViewPhoto = new Button();
            btnClearOffersSearch = new Button();
            btnDeleteOffer = new Button();
            btnEditOffer = new Button();
            btnAddOffer = new Button();
            dataGridViewOffers = new DataGridView();
            tabPage2 = new TabPage();
            btnSearchDemands = new Button();
            txtSearchDemands = new TextBox();
            btnClearDemandsSearch = new Button();
            btnDeleteDemand = new Button();
            btnEditDemand = new Button();
            btnAddDemand = new Button();
            dataGridViewDemands = new DataGridView();
            tabPage3 = new TabPage();
            btnExportMatches = new Button();
            btnViewMatch = new Button();
            btnMatch = new Button();
            dataGridMatches = new DataGridView();
            btnSaveDemandSearchResults = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOffers).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDemands).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridMatches).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(940, 499);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnSaveSearchResults1);
            tabPage1.Controls.Add(btnSearchOffers);
            tabPage1.Controls.Add(txtSearchOffers);
            tabPage1.Controls.Add(btnViewPhoto);
            tabPage1.Controls.Add(btnClearOffersSearch);
            tabPage1.Controls.Add(btnDeleteOffer);
            tabPage1.Controls.Add(btnEditOffer);
            tabPage1.Controls.Add(btnAddOffer);
            tabPage1.Controls.Add(dataGridViewOffers);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(932, 471);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Пропозиції";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSaveSearchResults1
            // 
            btnSaveSearchResults1.Location = new Point(841, 388);
            btnSaveSearchResults1.Name = "btnSaveSearchResults1";
            btnSaveSearchResults1.Size = new Size(75, 23);
            btnSaveSearchResults1.TabIndex = 8;
            btnSaveSearchResults1.Text = "Зберегти";
            btnSaveSearchResults1.UseVisualStyleBackColor = true;
            btnSaveSearchResults1.Click += btnSaveSearchResults1_Click;
            // 
            // btnSearchOffers
            // 
            btnSearchOffers.Location = new Point(695, 388);
            btnSearchOffers.Name = "btnSearchOffers";
            btnSearchOffers.Size = new Size(140, 23);
            btnSearchOffers.TabIndex = 7;
            btnSearchOffers.Text = "Пошук";
            btnSearchOffers.UseVisualStyleBackColor = true;
            btnSearchOffers.Click += btnSearchOffers_Click;
            // 
            // txtSearchOffers
            // 
            txtSearchOffers.Location = new Point(111, 388);
            txtSearchOffers.Name = "txtSearchOffers";
            txtSearchOffers.Size = new Size(578, 23);
            txtSearchOffers.TabIndex = 6;
            // 
            // btnViewPhoto
            // 
            btnViewPhoto.Location = new Point(549, 432);
            btnViewPhoto.Name = "btnViewPhoto";
            btnViewPhoto.Size = new Size(140, 23);
            btnViewPhoto.TabIndex = 5;
            btnViewPhoto.Text = "Переглянути фото";
            btnViewPhoto.UseVisualStyleBackColor = true;
            btnViewPhoto.Click += btnViewPhoto_Click;
            // 
            // btnClearOffersSearch
            // 
            btnClearOffersSearch.Location = new Point(695, 432);
            btnClearOffersSearch.Name = "btnClearOffersSearch";
            btnClearOffersSearch.Size = new Size(140, 23);
            btnClearOffersSearch.TabIndex = 4;
            btnClearOffersSearch.Text = "Очистити пошук";
            btnClearOffersSearch.UseVisualStyleBackColor = true;
            btnClearOffersSearch.Click += btnClearOffersSearch_Click;
            // 
            // btnDeleteOffer
            // 
            btnDeleteOffer.Location = new Point(403, 432);
            btnDeleteOffer.Name = "btnDeleteOffer";
            btnDeleteOffer.Size = new Size(140, 23);
            btnDeleteOffer.TabIndex = 3;
            btnDeleteOffer.Text = "Видалити";
            btnDeleteOffer.UseVisualStyleBackColor = true;
            btnDeleteOffer.Click += btnDeleteOffer_Click;
            // 
            // btnEditOffer
            // 
            btnEditOffer.Location = new Point(257, 432);
            btnEditOffer.Name = "btnEditOffer";
            btnEditOffer.Size = new Size(140, 23);
            btnEditOffer.TabIndex = 2;
            btnEditOffer.Text = "Редагувати";
            btnEditOffer.UseVisualStyleBackColor = true;
            btnEditOffer.Click += btnEditOffer_Click;
            // 
            // btnAddOffer
            // 
            btnAddOffer.Location = new Point(111, 432);
            btnAddOffer.Name = "btnAddOffer";
            btnAddOffer.Size = new Size(140, 23);
            btnAddOffer.TabIndex = 1;
            btnAddOffer.Text = "Додати";
            btnAddOffer.UseVisualStyleBackColor = true;
            btnAddOffer.Click += btnAddOffer_Click;
            // 
            // dataGridViewOffers
            // 
            dataGridViewOffers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOffers.Location = new Point(0, 0);
            dataGridViewOffers.Name = "dataGridViewOffers";
            dataGridViewOffers.Size = new Size(932, 370);
            dataGridViewOffers.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnSaveDemandSearchResults);
            tabPage2.Controls.Add(btnSearchDemands);
            tabPage2.Controls.Add(txtSearchDemands);
            tabPage2.Controls.Add(btnClearDemandsSearch);
            tabPage2.Controls.Add(btnDeleteDemand);
            tabPage2.Controls.Add(btnEditDemand);
            tabPage2.Controls.Add(btnAddDemand);
            tabPage2.Controls.Add(dataGridViewDemands);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(932, 471);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Попит";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSearchDemands
            // 
            btnSearchDemands.Location = new Point(612, 388);
            btnSearchDemands.Name = "btnSearchDemands";
            btnSearchDemands.Size = new Size(113, 23);
            btnSearchDemands.TabIndex = 10;
            btnSearchDemands.Text = "Пошук";
            btnSearchDemands.UseVisualStyleBackColor = true;
            btnSearchDemands.Click += btnSearchDemands_Click;
            // 
            // txtSearchDemands
            // 
            txtSearchDemands.Location = new Point(255, 388);
            txtSearchDemands.Name = "txtSearchDemands";
            txtSearchDemands.Size = new Size(351, 23);
            txtSearchDemands.TabIndex = 9;
            // 
            // btnClearDemandsSearch
            // 
            btnClearDemandsSearch.Location = new Point(612, 433);
            btnClearDemandsSearch.Name = "btnClearDemandsSearch";
            btnClearDemandsSearch.Size = new Size(113, 23);
            btnClearDemandsSearch.TabIndex = 4;
            btnClearDemandsSearch.Text = "Очистити пошук";
            btnClearDemandsSearch.UseVisualStyleBackColor = true;
            btnClearDemandsSearch.Click += btnClearDemandsSearch_Click;
            // 
            // btnDeleteDemand
            // 
            btnDeleteDemand.Location = new Point(493, 433);
            btnDeleteDemand.Name = "btnDeleteDemand";
            btnDeleteDemand.Size = new Size(113, 23);
            btnDeleteDemand.TabIndex = 3;
            btnDeleteDemand.Text = "Видалити";
            btnDeleteDemand.UseVisualStyleBackColor = true;
            btnDeleteDemand.Click += btnDeleteDemand_Click;
            // 
            // btnEditDemand
            // 
            btnEditDemand.Location = new Point(374, 433);
            btnEditDemand.Name = "btnEditDemand";
            btnEditDemand.Size = new Size(113, 23);
            btnEditDemand.TabIndex = 2;
            btnEditDemand.Text = "Редагувати";
            btnEditDemand.UseVisualStyleBackColor = true;
            btnEditDemand.Click += btnEditDemand_Click_1;
            // 
            // btnAddDemand
            // 
            btnAddDemand.Location = new Point(255, 433);
            btnAddDemand.Name = "btnAddDemand";
            btnAddDemand.Size = new Size(113, 23);
            btnAddDemand.TabIndex = 1;
            btnAddDemand.Text = "Додати";
            btnAddDemand.UseVisualStyleBackColor = true;
            btnAddDemand.Click += btnAddDemand_Click;
            // 
            // dataGridViewDemands
            // 
            dataGridViewDemands.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDemands.Location = new Point(0, 0);
            dataGridViewDemands.Name = "dataGridViewDemands";
            dataGridViewDemands.Size = new Size(932, 370);
            dataGridViewDemands.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnExportMatches);
            tabPage3.Controls.Add(btnViewMatch);
            tabPage3.Controls.Add(btnMatch);
            tabPage3.Controls.Add(dataGridMatches);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(932, 471);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Підбір";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnExportMatches
            // 
            btnExportMatches.Location = new Point(608, 427);
            btnExportMatches.Name = "btnExportMatches";
            btnExportMatches.Size = new Size(185, 23);
            btnExportMatches.TabIndex = 3;
            btnExportMatches.Text = "Експортувати результат";
            btnExportMatches.UseVisualStyleBackColor = true;
            btnExportMatches.Click += btnExportMatches_Click;
            // 
            // btnViewMatch
            // 
            btnViewMatch.Location = new Point(383, 427);
            btnViewMatch.Name = "btnViewMatch";
            btnViewMatch.Size = new Size(204, 23);
            btnViewMatch.TabIndex = 2;
            btnViewMatch.Text = "Переглянути відповідність";
            btnViewMatch.UseVisualStyleBackColor = true;
            btnViewMatch.Click += btnViewMatch_Click;
            // 
            // btnMatch
            // 
            btnMatch.Location = new Point(160, 427);
            btnMatch.Name = "btnMatch";
            btnMatch.Size = new Size(204, 23);
            btnMatch.TabIndex = 1;
            btnMatch.Text = "Підібрати варіанти";
            btnMatch.UseVisualStyleBackColor = true;
            btnMatch.Click += btnMatch_Click;
            // 
            // dataGridMatches
            // 
            dataGridMatches.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridMatches.Location = new Point(0, 0);
            dataGridMatches.Name = "dataGridMatches";
            dataGridMatches.Size = new Size(932, 370);
            dataGridMatches.TabIndex = 0;
            // 
            // btnSaveDemandSearchResults
            // 
            btnSaveDemandSearchResults.Location = new Point(731, 388);
            btnSaveDemandSearchResults.Name = "btnSaveDemandSearchResults";
            btnSaveDemandSearchResults.Size = new Size(75, 23);
            btnSaveDemandSearchResults.TabIndex = 11;
            btnSaveDemandSearchResults.Text = "Зберегти";
            btnSaveDemandSearchResults.UseVisualStyleBackColor = true;
            btnSaveDemandSearchResults.Click += btnSaveDemandSearchResults_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 523);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Помічник ріелтора.";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOffers).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDemands).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridMatches).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dataGridViewOffers;
        private DataGridView dataGridViewDemands;
        private TabPage tabPage3;
        private DataGridView dataGridMatches;
        private Button btnViewPhoto;
        private Button btnClearOffersSearch;
        private Button btnDeleteOffer;
        private Button btnEditOffer;
        private Button btnAddOffer;
        private Button btnClearDemandsSearch;
        private Button btnDeleteDemand;
        private Button btnEditDemand;
        private Button btnAddDemand;
        private Button btnExportMatches;
        private Button btnViewMatch;
        private Button btnMatch;
        private Button btnSearchOffers;
        private TextBox txtSearchOffers;
        private Button btnSearchDemands;
        private TextBox txtSearchDemands;
        private Button btnSaveSearchResults1;
        private Button btnSaveDemandSearchResults;
    }
}
