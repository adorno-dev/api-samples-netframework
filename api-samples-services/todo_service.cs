using Api.Samples.Data.EntityFramework.Repositories;
using Api.Samples.Domain.Models;
using Api.Samples.Domain.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Samples.Services
{
    public class TodoService
    {
        private IRepository<Todo> repository;

        public TodoService() => repository = new TodoRepository();

        public IList<Todo> All() => repository.All();
    }
}
