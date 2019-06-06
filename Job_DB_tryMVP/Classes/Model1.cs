using System;
using System.Linq;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Job_DB_tryMVP
{
    class Model1
    {
        #region Данные
        private DB db;
        private readonly string db_worker_way;
        private readonly string db_departament_way;
        private readonly string reqHeader = "Accept";
        private readonly string reqValue = "application/json";

        public DB Db { get => db; set => db = value; }
        #endregion

        /// <summary>
        /// Класс для доступа к БД
        /// </summary>
        /// <param name="worker_way">Путь к БД работников</param>
        /// <param name="dep_way">Путь к БД отделов</param>
        public Model1(string worker_way = @"https://localhost:44381/getemployeelist", string dep_way = @"https://localhost:44381/getdepartmentlist")
        {
            db = new DB();
            this.db_worker_way = worker_way;
            this.db_departament_way = dep_way;

        }

        #region Логика
        /// <summary>
        /// Загрузка БД
        /// </summary>
        public void LoadData()
        {
            try
            {
                HttpClient http = new HttpClient();
                http.DefaultRequestHeaders.Add(reqHeader, reqValue);
                var res = http.GetStringAsync(this.db_departament_way).Result;
                var list = JsonConvert.DeserializeObject<ObservableCollection<Department>>(res);
                db.DB_Departaments = list;
                Department.MaxId = db.DB_Departaments.Max().Id;
                list = null;

               

            }
            catch (Exception)
            {

                Console.WriteLine("Не нашел БД_Departaments");
            }
            try
            {
                
                HttpClient http = new HttpClient();
                http.DefaultRequestHeaders.Add(reqHeader, reqValue);
                var res = http.GetStringAsync(this.db_worker_way).Result;
                var list = JsonConvert.DeserializeObject<ObservableCollection<Employee>>(res);
                db.DB_Workers = list;
                Employee.MaxId = db.DB_Workers.Max().Id;
                list = null;


            }
            catch (Exception)
            {
                Console.WriteLine("Не нашел БД_Employee");
            }



        }      
     

        #endregion

    }
}
