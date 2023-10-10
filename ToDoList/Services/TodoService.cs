using System.Linq.Expressions;
using ToDoList.DataAccsess;
using ToDoList.Models;
using ToDoList.Services.Interface;

namespace ToDoList.Services
{
    public class TodoService : IToDoService
    {
        private readonly IDataContext _appDataContext;

        public TodoService(IDataContext dataContext)
        {
            _appDataContext = dataContext;            
        }

        public async ValueTask<ToDo> CreateAsync(ToDo toDo, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            if(!ValidationToNull(toDo))
                throw new ArgumentNullException("This a member of these emailTemplate null");

            if (ValidationExists(toDo))
                throw new ArgumentException("This emailTemplate already exists");

            await _appDataContext.ToDos.AddAsync(toDo);

            if(saveChanges)  await _appDataContext.SaveChangesAsync();

            return toDo;
        }
        
        public IQueryable<ToDo> Get(Expression<Func<ToDo, bool>> predicate)
        {
            return GetUnDeletedToDo().Where(predicate.Compile()).AsQueryable();
        }
        
        public ValueTask<ICollection<ToDo>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            var foundToDos = GetUnDeletedToDo().Where(toDo => ids.Contains(toDo.Id));

            return new ValueTask<ICollection<ToDo>>(foundToDos.ToList());
        }

        public ValueTask<ToDo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var foundToDo = GetUnDeletedToDo().FirstOrDefault(toDo => toDo.Id == id);

            if (foundToDo is null)
                throw new ArgumentException("EmailTemplate not found");

            return new ValueTask<ToDo?>(foundToDo);
        }

        public async ValueTask<ToDo> UpdateAsync(ToDo todo, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            if (!ValidationToNull(todo))
                throw new ArgumentNullException("This a member of these emailTemplate null");

            var foundToDo = await GetByIdAsync(todo.Id);

            foundToDo.Name = todo.Name;
            foundToDo.Description = todo.Description;

            if(saveChanges) await _appDataContext.SaveChangesAsync();
           
            return foundToDo;
        }

        public async ValueTask<ToDo> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var foundToDo = await GetByIdAsync(id);

            await _appDataContext.ToDos.RemoveAsync(foundToDo, cancellationToken);

            if(saveChanges) await _appDataContext.SaveChangesAsync() ;
            
            return foundToDo;
        }

        public async ValueTask<ToDo> DeleteAsync(ToDo toDo, bool saveChanges = true, CancellationToken cancellationToken = default)
            => await DeleteAsync(toDo, saveChanges, cancellationToken);
        
        private bool ValidationToNull(ToDo toDo)
        {
            if (string.IsNullOrEmpty(toDo.Name) || string.IsNullOrWhiteSpace(toDo.Description))
                return false;

            return true;
        }

        private bool ValidationExists(ToDo toDo)
        {
            var foundUsers = GetUnDeletedToDo().FirstOrDefault(search => search.Equals(toDo));
            
            if(foundUsers is  null) 
                return false;

            return true;
        }

        private IQueryable<ToDo> GetUnDeletedToDo()
            => _appDataContext.ToDos.Where(toDo =>!toDo.IsDeleted).AsQueryable();

    }
}
