using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhutShop.Data.Infrastructure
{
    public abstract class RepositoryBase<T>: IRepository<T> where T: class
    {
        private NhutShopDbContext dataContext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected NhutShopDbContext DbContent
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }

        protected RepositoryBase(IDbFactory dbFactory) 
        {
            DbFactory = dbFactory;
            dbSet = DbContent.Set<T>();
        }


        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(int id)
        {
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public virtual void DeleteMulti(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual T GetSingleById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where, string includes)
        {
            return dbSet.Where(where).ToList();
        }

        public virtual int Count(Expression<Func<T, bool>> where)
        {
            return dbSet.Count(where);
        }

        public  IQueryable<T> GetAll(string[] includes=null)
        {
            if(includes!=null && includes.Count()>0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.AsQueryable();
            }
            return dataContext.Set<T>().AsQueryable();
        }

        public T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes=null)
        {
            return GetAll(includes).FirstOrDefault(expression);
        }

        public  virtual IQueryable<T> GetMulti(Expression<Func<T, bool>> precidate, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.AsQueryable();
            }
            return dataContext.Set<T>().Where<T>(precidate).AsQueryable();
        }

        public virtual IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> precidate, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            int skipCount = index * size;
            IQueryable<T> _resetSet;

            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                _resetSet = precidate != null ? query.Where<T>(precidate).AsQueryable() : query.AsQueryable();
            }
            else
            {
                _resetSet = precidate != null ? dataContext.Set<T>().Where<T>(precidate).AsQueryable() : dataContext.Set<T>().AsQueryable();
            }

            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();    
        }

        public bool CheckContains(Expression<Func<T, bool>> precidate)
        {
            return dataContext.Set<T>().Count<T>(precidate) > 0;
        }

       
    }
  
}
