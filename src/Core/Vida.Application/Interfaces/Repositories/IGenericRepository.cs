﻿using Vida.Application.Interfaces.Specifications;
using Vida.Domain.Common;

namespace Vida.Application.Interfaces.Repositories;
public interface IGenericRepository<T> where T : BaseEntity
{
	public Task<IReadOnlyList<T>> GetAllAsync();
	public Task<IReadOnlyList<T>> GetAllAsync(ISpecifications<T> spec);
	public Task<T?> GetEntityAsync(int id);
	public Task AddAsync(T entity);
	public void Update(T entity);
	public void Delete(T entity);
}