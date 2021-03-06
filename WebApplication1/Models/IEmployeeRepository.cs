﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);

        IEnumerable<Employee> GetAllEmployees();
        Employee Add(Employee employee);
        Employee Delete(int id);
        Employee Update(Employee employee);
    }
}
