using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ZombieSurvivalSocialNetwork.Models;
using Microsoft.Extensions.DependencyInjection;
using ZombieSurvivalSocialNetwork.Core.Application.Features.Reports.Queries;
using SHOPRURETAIL.Application.Features.Customers.Queries;

namespace ZombieSurvivalSocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        private IMediator _mediator;
        private readonly ILogger<HomeController> _logger;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Report()
        {
            try
            {
                var response = await Mediator.Send(new GenerateReportQuery());
                return View(response.Data);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<IActionResult> Survivors()
        {
            try
            {
                var response = await Mediator.Send(new GetSurvivorsQuery());
                return View(response.Data);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
