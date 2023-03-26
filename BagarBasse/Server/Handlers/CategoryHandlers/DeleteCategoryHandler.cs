using BagarBasse.Server.Requests.CategoryRequest;
using MediatR;
using BagarBasse.Server.Services.CategoryService;

namespace BagarBasse.Server.Handlers.CategoryHandlers;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest, IResult>
{
    private readonly ICategoryService _categoryService;

    public DeleteCategoryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    public async Task<IResult> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        var result = await _categoryService.DeleteCategoryAsync(request.Id);
        return result;
    }
}