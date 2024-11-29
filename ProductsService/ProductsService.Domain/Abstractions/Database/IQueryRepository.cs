﻿using ProductsService.Domain.Abstractions.Specifications;
using ProductsService.Domain.Entities.Abstractions;

namespace ProductsService.Domain.Abstractions.Database;

public interface IQueryRepository<T> where T : IEntity
{
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(int id, ISpecification<T>? specification, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> ListAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
    Task<List<T>> ListWithPaginationAsync(int pageNo, int pageSize, ISpecification<T> specification, CancellationToken cancellationToken = default);
    Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
    Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToke = default);
}
