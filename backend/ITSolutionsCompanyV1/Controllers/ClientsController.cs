using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITSolutionsCompanyV1.Data;
using ITSolutionsCompanyV1.Models;
using ITSolutionsCompanyV1.Service.ApplicationUserService;

namespace ITSolutionsCompanyV1.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IApplicationUserService _applicationUserService;
        public ClientsController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }

        // GET: api/clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return _applicationUserService.GetAllClients();
        }

        // GET: api/clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(Guid id)
        {
            var client = _applicationUserService.GetClient(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/clients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(Guid id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            try
            {
                _applicationUserService.UpdateClient(id, client);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            try
            {
                _applicationUserService.InsertClient(client);
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> DeleteClient(Guid id)
        {
            var client = _applicationUserService.GetClient(id);
            if (client == null)
            {
                return NotFound();
            }

            client = _applicationUserService.DeleteClient(id);

            return client;
        }

        private bool ClientExists(Guid id)
        {
            if(_applicationUserService.GetClient(id) == null) {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
