using API_s.Data;
using API_s.Models;
using API_s.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_s.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public HomeController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet("getalluser")]
        public  IActionResult GetData()
        {
            try
            {
                var data = _applicationDbContext.Users.ToList();
                    return Ok(data);
            }
            catch (Exception ex)
            {               
                return BadRequest("Failed to retrieve data: " + ex.Message);
            }
        }




        [HttpPost("adduser")]
        public async Task<IActionResult> addusers(User model)
        {
            try
            {
                await _applicationDbContext.Users.AddAsync(model);
                await _applicationDbContext.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to save data: " + ex.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteData(int id)
        {
            try
            {              
                    var data = _applicationDbContext.Users.Find(id);
                    if (data != null)
                    {
                    _applicationDbContext.Users.Remove(data);
                    _applicationDbContext.SaveChanges();
                        return Ok("Data deleted successfully.");
                    }
                    else
                    {
                        return NotFound("Data not found.");
                    }                
            }
            catch (Exception ex)
            {              
                return BadRequest("Failed to delete data: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            User user = _applicationDbContext.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }




        [HttpPut("{id}")]
        public IActionResult UpdateData(int id, User updatedData)
        {
            try
            {
                    var data = _applicationDbContext.Users.Find(id);
                    if (data != null)
                    {
                        data.UserName = updatedData.UserName;
                        data.Address = updatedData.Address;
                        _applicationDbContext.SaveChanges();
                        return Ok("Data updated successfully.");
                    }
                    else
                    {
                        return NotFound("Data not found.");
                    }
                
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to update data: " + ex.Message);
            }
        }
    }
}
