﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsService.Application.DTO;
using ProductsService.Application.UseCases.ProductUseCases.Commands.AddProduct;
using ProductsService.Application.UseCases.ProductUseCases.Queries.ListProducts;
using ProductsService.Application.Models;
using ProductsService.Application.UseCases.ProductUseCases.Commands.AddAttributeToProduct;
using ProductsService.Application.UseCases.ProductUseCases.Commands.DeleteAttributeFromProduct;
using ProductsService.Application.UseCases.ProductUseCases.Commands.UpdateProduct;
using ProductsService.Application.UseCases.ProductUseCases.Commands.UpdateProductAttribute;
using ProductsService.Application.UseCases.ProductUseCases.Commands.DeleteProduct;

namespace ProductsService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    //[Authorize(Policy = "admin")]
    public async Task<IActionResult> CreateProduct([FromForm] PostProductDTO product, CancellationToken cancellationToken)
    {
        await _mediator.Send(new AddProductRequest(product), cancellationToken);

        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedListModel<ProductDTO>>> GetProductsListProducts(
        [FromQuery] ListProductsWithPaginationRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);

        return Ok(result);
    }

    [HttpPut]
    //[Authorize(Policy = "admin")]
    public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductDTO productDTO, CancellationToken cancellationToken)
    {
        await _mediator.Send(new UpdateProductRequest(productDTO), cancellationToken);

        return Ok();
    }

    [HttpDelete]
    //[Authorize(Policy = "admin")]
    public async Task<IActionResult> DeleteProduct([FromQuery] DeleteProductRequest request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);

        return Ok();
    }

    [HttpPost]
    [Route("/attrubite")]
    //[Authorize(Policy = "admin")]
    public async Task<IActionResult> AddProductAttribute([FromBody] AddAttributeToProductRequest request,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);

        return Ok();
    }

    [HttpPut]
    [Route("/attribute")]
    //[Authorize(Policy = "admin")]
    public async Task<IActionResult> UpdateProductAttribute([FromBody] UpdateProductAttributeRequest request,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);

        return Ok();
    }

    [HttpDelete]
    [Route("/attribute")]
    //[Authorize(Policy = "admin")]
    public async Task<IActionResult> DeleteProductAttribute([FromQuery] DeleteAttributeFromProductRequest request,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);

        return Ok();
    }
}
