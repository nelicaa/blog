﻿using projekatASP.application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.application.UseCases.Queries.Users
{
   public interface IGetUser : IQuery<int, UserDTO>
    {
    }
}
