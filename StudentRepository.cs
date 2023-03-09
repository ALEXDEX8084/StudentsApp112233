using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace StudentsApp
{
    public class StudentRepository
    {

        SQLiteConnection database;

        static object locker = new object();
        public StudentRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Student>();
        }
        public IEnumerable<Student> GetItems()
        {
            return database.Table<Student>().ToList();
        }
        public Student GetItem(int id)
        {
            return database.Get<Student>(id);
        }
        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<Student>(id);
            }
        }
        public int SaveItem(Student item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
