using cw9.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cw9
{
    public partial class Form1 : Form
    {
        public IEnumerable<Emp> Emps { get; set; }
        public IEnumerable<Dept> Depts { get; set; }

        public Form1()
        {
            InitializeComponent();
            LoadData();

            //LINQ to SQL, EF
            //LINQ to XML
            //LINQ - Language Integrated Query - IEnumerable<T>


            //1. Extension methods
            string str = "s1234";
            if (str.IsPjatkIndex())
            {

            }

            //2. Anonymous types
            var anon = new
            {
                FirstName="Jan",
                LastName="Kowalski"
            };

            //System.Dynamic
            //dynamic d = "Ala";
            //d = 10;

            //3. Wyrażenia Lambda/Anonimowe metody
            // delegate -> function pointer
            // event
            //Action, Function
            List<int> nums2 = new List<int>() { 3, 4, 2, 3, 1, 2, 3 };
            //var res = Filter(nums2, i => {
            //    //...
            //    return i % 2 == 1;
            //});
            var res = nums2.Filter(i => i % 2 == 0);


        }

        public static bool sdialjmlmaldakmdlsamdka(int i)
        {
            return i % 2 == 1;
        }

        private void LoadData()
        {
            var empsCol = new List<Emp>();
            var deptsCol = new List<Dept>();

            #region Load depts
            var d1 = new Dept
            {
                Deptno = 1,
                Dname = "Research",
                Loc = "Warsaw"
            };

            var d2 = new Dept
            {
                Deptno = 2,
                Dname = "Human Resources",
                Loc = "New York"
            };

            var d3 = new Dept
            {
                Deptno = 3,
                Dname = "IT",
                Loc = "Los Angeles"
            };

            deptsCol.Add(d1);
            deptsCol.Add(d2);
            deptsCol.Add(d3);
            Depts = deptsCol;
            #endregion

            #region Load emps
            var e1 = new Emp
            {
                Deptno = 1,
                Empno = 1,
                Ename = "Jan Kowalski",
                HireDate = DateTime.Now.AddMonths(-5),
                Job = "Backend programmer",
                Mgr = null,
                Salary = 2000
            };

            var e2 = new Emp
            {
                Deptno = 1,
                Empno = 20,
                Ename = "Anna Malewska",
                HireDate = DateTime.Now.AddMonths(-7),
                Job = "Frontend programmer",
                Mgr = e1,
                Salary = 4000
            };

            var e3 = new Emp
            {
                Deptno = 1,
                Empno = 2,
                Ename = "Marcin Korewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Frontend programmer",
                Mgr = null,
                Salary = 5000
            };

            var e4 = new Emp
            {
                Deptno = 2,
                Empno = 3,
                Ename = "Paweł Latowski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Frontend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e5 = new Emp
            {
                Deptno = 2,
                Empno = 4,
                Ename = "Michał Kowalski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Backend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e6 = new Emp
            {
                Deptno = 2,
                Empno = 5,
                Ename = "Katarzyna Malewska",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Manager",
                Mgr = null,
                Salary = 8000
            };

            var e7 = new Emp
            {
                Deptno = null,
                Empno = 6,
                Ename = "Andrzej Kwiatkowski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "System administrator",
                Mgr = null,
                Salary = 7500
            };

            var e8 = new Emp
            {
                Deptno = 2,
                Empno = 7,
                Ename = "Marcin Polewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Mobile developer",
                Mgr = null,
                Salary = 4000
            };

            var e9 = new Emp
            {
                Deptno = 2,
                Empno = 8,
                Ename = "Władysław Torzewski",
                HireDate = DateTime.Now.AddMonths(-9),
                Job = "CTO",
                Mgr = null,
                Salary = 12000
            };

            var e10 = new Emp
            {
                Deptno = 2,
                Empno = 9,
                Ename = "Andrzej Dalewski",
                HireDate = DateTime.Now.AddMonths(-4),
                Job = "Database administrator",
                Mgr = null,
                Salary = 9000
            };

            empsCol.Add(e1);
            empsCol.Add(e2);
            empsCol.Add(e3);
            empsCol.Add(e4);
            empsCol.Add(e5);
            empsCol.Add(e6);
            empsCol.Add(e7);
            empsCol.Add(e8);
            empsCol.Add(e9);
            empsCol.Add(e10);
            Emps = empsCol;
            ResultsDataGridView.DataSource = Emps;

            #endregion

        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        /*
            Celem ćwiczenia jest uzupełnienie poniższych metod.
         *  Każda metoda powinna zawierać kod C#, który z pomocą LINQ'a będzie realizować
         *  zapytania opisane za pomocą SQL'a.
         *  Rezultat zapytania powinien zostać wyświetlony za pomocą kontrolki DataGrid.
         *  W tym celu końcowy wynik należy rzutować do Listy (metoda ToList()).
         *  Jeśli dane zapytanie zwraca pojedynczy wynik możemy je wyświetlić w kontrolce
         *  TextBox WynikTextBox.
        */

        /// <summary>
        /// SELECT * FROM Emps WHERE Job = "Backend programmer";
        /// </summary>
        private void Przyklad1Button_Click(object sender, EventArgs e)
        {
            //var res = new List<Emp>();
            //foreach(var emp in Emps)
            //{
            //    if (emp.Job == "Backend programmer") res.Add(emp);
            //}

            //1. Query syntax (SQL)
            var res = from emp in Emps
                      where emp.Job == "Backend programmer"
                      select new
                      {
                          Nazwisko=emp.Ename,
                          Zawod=emp.Job
                      };


            //2. Lambda and Extension methods


            ResultsDataGridView.DataSource = res.ToList();
        }

        /// <summary>
        /// SELECT * FROM Emps Job = "Frontend programmer" AND Salary>1000 ORDER BY Ename DESC;
        /// </summary>
        private void Przyklad2Button_Click(object sender, EventArgs e)
        {
            var res = (from emp in Emps
                       join dept in Depts on emp.Deptno equals dept.Deptno
                       where emp.Job == "Frontend programmer" && emp.Salary > 1000
                       orderby emp.Ename descending
                       select emp).ToList();

            var res2 = Emps
                        .Where((emp, indx) => emp.Job == "Frontend programmer" && emp.Salary > 1000)
                        .OrderByDescending(emp => emp.Ename)
                        //.Filter(emp => emp.Mgr==1000)
                        .Select(emp => new
                        {
                            emp.Ename,
                            emp.Salary,
                            LiczbaDept=Depts.Count()
                        });


            ResultsDataGridView.DataSource = res2.ToList();
        }

        /// <summary>
        /// SELECT MAX(Salary) FROM Emps;
        /// </summary>
        private void Przyklad3Button_Click(object sender, EventArgs e)
        {
/*            var min = Emps.Min(emp => emp.Salary);
*/            var max = Emps.Max(emp => emp.Salary);
            /*var avg = Emps.Average(emp => emp.Salary);

            var groupBy = Emps.GroupBy(emp => emp.Deptno);

            var joinResult = Emps
                    .Join(Depts, emp => emp.Deptno, dept => dept.Deptno, (emp, dept) => new
                    {
                        emp,
                        dept
                    });

            //map, reduce, filter
            //select, aggregate, where

            var p1 = Emps.All(emp => emp.Salary > 2000);
            var p2 = Emps.Any(emp => emp.Salary > 2000);

            var p3 = Emps.Count(emp => emp.Salary > 2000);

            //var p4 = Emps.Skip(10).Take(10);

            var p5 = Emps.Distinct();

            var p6 = Emps.Sum(emp => emp.Salary);

            var p7 = Emps.First(); //EX
            var p7_2 = Emps.FirstOrDefault(); //null

            var p8 = Emps.Single();
            var p8_2 = Emps.SingleOrDefault();

            var p9 = Emps
                        .Select(emp => emp.Salary)
                        .Aggregate((res, next) => res+next);*/


            WynikTextBox.Text = max+"";
        }

        /// <summary>
        /// SELECT * FROM Emps WHERE Salary=(SELECT MAX(Salary) FROM Emps);
        /// </summary>
        private void Przyklad4Button_Click(object sender, EventArgs e)
        {
            var max = Emps.Max(emp => emp.Salary);

            var result = Emps
                         .Where((emp, indx) => emp.Salary == max);

            ResultsDataGridView.DataSource = result.ToList();
        }

        /// <summary>
        /// SELECT ename AS Nazwisko, job AS Praca FROM Emps;
        /// </summary>
        private void Przyklad5Button_Click(object sender, EventArgs e)
        {
            var result = (from emp in Emps
                          select new
                          {
                              Nazwisko = emp.Ename,
                              Praca = emp.Job
                          }).ToList();


            ResultsDataGridView.DataSource = result;
        }

        /// <summary>
        /// SELECT Emps.Ename, Emps.Job, Depts.Dname FROM Emps
        /// INNER JOIN Depts ON Emps.Deptno=Depts.Deptno
        /// Rezultat: Złączenie kolekcji Emps i Depts.
        /// </summary>
        private void Przyklad6Button_Click(object sender, EventArgs e)
        {
            var result = (from emp in Emps
                          join dept in Depts on emp.Deptno equals dept.Deptno
                          select new { 
                              emp.Ename, 
                              emp.Job, 
                              dept.Deptno
                          }).ToList();

            ResultsDataGridView.DataSource = result;
        }

        /// <summary>
        /// SELECT Job AS Praca, COUNT(1) LiczbaPracownikow FROM Emps GROUP BY Job;
        /// </summary>
        private void Przyklad7Button_Click(object sender, EventArgs e)
        {
            var result = Emps.GroupBy(emp => emp.Job)
                .Select(emp => new
                {
                    Praca = emp.Key,
                    LiczbaPracownikow = emp.Count()
                });

            ResultsDataGridView.DataSource = result.ToList();
        }

        /// <summary>
        /// Zwróć wartość "true" jeśli choć jeden
        /// z elementów kolekcji pracuje jako "Backend programmer".
        /// </summary>
        private void Przyklad8Button_Click(object sender, EventArgs e)
        {

            int result = (from emp in Emps
                          where emp.Job == "Backend programmer"
                          select emp).Count();
            
            if (result!=0)
            {
                WynikTextBox.Text = "Backend programmer istnieje w kolekcji";
            }
             
        }

        /// <summary>
        /// SELECT TOP 1 * FROM Emp WHERE Job="Frontend programmer"
        /// ORDER BY HireDate DESC;
        /// </summary>
        private void Przyklad9Button_Click(object sender, EventArgs e)
        {
            //FirstOrDefault()
            var result = (from emp in Emps
                          where emp.Job == "Frontend programmer"
                          orderby emp.HireDate descending
                          select emp).FirstOrDefault();

            //lista stworzona tylko po to, zeby przechowywac jeden element (inaczej nie mozna wlozyc jej do resultsDataGridView [troche glupie])
            List<Emp> listOfEmps = new List<Emp>();
            listOfEmps.Add(result);

            ResultsDataGridView.DataSource = listOfEmps;
        }

        /// <summary>
        /// SELECT Ename, Job, Hiredate FROM Emps
        /// UNION
        /// SELECT "Brak wartości", null, null;
        /// </summary>
        private void Przyklad10Button_Click(object sender, EventArgs e)
        {
            var result = (from emp in Emps
                         select new
                         {
                             emp.Ename,
                             emp.Job,
                             emp.HireDate
                         }).Union(from emp in Emps
                                  select new
                                  {
                                      Ename = "Brak wartosci",
                                      Job = (String)null,
                                      HireDate = (DateTime?)null
                                  }).ToList();


            ResultsDataGridView.DataSource = result;
        }




    }
}
