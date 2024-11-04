using Microsoft.AspNetCore.Mvc;
using Qbank.Data;
using Qbank.Models;
using Microsoft.EntityFrameworkCore;

namespace Qbank.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase 
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id) 
        {
            var account = await _context.Accounts.FindAsync(id);

            if(account == null) 
            {
                return NotFound();
            }
            
            return account;
        }

        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account account) 
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAccount), new { id = account.Id }, account);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, Account account) 
        {
            if (id != account.Id) 
            {
                return BadRequest();
            }

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Accounts.Any(e => e.Id == id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id) 
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null) 
            {
                return NotFound();
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return NoContent();
        }    
    }
}