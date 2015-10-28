using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;

namespace mba_client.ViewModels
{
    class Employee
    {
        public string Name { get; set; }
    }
    class MainWindowViewModel : ViewModelBase
    {
        public IEnumerable<Employee> Employees
        {
            get { return GetProperty(() => Employees); }
            private set { SetProperty(() => Employees, value); }
        }
        protected override void OnInitializeInDesignMode()
        {
            base.OnInitializeInDesignMode();
            Employees = new List<Employee>() {
            new Employee() { Name = "Employee 1" }
        };
        }
        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
            Employees = new List<Employee>() {
            new Employee() { Name = "Employee 1" }
            };
            //Employees = DatabaseController.GetEmployees();
        }
        //private void addRegistryMenuItem_Click(object sender, EventArgs e)
        //{
        //    // addRegistry = Registry.GetInstance(mainDockManager);
        //}

        // private Registry addRegistry;
    }
}
