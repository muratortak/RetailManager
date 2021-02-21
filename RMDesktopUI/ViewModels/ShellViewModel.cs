using Caliburn.Micro;
using RMDesktopUI.EventModels;
using RMDesktopUI.Library.Api;
using RMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.ViewModels
{
    // Have the handler specify what events you are listening for
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private SalesViewModel _salesVM;
        private ILoginUserModel _user;
        private IAPIHelper _apiHelper;
        public ShellViewModel(IEventAggregator events, SalesViewModel salesVM, ILoginUserModel user, IAPIHelper apiHelper)
        {
            _events = events;
            _salesVM = salesVM;
            _user = user;
            _apiHelper = apiHelper;

            _events.Subscribe(this);
            ActivateItem(IoC.Get<LoginViewModel>());
        }

        public bool IsLoggedIn
        {
            get
            {
                if (!string.IsNullOrEmpty(_user.Token))
                {
                    return true;
                }

                return false;
            }
        }

        public void ExitApplication()
        {
            TryClose();
        }

        public void LogOut()
        {
            _user.ResetUserModel();
            _apiHelper.LogOffUser();
            ActivateItem(IoC.Get<LoginViewModel>());
            NotifyOfPropertyChange(() => IsLoggedIn);
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_salesVM);
            NotifyOfPropertyChange(() => IsLoggedIn);
        }
    }
}
