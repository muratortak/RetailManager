﻿using System;

namespace RMDesktopUI.Library.Models
{
    public interface ILoginUserModel
    {
        DateTime CreatedDate { get; set; }
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string Id { get; set; }
        string LastName { get; set; }
        string Token { get; set; }
        void ResetUserModel();
    }
}