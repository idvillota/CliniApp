using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Data.Infrastructure
{
    public class BaseRepository<T> where T : class
    {
        #region Fields

        internal DBContext myContext;
        internal DbSet<T> myDbSet;

        #endregion

        #region Constructors

        public BaseRepository(DBContext context)
        {
            this.myContext = context;
            this.myDbSet = context.Set<T>();
        }

        #endregion

        #region Methods

        public virtual IEnumerable<T> GetWithRawSql(string query, params object[] parameters)
        {
            return myDbSet.SqlQuery(query, parameters).ToList();
        }

        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = myDbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual T GetByID(object id)
        {
            return myDbSet.Find(id);
        }

        public virtual void Insert(T entity)
        {
            myDbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = myDbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (myContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                myDbSet.Attach(entityToDelete);
            }
            myDbSet.Remove(entityToDelete);
        }

        public virtual void Update(T entityToUpdate)
        {
            myDbSet.Attach(entityToUpdate);
            myContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        #endregion
    }
}