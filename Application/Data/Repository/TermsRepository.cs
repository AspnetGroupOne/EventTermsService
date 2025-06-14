﻿using Application.Data.Context;
using Application.Entity;
using Application.Interfaces;
using Application.Models.Response;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Data.Repository;

public class TermsRepository(DataContext context) : ITermsRepository
{
    protected readonly DataContext _context = context;
    protected readonly DbSet<TermsEntity> _terms = context.Set<TermsEntity>();

    public async Task<RepositoryResponse> CreateTermsAsync(TermsEntity entity)
    {
        try
        {
            if (entity == null) { return RepositoryResponse.Error("Entity is null."); }

            var exists = await ExistsTermsAsync(e => e.EventId == entity.EventId);
            if (exists.Success) { return RepositoryResponse.AlreadyExists("Entity with this id already exists."); }

            await _terms.AddAsync(entity);
            await _context.SaveChangesAsync();

            return RepositoryResponse.Ok();
        }
        catch (Exception ex) { return RepositoryResponse.Error(ex.Message); }
    }

    public async Task<RepositoryResponse> ExistsTermsAsync(Expression<Func<TermsEntity, bool>> expression)
    {
        try
        {
            if (expression == null) { return RepositoryResponse.Error("Expression is null."); }

            var exists = await _terms.AnyAsync(expression);
            if (!exists) { return RepositoryResponse.NotFound("Entity not found."); }

            return RepositoryResponse.Ok();
        }
        catch (Exception ex) { return RepositoryResponse.Error(ex.Message); }
    }

    public async Task<RepositoryResponse<TermsEntity>> GetTermsAsync(Expression<Func<TermsEntity, bool>> expression)
    {
        try
        {
            if (expression == null) { return RepositoryResponse<TermsEntity>.Error("Expression is null.", null); }

            var entity = await _terms.Include(e => e.Section).FirstOrDefaultAsync(expression);
            if (entity == null) { return RepositoryResponse<TermsEntity>.Error("Entity is null.", null); }

            return RepositoryResponse<TermsEntity>.Ok(entity);
        }
        catch (Exception ex) { return RepositoryResponse<TermsEntity>.Error(ex.Message, null); }
    }

    public async Task<RepositoryResponse> UpdateTermsAsync(TermsEntity entity)
    {
        try
        {
            if (entity == null) return RepositoryResponse.Error("Entity is null.");

            var existing = await _terms.Include(e => e.Section).FirstOrDefaultAsync(e => e.EventId == entity.EventId);
            if (existing == null) return RepositoryResponse.NotFound("Entity with this EventId does not exist.");

            existing.Section = entity.Section;

            await _context.SaveChangesAsync();
            return RepositoryResponse.Ok();
        }
        catch (Exception ex) { return RepositoryResponse.Error(ex.Message); }
    }

    public async Task<RepositoryResponse> DeleteTermsAsync(TermsEntity entity)
    {
        try
        {
            if (entity == null) { return RepositoryResponse.Error("Expression is null."); }

            _terms.Remove(entity);
            await _context.SaveChangesAsync();

            return RepositoryResponse.Ok();
        }
        catch (Exception ex) { return RepositoryResponse.Error(ex.Message); }
    }
}
