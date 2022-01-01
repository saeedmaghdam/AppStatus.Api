using System;
using System.Collections.Generic;
using System.Linq;
using AppStatus.Api.Framework.Services.Company;

namespace AppStatus.Api.Controllers.Company.ViewModels
{
    public class CompanyViewModel
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

        public string Url
        {
            get;
            set;
        }

        public string[] Emails
        {
            get;
            set;
        }

        public string[] PhoneNumbers
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public static IEnumerable<CompanyViewModel> ToViewModel(IEnumerable<ICompany> companies)
        {
            return companies.Select(x => new CompanyViewModel()
            {
                Address = x.Address,
                CreatorAccountId = x.CreatorAccountId,
                Emails = x.Emails,
                Id = x.Id,
                Name = x.Name,
                PhoneNumbers = x.PhoneNumbers,
                RecordInsertDate = x.RecordInsertDate,
                RecordLastEditDate = x.RecordLastEditDate,
                RecordStatus = x.RecordStatus,
                Url = x.Url
            });
        }
    }
}
