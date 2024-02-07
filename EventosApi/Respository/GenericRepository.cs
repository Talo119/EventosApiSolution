
using AutoMapper;
using Events.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EventosApi.Respository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {

        private readonly EventsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GenericRepository(EventsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _dbContext.Set<T>().FindAsync(id);
            if (item == null)
            {
                return false;
            }
            _dbContext.Set<T>().Remove(item);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var items = await _dbContext.Set<T>().ToListAsync();

            return items;
        }

        public async Task<T?> GetAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);

        }

        public async Task<T> PostAsync(T item)
        {
            _dbContext.Set<T>().Add(item);

            await _dbContext.SaveChangesAsync();

            return item;
        }

        public async Task<bool> PutAsync(int id, T item)
        {
            var oldItem = await _dbContext.Set<T>().LongCountAsync();

            if (oldItem <= null)
            {
                return false;
            }

            //_mapper.Map(item, oldItem);
            
            _dbContext.Set<T>().Update(item);
            await _dbContext.SaveChangesAsync();


            return true;
        }
    }
}
