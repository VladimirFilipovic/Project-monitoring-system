using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITSolutionsCompanyV1.Data;
using ITSolutionsCompanyV1.Models;
using Microsoft.AspNetCore.Identity;
using ITSolutionsCompanyV1.Models.Dto;
using ITSolutionsCompanyV1.Service.TokenService;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ITSolutionsCompanyV1.Controllers
{
    [AllowAnonymous ]
    [Route("api/users")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly TokenService _tokenService;

        public AccountController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, TokenService tokenService)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        //// GET: api/Account
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers()
        //{
        //    return await _context.Users.ToListAsync();
        //}

        // GET: api/Account/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> GetApplicationUser(Guid id)
        {
            var applicationUser = await _context.Users.FindAsync(id);

            if (applicationUser == null)
            {
                return NotFound();
            }

            return applicationUser;
        }

        // PUT: api/Account/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationUser(Guid id, ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(applicationUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Account
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> PostApplicationUser(ApplicationUser applicationUser)
        {
            _context.Users.Add(applicationUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplicationUser", new { id = applicationUser.Id }, applicationUser);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto login)
        {
            var user = await _userManager.FindByEmailAsync(login.email);

            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, login.password, false); 

            if(result.Succeeded)
            {
                return new UserDto
                {
                    Username = user.UserName,
                    Token = _tokenService.CreateToken(user)
                };
            }
            return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto applicationUser)
        {
            if(await _userManager.Users.AnyAsync(x=> x.Email == applicationUser.Email))
            {
                ModelState.AddModelError("email", "Email taken");
                return ValidationProblem();
            }
            if (await _userManager.Users.AnyAsync(x => x.UserName == applicationUser.UserName))
            {
                ModelState.AddModelError("username", "Username taken");
                return ValidationProblem();
            }

            var user = new Client
            {
                UserName = applicationUser.UserName,
                Email = applicationUser.Email,
                Pib = applicationUser.Pib,
                CompanyName = applicationUser.CompanyName
            };

            var result = await _userManager.CreateAsync(user, applicationUser.Password);

            if (result.Succeeded)
            {
                var result2 = await _userManager.AddToRoleAsync(user, "User");

                if (result2.Succeeded)
                {
                    return new UserDto
                    {
                        Username = user.UserName,
                        Token = _tokenService.CreateToken(user),
                        Role = "User"
                    };
                }
            }
               
            return BadRequest("Problem registering user");

        }
        
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
            var role = await _userManager.GetRolesAsync(user);

            return CreateUserObject(user, role[0]);
        }

        private UserDto CreateUserObject(ApplicationUser user, string role)
        {

            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user),
                Role = role
            };
        }
        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApplicationUser>> DeleteApplicationUser(Guid id)
        {
            var applicationUser = await _context.Users.FindAsync(id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            _context.Users.Remove(applicationUser);
            await _context.SaveChangesAsync();

            return applicationUser;
        }

        private bool ApplicationUserExists(Guid id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
