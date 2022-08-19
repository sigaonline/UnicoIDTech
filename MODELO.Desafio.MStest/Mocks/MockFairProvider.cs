using MODELO.Desafio.Model.Result;
using MODELO.Desafio.Service.Interface.Providers;
using Moq;

namespace MODELO.Desafio.MStest.Mocks
{
    public static class MockFairProvider 
    {
        public static Mock<IFairProvider> MockGetByIdAsync(this Mock<IFairProvider> mock, FairResult @return)
        {
            mock.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(@return);
            return mock;
        }
        public static Mock<IFairProvider> MockGetByFairNameAsync(this Mock<IFairProvider> mock, FairResult @return)
        {
            mock.Setup(s => s.GetByFairNameAsync(It.IsAny<string>())).ReturnsAsync(@return);
            return mock;
        }
    }
}
