
namespace Domain.Interfaces
{
    public interface IRepositoryWrapper//просто чтобы не писать кучу методов Save для разных сущностей
    {
        IEmployeeRepository Employee{ get; }//доступ к конкретному репозиторию для работы через интерфейс
        Task Save();
    }
}
