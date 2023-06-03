﻿namespace HrManagement.Domain.Entities.Company
{
    public class DepartmentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<EmployeeEntity> Employees { get; set; }
    }
}
