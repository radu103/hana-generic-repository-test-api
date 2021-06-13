using HanaGenericRepository;
using Microsoft.AspNetCore.Mvc;
using Sap.Data.Hana;
using System;
using System.Collections.Generic;
using TestAPIWithHanaGenericRepository.Models;

namespace TestAPIWithHanaGenericRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private HanaConnectionInfo _hanaConnInfo = null;
        private HanaConnection _hanaConnection = null;
        private bool _preventSqlInjection = true;

        private HanaGenericRepository<Model1> repo1 = null;

        public ModelController()
        {
            _hanaConnInfo = new HanaConnectionInfo()
            {
                Tenant = "HXE",
                UserName = "D118DA114BA14CA5AA1ECF261DBAE68B_183JN8QS8E7HWULO7SL3FNIUQ_RT",
                Password = "Wk98eti9PfZt0UDYB90nFHXExBkV0H19A4COXLwkzGVf5TAelMQOU-U1AhzhRh_rMlTRlqNaOW8y1nRbES-ddKyzeOikp_n_0bM4gxOTwGB.FeFX062GBnUiMzha89pe",
                Schema = "D118DA114BA14CA5AA1ECF261DBAE68B",
                Host = "hxehost",
                Port = 39015
            };

            var connFactory = new HanaDbConnectionFactory();
            _hanaConnection = connFactory.CreateConnection(_hanaConnInfo);
            repo1 = new HanaGenericRepository<Model1>(_hanaConnection, _preventSqlInjection);
        }

        [HttpGet]
        public List<Model1> GetModel1Objects()
        {
            var count = repo1.Count();
            if(count == 0)
            {
                var newRecord = new Model1()
                {
                    Active = true,
                    DateTimeValue = DateTime.Now,
                    Email = "test@test.com",
                    Id = Guid.NewGuid(),
                    IntValue = 1,
                    Name = "name",
                    NotMappedProperty = "does not persist",
                    NotMappedProperty2 = 2f
                };
                var ok = repo1.Create(newRecord);
            }

            var models = repo1.GetPaged();            
            return models;
        }
    }
}