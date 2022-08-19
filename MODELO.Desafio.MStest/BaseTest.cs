using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MODELO.Desafio.API;
using MODELO.Desafio.DAL;
using MODELO.Desafio.DAL.Interface.Entities;
using MODELO.Desafio.Model.Validators;
using MODELO.Desafio.MStest.Builders.Entities;
using MODELO.Desafio.Service.Interface.Providers;
using MODELO.Desafio.Service.Interface.Updaters;
using MODELO.Desafio.Service.Providers;
using MODELO.Desafio.Service.Updaters;
using Moq;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace MODELO.Desafio.MStest
{
    public class InMemoryDbContextFactory
    {
        public DataBaseContext GetDbContext()
        {

            var options = new DbContextOptionsBuilder<DataBaseContext>()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString())
                            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                            .Options
                            ;
            var dbContext = new DataBaseContext(options);

            return dbContext;
        }
    }

    public class BaseTest : WebApplicationFactory<Startup>
    {
        protected static DataBaseContext _dbContext;
        protected Mock<IMapper> _mockMapper;
        protected IFairProvider _fairProvider;
        protected IFairUpdater _fairUpdater;
        protected IFairUpdater _fairUpdaterMock;
        protected FairRequestValidator _fairRequestValidator;
        protected Mock<IFairProvider> _mockfairProvider;

        protected IMapper _mapper => _mockMapper.Object;

        public readonly HttpClient client;
        protected ServiceProvider serviceProvider { get; set; }

        public BaseTest()
        {
            if (_dbContext == null)
            {
                _dbContext = new InMemoryDbContextFactory().GetDbContext();

                LoadFairs();
            }
            LoadMocks();

        }

        private void LoadFairs()
        {
            try
            {
                var entity = new FairBuilder().Default().Build();
                entity.Id = 99999;
                _dbContext.Fairs.Add(entity);
                _dbContext.SaveChanges();
                _dbContext.Entry(entity).State = EntityState.Detached;


            }
            catch (System.Exception)
            {
            }
        }
        private void LoadMocks()
        {
            _mockMapper = new Mock<IMapper>();
            _fairRequestValidator = new FairRequestValidator();
            _mockfairProvider = new Mock<IFairProvider>(); 
            _fairProvider = new FairProvider(_dbContext, _mockMapper.Object);
            _fairProvider = new FairProvider(_dbContext, _mockMapper.Object);
            _fairUpdater = new FairUpdater(_dbContext, _mockMapper.Object, _fairRequestValidator, _fairProvider);
            _fairUpdaterMock = new FairUpdater(_dbContext, _mapper, _fairRequestValidator, _mockfairProvider.Object);
        }
    }
}
