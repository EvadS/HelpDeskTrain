using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskTrain.Models
{
    // Перечисление для приоритета заявки
    public enum RequestPriority
    {
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4
    }
}