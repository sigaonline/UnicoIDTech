using Microsoft.VisualStudio.TestTools.UnitTesting;
using MODELO.Desafio.Model.Exceptions;
using MODELO.Desafio.MStest.Builders.Contracts;
using MODELO.Desafio.MStest.Builders.Entities;
using MODELO.Desafio.MStest.Mocks;
using System;
using System.Threading.Tasks;

namespace MODELO.Desafio.MStest.Tests
{
    [TestClass]
    public class FairUpdaterTests : BaseTest
    {

        [TestMethod]
        public async Task Success_ExistsFair()
        {
            var request = new FairRequestBuilder().Default().Build();
            request.Id = 99999;
            var result = await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () =>await _fairUpdater.SaveAsync(request));
            Assert.IsTrue(result.Message.Contains("Value cannot be null. (Parameter 'key')"));
        }
        
        [TestMethod]
        public async Task Success_SaveFair()
        {
            var request = new FairRequestBuilder().Default().Build();
            _mockMapper.MockMapperFair(new FairBuilder().Default().Build());
            var result = await _fairUpdaterMock.SaveAsync(request);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public async Task Success_SaveFair_ExistsFair()
        {
            _mockfairProvider.MockGetByFairNameAsync(new FairResultBuilder().Default().Build());
            var request = new FairRequestBuilder().Default().Build();
            request.NameFair = "nome da feira";
            _mockMapper.MockMapperFair(new FairBuilder().Default().Build());
            var result = await Assert.ThrowsExceptionAsync<BusinessException>(async () => await _fairUpdaterMock.SaveAsync(request));
            Assert.IsTrue(result.Message.Contains("Feira já existe na base de dados!"));
        }

        [TestMethod]
        public async Task Success_Update_NotExistsFair()
        {
            var request = new FairRequestBuilder().Default().Build();
            request.Id = 3;
            var result = await Assert.ThrowsExceptionAsync<BusinessException>(async () => await _fairUpdater.UpdateAsync(request));
            Assert.IsTrue(result.Message.Contains("Feira não existe na base de dados!"));
        }
        [TestMethod]
        public async Task Success_Update()
        {
            _mockfairProvider.MockGetByIdAsync(new FairResultBuilder().Default().Build());
            _mockMapper.MockMapperFair(new FairBuilder().Default().Build());
            var request = new FairRequestBuilder().Default().Build();
            request.NameFair = "alteração";
            var result = await _fairUpdaterMock.UpdateAsync(request);
            Assert.IsNotNull(result);
        }
    }
}
