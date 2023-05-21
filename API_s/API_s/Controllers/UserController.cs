
using API_s.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_s.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UserController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        //public static List<User> user = new List<User>()
        //{
        //    new User()
        //    {
        //        Id = 1,
        //        UserName="Sandesh",
        //        Address="Kapan"
        //    },
        //     new User()
        //    {
        //        Id = 2,
        //        UserName="Roshan",
        //        Address="Kapan Gumba"
        //    },
        //      new User()
        //    {
        //        Id = 3,
        //        UserName="Bhaskar",
        //        Address="Chabahil"
        //    }
        //};
        //[HttpGet("getalluser")]
        ////get api to get all user from list. The url rout will be 
        ////localhost:7226/api/User/getalluser
        //public List<User> Getuser()
        //{
        //    return user;
        //}

        //[HttpPost("adduser")]

        //public List<User> addUser(User user1)
        //{
        //    user.Add(user1);
        //    return user;
        //}
        ////////////////////////////////////
        //public IActionResult AddUser(User users)
        //{
        //    try
        //    {                
        //        user.Add(users);
        //        return Ok(user);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpPut("{id}")]

        //public User updateUser(int id, User users)
        //{
        //user.Where(x => x.Id == id).FirstOrDefault().Id=users.Id;
        //user.Where(x => x.Id == id).FirstOrDefault().UserName=users.UserName;
        //user.Where(x => x.Id == id).FirstOrDefault().Address=users.Address;
        //updateUser = users;
        // return users;
        //}


        //public IActionResult updateUser(int id, User users) 
        //{
        //    User existingUser = user.FirstOrDefault(x => x.Id == id);
        //    if (existingUser == null)
        //    {
        //        return NotFound();
        //    }
        //    existingUser.Id = users.Id;
        //    existingUser.UserName = users.UserName;
        //    existingUser.Address = users.Address;
        //    return Ok(existingUser);
        //}



        //[HttpDelete("{id}")]

        //public User deleteUser(int id)
        //{
        //    var deleteUser=user.Where(x => x.Id == id).FirstOrDefault();
        //    user.Remove(deleteUser);
        //    return deleteUser;
        //}


        //public IActionResult deleteUser(int id)
        //{
        //    User deleteUsers=user.FirstOrDefault(x => x.Id == id);
        //    if (deleteUsers == null)
        //    {
        //        return NotFound();
        //    }
        //    user.RemoveAll(x=>x.Id==id);
        //    return Ok(deleteUsers);
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetUserById(int id)
        //{
        //    User users = user.FirstOrDefault(x => x.Id == id);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(users);
        //}
    } 
}
