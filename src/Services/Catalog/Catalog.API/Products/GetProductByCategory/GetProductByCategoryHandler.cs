﻿using Catalog.API.Products.GetProduct;

namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;
public record GetProductByCategoryResult(IEnumerable<Product> Products);
internal class GetProductByCategoryQueryHandler
    (
        IDocumentSession session
        //, ILogger<GetProductsQueryHandler> logger
    )
    : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult>
        Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        //logger.LogInformation("GetProductByCategoryQueryHandler.Handle : called with {@Query}", query);
        var products = await session.Query<Product>()
            .Where( p => p.Category.Contains(query.Category))
            .ToListAsync();
            //.ToPagedListAsync(
            //    query.PageNumber ?? 1,
            //    query.PageSize ?? 10,
            //    cancellationToken
            //);

        return new GetProductByCategoryResult(products);
    }
}