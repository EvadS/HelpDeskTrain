using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskTrain.Models
{
    /// Перечисление для статуса заявки
    public enum RequestStatus
    {
        Open = 1,
        Distributed = 2,
        Proccesing = 3,
        Checking = 4,
        Closed = 5
    }
}