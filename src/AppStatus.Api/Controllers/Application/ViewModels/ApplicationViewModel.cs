using System;
using System.Collections.Generic;
using System.Linq;
using AppStatus.Api.Controllers.Company.ViewModels;
using AppStatus.Api.Controllers.Employee.Models;
using AppStatus.Api.Framework.Services.Application;

namespace AppStatus.Api.Controllers.Application.ViewModels
{
    public class ApplicationViewModel
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

        public string JobTitle
        {
            get;
            set;
        }

        public string Salary
        {
            get;
            set;
        }

        public CompanyViewModel Company
        {
            get;
            set;
        }

        public IEnumerable<EmployeeViewModel> Employees
        {
            get;
            set;
        }

        public short StateId
        {
            get;
            set;
        }

        public string State
        {
            get;
            set;
        }

        public string ApplySource
        {
            get;
            set;
        }

        public string ResumeId
        {
            get;
            set;
        }

        public string CoverLetterId
        {
            get;
            set;
        }

        public string[] History
        {
            get;
            set;
        }

        public static IEnumerable<ApplicationViewModel> ToViewModel(IEnumerable<IApplication> applications)
        {
            return applications.Select(x => new ApplicationViewModel()
            {
                JobTitle = x.JobTitle,
                Salary = x.Salary,
                Company = x.Company == null ? null : CompanyViewModel.ToViewModel(new[] { x.Company }).First(),
                Employees = x.Employees == null ? null : EmployeeViewModel.ToViewModel(x.Employees),
                ApplySource = x.ApplySource,
                CoverLetterId = x.CoverLetterId,
                History = x.History,
                Id = x.Id,
                RecordInsertDate = x.RecordInsertDate,
                RecordLastEditDate = x.RecordLastEditDate,
                RecordStatus = x.RecordStatus,
                ResumeId = x.ResumeId,
                State = x.State,
                StateId = x.StateId
            });
        }
    }
}
