using System.IO;
using System.Text;
using System.Text.Json;
using Course.Models;

namespace Course
{
    public partial class MainForm : Form
    {
        private RealEstateAgency agency = new RealEstateAgency(); //����� ��������� �����

        private const string OffersFile = "offers.json";
        private const string DemandsFile = "demands.json";
        private Demand lastMatchedDemand; //������� ����� ��� ������
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
            //������� �������� ������� �����
            dataGridViewOffers.DataSource = null;

            //����'����� ������ ����������
            dataGridViewOffers.DataSource = agency.Offers;

            //���. �������
            if (dataGridViewOffers.Columns.Contains("Photo"))
                dataGridViewOffers.Columns["Photo"].Visible = false;

            if (dataGridViewOffers.Columns.Contains("PhotoBase64"))
                dataGridViewOffers.Columns["PhotoBase64"].Visible = false;

            dataGridViewOffers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //�� ��� ������ ����

            //�������� ����� ��� ����
            dataGridViewOffers.Columns["District"].HeaderText = "�����";
            dataGridViewOffers.Columns["Address"].HeaderText = "������";
            dataGridViewOffers.Columns["HouseDescription"].HeaderText = "��� �������";
            dataGridViewOffers.Columns["FlatDescription"].HeaderText = "��� ��������";
            dataGridViewOffers.Columns["Price"].HeaderText = "ֳ��";
            dataGridViewOffers.Columns["OwnerName"].HeaderText = "�������";
            dataGridViewOffers.Columns["PhoneNumber"].HeaderText = "�������";
        }

        private void RefreshDemandGrid()
        {
            //������� ������� �����
            dataGridViewDemands.DataSource = null;

            //����������� ������ ������ �� �������
            dataGridViewDemands.DataSource = agency.Demands;

            //��������� �� ������� ��� ��������
            var grid = dataGridViewDemands;

            // ������ �������, �� ������� ��������� 
            string[] hiddenColumns =
                {
                "PreferredDistricts",        //������������ ������ ������
                "PreferredHouseTypes",       //������ ���� �������
                "PreferredFlatTypes"         //������ ���� �������
                };

            //��������, �� ������� ������ �� �������, ��� �� ��������
            foreach (var col in hiddenColumns)
            {
                if (grid.Columns.Contains(col))
                    grid.Columns[col].Visible = false;
            }
            dataGridViewDemands.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //�� ��� ������ ����

            //���� ����� ��� ����
            dataGridViewDemands.Columns["BuyerName"].HeaderText = "��������";
            dataGridViewDemands.Columns["PhoneNumber"].HeaderText = "�������";
            dataGridViewDemands.Columns["MinPrice"].HeaderText = "ֳ�� ��";
            dataGridViewDemands.Columns["MaxPrice"].HeaderText = "ֳ�� ��";
            dataGridViewDemands.Columns["DistrictsDisplay"].HeaderText = "������";
            dataGridViewDemands.Columns["HouseTypesDisplay"].HeaderText = "�������";
            dataGridViewDemands.Columns["FlatTypesDisplay"].HeaderText = "��������";
        }
        //��������� ����������
        private void btnAddOffer_Click(object sender, EventArgs e)
        {
            var form = new AddOfferForm(); //���� ����� ��� �������� 
            if (form.ShowDialog() == DialogResult.OK) //���� ����������, ��������
            {
                agency.AddOffer(form.Apartment);
                RefreshOfferGrid(); //��������� ������� 
            }
        }

        //��������� ������
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
            //����������, �� ������� ����� � ������� dataGridViewDemands
            if (dataGridViewDemands.CurrentRow?.DataBoundItem is Demand selectedDemand)
            {
                //�������� ������� �����, ��� �����, � ��� ��������
                lastMatchedDemand = selectedDemand;

                //��������� �� ����������, �� ���������� ����� ������
                var matches = agency.FindMatches(selectedDemand);

                //������� ��������� ���� ������� � ������������ ������
                dataGridMatches.DataSource = null;

                //��������� ��� ���������� �� �������
                dataGridMatches.DataSource = matches;

                //�� ��� ������ ����
                dataGridMatches.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                //��������� ��������� ������� ���������� �����
                dataGridMatches.Columns["District"].HeaderText = "�����";
                dataGridMatches.Columns["Address"].HeaderText = "������";
                dataGridMatches.Columns["HouseDescription"].HeaderText = "�������";
                dataGridMatches.Columns["FlatDescription"].HeaderText = "��������";
                dataGridMatches.Columns["Price"].HeaderText = "ֳ��";
                dataGridMatches.Columns["OwnerName"].HeaderText = "�������";
                dataGridMatches.Columns["PhoneNumber"].HeaderText = "�������";

                //������ ������� �������
                if (dataGridMatches.Columns.Contains("PhotoBase64"))
                    dataGridMatches.Columns["PhotoBase64"].Visible = false;
            }
            else
            {

                MessageBox.Show("������� ����� ��� ������.");
            }
        }


        private void btnDeleteOffer_Click(object sender, EventArgs e)
        {
            if (dataGridViewOffers.CurrentRow?.DataBoundItem is Apartment selectedApartment)
            {
                var confirm = MessageBox.Show("�� �������, �� ������ �������� �� ����������?",
                                              "ϳ����������� ���������",
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
                MessageBox.Show("���� �����, ������� ���������� ��� ���������.");
            }
        }
        //���� ����������
        private void btnEditOffer_Click(object sender, EventArgs e)
        {
            //����������, �� ������� ����� � ������� �� �� � � ����� ��� ���� Apartment
            if (dataGridViewOffers.CurrentRow?.DataBoundItem is Apartment selectedApartment)
            {
                //��������� ����� ����������� � �������� � �� ������� ����������
                var editForm = new AddOfferForm(selectedApartment);

                //��������� �� �� �����
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    //��������� ������ ����� ���������� � ������
                    int index = agency.Offers.IndexOf(selectedApartment);

                    //�������� ����� ���������� ����� (�������������)
                    agency.Offers[index] = editForm.Apartment;

                    //��������� ������� � ������������
                    RefreshOfferGrid();
                }
            }
            else
            {
                // ���� �� ������� ������� �����
                MessageBox.Show("���� �����, ������� ���������� ��� �����������.");
            }
        }

        private void btnViewPhoto_Click(object sender, EventArgs e)
        {
            //����������, �� ������� ����� � ������� � ������������
            if (dataGridViewOffers.CurrentRow?.DataBoundItem is Apartment selectedApartment)
            {
                //����������, �� � ���������� � ���� 
                if (selectedApartment.Photos != null && selectedApartment.Photos.Count > 0)
                {
                    //��������� ����� ��� ��������� ���� � �������� ���� ������ ���������
                    var photoForm = new PhotoForm(selectedApartment.Photos);
                    photoForm.ShowDialog();
                }
                else
                {

                    MessageBox.Show("�� ���������� �� ������ ����.");
                }
            }
            else
            {

                MessageBox.Show("���� �����, ������� ����������.");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            agency.SaveToFiles();
        }

        

        private void btnViewMatch_Click(object sender, EventArgs e)
        {
            if (dataGridMatches.CurrentRow?.DataBoundItem is Apartment selectedApartment &&
       dataGridViewDemands.CurrentRow?.DataBoundItem is Demand selectedDemand) //�������� ������ ���������� � ������ 
            {
                string info = $"����������:\n" +
                              $"�����: {selectedApartment.District}\n" +
                              $"������: {selectedApartment.Address}\n" +
                              $"�������: {selectedApartment.HouseDescription}\n" +
                              $"��������: {selectedApartment.FlatDescription}\n" +
                              $"ֳ��: {selectedApartment.Price:C}\n" +
                              $"�������: {selectedApartment.OwnerName}, {selectedApartment.PhoneNumber}\n\n" +

                              $"������ �������:\n" +
                              $"��'�: {selectedDemand.BuyerName}, ���: {selectedDemand.PhoneNumber}\n" +
                              $"������: {string.Join(", ", selectedDemand.PreferredDistricts)}\n" +
                              $"�������: {string.Join(", ", selectedDemand.PreferredHouseTypes)}\n" +
                              $"��������: {string.Join(", ", selectedDemand.PreferredFlatTypes)}\n" +
                              $"������: {selectedDemand.MinPrice:C} - {selectedDemand.MaxPrice:C}";

                MessageBox.Show(info, "³���������", MessageBoxButtons.OK, MessageBoxIcon.Information); //�������� ���������� 
            }
            else
            {
                MessageBox.Show("���� �����, ������� ��� � �����.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteDemand_Click(object sender, EventArgs e)
        {
            if (dataGridViewDemands.CurrentRow?.DataBoundItem is Demand selectedDemand)
            {
                var confirm = MessageBox.Show(
                    "�� �������, �� ������ �������� ��� ����� �������?",
                    "ϳ����������� ���������",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    agency.Demands.Remove(selectedDemand); //��������� � ��������
                    RefreshDemandGrid();

                    //���� ���� �� ����� ���������� ������, �������
                    if (selectedDemand == lastMatchedDemand)
                    {
                        dataGridMatches.DataSource = null;
                        lastMatchedDemand = null;
                    }
                }
            }
            else
            {
                MessageBox.Show("���� �����, ������� ����� ��� ���������.");
            }
        }

        private void btnExportMatches_Click(object sender, EventArgs e)
        {
            //���������� �� � �������� ����� � ����
            if (lastMatchedDemand == null || dataGridMatches.DataSource is not List<Apartment> matches || matches.Count == 0)
            {
                MessageBox.Show("���� ���������� ��� ��������.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //����� ���������� �����
            using var sfd = new SaveFileDialog
            {
                Filter = "��������� ���� (*.txt)|*.txt|CSV ���� (*.csv)|*.csv",
                FileName = "matches_export.txt",
                Title = "���������� ���������� ������"
            };


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    using var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8);

                    //���� ���������� ��� �����
                    sw.WriteLine("------------ ����� ------------");
                    sw.WriteLine($"��'�: {lastMatchedDemand.BuyerName}");
                    sw.WriteLine($"�������: {lastMatchedDemand.PhoneNumber}");
                    sw.WriteLine($"������: {string.Join(", ", lastMatchedDemand.PreferredDistricts)}");
                    sw.WriteLine($"���� �������: {string.Join(", ", lastMatchedDemand.PreferredHouseTypes)}");
                    sw.WriteLine($"���� �������: {string.Join(", ", lastMatchedDemand.PreferredFlatTypes)}");
                    sw.WriteLine($"������: {lastMatchedDemand.MinPrice:C} - {lastMatchedDemand.MaxPrice:C}");
                    sw.WriteLine();

                    //��������� ������� � ������������
                    sw.WriteLine("------------ ²���²�Ͳ �������ֲ� ------------");
                    sw.WriteLine(string.Format("{0,-12} | {1,-20} | {2,-15} | {3,-15} | {4,10} | {5,-15} | {6}",
                        "�����", "������", "�������", "��������", "ֳ��", "�������", "�������"));
                    sw.WriteLine(new string('-', 110)); // ������������ ���

                    //�������� ����� �������� ���������� �� ������� �����
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


                    MessageBox.Show("������� �������� ������.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("������� ��� ���������: " + ex.Message, "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnSearchOffers_Click(object sender, EventArgs e)
        {
            string query = txtSearchOffers.Text.Trim().ToLower(); //����� ������

            //�������� ���� �� ����� ������
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
            txtSearchOffers.Clear(); //���� ������--
            RefreshOfferGrid();
        }

        private void btnSearchDemands_Click(object sender, EventArgs e)
        {
            string query = txtSearchDemands.Text.Trim().ToLower(); //����� ������

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
                var form = new AddDemandForm(selectedDemand); //���� ����� �����������
                if (form.ShowDialog() == DialogResult.OK)
                {
                    int index = agency.Demands.IndexOf(selectedDemand); //������
                    agency.Demands[index] = form.Demand; //����� ������� �� �����
                    RefreshDemandGrid();
                }
            }
            else
            {
                MessageBox.Show("���� �����, ������� ����� ��� �����������.");
            }
        }

        private void btnSaveSearchResults1_Click(object sender, EventArgs e)
        {
            //����������, �� � ���� � dataGridViewOffers
            if (dataGridViewOffers.DataSource is not List<Apartment> results || results.Count == 0)
            {
                MessageBox.Show("���� ���������� ��� ����������.", "����������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //����� ���������� �����
            using var sfd = new SaveFileDialog
            {
                Filter = "��������� ���� (*.txt)|*.txt|CSV ���� (*.csv)|*.csv",
                FileName = "search_results.txt",
                Title = "���������� ���������� ������"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8);

                    sw.WriteLine("------------ ���������� ������ ------------");
                    sw.WriteLine(string.Format("{0,-12} | {1,-20} | {2,-15} | {3,-15} | {4,10} | {5,-15} | {6}",
                        "�����", "������", "�������", "��������", "ֳ��", "�������", "�������"));
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

                    MessageBox.Show("���������� ������ ��������� ������.", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("������� ��� ���������: " + ex.Message, "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSaveDemandSearchResults_Click(object sender, EventArgs e)
        {
            // ����������, �� ������� ����� � ������� ������ � �� ���� �� ������
            if (dataGridViewDemands.DataSource is not List<Demand> results || results.Count == 0)
            {
                MessageBox.Show("���� ���������� ��� ����������.", "����������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //���������� ����� ����������
            using var sfd = new SaveFileDialog
            {
                Filter = "��������� ���� (*.txt)|*.txt|CSV ���� (*.csv)|*.csv",
                FileName = "demand_search_results.txt",
                Title = "���������� ���������� ������ �� ������"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8);

                    //���������
                    sw.WriteLine("------------ ���������� ������ �� ������ ------------");
                    sw.WriteLine(string.Format("{0,-20} | {1,-15} | {2,-25} | {3,-25} | {4,-25} | {5,15}",
                        "��� �������", "�������", "������", "�������", "��������", "������"));
                    sw.WriteLine(new string('-', 140));

                    //���� ������� ������
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

                    MessageBox.Show("���������� ������ ��������� ������.", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("������� ��� ���������: " + ex.Message, "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
