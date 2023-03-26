using BagarBasse.Server.Requests.CategoryRequest;
using BagarBasse.Server.Services.CategoryService;
using MediatR;

namespace BagarBasse.Server.Handlers.CategoryHandlers;

public class GetCategoriesHandler : IRequestHandler<GetCategoriesRequest, IResult>
{
    private readonly ICategoryService _categoryService;

    public GetCategoriesHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    public async Task<IResult> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
    {
        var result = await _categoryService.GetCategoriesAsync();
        return result;
    }
}