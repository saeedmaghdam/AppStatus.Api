﻿using System;

namespace AppStatus.Api.Controllers.Account.ViewModels
{
    public class LoginViewModel
    {
        public string Token
        {
            get;
            set;
        }

        public bool IsSuccessful
        {
            get;
            set;
        }

        public DateTime ExpirationDate
        {
            get;
            set;
        }
    }
}
