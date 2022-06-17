﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        //List<Notification> GetNotifications();
        //void Handle(Notification notification);
        void Handle(string notification);
    }
}
