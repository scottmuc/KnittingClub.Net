using System.Collections.Generic;
using Castle.Facilities.NHibernateIntegration;
using NHibernate;


namespace KnittingClub.DataAccess
{
    public class CoreRepository<T> : IRepository<T>
    {        
        public CoreRepository(ISessionManager sessionManager)
        {
            this.SessionManager = sessionManager;
        }

        public ISessionManager SessionManager { private set; get; }
        
        public T GetById(object id)
        {
            using(var session = SessionManager.OpenSession())
            {
                return session.Load<T>(id);
            }
        }

        public T[] GetAll()
        {
            using(var session = SessionManager.OpenSession())
            {
                ICriteria crit = session.CreateCriteria(typeof (T));
                return new List<T>(crit.List<T>()).ToArray();
            }
        }

        public void Save(T entity)
        {
            using(var session = SessionManager.OpenSession())
            using(var transaction = session.BeginTransaction())
            {
                session.Save(entity);
                transaction.Commit();                
            }
        }

        public void Update(T entity)
        {
            using(var session = SessionManager.OpenSession())
            using(var transaction = session.BeginTransaction())
            {
                session.Update(entity);
                transaction.Commit(); 
            }
        }
    }
}