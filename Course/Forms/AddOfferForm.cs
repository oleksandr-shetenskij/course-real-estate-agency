using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Course.Models;

namespace Course
{
    public partial class AddOfferForm : Form
    {
        public Apartment Apartment { get; private set; }

        private List<Image> selectedPhotos = new(); // список обраних фото

        public AddOfferForm()
        {
            InitializeComponent();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                // Перевірка обраних значень
                if (comboBoxHouseDesc.SelectedItem == null || comboBoxFlatDesc.SelectedItem == null)
                {
                    MessageBox.Show("Будь ласка, виберіть тип будинку і квартири.");
                    return;
                }

                // Перевірка числового значення ціни
                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    MessageBox.Show("Ціна має бути числом.");
                    return;
                }

                if (price < 0)
                {
                    MessageBox.Show("Ціна не може бути від’ємною.");
                    return;
                }

                Apartment = new Apartment(
                    txtDistrict.Text,
                    txtAddress.Text,
                    comboBoxHouseDesc.SelectedItem.ToString(),
                    comboBoxFlatDesc.SelectedItem.ToString(),
                    price,
                    txtOwner.Text,
                    txtPhone.Text,
                    new List<Image>(selectedPhotos)
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка введення: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public AddOfferForm(Apartment existing)
        {
            InitializeComponent();

            txtDistrict.Text = existing.District;
            txtAddress.Text = existing.Address;
            comboBoxHouseDesc.SelectedItem = existing.HouseDescription;
            comboBoxFlatDesc.SelectedItem = existing.FlatDescription;
            txtPrice.Text = existing.Price.ToString();
            txtOwner.Text = existing.OwnerName;
            txtPhone.Text = existing.PhoneNumber;
            //копіювання фото
            selectedPhotos = new List<Image>(existing.Photos);
            flowLayoutPanel1.Controls.Clear();
            //вивід зображень
            foreach (var image in selectedPhotos)
            {
                var pic = new PictureBox
                {
                    Image = image,
                    Width = 100,
                    Height = 100,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Margin = new Padding(5)
                };

                pic.Click += (s, _) =>
                {
                    flowLayoutPanel1.Controls.Remove(pic);
                    selectedPhotos.Remove(image);
                };

                flowLayoutPanel1.Controls.Add(pic);
            }
        }

        private void btnLoadPhoto_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "Зображення|*.png;*.jpg;*.jpeg;*.bmp",
                Multiselect = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in ofd.FileNames)
                {
                    var image = Image.FromFile(file);
                    selectedPhotos.Add(image); //дод у список

                    var pic = new PictureBox
                    {
                        Image = image,
                        Width = 100,
                        Height = 100,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Margin = new Padding(5)
                    };

                    //подія для видалення по кліку
                    pic.Click += (s, _) =>
                    {
                        
                        selectedPhotos.Remove(image);
                    };

                    flowLayoutPanel1.Controls.Add(pic);
                }
            }
        }

        private void btnClearPhotos_Click(object sender, EventArgs e)
        {
            selectedPhotos.Clear(); //очищає список
            flowLayoutPanel1.Controls.Clear(); //очищає мініатюри з панелі
        }
    }
}
