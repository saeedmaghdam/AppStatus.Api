using System;
using System.Collections.Generic;
using System.Linq;
using AppStatus.Api.Framework.Services.Employee;

namespace AppStatus.Api.Controllers.Employee.Models
{
    public class EmployeeViewModel
    {
        public string Id
        {
            get;
            set;
        }

        public short RecordStatus
        {
            get;
            set;
        }

        public DateTime RecordInsertDate
        {
            get;
            set;
        }

        public DateTime RecordLastEditDate
        {
            get;
            set;
        }

        public string CreatorAccountId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public short RoleId
        {
            get;
            set;
        }

        public string Role
        {
            get;
            set;
        }

        public string PhoneNumber
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string ProfileUrl
        {
            get;
            set;
        }

        public string PictureId
        {
            get;
            set;
        }

        public static IEnumerable<EmployeeViewModel> ToViewModel(IEnumerable<IEmployee> employees)
        {
            return employees.Select(x => new EmployeeViewModel()
            {
                RecordStatus = x.RecordStatus,
                RecordLastEditDate = x.RecordLastEditDate,
                RecordInsertDate = x.RecordInsertDate,
                Name = x.Name,
                Id = x.Id,
                CreatorAccountId = x.CreatorAccountId,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                PictureId = x.PictureId,
                ProfileUrl = x.ProfileUrl,
                Role = x.Role,
                RoleId = x.RoleId
            });
        }
    }
}
