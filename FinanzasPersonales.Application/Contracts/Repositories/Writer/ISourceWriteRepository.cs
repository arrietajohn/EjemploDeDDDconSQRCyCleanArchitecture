using FinanzasPersonales.Domain.Entities;
using System.Data;

namespace FinanzasPersonales.Application.Contracts.Repositories.Writer;

public interface ISourceWriteRepository<T> : IBaseDomainModelWriteRepository<T> where T : Source
{

    

}
