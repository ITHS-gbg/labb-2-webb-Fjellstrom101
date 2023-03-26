using BagarBasse.Server.Requests.CategoryRequest;
using BagarBasse.Server.Services.CategoryService;
using MediatR;

namespace BagarBasse.Server.Handlers.CategoryHandlers;

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
        return result;
    }
}