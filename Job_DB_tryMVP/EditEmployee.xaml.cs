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
using System.Windows.Shapes;

namespace Job_DB_tryMVP
{
    /// <summary>
    /// Логика взаимодействия для EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window,IAddView
    {
        public EditEmployee()
        {
            InitializeComponent();
            
        }

        public ObservableCollection<Employee> employees { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ObservableCollection<Department> departments { get => throw new NotImplementedException(); set => comboboxDep.ItemsSource = value; }
        public Employee employee { get => new Employee(inputFirstName.Text, inputLastName.Text, comboboxDep.Text, Convert.ToInt32(inputSalary.Text)); set => throw new NotImplementedException(); }
        public Department department { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
