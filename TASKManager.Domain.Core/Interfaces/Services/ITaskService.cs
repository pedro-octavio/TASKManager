using System.Collections.Generic;
using TASKManager.Domain.Entities;

namespace TASKManager.Domain.Core.Interfaces.Services
{
    public interface ITaskService
    {
        IEnumerable<Task> GetAll();
        Task GetById(int id);
        void Add(Task task);
        void Update(Task task);
        void Remove(int id);
    }
}
