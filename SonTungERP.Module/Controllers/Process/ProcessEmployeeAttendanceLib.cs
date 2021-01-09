using SonTungERP.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SonTungERP.Module.Controllers.Process
{
    public class ProcessEmployeeAttendanceLib
    {
        public static void process_get_actual_in_out_time(
            Employee employee,
            DateTime date,
            List<EmployeeCheckIn> checkIns,
            ShiftType shiftType,
            out DateTime? InTime,
            out DateTime? OutTime)
        {
            InTime = null;
            OutTime = null;

            var employeeCheckIns = checkIns
                .Where(item => item.Employee == employee &&
                       item.Date.Date == date.Date);
            
            if(!shiftType.IsOvernight)
            {

            }    
            else
            {
                var temp = employeeCheckIns.FirstOrDefault();

                if (temp != null)
                {
                    if(shiftType.AllowInTime != null)
                    {
                        if (temp.Time.TimeOfDay > ((DateTime)shiftType.AllowInTime).TimeOfDay)
                        {

                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        //InTime = (DateTime)temp;
                    }
                }
                else
                    InTime = null;

                OutTime = employeeCheckIns.LastOrDefault()?.Time;
            }
        }


        public ShiftType process_get_employee_shift_by_date(
            Employee employee,
            List<ShiftAssigment> shiftAssigments,
            DateTime date)
        {
            var employeeShift = shiftAssigments
                .OrderByDescending(item => item.StartDate)
                .FirstOrDefault(item => item.Employee == employee && IsValidDateByEndDate(date, item.EndDate));
            return employeeShift != null ? employeeShift.ShiftType : null;
        }


        #region support function

        public bool IsValidDateByEndDate(DateTime date, DateTime? endDate)
        {
            if(endDate != null)
            {
                return date <= endDate ? true : false;
            }
            return true;
        }

        #endregion
    }
}