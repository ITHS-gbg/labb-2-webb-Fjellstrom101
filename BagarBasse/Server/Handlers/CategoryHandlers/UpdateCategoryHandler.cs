using BagarBasse.Server.Requests.CategoryRequest;
using BagarBasse.Server.Services.CategoryService;
using BagarBasse.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace BagarBasse.Server.Handlers.CategoryHandlers;

[Authorize(Roles = "Admin")]
public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest, IResult>
{
    private readonly ICategoryService _categoryService;

    public UpdateCategoryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IResult> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var result = await _categoryService.UpdateCategoryAsync(request.Category);
        return result != null ? TypedResults.Ok(result) : TypedResults.NotFound("Category not found");
    }
}