using AutoMapper;
using MODELO.Desafio.DAL.Interface.Entities;
using MODELO.Desafio.Model.Request;
using Moq;

namespace MODELO.Desafio.MStest.Mocks
{
    public static class MockMapper
    {
        public static Mock<IMapper> MockMapperFair(this Mock<IMapper> mock, Fair @return)
        {
            mock.Setup(x => x.Map<Fair>(It.IsAny<FairRequest>())).Returns(@return); ;
            return mock;
        }
    }
}
