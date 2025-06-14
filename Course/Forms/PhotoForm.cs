using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;
using Course.Models;

namespace Course
{
    public partial class PhotoForm : Form
    {
        private List<Image> photos; //список зображень 
        private int currentIndex = 0;

        public PhotoForm(List<Image> images)
        {
            InitializeComponent();
            //присвоюємо переданий список зображень змінній photos
            //якщо передано null — створюємо порожній список
            photos = images ?? new List<Image>();

            //якщо список фото порожній
            if (photos.Count == 0)
            {
                MessageBox.Show("Фото відсутні.");
                Close(); 
                return;
            }

            ShowImage();      //показуємо перше зображення на формі
            UpdateButtons();  //оновлюємо стан кнопок
        }

        private void ShowImage()
        {
            pictureBoxMain.Image = photos[currentIndex]; //поточне зображення
        }


        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                ShowImage();
                UpdateButtons();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < photos.Count - 1)
            {
                currentIndex++;
                ShowImage();
                UpdateButtons();
            }
        }

        private void UpdateButtons()
        {
            btnPrev.Enabled = currentIndex > 0;
            btnNext.Enabled = currentIndex < photos.Count - 1;
        }
    }
}
