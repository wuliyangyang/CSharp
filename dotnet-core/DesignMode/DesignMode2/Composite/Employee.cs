using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode2.Composite
{
    public class Employee
    {
        private string _name; //名字
        private string _dept; //部门
        private double _salary;//薪水
        private List<Employee> _subordinates;//下属人数

        public Employee(string name,string dept,double salary)
        {
            this._name = name;
            this._dept = dept;
            this._salary = salary;
            this._subordinates = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            this._subordinates.Add(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            this._subordinates.Remove(employee);
        }

        public List<Employee> GetEmployees()
        {
            return this._subordinates;
        }   
    }
}
