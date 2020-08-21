using System.Collections.Generic;
using TASKManager.Domain.Entities;

namespace TASKManager.Domain.Core.Interfaces.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetAll();
        Task GetById(int id);
        void Add(Task task);
        void Update(Task task);
        void Remove(int id);
    }
}
