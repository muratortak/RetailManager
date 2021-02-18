﻿using RMDesktopUI.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticateUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
        HttpClient ApiClient { get; }
    }
}