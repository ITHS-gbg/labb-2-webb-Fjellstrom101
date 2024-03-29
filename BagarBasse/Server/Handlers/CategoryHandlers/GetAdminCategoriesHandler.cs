﻿using BagarBasse.Server.Requests.CategoryRequest;
using MediatR;
using BagarBasse.Server.Services.CategoryService;

namespace BagarBasse.Server.Handlers.CategoryHandlers;

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
        return result;
    }
}