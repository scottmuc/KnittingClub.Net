using System.Collections.Generic;
using Castle.Facilities.NHibernateIntegration;
using Castle.Services.Transaction;
using NHibernate;


namespace KnittingClub.DataAccess
{
    public class CoreRepository<T> : IRepository<T>
    {
        private readonly ISessionManager sessionManager;

        public CoreRepository(ISessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
        }


        public T GetById(object id)
        {
            using(var session = sessionManager.OpenSession())
            {
                return session.Load<T>(id);
            }
        }

        public T[] GetAll()
        {
            using(var session = sessionManager.OpenSession())
            {
                ICriteria crit = session.CreateCriteria(typeof (T));

                return new List<T>(crit.List<T>()).ToArray();
            }
        }

        [Transaction(TransactionMode.Requires)]
        public void Save(T entity)
        {
            using(var session = sessionManager.OpenSession())
            {
                session.Save(entity);
                
            }
        }

        [Transaction(TransactionMode.Requires)]
        public void Update(T entity)
        {
            using(var session = sessionManager.OpenSession())
            {
                session.Update(entity);
                session.Flush();
            }
        }
    }
}