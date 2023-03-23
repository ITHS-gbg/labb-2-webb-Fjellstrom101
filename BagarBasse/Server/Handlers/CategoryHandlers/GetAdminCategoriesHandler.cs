using BagarBasse.Server.Requests.CategoryRequest;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using BagarBasse.Server.Services.CategoryService;

namespace BagarBasse.Server.Handlers.CategoryHandlers;

[Authorize(Roles = "Admin")]
public class GetAdminCategoriesHandler : IRequestHandler<GetAdminCategoriesRequest, IResult>
{
    private readonly ICategoryService _categoryService;

    public GetAdminCategoriesHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IResult> Handle(GetAdminCategoriesRequest request, CancellationToken cancellationToken)
    {
        var result = await _categoryService.GetAdminCategoriesAsync();
        return TypedResults.Ok(result);
    }
}