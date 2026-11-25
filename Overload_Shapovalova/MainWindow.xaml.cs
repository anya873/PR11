using Overload_Shapovalova.Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Overload_Shapovalova
{
    public partial class MainWindow : Window
    {
        StudentsRepo repo = new StudentsRepo();

        public MainWindow()
        {
            InitializeComponent();
            UpdateList();
        }

        private void UpdateList()
        {
            lstStudents.Items.Clear();
            foreach (string name in repo.GetNames())
            {
                lstStudents.Items.Add(name);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                repo.AddName(fio.Text);
                fio.Clear();
                UpdateList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lstStudents.SelectedItem != null)
            {
                repo.RemoveName(lstStudents.SelectedItem.ToString());
                UpdateList();
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            repo.Clear();
            UpdateList();
            txtResult.Text = "";
        }

        private void cmbSeparator_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSeparator.SelectedItem != null)
            {
                razd.Text = (cmbSeparator.SelectedItem as ComboBoxItem).Content.ToString();
            }
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            string sep = razd.Text;
            string result = "";
            string methodName = "";

            if (chkSort.IsChecked == true && chkReverse.IsChecked == true)
            {
                result = repo.PrintNames(sep, true, true);
                methodName = "PrintNames(string separator, bool sort, bool reverse)";
            }
            else if (chkSort.IsChecked == true)
            {
                result = repo.PrintNames(sep, true);
                methodName = "PrintNames(string separator, bool sort)";
            }
            else
            {
                result = repo.PrintNames(sep);
                methodName = "PrintNames(string separator)";
            }

            txtResult.Text = result + "\n\nВызван метод: " + methodName;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var found = repo.SearchByName(txtSearch.Text);
            lstStudents.Items.Clear();
            foreach (var name in found)
            {
                lstStudents.Items.Add(name);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            repo.PrintNames(razd.Text, "students.txt");
            MessageBox.Show("Сохранено в students.txt");
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            repo.LoadFromFile("students.txt");
            UpdateList();
            MessageBox.Show("Загружено из students.txt");
        }

        
    }
}