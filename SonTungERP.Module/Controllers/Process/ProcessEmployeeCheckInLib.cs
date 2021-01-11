using DevExpress.ExpressApp;
using SonTungERP.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonTungERP.Module.Controllers.Process
{
    public class ProcessEmployeeCheckInLib
    {
        public static void process_add_multi_checkin(
           IObjectSpace objectSpace,
           List<Employee> employees,
           DateTime? Date,
           DateTime? TimeIn,
           DateTime? TimeOut)
        {
            foreach (Employee employee in employees)
            {
                if (Date != null)
                {
                    var addedEmployee = objectSpace.GetObjectByKey<Employee>(employee.Oid);

                    if (TimeIn != null)
                    {
                        var addedCheckIn = objectSpace.CreateObject<EmployeeCheckIn>();
                        addedCheckIn.Employee = addedEmployee;
                        addedCheckIn.Date = (DateTime)Date;
                        addedCheckIn.Time = ((DateTime)Date).Date.Add(((DateTime)TimeIn).TimeOfDay);
                    }

                    if (TimeOut != null)
                    {
                        var addedCheckOut = objectSpace.CreateObject<EmployeeCheckIn>();
                        addedCheckOut.Employee = addedEmployee;
                        addedCheckOut.Date = (DateTime)Date;
                        addedCheckOut.Time = ((DateTime)Date).Date.Add(((DateTime)TimeOut).TimeOfDay);
                    }
                }
            }
        }
    }
}
