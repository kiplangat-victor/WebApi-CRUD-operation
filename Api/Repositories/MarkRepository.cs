using Api.Data;
using Api.Dtos.Marks;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class MarkRepository : IMarkRepository
    {
        private readonly AppDbContext _dbContext;
        public MarkRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Marks> CreateAsycn(Marks marks)
        {
            await _dbContext.Marks.AddAsync(marks);
            await _dbContext.SaveChangesAsync();
            return marks;
        }

        public Task<Marks> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Marks>> GetAllAsycn()
        {
           return await _dbContext.Marks.ToListAsync();    
        }

        public async Task<Marks?> GetByIdAsync(int id)
        {
            return await _dbContext.Marks.FindAsync(id);    
        }

        public async Task<Marks> UpdateAsync(int id, UpdateDto marks)
        {
            var update=await _dbContext.Marks.FindAsync(id);
            if (update == null)
            {
                return null;
            }
            update.Maths=marks.Maths;
            update.English=marks.English;
            update.Kiswahili=marks.Kiswahili;
            update.Chemistry="marks.Chemistry";
            update.StudentId=marks.StudentId; 
            // update.CreatedAt="eeee";
            await _dbContext.SaveChangesAsync();
            return update;  
        }
    }
}