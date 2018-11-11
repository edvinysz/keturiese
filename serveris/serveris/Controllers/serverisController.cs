using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using serveris.Models;

namespace serveris.Controllers
{
    [Route("api/serveris")]
    [ApiController]
    public class serverisController : ControllerBase
    {
        private readonly serverisContext _context;

        public serverisController(serverisContext context)
        {
            _context = context;

            if (_context.serverisItems.Count() == 0)
            {
                //sukuriam nauja serverisItem jei empty, reiskia negalim istrint visu serverisItems
                _context.serverisItems.Add(new serverisItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }
         
        [HttpGet]
        public ActionResult<List<serverisItem>> GetAll()
        {
            return _context.serverisItems.ToList();
        }

        [HttpGet("{id}", Name = "Getserveris")]
        public ActionResult<serverisItem> GetById(long id)
        {
            var item = _context.serverisItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
    }
}
