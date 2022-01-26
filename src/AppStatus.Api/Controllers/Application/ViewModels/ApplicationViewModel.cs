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

        public IEnumerable<ApplicationHistoryItemViewModel> History
        {
            get;
            set;
        }

        public IEnumerable<ApplicationToDoItemViewModel> ToDo
        {
            get;
            set;
        }

        public int UnDoneToDoCount
        {
            get;
            set;
        }

        public string Notes
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
                Id = x.Id,
                RecordInsertDate = x.RecordInsertDate,
                RecordLastEditDate = x.RecordLastEditDate,
                RecordStatus = x.RecordStatus,
                ResumeId = x.ResumeId,
                State = x.State,
                StateId = x.StateId,
                History = x.History == null ? null : x.History.Select(x => new ApplicationHistoryItemViewModel()
                {
                    Description = x.Description,
                    Id = x.Id,
                    RecordInsertDate = x.RecordInsertDate,
                    LogDateTime = x.LogDateTime
                }),
                ToDo = x.ToDo == null ? null : x.ToDo.Select(x => new ApplicationToDoItemViewModel()
                {
                    RecordInsertDate = x.RecordInsertDate,
                    Id = x.Id,
                    IsDone = x.IsDone,
                    Title = x.Title
                }),
                UnDoneToDoCount = x.ToDo == null ? 0 : x.ToDo.Count(x => !x.IsDone),
                Notes = x.Notes
            });
        }
    }

    public class ApplicationHistoryItemViewModel
    {
        public string Id
        {
            get;
            set;
        }

        public DateTime RecordInsertDate
        {
            get;
            set;
        }

        public DateTime LogDateTime
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
    }

    public class ApplicationToDoItemViewModel
    {
        public string Id
        {
            get;
            set;
        }

        public DateTime RecordInsertDate
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public bool IsDone
        {
            get;
            set;
        }
    }
}
