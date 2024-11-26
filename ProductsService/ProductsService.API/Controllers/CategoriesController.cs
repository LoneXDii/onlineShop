﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsService.Application.DTO;
using ProductsService.Application.UseCases.CategoryUseCases.Queries.GetAllCategories;
using ProductsService.Application.UseCases.CategoryUseCases.Queries.GetCategoryAttributes;

namespace ProductsService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryDTO>>> GetCategories(CancellationToken cancellationToken)
    {
        var categories = await _mediator.Send(new GetAllCategoriesReguest(), cancellationToken);

        return Ok(categories);
    }

    [HttpGet]
    [Route("attributes")]
    public async Task<ActionResult<List<AttributeDTO>>> GetCategoryAttributes([FromQuery] GetCategoryAttributesRequest request,
        CancellationToken cancellationToken)
    {
       var attributes = await _mediator.Send(request, cancellationToken);

        return Ok(attributes);
    }
}
