using Api.Dtos.Marks;
using Api.Models;

namespace Api.Interfaces
{
    public interface IMarkRepository
    {
        Task <List<Marks>> GetAllAsycn();
        Task <Marks?> GetByIdAsync(int id);
        Task <Marks> CreateAsycn(Marks marks);
        Task<Marks> UpdateAsync(int id, UpdateDto marks);
        Task<Marks> DeleteAsync(int id);
    }

}
