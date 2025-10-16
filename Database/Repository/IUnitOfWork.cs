using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository;
public interface IUnitOfWork : IDisposable
{
    void Begin();
    void Commit();
    void Rollback();
}
