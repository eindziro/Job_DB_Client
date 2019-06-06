using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_DB_tryMVP
{
    public class Presenter
    {
        private Model1 model;
        private BaseView view;
        public BaseView View
        {
            get => view;
            set
            {
                view = value;
                /*if (view is IAddView)*/ view.departments = model.Db.DB_Departaments;

            }
        }

        /// <summary>
        /// Презентер связывает интерфейс с моделью данных
        /// </summary>
        /// <param name="view">текущий интерфейс</param>
        public Presenter(BaseView view)
        {
            this.view = view;
            model = new Model1();
        }

        #region Логика
        /// <summary>
        /// Загрузка данных
        /// </summary>
        public void LoadData()
        {
            model.LoadData();
            view.employees = model.Db.DB_Workers;
            view.departments = model.Db.DB_Departaments;

        }


        /// <summary>
        /// Добавление нового сотрудника
        /// </summary>
        public void AddNewEmployee()
        {
            model.Db.AddEmployee(view.employee);

        }

        /// <summary>
        /// Редактирование сотрудника
        /// </summary>
        /// <param name="e">Сотрудник для редактирования</param>
        public void EditEmployee(Employee e)
        {
            model.Db.EditEmployee(e, view.employee);

        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        public void DeleteEmployee()
        {
            model.Db.RemoveEmployee(view.employee);


        }

        /// <summary>
        /// Добавление отдела
        /// </summary>
        public void AddDepartment()
        {
            model.Db.AddDepartament(view.department);

        }

        /// <summary>
        /// Удаление отдела
        /// </summary>
        /// <param name="d">Отдел под удаление</param>
        public void DeleteDepartment(Department d)
        {
            model.Db.RemoveDepartament(d);
        }

        /// <summary>
        /// Переименование отдела
        /// </summary>
        /// <param name="d">Отдел для редактирования</param>
        public void ReNameDepartment(Department d)
        {
            model.Db.RenameDepartment(d, view.department);

        }
        #endregion


    }
}
