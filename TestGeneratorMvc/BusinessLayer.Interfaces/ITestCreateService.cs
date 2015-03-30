﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.ApiModel;

namespace BusinessLayer.Interfaces
{
    public interface ITestCreateService
    {
        List<ApiShowQuestion> GetQuestions();

        void CreateTest(ApiCreateTest test);
    }
}
