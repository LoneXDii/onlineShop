﻿using OrderService.Domain.Entities;
using System.Linq.Expressions;

namespace OrderService.Domain.Abstractions.Data;

public interface IOrderRepository
{
    Task CreateAsync(OrderEntity order, CancellationToken cancellationToken = default);
    Task<List<OrderEntity>> ListWithPaginationAsync(int pageNo = 1, int pageSize = 10, CancellationToken cancellationToken = default, params Expression<Func<OrderEntity, bool>>[] filters);
    Task<OrderEntity?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task UpdateAsync(OrderEntity order, CancellationToken cancellationToken = default);
    Task<long> CountAsync(CancellationToken cancellationToken = default);
    Task<long> CountAsync(CancellationToken cancellationToken = default, params Expression<Func<OrderEntity, bool>>[] filters);
}
