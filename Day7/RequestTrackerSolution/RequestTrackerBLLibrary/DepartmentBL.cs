using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class DepartmentBL : IDepartmentService
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL()
        {
            _departmentRepository = new DepartmentRepository();
        }

        public int AddDepartment(Department department)
        {
            var result = _departmentRepository.Add(department);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateDepartmentNameException();
        }

        public Department ChangeDepartmentName(Department department, string departmentNewName)
        {
            Department nameUpdatedDepartment = new Department();

            // check if department exits
            if (_departmentRepository.Get(department.Id) == null) throw new DepartmentNotFoundException();

            // check if any department has the new name
            List<Department> departmentList = _departmentRepository.GetAll();   

            foreach (var departmentItem in departmentList)
            {
                if (departmentItem.Id != department.Id && departmentItem.Name == departmentNewName)
                {
                    throw new DuplicateDepartmentNameException();
                }
            }

            // updating the department name
            foreach (var departmentItem in departmentList)
            {
                if (department.Id == departmentItem.Id)
                {
                    nameUpdatedDepartment = _departmentRepository.Update(department);
                }
            }

            return nameUpdatedDepartment;
        }

        public Department GetDepartmentById(int id)
        {
            Department department = _departmentRepository.Get(id);
            if (department == null) throw new DepartmentNotFoundException();
            return department;
        }

        public Department GetDepartmentByName(string departmentName)
        {
            List<Department> allDepartments = _departmentRepository.GetAll();

            Department department = null;

            foreach (var currentDepartment in allDepartments)
            {
                if (currentDepartment.Name == departmentName) department = currentDepartment;
            }

            if (department == null) throw new DepartmentNotFoundException();
            return department;
        }

        public int GetDepartmentHeadId(int departmentId)
        {
            Department department = GetDepartmentById(departmentId);
            
            return department.Department_Head;
        }

        public List<Department> GetDepartmentList()
        {
            List <Department> allDepartments = _departmentRepository.GetAll();

            if (allDepartments == null) throw new DepartmentsNotAvailableException();

            return allDepartments;
        }
    }
}
