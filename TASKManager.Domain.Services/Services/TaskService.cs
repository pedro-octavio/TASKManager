using FluentValidation;
using System;
using System.Collections.Generic;
using TASKManager.Domain.Core.Interfaces.Repositories;
using TASKManager.Domain.Core.Interfaces.Services;
using TASKManager.Domain.Entities;

namespace TASKManager.Domain.Services.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IValidator<Task> _validator;

        public TaskService(ITaskRepository taskRepository, IValidator<Task> validator)
        {
            _taskRepository = taskRepository;
            _validator = validator;
        }

        public IEnumerable<Task> GetAll()
        {
            try
            {
                return _taskRepository.GetAll();
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
                var task = _taskRepository.GetById(id);

                return task ?? throw new Exception("This task don't exists.");
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
                var resultValidator = _validator.Validate(task);

                if (resultValidator.IsValid) _taskRepository.Add(task);
                else throw new Exception(resultValidator.Errors[0].ErrorMessage);
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
                var resultValidator = _validator.Validate(task);

                if (resultValidator.IsValid) _taskRepository.Update(task);
                else throw new Exception(resultValidator.Errors[0].ErrorMessage);
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
                _taskRepository.Remove(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
