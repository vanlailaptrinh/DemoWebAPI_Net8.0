﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(String id)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia
            };
            hangHoas.Add(hanghoa);
            return Ok(new
            {
                Success = true,
                Data = hanghoa
            });
        }
        [HttpPut("{id}")]
        public IActionResult Edit(String id, HangHoa hangHoaEdit)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                if (id != hangHoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                // Update
                hangHoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                hangHoa.DonGia = hangHoaEdit.DonGia;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(String id)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }

                hangHoas.Remove(hangHoa);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
    //Testttttt
}
