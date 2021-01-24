using Microsoft.EntityFrameworkCore;
using Shop.Context;
using Shop.Inferastructure.IRepository;
using Shop.Models;
using System.Linq;

namespace Shop.Inferastructure.Repository
{
    public class VenderRepository : IVenderRepository
    {
        private readonly ShopContext _context;
        public VenderRepository(ShopContext context)
        {
            _context = context;
        }
        public Vender GetByIdVender(int id)
        {
            return _context.vender.Where(n => n.Id == id).Include(b => b.Tags).FirstOrDefault();
        }
        public Vender GetById(int Id)
        {
            return _context.vender.Where(c => c.Id == Id).FirstOrDefault(); // find(id)
        }
        public int Insert(Vender vender)
        {
            _context.vender.Add(vender);
            return _context.SaveChanges();
        }
        public int Update(Vender vender)
        {
            _context.vender.Update(vender);
            return _context.SaveChanges();
        }
        public int Delete(Vender vender)
        {
            _context.vender.Remove(vender);
            return _context.SaveChanges();
        }
    }
}
