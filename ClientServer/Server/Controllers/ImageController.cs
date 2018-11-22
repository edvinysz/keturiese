using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/image")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ImageContext _context;

        public ImageController(ImageContext context)
        {
            _context = context;

            if (_context.Images.Count() == 0)
            {
                //sukuriam nauja Image jei empty, reiskia negalim istrint visu Images
                _context.Images.Add(new Image { Link = "http://www.test.lt/image1.jpg" });
                _context.SaveChanges();
            }
        }


        // GET METODAS
        [HttpGet]
        public ActionResult<List<Image>> GetAll()
        {
            return _context.Images.ToList();
        }

        [HttpGet("{id}", Name = "GetImage")]
        public ActionResult<Image> GetById(long id)
        {
            var item = _context.Images.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        //POST METODAS
        [HttpPost]
        public IActionResult Create(Image item)
        {
            _context.Images.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetImage", new { id = item.Id }, item);
        }

        //UPDATE METODAS
        [HttpPut("{id}")]
        public IActionResult Update(long id, Image item)
        {
            var todo = _context.Images.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Link = item.Link;

            _context.Images.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        //DELETE METODAS
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Images.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Images.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
