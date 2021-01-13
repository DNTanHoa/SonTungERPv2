using DevExpress.ExpressApp;
using SonTungERP.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.Controllers.Process
{
    public class ProcessShiftAssignmentLib
    {
        public static void process_add_multi_shift(
            IObjectSpace objectSpace,
            DateTime startDate,
            DateTime? endDate,
            ShiftType shiftType,
            List<Employee> employees)
        {
            var shift = objectSpace.GetObjectByKey<ShiftType>(shiftType.Oid);

            foreach(var employee in employees)
            {
                var assignment = objectSpace.CreateObject<ShiftAssigment>();
                assignment.Employee = objectSpace.GetObjectByKey<Employee>(employee.Oid);
                assignment.ShiftType = shift;
                assignment.StartDate = startDate;
                assignment.EndDate = endDate;
            }
        }
    }
}
