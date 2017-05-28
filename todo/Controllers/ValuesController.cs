using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using todo.Models;
using System.Data;
using System.Data.Entity;

namespace todo.Controllers
{
    public class ValuesController : ApiController
    {
        TaskDBEntities db = new TaskDBEntities();//экзамепляр класса для доступа к модели

        // GET api/values
        public IEnumerable<Task> GetTasks()//получение всех заданий
        {
            return db.Tasks;
        }

        // GET api/values/5
        public Task GetTask(int id)//получение задания по ID
        {
            Task task = db.Tasks.Find(id);
            return task;
        }

        // POST api/values
        [HttpPost]
        public void CreateTask([FromBody]Task task)//создание нового задания
        {
            db.Tasks.Add(task);
            db.SaveChanges();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Task task)//изменить задание
        {
            if(id == task.Id)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        // DELETE api/values/5
        public void Delete(int id)//удаление задания по ID
        {
            Task task = db.Tasks.Find(id);
            if(task!=null)
            {
                db.Tasks.Remove(task);
                db.SaveChanges();
            }
        }
    }
}
