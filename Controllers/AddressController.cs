/*
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Back_End_Employee.Data;
using Back_End_Employee.Data.Entities;

namespace Back_End_Employee.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly MyDbContext _dbcontext;

        public AddressController(MyDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("All_Records")]
        public async Task<ActionResult> GetAddresses()
        {
            var AddressList = await _dbcontext.ViaCepAddress.ToListAsync();
            return Ok(AddressList);
            
        }

        [HttpGet]
        [Route("GetIdentifiedRecord/{id}")]
        public async Task<ActionResult<ViaCepAddress>> GetAddress(int id)
        {
            var address = await _dbcontext.ViaCepAddress.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        [HttpPost]
        [Route("AddRegister")]
        public async Task<ActionResult<ViaCepAddress>> CreateAddress(ViaCepAddress address)
        {
            _dbcontext.ViaCepAddress.Add(address);
            await _dbcontext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAddress), new { id = address.id }, address);
        }

        [HttpPut]
        [Route("ChangeUpdate/{id}")]
        public async Task<IActionResult> UpdateAddress([FromRoute] int id, [FromBody] ViaCepAddress newVia)
        {
            var ViaFound = await _dbcontext.ViaCepAddress.FindAsync(id);

            if (ViaFound == null)
            {
                return NotFound();
            }

            ViaFound.Cep = newVia.Cep;
            ViaFound.Logradouro = newVia.Logradouro;
            ViaFound.Complemento = newVia.Complemento;
            ViaFound.Bairro = newVia.Bairro;
            ViaFound.Localidade = newVia.Localidade;
            ViaFound.Uf = newVia.Uf;
            ViaFound.Ibge = newVia.Ibge;
            ViaFound.Gia= newVia.Gia;
            ViaFound.Ddd = newVia.Ddd;
            ViaFound.Siafi = newVia.Siafi;
            

            await _dbcontext.SaveChangesAsync();

            return Ok(ViaFound);
        }

            [HttpDelete]
        [Route("DeleteRegister/{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var address = await _dbcontext.ViaCepAddress.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            _dbcontext.ViaCepAddress.Remove(address);
            await _dbcontext.SaveChangesAsync();

            return NoContent();
        }
    }
}
*/