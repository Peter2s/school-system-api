﻿using Microsoft.EntityFrameworkCore;
using school.Core.Interfaces;
using school.Core.Models;
using school.Data;

namespace school.Repositories
{
    public class BaseRepository<T> : IBaseRepo<T> where T : BaseModel
    {
        protected ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> AddMany(List<T> rows)
        {
            await _context.Set<T>().AddRangeAsync(rows);
            await _context.SaveChangesAsync();
            return rows;
        }

        public async Task<IReadOnlyList<T>> getList()
        {
           return await  _context.Set<T>().ToListAsync();
        }

    }
}
