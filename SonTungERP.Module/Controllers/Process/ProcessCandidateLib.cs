using DevExpress.ExpressApp;
using SonTungERP.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.Controllers.Process
{
    public class ProcessCandidateLib
    {
        public static void process_convert_to_employee(
            IObjectSpace objectSpace,
            Candidate candidate,
            Department department,
            string empID)
        {
            if (!string.IsNullOrEmpty(candidate?.EmployeeCode))
            {
                return;
            }

            var departmentUpdate = objectSpace.GetObjectByKey<Department>(department.Oid);

            var employee = objectSpace.CreateObject<Employee>();
            candidate.Employee = true;
            candidate.EmployeeCode = empID;

            #region employee infor
            employee.Code = empID;
            employee.FullName = candidate.FullName;
            employee.Gender = candidate.Gender;
            employee.DateOfBirth = candidate.DateOfBirth;
            employee.PlaceOfBirth = candidate.PlaceOfBirth;
            employee.DateOfJoining = candidate.WillJoinDate.GetValueOrDefault();
            employee.Department = departmentUpdate;
            employee.Job = candidate.Job;
            employee.Designation = candidate.Designation;
            employee.Religion = candidate.Religion;
            employee.Identity = candidate.Identity;
            employee.IdentiyLicesenPlace = candidate.IdentiyLicesenPlace;
            employee.IdetityLicesenDate = candidate.IdetityLicesenDate;
            employee.Major = candidate.Major;
            employee.MaritalStatus = candidate.MaritalStatus;
            employee.Group = departmentUpdate.Group;
            #endregion

            #region employee contact

            var employeeContact = objectSpace.CreateObject<EmployeeContact>();
            employeeContact.Employee = employee;
            employeeContact.PersonalEmail = candidate.Email;
            employeeContact.PersonalPhone = candidate.Phone;
            employeeContact.OriginAddress = candidate.OriginAddress;
            employeeContact.TemporaryAddress = candidate.TemporaryAddress;

            #endregion

            #region employee relative
            foreach (var relative in candidate.Relatives)
            {
                var employeeRelative = objectSpace.CreateObject<EmployeeRelative>();
                employeeRelative.Employee = employee;
                employeeRelative.Type = relative.Type;
                employeeRelative.FullName = relative.FullName;
                employeeRelative.OriginAddress = relative.OriginAddress;
                employeeRelative.TemporaryAddress = relative.TemporaryAddress;
                employeeRelative.Phone = relative.Phone;
                employeeRelative.Email = relative.Email;
                employeeRelative.DateOfBirth = relative.DateOfBirth;
                employeeRelative.Job = relative.Job;
            }
            #endregion

            #region employee experience

            foreach (var exp in candidate.Experiences)
            {
                var employeeExperience = objectSpace.CreateObject<EmployeeExperience>();
                employeeExperience.Employee = employee;
                employeeExperience.Time = exp.Time;
                employeeExperience.Company = exp.Company;
                employeeExperience.CompanyAddress = exp.CompanyAddress;
                employeeExperience.CompanySize = exp.CompanySize;
                employeeExperience.CompanyBussiness = exp.CompanyBussiness;
                employeeExperience.Designation = exp.Designation;
                employeeExperience.JobDescription = exp.JobDescription;
                employeeExperience.Salary = exp.Salary;
                employeeExperience.ReasonOfLeave = exp.ReasonOfLeave;
                employeeExperience.Contact = exp.Contact;
                employeeExperience.ContactPhone = exp.ContactPhone;
                employeeExperience.ContactDesignation = exp.ContactDesignation;
                employeeExperience.ContactMobile = exp.ContactMobile;
            }

            #endregion

            #region employee education

            foreach (var education in candidate.Educations)
            {
                var employeeEducation = objectSpace.CreateObject<EmployeeEducation>();
                employeeEducation.Employee = employee;
                employeeEducation.Time = education.Time;
                employeeEducation.School = education.School;
                employeeEducation.Major = education.Major;
                employeeEducation.Level = education.Level;
                employeeEducation.Type = education.Type;
            }

            #endregion

            #region employee skill

            foreach (var skill in candidate.Skills)
            {
                var employeeSkill = objectSpace.CreateObject<EmployeeSkill>();
                employeeSkill.Employee = employee;
                employeeSkill.Skill = skill.Skill;
                employeeSkill.Level = skill.Level;
            }

            #endregion
        }
    }
}
