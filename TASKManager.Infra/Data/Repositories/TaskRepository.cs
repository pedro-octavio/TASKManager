using System;
using System.Collections.Generic;
using System.Linq;
using TASKManager.Domain.Core.Interfaces.Repositories;
using TASKManager.Domain.Entities;

namespace TASKManager.Infra.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _dataContext;

        public TaskRepository(DataContext dataContext) => _dataContext = dataContext;

        public IEnumerable<Task> GetAll()
        {
            try
            {
                return _dataContext.Tasks.ToList().OrderBy(t => t.Importancy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task GetById(int id)
        {
            try
            {
                return _dataContext.Tasks.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Add(Task task)
        {
            try
            {
                _dataContext.Tasks.Add(task);

                _dataContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Task task)
        {
            try
            {
                _dataContext.Tasks.Update(task);

                _dataContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(int id)
        {
            try
            {
                _dataContext.Tasks.Remove(GetById(id));

                _dataContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
