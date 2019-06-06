using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;

namespace Job_DB_tryMVP
{
    class DB
    {

        #region База данных
        private readonly string reqValue = "application/json";
        private ObservableCollection<Employee> db_workers;
        private ObservableCollection<Department> db_departments;

        public ObservableCollection<Employee> DB_Workers { get => db_workers; set => db_workers = value; }
        public ObservableCollection<Department> DB_Departaments { get => db_departments; set => db_departments = value; }

        #endregion

        public DB()
        {
            db_workers = new ObservableCollection<Employee>();
            db_departments = new ObservableCollection<Department>();
        }

        #region Логика
        /// <summary>
        /// Добавление нового сотрудника
        /// </summary>
        /// <param name="e">Данные нового сотрудника</param>
        public void AddEmployee(Employee e)
        {
            if (!db_workers.Contains(e))
            {
                e.Id = ++Employee.MaxId;
                db_workers.Add(e);
                Console.WriteLine($"Новый сотрдуник,  {e.FirstName} {e.Id}");
                HttpClient http = new HttpClient();
                string url = @"https://localhost:44381/addemployee";
                string emplJson = JsonConvert.SerializeObject(e);
                StringContent content = new StringContent(emplJson, Encoding.UTF8, reqValue);


                var post = http.PostAsync(url, content).Result;
            }
            else Console.WriteLine($"Уже есть сотрудник,  {e.FirstName}");
        }
        /// <summary>
        /// редактирование существующего сотруднкиа
        /// </summary>
        /// <param name="e">Сотрудник для редактирования</param>
        /// <param name="newE">Новые данные сотрудника</param>
        public void EditEmployee(Employee e, Employee newE)
        {
            newE.Id = e.Id;
            if (db_workers.Contains(e))
            {
                Console.WriteLine(db_workers[db_workers.IndexOf(e)].Id);
                db_workers[db_workers.IndexOf(e)] = newE;
                Console.WriteLine(db_workers[db_workers.IndexOf(newE)].Id);
                Console.WriteLine($"поменяли инфу про сотрудника {e.FirstName}");
                HttpClient http = new HttpClient();
                string url = $"https://localhost:44381/editemployee";
                string employeeJson = JsonConvert.SerializeObject(newE);
                StringContent content = new StringContent(employeeJson, Encoding.UTF8, reqValue);
                var res = http.PostAsync(url, content).Result;
            }

        }
        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="e">Сотрудник для удаления</param>
        public void RemoveEmployee(Employee e)
        {
            db_workers.Remove(e);
            Console.WriteLine($"Удалили сотрудника {e.FirstName}");

            HttpClient http = new HttpClient();
            string url = $"https://localhost:44381/removeemployee";
            string idJson = JsonConvert.SerializeObject(e.Id);
            StringContent content = new StringContent(idJson, Encoding.UTF8, reqValue);
            var res = http.PostAsync(url, content).Result;

        }
        /// <summary>
        /// Добавление нового отдела
        /// </summary>
        /// <param name="d">Название нового отдела</param>
        public void AddDepartament(Department d)
        {
            if (!db_departments.Contains(d) && d.DP != "")
            {
                d.Id = ++Department.MaxId;
                db_departments.Add(d);
                Console.WriteLine($"новый деп-т {d.DP}");

                HttpClient http = new HttpClient();
                string url = $"https://localhost:44381/adddepartment";
                var departmentJson = JsonConvert.SerializeObject(d);
                StringContent content = new StringContent(departmentJson, Encoding.UTF8, reqValue);
                var res = http.PostAsync(url, content).Result;
            }
        }
        /// <summary>
        /// Удаление сущ-о отдела
        /// </summary>
        /// <param name="d">Отдел для удаления</param>
        public void RemoveDepartament(Department d)
        {
            HttpClient http = new HttpClient();
            string url = $"https://localhost:44381/removedepartment";
            var departmentJson = JsonConvert.SerializeObject(d.Id);
            StringContent content = new StringContent(departmentJson, Encoding.UTF8, reqValue);
            var res = http.PostAsync(url, content).Result;
            db_departments.Remove(d);
            for (int i = db_workers.Count - 1; i >= 0; i--)
            {

                if (db_workers[i].Dep == d.DP) /*this.RemoveEmployee(db_workers[i]);*/
                {
                    
                    Console.WriteLine($"Пришлось удалить {db_workers[i]}, потому что удалили {d.DP}");
                    this.RemoveEmployee(db_workers[i]);

                }

            }

            Console.WriteLine($"Удалили департамент {d.DP}");
        }
        /// <summary>
        /// Переименование отдела
        /// </summary>
        /// <param name="d">департамент для переименования</param>
        /// <param name="newD">Новый отдел</param>
        public void RenameDepartment(Department d, Department newD)
        {
            newD.Id = d.Id;
            HttpClient http = new HttpClient();
            string url = $"https://localhost:44381/editdepartment";
            var departmentJson = JsonConvert.SerializeObject(newD);
            StringContent content = new StringContent(departmentJson, Encoding.UTF8, reqValue);
            var res = http.PostAsync(url, content).Result;

            for (int i = db_workers.Count - 1; i >= 0; i--)
            {

                if (db_workers[i].Dep == d.DP)
                {
                    var tmpEmployee = db_workers[i];
                    tmpEmployee.Dep = newD.DP;
                    this.EditEmployee(db_workers[i], tmpEmployee);
                    Console.WriteLine($"{db_workers[i]} перешел на {newD.DP}");
                    db_workers[i].Dep = newD.DP;
                }

            }
            Console.WriteLine($"Переименовал {d.DP} на {newD.DP}");
            db_departments[db_departments.IndexOf(d)] = newD;

        }

        #endregion





    }
}
