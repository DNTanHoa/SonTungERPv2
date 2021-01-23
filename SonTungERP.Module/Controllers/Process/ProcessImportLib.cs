using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using ExcelDataReader;
using SonTungERP.Module.BusinessObjects;
using SonTungERP.Module.Imports;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SonTungERP.Module.Controllers.Process
{
    public class ProcessImportLib
    {
        public static void process_read_employee_data(
            IObjectSpace objectSpace,
            string fileSavePath,
            string configFilePath,
            out List<Employee> readResult)
        {
            readResult = new List<Employee>();

            using (var stream = File.Open(fileSavePath, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {

                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    });

                    if (dataSet.Tables.Count > 0)
                    {
                        SheetTemplateImport templateImport = new SheetTemplateImport(configFilePath);

                        DataTable table = dataSet.Tables[templateImport.SheetName];

                        foreach (var column in templateImport.Columns)
                        {
                            if (!string.IsNullOrWhiteSpace(column.excelHeader))
                            {
                                table.Columns[column.excelHeader].ColumnName = column.propertyName;
                            }
                        }

                        /// Map employee data
                        process_map_employee_data(objectSpace,
                               table,
                               out List<Employee> mapResult);

                        readResult = mapResult;
                    }
                }
            }
        }

        public static void process_map_employee_data(
            IObjectSpace objectSpace,
            DataTable employeeDataTable,
            out List<Employee> mapResult)
        {
            mapResult = new List<Employee>();
            foreach (DataRow row in employeeDataTable.Rows)
            {
                var employee = objectSpace.CreateObject<Employee>();

                ///Get base property data
                employee = process_get_employee_base_property_data(employee, row);

                ///Get association property data
                process_get_employee_association_property_data(objectSpace,
                    employee,
                    row,
                    out employee);

                mapResult.Add(employee);
            }
        }

        public static Employee process_get_employee_base_property_data(
            Employee employee,
            DataRow row)
        {
            PropertyInfo[] propertyInfos = employee.GetType().GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                try
                {
                    string infoName = propertyInfo.Name;
                    employee.SetMemberValue(
                        infoName,
                        Convert.ChangeType(row[infoName], propertyInfo.PropertyType));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return employee;
        }

        public static void process_get_employee_association_property_data(
            IObjectSpace objectSpace,
            Employee employee,
            DataRow rowData,
            out Employee result)
        {
            result = employee;

            var departments = objectSpace.GetObjects<Department>();
            var groups = objectSpace.GetObjects<Group>();
            var jobs = objectSpace.GetObjects<Job>();
            var designations = objectSpace.GetObjects<Designation>();
            var nations = objectSpace.GetObjects<Nation>();
            var religions = objectSpace.GetObjects<Religion>();
            var genders = objectSpace.GetObjects<Gender>();
            var nationalities = objectSpace.GetObjects<Nationality>();
            var maritalStatuses = objectSpace.GetObjects<MaritalStatus>();
            var schools = objectSpace.GetObjects<School>();
            var employeeStatuses = objectSpace.GetObjects<EmployeeStatus>();
            var identityLicensePlaces = objectSpace.GetObjects<IdentiyLicesenPlace>();
            var educationLevels = objectSpace.GetObjects<EducationLevel>();

            if (!string.IsNullOrEmpty(rowData["DepartmentCode"]?.ToString()))
            {
                var department = departments
                    .FirstOrDefault(item => item.Code?.ToUpper() == rowData["DepartmentCode"]?.ToString().ToUpper());
                result.SetMemberValue("Department", department);
            }

            if (!string.IsNullOrEmpty(rowData["Group"]?.ToString()))
            {
                var group = groups
                    .FirstOrDefault(item => item.Name?.ToUpper() == rowData["Group"]?.ToString().ToUpper());

                if (group != null)
                {
                    result.SetMemberValue("Group", group);
                }
                else
                {
                    result.SetMemberValue("Group", result?.Department?.Group);
                }
            }
            else
            {
                result.SetMemberValue("Group", result?.Department?.Group);
            }

            if (!string.IsNullOrEmpty(rowData["Job"]?.ToString()))
            {
                var job = jobs
                    .FirstOrDefault(item => item.Name?.ToUpper() == rowData["Job"]?.ToString().ToUpper());
                result.SetMemberValue("Job", job);
            }

            if (!string.IsNullOrEmpty(rowData["Designation"]?.ToString()))
            {
                var designation = designations
                    .FirstOrDefault(item => item.Name?.ToUpper() == rowData["Designation"]?.ToString().ToUpper());
                result.SetMemberValue("Designation", designation);
            }

            if (!string.IsNullOrEmpty(rowData["Nation"]?.ToString()))
            {
                var nation = nations
                    .FirstOrDefault(item => item.Name?.ToUpper() == rowData["Nation"]?.ToString().ToUpper());
                result.SetMemberValue("Nation", nation);
            }

            if (!string.IsNullOrEmpty(rowData["Gender"]?.ToString()))
            {
                var gender = genders
                    .FirstOrDefault(item => item.Name?.ToUpper() == rowData["Gender"]?.ToString().ToUpper());
                result.SetMemberValue("Gender", gender);
            }

            //if (!string.IsNullOrEmpty(rowData["Nationality"]?.ToString()))
            //{
            //    var nationality = nationalities
            //        .FirstOrDefault(item => item.Name?.ToUpper() == rowData["Nationality"]?.ToString());
            //    result.SetMemberValue("Nationality", nationality);
            //}

            if (!string.IsNullOrEmpty(rowData["Religion"]?.ToString()))
            {
                var religion = religions
                    .FirstOrDefault(item => item.Name?.ToUpper() == rowData["Religion"]?.ToString().ToUpper());
                result.SetMemberValue("Religion", religion);
            }

            if (!string.IsNullOrEmpty(rowData["Status"]?.ToString()))
            {
                var employeeStatus = employeeStatuses
                    .FirstOrDefault(item => item.Name?.ToUpper() == rowData["Status"]?.ToString().ToUpper());
                result.SetMemberValue("Status", employeeStatus);
            }

            if (!string.IsNullOrEmpty(rowData["IdentiyLicesenPlace"]?.ToString()))
            {
                var identityLicensePlace = identityLicensePlaces
                    .FirstOrDefault(item => item.Name?.ToUpper() == rowData["IdentiyLicesenPlace"]?.ToString().ToUpper());
                result.SetMemberValue("IdentiyLicesenPlace", identityLicensePlace);
            }

            if (!string.IsNullOrEmpty(rowData["EducationLevel"]?.ToString()))
            {
                var educationLevel = educationLevels
                    .FirstOrDefault(item => item.Name?.ToUpper() == rowData["EducationLevel"]?.ToString().ToUpper());
                result.SetMemberValue("EducationLevel", educationLevel);
            }

        }

        public static void process_read_employee_contract_data(
            IObjectSpace objectSpace,
            string fileSavePath,
            string configFilePath)
        {
            using (var stream = File.Open(fileSavePath, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {

                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    });

                    if (dataSet.Tables.Count > 0)
                    {
                        SheetTemplateImport templateImport = new SheetTemplateImport(configFilePath);

                        DataTable table = dataSet.Tables[templateImport.SheetName];

                        foreach (var column in templateImport.Columns)
                        {
                            if (!string.IsNullOrWhiteSpace(column.excelHeader))
                            {
                                table.Columns[column.excelHeader].ColumnName = column.propertyName;
                            }
                        }

                        ///Map data from excel to bussiness object
                        process_map_employee_contract_data(
                            objectSpace,
                            table,
                            out List<EmployeeContract> contracts);
                    }
                }
            }
        }

        public static void process_map_employee_contract_data(
            IObjectSpace objectSpace,
            DataTable employeeContractDataTable,
            out List<EmployeeContract> mapResult)
        {
            var employees = objectSpace.GetObjects<Employee>();
            var contractTypes = objectSpace.GetObjects<ContractType>();
            var designations = objectSpace.GetObjects<Designation>();
            var jobs = objectSpace.GetObjects<Job>();

            Employee employee = null;
            ContractType contractType = null;
            Designation designation = null;
            Employee signPerson = null;
            Job job = null;

            string empID = string.Empty;
            string contractTypeName = string.Empty;
            string designationName = string.Empty;
            string signPersonID = string.Empty;
            string jobName = string.Empty;

            mapResult = new List<EmployeeContract>();

            foreach (DataRow row in employeeContractDataTable.Rows)
            {
                if (empID != row["EmpID"]?.ToString())
                {
                    empID = row["EmpID"]?.ToString();
                    employee = employees
                        .Where(item => item.Code == empID)
                        .FirstOrDefault();
                }

                if (contractTypeName != row["Type"]?.ToString())
                {
                    contractTypeName = row["Type"]?.ToString();
                    contractType = contractTypes
                        .Where(item => item.Name.ToUpper() == contractTypeName.ToUpper())
                        .FirstOrDefault();
                }

                if (designationName != row["Designation"]?.ToString())
                {
                    designationName = row["Designation"]?.ToString();
                    designation = designations
                        .Where(item => item.Name.ToUpper() == designationName.ToUpper())
                        .FirstOrDefault();
                }

                if (signPersonID != row["CompanySignPerson"]?.ToString())
                {
                    signPersonID = row["CompanySignPerson"]?.ToString();
                    signPerson = employees
                        .Where(item => item.Code == signPersonID)
                        .FirstOrDefault();
                }

                if (jobName != row["Job"]?.ToString())
                {
                    jobName = row["Job"]?.ToString();
                    job = jobs
                        .Where(item => item.Name.ToUpper() == jobName.ToUpper())
                        .FirstOrDefault();
                }

                if (employee != null)
                {
                    var contract = objectSpace.CreateObject<EmployeeContract>();
                    contract.SetMemberValue("ContractNumber", row["ContractNumber"]?.ToString());
                    contract.SetMemberValue("Employee", employee);
                    contract.SetMemberValue("Type", contractType);
                    contract.SetMemberValue("Designation", designation);
                    contract.SetMemberValue("CompanySignPerson", signPerson);
                    contract.SetMemberValue("Job", job);
                    contract.SetMemberValue("BaseSalary", row["BaseSalary"]);
                    contract.SetMemberValue("InsurranceSalary", row["InsurranceSalary"]);
                    contract.SetMemberValue("SignedDate", row["SignedDate"]);
                    contract.SetMemberValue("ValidFromDate", row["ValidFromDate"]);

                    mapResult.Add(contract);
                }
            }
        }

        public static void process_read_employee_checkin_data(
            IObjectSpace objectSpace,
            string fileSavePath,
            string configFilePath)
        {
            using (var stream = File.Open(fileSavePath, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    });

                    if (dataSet.Tables.Count > 0)
                    {
                        SheetTemplateImport templateImport = new SheetTemplateImport(configFilePath);

                        DataTable table = dataSet.Tables[templateImport.SheetName];

                        foreach (var column in templateImport.Columns)
                        {
                            if (!string.IsNullOrWhiteSpace(column.excelHeader))
                            {
                                table.Columns[column.excelHeader].ColumnName = column.propertyName;
                            }
                        }

                        process_map_employee_checkin_data(
                            objectSpace,
                            table,
                            out List<EmployeeCheckIn> designations);
                    }
                }
            }
        }

        public static void process_map_employee_checkin_data(
            IObjectSpace objectSpace,
            DataTable checkInDatatable,
            out List<EmployeeCheckIn> mapResult)
        {
            mapResult = new List<EmployeeCheckIn>();
            var employees = objectSpace.GetObjects<Employee>();

            string empID = string.Empty;
            Employee existEmployee = null;

            foreach (DataRow row in checkInDatatable.Rows)
            {
                if (empID != row["Code"]?.ToString())
                {
                    empID = row["Code"]?.ToString();
                    existEmployee = employees.Where(item => item.Code == empID).FirstOrDefault();
                }

                var checkinRequest = objectSpace.CreateObject<EmployeeCheckIn>();
                checkinRequest.SetMemberValue("Employee", existEmployee);
                checkinRequest.SetMemberValue("AttendanceDeviceID", row["AttendanceDeviceID"]?.ToString());
                checkinRequest.SetMemberValue("Date", row["Date"]);
                checkinRequest.SetMemberValue("Time", row["Time"]);

                mapResult.Add(checkinRequest);
            }
        }

        public static void process_read_department_data(
            IObjectSpace objectSpace,
            string fileSavePath,
            string configFilePath)
        {
            using (var stream = File.Open(fileSavePath, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {

                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    });

                    if (dataSet.Tables.Count > 0)
                    {
                        SheetTemplateImport templateImport = new SheetTemplateImport(configFilePath);

                        DataTable table = dataSet.Tables[templateImport.SheetName];

                        foreach (var column in templateImport.Columns)
                        {
                            if (!string.IsNullOrWhiteSpace(column.excelHeader))
                            {
                                table.Columns[column.excelHeader].ColumnName = column.propertyName;
                            }
                        }

                        ///Map data from excel to bussiness object
                        process_map_department_data(
                            objectSpace,
                            table,
                            out List<Department> deparments);
                    }
                }
            }
        }

        public static void process_map_department_data(
            IObjectSpace objectSpace,
            DataTable deparmentDataTable,
            out List<Department> mapResult)
        {
            mapResult = new List<Department>();

            var groups = objectSpace.GetObjects<Group>();
            string groupCode = string.Empty;
            Group existGroup = null;

            foreach (DataRow row in deparmentDataTable.Rows)
            {

                if (groupCode != row["Group"]?.ToString())
                {
                    groupCode = row["Group"]?.ToString();
                    existGroup = groups.Where(item => item.Code == groupCode).FirstOrDefault();
                }

                if (existGroup != null)
                {
                    var department = objectSpace.CreateObject<Department>();
                    department.SetMemberValue("Code", row["Code"]?.ToString());
                    department.SetMemberValue("Name", row["Name"]?.ToString());
                    department.SetMemberValue("Group", existGroup);
                    mapResult.Add(department);
                }
            }
        }

        public static void process_read_group_data(
            IObjectSpace objectSpace,
            string fileSavePath,
            string configFilePath
            )
        {
            using (var stream = File.Open(fileSavePath, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {

                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    });

                    if (dataSet.Tables.Count > 0)
                    {
                        SheetTemplateImport templateImport = new SheetTemplateImport(configFilePath);

                        DataTable table = dataSet.Tables[templateImport.SheetName];

                        foreach (var column in templateImport.Columns)
                        {
                            if (!string.IsNullOrWhiteSpace(column.excelHeader))
                            {
                                table.Columns[column.excelHeader].ColumnName = column.propertyName;
                            }
                        }

                        ///Map data from excel to bussiness object
                        process_map_group_data(
                            objectSpace,
                            table,
                            out List<Group> groups);
                    }
                }
            }
        }

        public static void process_map_group_data(
            IObjectSpace objectSpace,
            DataTable groupDataTable,
            out List<Group> mapResult)
        {
            mapResult = new List<Group>();

            foreach (DataRow row in groupDataTable.Rows)
            {
                var group = objectSpace.CreateObject<Group>();
                group.SetMemberValue("Name", row["Name"]);
                group.SetMemberValue("Code", row["Code"]);
                mapResult.Add(group);
            }
        }

        public static void process_read_job_data(
            IObjectSpace objectSpace,
            string fileSavePath,
            string configFilePath)
        {
            using (var stream = File.Open(fileSavePath, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    });

                    if (dataSet.Tables.Count > 0)
                    {
                        SheetTemplateImport templateImport = new SheetTemplateImport(configFilePath);

                        DataTable table = dataSet.Tables[templateImport.SheetName];

                        foreach (var column in templateImport.Columns)
                        {
                            if (!string.IsNullOrWhiteSpace(column.excelHeader))
                            {
                                table.Columns[column.excelHeader].ColumnName = column.propertyName;
                            }
                        }

                        ///Map data from excel to bussiness object
                        process_map_job_data(
                            objectSpace,
                            table,
                            out List<Job> jobs);
                    }
                }
            }
        }

        public static void process_map_job_data(
            IObjectSpace objectSpace,
            DataTable jobDataTable,
            out List<Job> mapResult)
        {
            mapResult = new List<Job>();
            foreach (DataRow row in jobDataTable.Rows)
            {
                var job = objectSpace.CreateObject<Job>();
                job.SetMemberValue("Name", row["Name"]);
                job.SetMemberValue("Code", row["Code"]);
                mapResult.Add(job);
            }
        }

        public static void process_read_designation_data(
            IObjectSpace objectSpace,
            string fileSavePath,
            string configFilePath)
        {
            using (var stream = File.Open(fileSavePath, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {

                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    });

                    if (dataSet.Tables.Count > 0)
                    {
                        SheetTemplateImport templateImport = new SheetTemplateImport(configFilePath);

                        DataTable table = dataSet.Tables[templateImport.SheetName];

                        foreach (var column in templateImport.Columns)
                        {
                            if (!string.IsNullOrWhiteSpace(column.excelHeader))
                            {
                                table.Columns[column.excelHeader].ColumnName = column.propertyName;
                            }
                        }

                        ///Map data from excel to bussiness object
                        process_map_designation_data(
                            objectSpace,
                            table,
                            out List<Designation> designations);
                    }
                }
            }
        }
        
        public static void process_map_designation_data(
            IObjectSpace objectSpace,
            DataTable jobDataTable,
            out List<Designation> mapResult)
        {
            mapResult = new List<Designation>();
            foreach (DataRow row in jobDataTable.Rows)
            {
                var designation = objectSpace.CreateObject<Designation>();
                designation.SetMemberValue("Name", row["Name"]);
                designation.SetMemberValue("Code", row["Code"]);
                mapResult.Add(designation);
            }
        }

        public static void process_read_health_insurrance_register_place_data(
            IObjectSpace objectSpace,
            string fileSavePath,
            string configFilePath)
        {
            using (var stream = File.Open(fileSavePath, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {

                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    });

                    if (dataSet.Tables.Count > 0)
                    {
                        SheetTemplateImport templateImport = new SheetTemplateImport(configFilePath);

                        DataTable table = dataSet.Tables[templateImport.SheetName];

                        foreach (var column in templateImport.Columns)
                        {
                            if (!string.IsNullOrWhiteSpace(column.excelHeader))
                            {
                                table.Columns[column.excelHeader].ColumnName = column.propertyName;
                            }
                        }

                        ///Map data from excel to bussiness object
                        process_map_health_insurrance_register_place_data(
                            objectSpace,
                            table,
                            out List<HealthInsuranceRegisterPlace> mapResult);
                    }
                }
            }
        }
        
        public static void process_map_health_insurrance_register_place_data(
            IObjectSpace objectSpace,
            DataTable healthInsurranceRegisterPlaceDataTable,
            out List<HealthInsuranceRegisterPlace> mapResult)
        {
            var provinces = objectSpace.GetObjects<Province>();

            string provinceCode = string.Empty;
            Province province = null;

            mapResult = new List<HealthInsuranceRegisterPlace>();

            foreach (DataRow row in healthInsurranceRegisterPlaceDataTable.Rows)
            {
                if (provinceCode != row["Province"]?.ToString())
                {
                    provinceCode = row["Province"]?.ToString();
                    province = provinces
                        .Where(item => item.Code == provinceCode)
                        .FirstOrDefault();
                }

                if (province != null)
                {
                    HealthInsuranceRegisterPlace healthInsuranceRegisterPlace =
                        objectSpace.CreateObject<HealthInsuranceRegisterPlace>();

                    healthInsuranceRegisterPlace.SetMemberValue("Name", row["Name"]?.ToString());
                    healthInsuranceRegisterPlace.SetMemberValue("Code", row["Code"]?.ToString());
                    healthInsuranceRegisterPlace.SetMemberValue("Province", province);

                    mapResult.Add(healthInsuranceRegisterPlace);
                }
            }
        }

        public static void process_read_employee_contact_data(
            IObjectSpace objectSpace,
            string fileSavePath,
            string configFilePath)
        {
            using (var stream = File.Open(fileSavePath, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {

                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    });

                    if (dataSet.Tables.Count > 0)
                    {
                        SheetTemplateImport templateImport = new SheetTemplateImport(configFilePath);

                        DataTable table = dataSet.Tables[templateImport.SheetName];

                        foreach (var column in templateImport.Columns)
                        {
                            if (!string.IsNullOrWhiteSpace(column.excelHeader))
                            {
                                table.Columns[column.excelHeader].ColumnName = column.propertyName;
                            }
                        }

                        processs_map_employee_contact_data(
                            objectSpace,
                            table,
                            out List<EmployeeContact> mapResult);
                    }
                }
            }
        }

        public static void processs_map_employee_contact_data(
            IObjectSpace objectSpace,
            DataTable employeeContactDataTable,
            out List<EmployeeContact> mapResult)
        {
            mapResult = new List<EmployeeContact>();
            var employees = objectSpace.GetObjects<Employee>(
                CriteriaOperator.Parse("[HasLeft] = ?", false));

            Employee employee = null;
            string EmpID = string.Empty;

            foreach (DataRow row in employeeContactDataTable.Rows)
            {
                if(EmpID != row["Code"]?.ToString())
                {
                    EmpID = row["Code"]?.ToString();
                    employee = employees
                        .FirstOrDefault(item => item.Code == EmpID);
                }   
                
                if(employee != null)
                {
                    var contact = objectSpace.CreateObject<EmployeeContact>();

                    contact.SetMemberValue("Employee", employee);
                    contact.SetMemberValue("PersonalPhone",row["PersonalPhone"]?.ToString());
                    contact.SetMemberValue("PersonalEmail", row["PersonalEmail"]?.ToString());
                    contact.SetMemberValue("CompanyPhone", row["CompanyPhone"]?.ToString());
                    contact.SetMemberValue("CompanyEmail", row["CompanyEmail"]?.ToString());
                    contact.SetMemberValue("OriginAddress", row["OriginAddress"]?.ToString());
                    contact.SetMemberValue("TemporaryAddress", row["TemporaryAddress"]?.ToString());

                    mapResult.Add(contact);
                }    
            }    
        }

        public static void process_read_employee_bank_account_data(
            IObjectSpace objectSpace,
            string fileSavePath,
            string configFilePath)
        {
            using (var stream = File.Open(fileSavePath, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {

                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    });

                    if (dataSet.Tables.Count > 0)
                    {
                        SheetTemplateImport templateImport = new SheetTemplateImport(configFilePath);

                        DataTable table = dataSet.Tables[templateImport.SheetName];

                        foreach (var column in templateImport.Columns)
                        {
                            if (!string.IsNullOrWhiteSpace(column.excelHeader))
                            {
                                table.Columns[column.excelHeader].ColumnName = column.propertyName;
                            }
                        }

                        processs_map_employee_bank_account_data(
                            objectSpace,
                            table,
                            out List<EmployeeBankAccount> mapResult);
                    }
                }
            }
        }

        public static void processs_map_employee_bank_account_data(
            IObjectSpace objectSpace,
            DataTable employeeBankAcountDataTable,
            out List<EmployeeBankAccount> mapResult)
        {
            mapResult = new List<EmployeeBankAccount>();
            var employees = objectSpace.GetObjects<Employee>(
                CriteriaOperator.Parse("[HasLeft] = ?", false));
            var banks = objectSpace.GetObjects<Bank>();

            Employee employee = null;
            Bank bank = null;
            string EmpID = string.Empty;
            string bankName = string.Empty;

            foreach (DataRow row in employeeBankAcountDataTable.Rows)
            {
                if (EmpID != row["Code"]?.ToString())
                {
                    EmpID = row["Code"]?.ToString();
                    employee = employees
                        .FirstOrDefault(item => item.Code == EmpID);
                }

                if (bankName != row["Bank"]?.ToString())
                {
                    bankName = row["Bank"]?.ToString();
                    bank = banks
                        .FirstOrDefault(item => item.Name.ToUpper() == bankName.ToUpper());
                }

                if (employee != null && bank != null)
                {
                    var account = objectSpace.CreateObject<EmployeeBankAccount>();

                    account.SetMemberValue("Employee", employee);
                    account.SetMemberValue("Bank", bank);
                    account.SetMemberValue("Account", row["Account"]?.ToString());
                    account.SetMemberValue("BranchName", row["BranchName"]?.ToString());

                    mapResult.Add(account);
                }
            }
        }
    }
}
