using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjetoTeste.Api.Controllers;
using ProjetoTeste.Api.Tests.Helpers;
using ProjetoTeste.Infra.Services.Abstraction;
using System.Net;
using Xunit;

namespace ProjetoTeste.Api.Tests
{
    public class ProdutosControllerTests
    {
        private readonly Mock<IProductService> _productServiceMock;
        private readonly ProdutosController _controller;

        public ProdutosControllerTests()
        {
            _productServiceMock = new Mock<IProductService>();
            _controller = new ProdutosController(_productServiceMock.Object);
        }

        [Fact]
        public void Get_ReturnExpectedStatusCode()
        {
            var actionResult = _controller.Get().Result;
            actionResult.Result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public void Get_ReturnExpectedStatusRoute()
        {
            const string expectedRoute = "api/[controller]/";
            var route = RouteHelperController.GetRoute<ProdutosController>(nameof(ProdutosController.Get));

            route.Should().Be(expectedRoute);
        }

        [Fact]
        public void Get_VerifyServiceWasCalled()
        {
            _ = _controller.Get().Result;

            _productServiceMock.Verify(t => t.ObterTodosProdutos(), Times.Once, "ObterTodosProdutos não foi invocado.");
        }
    }
}
