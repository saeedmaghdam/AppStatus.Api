using System;

namespace AppStatus.Api.Controllers.Application.InputModels
{
    public class PathStateInputModel
    {
        public short StateId
        {
            get;
            set;
        }

        public string LogMessage
        {
            get;
            set;
        }

        public DateTime DateTime
        {
            get;
            set;
        }
    }
}
