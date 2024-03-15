using Domain.Common;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public void Create(T entity)
        {
            AppDbContext<T>.datas.Add(entity);
        }

        public void Delete(T entity)
        {
            AppDbContext<T>.datas.Remove(entity);
        }

        public List<T> GetAll()
        {
            return AppDbContext<T>.datas.ToList();
        }

        

        public List<T> GetAllWithExpression(Func<T, bool> predicate)
        {
            return AppDbContext<T>.datas.Where(predicate).ToList();
        }

        public T GetById(int id)
        {
            return AppDbContext<T>.datas.FirstOrDefault(m => m.Id == id);
        }

        public void Update(T entity)
        {
            T existingEntity = AppDbContext<T>.datas.FirstOrDefault(m => m.Id == entity.Id);
            if (existingEntity != null)
            {
                int index = AppDbContext<T>.datas.IndexOf(existingEntity);
                AppDbContext<T>.datas[index] = entity;
            }
            else
            {
                throw new InvalidOperationException("Entity not found");
            }
        }
    }
}
