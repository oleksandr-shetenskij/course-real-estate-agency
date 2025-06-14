using System.IO;
using System.Text;
using System.Text.Json;
using Course.Models;

namespace Course
{
    public partial class MainForm : Form
    {
        private RealEstateAgency agency = new RealEstateAgency(); //новий екземпляр класу

        private const string OffersFile = "offers.json";
        private const string DemandsFile = "demands.json";
        private Demand lastMatchedDemand; //останній попит для підбору
        public MainForm()
        {
            InitializeComponent();
            agency.LoadFromFiles();
            RefreshOfferGrid();
            RefreshDemandGrid();
            this.FormClosing += Form1_FormClosing;
        }

        private void RefreshOfferGrid()
        {
            //очищаємо попереднє джерело даних
            dataGridViewOffers.DataSource = null;

            //прив'язуємо список пропозицій
            dataGridViewOffers.DataSource = agency.Offers;

            //тех. колонки
            if (dataGridViewOffers.Columns.Contains("Photo"))
                dataGridViewOffers.Columns["Photo"].Visible = false;

            if (dataGridViewOffers.Columns.Contains("PhotoBase64"))
                dataGridViewOffers.Columns["PhotoBase64"].Visible = false;

            dataGridViewOffers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //на всю ширину гріда

            //нормальні назви для табл
            dataGridViewOffers.Columns["District"].HeaderText = "Район";
            dataGridViewOffers.Columns["Address"].HeaderText = "Адреса";
            dataGridViewOffers.Columns["HouseDescription"].HeaderText = "Тип будинку";
            dataGridViewOffers.Columns["FlatDescription"].HeaderText = "Тип квартири";
            dataGridViewOffers.Columns["Price"].HeaderText = "Ціна";
            dataGridViewOffers.Columns["OwnerName"].HeaderText = "Власник";
            dataGridViewOffers.Columns["PhoneNumber"].HeaderText = "Телефон";
        }

        private void RefreshDemandGrid()
        {
            //скидаємо джерело даних
            dataGridViewDemands.DataSource = null;

            //аактуальний список попитів до таблиці
            dataGridViewDemands.DataSource = agency.Demands;

            //посилання на таблицю для зручності
            var grid = dataGridViewDemands;

            // Список колонок, які потрібно приховати 
            string[] hiddenColumns =
                {
                "PreferredDistricts",        //необроблений список районів
                "PreferredHouseTypes",       //список типів будинку
                "PreferredFlatTypes"         //список типів квартир
                };

            //перевірка, чи таблиця містить ці колонки, щоб їх прибрати
            foreach (var col in hiddenColumns)
            {
                if (grid.Columns.Contains(col))
                    grid.Columns[col].Visible = false;
            }
            dataGridViewDemands.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //на всю ширину гріда

            //норм назви для табл
            dataGridViewDemands.Columns["BuyerName"].HeaderText = "Покупець";
            dataGridViewDemands.Columns["PhoneNumber"].HeaderText = "Телефон";
            dataGridViewDemands.Columns["MinPrice"].HeaderText = "Ціна від";
            dataGridViewDemands.Columns["MaxPrice"].HeaderText = "Ціна до";
            dataGridViewDemands.Columns["DistrictsDisplay"].HeaderText = "Райони";
            dataGridViewDemands.Columns["HouseTypesDisplay"].HeaderText = "Будинки";
            dataGridViewDemands.Columns["FlatTypesDisplay"].HeaderText = "Квартири";
        }
        //Додавання пропозиції
        private void btnAddOffer_Click(object sender, EventArgs e)
        {
            var form = new AddOfferForm(); //нова форма для введення 
            if (form.ShowDialog() == DialogResult.OK) //якщо підтвердить, зберігаємо
            {
                agency.AddOffer(form.Apartment);
                RefreshOfferGrid(); //оновлення таблиці 
            }
        }

        //Додавання попиту
        private void btnAddDemand_Click(object sender, EventArgs e)
        {
            var form = new AddDemandForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                agency.AddDemand(form.Demand);
                RefreshDemandGrid();
            }
        }

        private void btnMatch_Click(object sender, EventArgs e)
        {
            //перевіряємо, чи вибрано попит у таблиці dataGridViewDemands
            if (dataGridViewDemands.CurrentRow?.DataBoundItem is Demand selectedDemand)
            {
                //зберігаємо обраний попит, щоб знати, з чим працюємо
                lastMatchedDemand = selectedDemand;

                //знаходимо всі пропозиції, що відповідають цьому попиту
                var matches = agency.FindMatches(selectedDemand);

                //очищаємо попередній вміст таблиці з результатами підбору
                dataGridMatches.DataSource = null;

                //прив’язуємо нові результати до таблиці
                dataGridMatches.DataSource = matches;

                //на всю ширину гріда
                dataGridMatches.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                //локалізуємо заголовки колонок українською мовою
                dataGridMatches.Columns["District"].HeaderText = "Район";
                dataGridMatches.Columns["Address"].HeaderText = "Адреса";
                dataGridMatches.Columns["HouseDescription"].HeaderText = "Будинок";
                dataGridMatches.Columns["FlatDescription"].HeaderText = "Квартира";
                dataGridMatches.Columns["Price"].HeaderText = "Ціна";
                dataGridMatches.Columns["OwnerName"].HeaderText = "Власник";
                dataGridMatches.Columns["PhoneNumber"].HeaderText = "Телефон";

                //ховаємо технічну колонку
                if (dataGridMatches.Columns.Contains("PhotoBase64"))
                    dataGridMatches.Columns["PhotoBase64"].Visible = false;
            }
            else
            {

                MessageBox.Show("Виберіть попит для підбору.");
            }
        }


        private void btnDeleteOffer_Click(object sender, EventArgs e)
        {
            if (dataGridViewOffers.CurrentRow?.DataBoundItem is Apartment selectedApartment)
            {
                var confirm = MessageBox.Show("Ви впевнені, що хочете видалити цю пропозицію?",
                                              "Підтвердження видалення",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    agency.Offers.Remove(selectedApartment);
                    RefreshOfferGrid();
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть пропозицію для видалення.");
            }
        }
        //зміна пропозицій
        private void btnEditOffer_Click(object sender, EventArgs e)
        {
            //перевіряємо, чи вибрано рядок у таблиці та чи є в ньому дані типу Apartment
            if (dataGridViewOffers.CurrentRow?.DataBoundItem is Apartment selectedApartment)
            {
                //створюємо форму редагування і передаємо у неї вибрану пропозицію
                var editForm = new AddOfferForm(selectedApartment);

                //відкриваємо її як діалог
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    //знаходимо індекс старої пропозиції у списку
                    int index = agency.Offers.IndexOf(selectedApartment);

                    //замінюємо стару пропозицію новою (відредагованою)
                    agency.Offers[index] = editForm.Apartment;

                    //оновлюємо таблицю з пропозиціями
                    RefreshOfferGrid();
                }
            }
            else
            {
                // Якщо не вибрано жодного рядка
                MessageBox.Show("Будь ласка, виберіть пропозицію для редагування.");
            }
        }

        private void btnViewPhoto_Click(object sender, EventArgs e)
        {
            //перевіряємо, чи вибрано рядок у таблиці з пропозиціями
            if (dataGridViewOffers.CurrentRow?.DataBoundItem is Apartment selectedApartment)
            {
                //перевіряємо, чи у пропозиції є фото 
                if (selectedApartment.Photos != null && selectedApartment.Photos.Count > 0)
                {
                    //створюємо форму для перегляду фото і передаємо туди список зображень
                    var photoForm = new PhotoForm(selectedApartment.Photos);
                    photoForm.ShowDialog();
                }
                else
                {

                    MessageBox.Show("Ця пропозиція не містить фото.");
                }
            }
            else
            {

                MessageBox.Show("Будь ласка, виберіть пропозицію.");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            agency.SaveToFiles();
        }

        

        private void btnViewMatch_Click(object sender, EventArgs e)
        {
            if (dataGridMatches.CurrentRow?.DataBoundItem is Apartment selectedApartment &&
       dataGridViewDemands.CurrentRow?.DataBoundItem is Demand selectedDemand) //перевірка вибору пропозиції і попиту 
            {
                string info = $"Пропозиція:\n" +
                              $"Район: {selectedApartment.District}\n" +
                              $"Адреса: {selectedApartment.Address}\n" +
                              $"Будинок: {selectedApartment.HouseDescription}\n" +
                              $"Квартира: {selectedApartment.FlatDescription}\n" +
                              $"Ціна: {selectedApartment.Price:C}\n" +
                              $"Власник: {selectedApartment.OwnerName}, {selectedApartment.PhoneNumber}\n\n" +

                              $"Вимоги покупця:\n" +
                              $"Ім'я: {selectedDemand.BuyerName}, Тел: {selectedDemand.PhoneNumber}\n" +
                              $"Райони: {string.Join(", ", selectedDemand.PreferredDistricts)}\n" +
                              $"Будинки: {string.Join(", ", selectedDemand.PreferredHouseTypes)}\n" +
                              $"Квартири: {string.Join(", ", selectedDemand.PreferredFlatTypes)}\n" +
                              $"Бюджет: {selectedDemand.MinPrice:C} - {selectedDemand.MaxPrice:C}";

                MessageBox.Show(info, "Відповідність", MessageBoxButtons.OK, MessageBoxIcon.Information); //виводимо інформацію 
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть збіг і попит.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteDemand_Click(object sender, EventArgs e)
        {
            if (dataGridViewDemands.CurrentRow?.DataBoundItem is Demand selectedDemand)
            {
                var confirm = MessageBox.Show(
                    "Ви впевнені, що хочете видалити цей запит покупця?",
                    "Підтвердження видалення",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    agency.Demands.Remove(selectedDemand); //видаляємо з колекції
                    RefreshDemandGrid();

                    //якщо підбір на основі видаленого попиту, очищаємо
                    if (selectedDemand == lastMatchedDemand)
                    {
                        dataGridMatches.DataSource = null;
                        lastMatchedDemand = null;
                    }
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть запит для видалення.");
            }
        }

        private void btnExportMatches_Click(object sender, EventArgs e)
        {
            //перевіряємо чи є вибраний попит і збіги
            if (lastMatchedDemand == null || dataGridMatches.DataSource is not List<Apartment> matches || matches.Count == 0)
            {
                MessageBox.Show("Немає результатів для експорту.", "Експорт", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //діалог збереження файлу
            using var sfd = new SaveFileDialog
            {
                Filter = "Текстовий файл (*.txt)|*.txt|CSV файл (*.csv)|*.csv",
                FileName = "matches_export.txt",
                Title = "Збереження результатів підбору"
            };


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    using var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8);

                    //вивід інформації про запит
                    sw.WriteLine("------------ ЗАПИТ ------------");
                    sw.WriteLine($"Ім'я: {lastMatchedDemand.BuyerName}");
                    sw.WriteLine($"Телефон: {lastMatchedDemand.PhoneNumber}");
                    sw.WriteLine($"Райони: {string.Join(", ", lastMatchedDemand.PreferredDistricts)}");
                    sw.WriteLine($"Типи будинків: {string.Join(", ", lastMatchedDemand.PreferredHouseTypes)}");
                    sw.WriteLine($"Типи квартир: {string.Join(", ", lastMatchedDemand.PreferredFlatTypes)}");
                    sw.WriteLine($"Бюджет: {lastMatchedDemand.MinPrice:C} - {lastMatchedDemand.MaxPrice:C}");
                    sw.WriteLine();

                    //заголовок таблиці з вирівнюванням
                    sw.WriteLine("------------ ВІДПОВІДНІ ПРОПОЗИЦІЇ ------------");
                    sw.WriteLine(string.Format("{0,-12} | {1,-20} | {2,-15} | {3,-15} | {4,10} | {5,-15} | {6}",
                        "Район", "Адреса", "Будинок", "Квартира", "Ціна", "Власник", "Телефон"));
                    sw.WriteLine(new string('-', 110)); // розділювальна лінія

                    //виводимо кожну відповідну пропозицію як окремий рядок
                    foreach (var apt in matches)
                    {
                        sw.WriteLine(string.Format("{0,-12} | {1,-20} | {2,-15} | {3,-15} | {4,10:C} | {5,-15} | {6}",
                            apt.District,
                            apt.Address,
                            apt.HouseDescription,
                            apt.FlatDescription,
                            apt.Price,
                            apt.OwnerName,
                            apt.PhoneNumber));
                    }


                    MessageBox.Show("Експорт виконано успішно.", "Експорт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Помилка при збереженні: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnSearchOffers_Click(object sender, EventArgs e)
        {
            string query = txtSearchOffers.Text.Trim().ToLower(); //текст пошуку

            //перевірка полів на текст пошуку
            var filtered = agency.Offers.Where(a =>
                a.District.ToLower().Contains(query) ||
                a.Address.ToLower().Contains(query) ||
                a.HouseDescription.ToLower().Contains(query) ||
                a.FlatDescription.ToLower().Contains(query) ||
                a.OwnerName.ToLower().Contains(query) ||
                a.PhoneNumber.Contains(query) ||
                a.Price.ToString().Contains(query)
            ).ToList();

            dataGridViewOffers.DataSource = null;
            dataGridViewOffers.DataSource = filtered;
        }

        private void btnClearOffersSearch_Click(object sender, EventArgs e)
        {
            txtSearchOffers.Clear(); //поле пошуку--
            RefreshOfferGrid();
        }

        private void btnSearchDemands_Click(object sender, EventArgs e)
        {
            string query = txtSearchDemands.Text.Trim().ToLower(); //текст пошуку

            var filtered = agency.Demands.Where(d =>
                d.BuyerName.ToLower().Contains(query) ||
                d.PhoneNumber.Contains(query) ||
                d.MinPrice.ToString().Contains(query) ||
                d.MaxPrice.ToString().Contains(query) ||
                d.PreferredDistricts.Any(r => r.ToLower().Contains(query)) ||
                d.PreferredFlatTypes.Any(f => f.ToLower().Contains(query)) ||
                d.PreferredHouseTypes.Any(h => h.ToLower().Contains(query))
            ).ToList();

            dataGridViewDemands.DataSource = null;
            dataGridViewDemands.DataSource = filtered;
        }

        private void btnClearDemandsSearch_Click(object sender, EventArgs e)
        {
            txtSearchDemands.Clear();
            RefreshDemandGrid();
        }

        private void btnEditDemand_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewDemands.CurrentRow?.DataBoundItem is Demand selectedDemand)
            {
                var form = new AddDemandForm(selectedDemand); //нова форма редагування
                if (form.ShowDialog() == DialogResult.OK)
                {
                    int index = agency.Demands.IndexOf(selectedDemand); //індекс
                    agency.Demands[index] = form.Demand; //заміна старого на новий
                    RefreshDemandGrid();
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть попит для редагування.");
            }
        }

        private void btnSaveSearchResults1_Click(object sender, EventArgs e)
        {
            //перевіряємо, чи є щось у dataGridViewOffers
            if (dataGridViewOffers.DataSource is not List<Apartment> results || results.Count == 0)
            {
                MessageBox.Show("Немає результатів для збереження.", "Збереження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //діалог збереження файлу
            using var sfd = new SaveFileDialog
            {
                Filter = "Текстовий файл (*.txt)|*.txt|CSV файл (*.csv)|*.csv",
                FileName = "search_results.txt",
                Title = "Збереження результатів пошуку"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8);

                    sw.WriteLine("------------ РЕЗУЛЬТАТИ ПОШУКУ ------------");
                    sw.WriteLine(string.Format("{0,-12} | {1,-20} | {2,-15} | {3,-15} | {4,10} | {5,-15} | {6}",
                        "Район", "Адреса", "Будинок", "Квартира", "Ціна", "Власник", "Телефон"));
                    sw.WriteLine(new string('-', 110));

                    foreach (var apt in results)
                    {
                        sw.WriteLine(string.Format("{0,-12} | {1,-20} | {2,-15} | {3,-15} | {4,10:C} | {5,-15} | {6}",
                            apt.District,
                            apt.Address,
                            apt.HouseDescription,
                            apt.FlatDescription,
                            apt.Price,
                            apt.OwnerName,
                            apt.PhoneNumber));
                    }

                    MessageBox.Show("Результати пошуку збережено успішно.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при збереженні: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSaveDemandSearchResults_Click(object sender, EventArgs e)
        {
            // Перевіряємо, чи джерело даних є списком попитів і чи воно не порожнє
            if (dataGridViewDemands.DataSource is not List<Demand> results || results.Count == 0)
            {
                MessageBox.Show("Немає результатів для збереження.", "Збереження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //відображаємо діалог збереження
            using var sfd = new SaveFileDialog
            {
                Filter = "Текстовий файл (*.txt)|*.txt|CSV файл (*.csv)|*.csv",
                FileName = "demand_search_results.txt",
                Title = "Збереження результатів пошуку по попиту"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8);

                    //заголовок
                    sw.WriteLine("------------ РЕЗУЛЬТАТИ ПОШУКУ ПО ПОПИТУ ------------");
                    sw.WriteLine(string.Format("{0,-20} | {1,-15} | {2,-25} | {3,-25} | {4,-25} | {5,15}",
                        "Ім’я покупця", "Телефон", "Райони", "Будинки", "Квартири", "Бюджет"));
                    sw.WriteLine(new string('-', 140));

                    //вивід кожного запиту
                    foreach (var demand in results)
                    {
                        string districts = string.Join(", ", demand.PreferredDistricts);
                        string houses = string.Join(", ", demand.PreferredHouseTypes);
                        string flats = string.Join(", ", demand.PreferredFlatTypes);
                        string budget = $"{demand.MinPrice:C} - {demand.MaxPrice:C}";

                        sw.WriteLine(string.Format("{0,-20} | {1,-15} | {2,-25} | {3,-25} | {4,-25} | {5,15}",
                            demand.BuyerName,
                            demand.PhoneNumber,
                            districts,
                            houses,
                            flats,
                            budget));
                    }

                    MessageBox.Show("Результати пошуку збережено успішно.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при збереженні: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
