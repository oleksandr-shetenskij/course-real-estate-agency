using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Course.Models;

namespace Course
{
    public partial class AddDemandForm : Form
    {

        public Demand Demand { get; private set; }

        public AddDemandForm()
        {
            InitializeComponent();
        }

        public AddDemandForm(Demand existing) : this()
        {
            //заповнення полів
            txtDistricts.Text = string.Join(", ", existing.PreferredDistricts);
            txtMinPrice.Text = existing.MinPrice.ToString();
            txtMaxPrice.Text = existing.MaxPrice.ToString();
            txtName.Text = existing.BuyerName;
            txtPhone.Text = existing.PhoneNumber;

            //вибір у CheckedListBox
            foreach (var item in existing.PreferredHouseTypes)
                CheckItemIfExists(checkedListHouseTypes, item);

            foreach (var item in existing.PreferredFlatTypes)
                CheckItemIfExists(checkedListFlatTypes, item);
        }

        //метод для встановлення позначки
        private void CheckItemIfExists(CheckedListBox clb, string value)
        {
            for (int i = 0; i < clb.Items.Count; i++)
            {
                if (clb.Items[i].ToString().Equals(value, StringComparison.OrdinalIgnoreCase))
                {
                    clb.SetItemChecked(i, true);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                // Отримуємо райони
                var districts = txtDistricts.Text
                    .Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .ToList();

                // Перевірка: хоча б один район має бути введений
                if (districts.Count == 0)
                {
                    MessageBox.Show("Будь ласка, введіть хоча б один район.");
                    return;
                }

                // Отримуємо обрані типи будинків і квартир
                var houseTypes = GetCheckedItems(checkedListHouseTypes);
                var flatTypes = GetCheckedItems(checkedListFlatTypes);

                if (houseTypes.Count == 0 || flatTypes.Count == 0)
                {
                    MessageBox.Show("Оберіть хоча б один тип будинку та квартири.");
                    return;
                }

                // Перевірка числових значень
                if (!decimal.TryParse(txtMinPrice.Text, out decimal minPrice))
                {
                    MessageBox.Show("Мінімальна ціна має бути числом.");
                    return;
                }

                if (!decimal.TryParse(txtMaxPrice.Text, out decimal maxPrice))
                {
                    MessageBox.Show("Максимальна ціна має бути числом.");
                    return;
                }

                if (minPrice < 0 || maxPrice < 0)
                {
                    MessageBox.Show("Ціни не можуть бути від’ємними.");
                    return;
                }

                if (minPrice > maxPrice)
                {
                    MessageBox.Show("Мінімальна ціна не може перевищувати максимальну.");
                    return;
                }

                Demand = new Demand(
                    districts,
                    houseTypes,
                    flatTypes,
                    minPrice,
                    maxPrice,
                    txtName.Text.Trim(),
                    txtPhone.Text.Trim()
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }
        //метод для отримання вибр
        private List<string> GetCheckedItems(CheckedListBox clb)
        {
            return clb.CheckedItems.Cast<string>().ToList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        
    }
}
