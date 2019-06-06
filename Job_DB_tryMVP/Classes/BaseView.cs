using System;
using System.Collections.ObjectModel;


namespace Job_DB_tryMVP
{
    public interface BaseView
    {
        ObservableCollection<Employee> employees { get; set; }
        ObservableCollection<Department> departments { get; set; }
        Employee employee { get; set; }
        Department department { get; set; }


    }
}
