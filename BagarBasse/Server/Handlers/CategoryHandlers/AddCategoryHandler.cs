using BagarBasse.Server.Requests.CategoryRequest;
using BagarBasse.Server.Services.CategoryService;
using BagarBasse.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace BagarBasse.Server.Handlers.CategoryHandlers;

public class AddCategoryHandler : IRequestHandler<AddCategoryRequest, IResult>
{
    private readonly ICategoryService _categoryService;

    public AddCategoryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    public async Task<IResult> Handle(AddCategoryRequest request, CancellationToken cancellationToken)
    {
        var result = await _categoryService.AddCategoryAsync(request.Category);
        return TypedResults.Ok(result);
    }
}