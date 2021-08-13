using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using PBL3.Data;
using PBL3.Models;
using System.Linq.Expressions;

namespace PBL3.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T: class
    {
        
        public PBL3Context _context = null;
        public DbSet<T> table = null;
        public GenericRepository()
        {
 
            this._context = new PBL3Context();
            this.table = _context.Set<T>();
        }
        public GenericRepository(PBL3Context _context)
        {
            this._context = _context;
            this.table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table;
        }
        public T GetById(int id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Update(obj);
        }
        public void Delete(int id)
        {
            var data = table.Find(id);
            table.Remove(data);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
         
    }
}
