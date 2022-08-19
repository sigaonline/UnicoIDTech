using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace MODELO.Desafio.MStest.Tests
{
    [TestClass]
    public class FairProviderTests : BaseTest
    {

        [TestMethod]
        public async Task Success_GetAllFairs()
        {
            var result = _fairProvider.GetAllAsync();
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public async Task Success_GetFairById()
        {
            var result = _fairProvider.GetByIdAsync(99999);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public async Task Success_GetFairByName()
        {
            var result = _fairProvider.GetByFairNameAsync("nome da feira");
            Assert.IsNotNull(result);
        }

    }
}
