using Database.Repository;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    internal class NHibernateUnitOfWork(ISession session) : IUnitOfWork
    {
        private ITransaction? transaction;

        public void Begin()
        {
            if (transaction != null) return;
            transaction = session.BeginTransaction();
        }

        public void Commit()
        {
            if (transaction == null) return; 
            transaction.Commit();
        }

        public void Rollback()
        {
            if (transaction == null) return;
            transaction.Rollback();
        }

        public void Dispose()
        {
            transaction?.Dispose();
        }
    }
}
