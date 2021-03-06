﻿namespace MTS.PL.Web.Blazor.Client.Utils
{
    public class BlazorConstants
    {
        public const string UNDER_CONSTRUCTION_TITLE = "Under construction";
        public const string UNDER_CONSTRUCTION_MESSAGE = "This part or page is under construction and is therefore unavailible to you.\nThank you for your patience.";
        public const string UNDER_CONSTRUCTION_MESSAGE_AVAILIBLE = "This part or page is under construction and might therefore misbehave.\nThank you for your understanding.";

        public class HttpClients
        {
            public const string API = "httpclientapi";
        }


        public class Pages
        { 
            public class Account
            {
                public const string CRUD_ACCOUNT = "/account/crud/crudusers";
                public const string EDIT_ACCOUNT = "/account/edit";
                public const string CONFIRM_EMAIL = "/account/register/confirmemail";
                public const string REGISTER = "/account/register";
            }

            public class Authentication
            {
                public const string UNAUTHORIZED = "/authentication/unauthorized";
                public const string AUTHORIZING = "/authentication/authorizing";
                public const string TOKEN_EXPIRED = "/authentication/tokenexpired";
                public const string LOGIN = "/authentication/login";
                public const string LOGOUT = "/authentication/logout";
            }

            public class Error
            {
                public const string NOT_FOUND = "/error/notfound";
            }

            public class CloudStorage
            {
                public const string PERSONAL_CLOUD_STORAGE = "/cloudstorage/personalstorage";
            }

            public class Feedback
            {
                public const string FEEDBACK = "/Feedback";
            }

            public const string CREDITS = "/credits";
            public const string INDEX = "/";
        }
    }
}
