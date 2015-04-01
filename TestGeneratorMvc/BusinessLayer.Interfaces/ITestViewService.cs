﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.ApiModel;

namespace BusinessLayer.Interfaces
{
    public interface ITestViewService
    {
        List<ApiShowTest> GetTests();

        List<ApiShowTest> GetTestsWithUsers();

        int GetTestCount();
    }
}
