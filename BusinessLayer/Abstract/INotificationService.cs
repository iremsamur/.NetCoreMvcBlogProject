﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        List<Notification> GetNotificationsListByStatus();//sadece aktiflik durumu true olan duyuruları getirsin.
    }
}
