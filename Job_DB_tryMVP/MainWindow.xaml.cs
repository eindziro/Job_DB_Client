using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Job_DB_tryMVP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, BaseView
    {
        Presenter presenter;

        public MainWindow()
        {
            InitializeComponent();
            presenter = new Presenter(this);

            this.Loaded += delegate { presenter.LoadData(); };

            addEmpl.Click += delegate
            {
                AddNewEmployee e = new AddNewEmployee();
                presenter.View = e;
                e.addBtn.Click += delegate
                {
                    presenter.AddNewEmployee();
                    presenter.View = this;
                    e.Close();
                };
                e.Show();

            };
            ListView.MouseDoubleClick += delegate
            {
                EditEmployee e = new EditEmployee();
                e.DataContext = ListView.SelectedItem as Employee;
                presenter.View = e;
                e.Show();
                e.editBtn.Click += delegate
                {
                    presenter.EditEmployee(ListView.SelectedItem as Employee);
                    presenter.View = this;
                    e.Close();

                };
            };
            deleteEmpl.Click += delegate { presenter.DeleteEmployee(); };
            addDep.Click += delegate
            {
                presenter.AddDepartment();
                newDep.Text = default;


            };
            deleteDep.Click += delegate
            {
                presenter.DeleteDepartment(cmbbDeps.SelectedItem as Department);
            };
            editDep.Click += delegate
            {
                presenter.ReNameDepartment(cmbbDeps.SelectedItem as Department);
                newDep.Text = default;

            };


        }

        public ObservableCollection<Employee> employees { get => throw new NotImplementedException(); set { ListView.ItemsSource = value; } }
        public ObservableCollection<Department> departments { get => throw new NotImplementedException(); set => cmbbDeps.ItemsSource = value; }
        public Employee employee { get => ListView.SelectedItem as Employee; set => throw new NotImplementedException(); }
        public Department department { get => new Department(newDep.Text); set => newDep.Text = value.DP; }
    }
}
