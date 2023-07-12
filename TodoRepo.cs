using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public class TodoRepo
    {
        private DbContext _dbContext;
        private DbSet<Todo> _todoSet;

        public TodoRepo(DbContext todoContext)
        {
            _dbContext = todoContext;
            _todoSet = todoContext.Set<Todo>();
        }

        public IList<Todo> GetAllTodos()
        {
            return _todoSet.Select(item => item).ToList();
        }

        public void AddTodo(Todo item)
        {
            _todoSet.Add(item);
        }

        public void DeleteById(int Id)
        {
            Todo? todo = _todoSet.FirstOrDefault(item => item.Id == Id);

            if (todo == null)
            {
                throw new Exception("Could not delete Item as it does not exist");
            }

            DeleteTodo(todo);
        }

        public void DeleteTodo(Todo item)
        {
            _todoSet.Remove(item);
        }

        public void UpdateTodo(Todo item)
        {
            var todo = (from t in GetAllTodos()
                        where t.Id == item.Id
                        select t).First();

            DeleteTodo(todo);
            AddTodo(item);
        }

        public void Save() 
        { 
            _dbContext.SaveChanges(); 
        }
    }
}
