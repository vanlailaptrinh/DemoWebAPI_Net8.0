using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.Data;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private readonly MyDbContext _context;

        public LoaisController(MyDbContext context) { 
            _context = context;
        }
        [HttpGet] 
        public IActionResult GetAll ()
        {
            var dsLoai = _context.Loais.ToList();
            return Ok(dsLoai);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (loai != null)
            {
                return Ok(loai); 
            }
            else
            {
                return NotFound();
            }
           
            
        }
        [HttpPost]
        public IActionResult CreateNew(LoaiModel model)
        {
            try {
                var loai = new Loai
                {
                    TenLoai = model.TenLoai

                };
                _context.Add(loai);
                _context.SaveChanges();
                return Ok(loai);
            }
            catch
            {
                return BadRequest();
            }
            }
        [HttpPut("{id}")]
        public IActionResult UpdateLoaiById(int id, LoaiModel model)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (loai != null)
            {
                loai.TenLoai = model.TenLoai;
                _context.SaveChanges();

                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (loai != null)
            {
                _context.Loais.Remove(loai);
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    return NoContent();
                }
                else
                {
                    return StatusCode(500, "Error System");
                }
            }
            else
            {
                return NotFound();
            }


        }

    }
}
