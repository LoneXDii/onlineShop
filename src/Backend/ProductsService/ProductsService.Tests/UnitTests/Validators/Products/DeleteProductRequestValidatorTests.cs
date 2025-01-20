﻿using ProductsService.Application.UseCases.ProductUseCases.Commands.DeleteProduct;
using ProductsService.Application.Validators.Products;

namespace ProductsService.Tests.UnitTests.Validators.Products;

public class DeleteProductRequestValidatorTests
{
    private readonly DeleteProductRequestValidator _validator = new();

    [Fact]
    public void Validate_WhenProductIdIsZero_ShouldReturnFalseWithCorrectErrorMessage()
    {
        //Arrange
        var request = new DeleteProductRequest(0);

        //Act
        var result = _validator.Validate(request);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal("Wrong product id", result.Errors[0].ErrorMessage);
    }

    [Fact]
    public void Validate_WhenProductIdIsNegative_ShouldReturnFalseWithCorrectErrorMessage()
    {
        //Arrange
        var request = new DeleteProductRequest(-1);

        //Act
        var result = _validator.Validate(request);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal("Wrong product id", result.Errors[0].ErrorMessage);
    }

    [Fact]
    public void Validate_WhenProductIdIsValid_ShouldReturnTrueWithNoErrors()
    {
        //Arrange
        var request = new DeleteProductRequest(1);

        //Act
        var result = _validator.Validate(request);

        //Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }
}