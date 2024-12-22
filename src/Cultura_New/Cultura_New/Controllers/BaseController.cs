﻿using Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace Cultura_New.Controllers
{
    [Controller]
    public abstract class BaseController : ControllerBase
    {
        //returns the current authenticated account (null if not logged in)
        public User user => (User)HttpContext.Items["User"];
    }
}