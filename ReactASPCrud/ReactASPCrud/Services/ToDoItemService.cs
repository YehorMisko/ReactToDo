using ReactASPCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace ReactASPCrud.Services
{
    public class ToDoItemService
    {
        private static List<ToDoItem> ToDoList = new List<ToDoItem>();
        private static int Count = 1;
        private static readonly string[] names = new string[] { "Wake up", "Put on a little bit of make up", "Table", "Get to Valhalla", "Sacrifice the child to Odin", "Corrupt the child", "Spend money on micro-transactions", "The concept" };
        static ToDoItemService()
        {
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                string currName = names[rnd.Next(names.Length)];
                ToDoItem action = new ToDoItem
                {
                    Id = Count++,
                    Name = currName,
                    IsDone = false
                };
                ToDoList.Add(action);
            }
        }
        public List<ToDoItem> GetAll()
        {


            var query = from ToDoItem in ToDoList
                        orderby ToDoItem.IsDone ascending
                        select ToDoItem;

            return query.ToList();
        }
        public ToDoItem GetById(int id)
        {
            return ToDoList.Where(user => user.Id == id).FirstOrDefault();
        }
        public ToDoItem Create(ToDoItem action)
        {
            action.Id = Count++;
            ToDoList.Add(action);
            return action;
        }
        public void Update(int id, ToDoItem action)
        {
            ToDoItem found = ToDoList.Where(n => n.Id == id).FirstOrDefault();
            found.Name = action.Name;
            found.IsDone = action.IsDone;
        }
        public void ChangeState(int id, ToDoItem action)
        {
            ToDoItem found = ToDoList.Where(n => n.Id == id).FirstOrDefault();
            found.IsDone = !action.IsDone;
        }
        public void Delete(int id)
        {
            ToDoList.RemoveAll(n => n.Id == id);
        }
    }
}