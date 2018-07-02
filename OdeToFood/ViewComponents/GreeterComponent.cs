﻿using Microsoft.AspNetCore.Mvc;
using OdeToFood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
    public class GreeterComponent : ViewComponent
    {
        private IGreeter _greeter;

        public GreeterComponent(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public IViewComponentResult Invoke()
        {
            var model = _greeter.Greet();
            return View("Default", model);
        }
    }
}
