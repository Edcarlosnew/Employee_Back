using Microsoft.AspNetCore.Mvc;
using Back_End_Employee.Data;
using Back_End_Employee.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


// 12ª passo criar o Controller

namespace Back_End_Employee.Controllers
{
    [ApiController] // definindo API
    [Route("api/[controller]")]  // rota da API
    public class EmployeeController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public EmployeeController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // definir a tarefa assincrona com o atributo - de forma explicita - [HttpGet]
        [HttpGet]
        [Route("All_Records")]
        public async Task<IActionResult> GetAllRecords()
        {
            var EmployeeList = await _dbContext.Employee.ToListAsync();
            return Ok(EmployeeList);
        }
        // ACESSO DE TODOS OS REGISTROS
        //===================================================================

        [HttpGet]
        [Route("GetIdentifiedRecord/{id}")]
        public async Task<IActionResult> GetIdentifiedRecord(int id)
        {
            var IdentifiedRecord = await _dbContext.Employee.FindAsync(id);

            if (IdentifiedRecord == null)
            {
                return NotFound();
            }

            return Ok(IdentifiedRecord);
        }

        // ACESSO DE REGISTRO IDENTIFICADO NO CASO O ID
        //===================================================================

        [HttpPost]
        [Route("AddRegister")]
        public async Task<IActionResult> Post(Employee employee)
        {
            
            _dbContext.Employee.Add(employee);
            await _dbContext.SaveChangesAsync();

            return Ok(employee);
        }

                      


        /*
        [HttpPost]
        [Route("AddRegister")]
        public async Task<IActionResult> Post(Employee register)
        {
            _dbContext.Employee.Add(register);

            await _dbContext.SaveChangesAsync();

            return Ok(register);
        }
        */

        // ACESSO PARA ADICIONAR REGISTRO
        //===================================================================


        [HttpPut]
        [Route("ChangeUpdate/{id}")]
        public async Task<IActionResult> PutChangeUpdate([FromRoute] int id, [FromBody] Employee newEmployee)
        {
        var employeeFound = await _dbContext.Employee.FindAsync(id);

        if (employeeFound == null)
        {
        return NotFound();
        }

            employeeFound.NameEmployee = newEmployee.NameEmployee;
            employeeFound.Cpf = newEmployee.Cpf;
            employeeFound.Rg = newEmployee.Rg;
            employeeFound.ExpeditionAgency = newEmployee.ExpeditionAgency;
            employeeFound.HiringDate = newEmployee.HiringDate;
            employeeFound.DepartamentId = newEmployee.DepartamentId;
            employeeFound.MobilePhone = newEmployee.MobilePhone;
            employeeFound.Address = newEmployee.Address;
            employeeFound.Complement = newEmployee.Complement;
            employeeFound.Neighborhood = newEmployee.Neighborhood;
            employeeFound.State = newEmployee.State;
            employeeFound.City = newEmployee.City;
            employeeFound.ZipCode = newEmployee.ZipCode;
            employeeFound.Salary = newEmployee.Salary;

            await _dbContext.SaveChangesAsync();

            return Ok(employeeFound);
        }


        // ACESSO PARA ALTERAR/ATUALIZAR OS REGISTROS
        //===================================================================

        [HttpDelete]
        [Route("DeleteRegister/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteRegister = await _dbContext.Employee.FindAsync(id);

            if (deleteRegister == null)
            {
            return NotFound();
            }

            _dbContext.Employee.Remove(deleteRegister);

            await _dbContext.SaveChangesAsync();

            return Ok(deleteRegister);
        }

    }
}





// ACESSO PARA DELETAR OS REGISTROS
//===================================================================







/*

[HttpGet]
[Route("Endereco/{cep}")]
public async Task<IActionResult> GetEnderecoViaCep(string cep)
{
    if (!System.Text.RegularExpressions.Regex.IsMatch(cep, "^\\d{8}$"))
    {
        return BadRequest("O CEP deve conter 8 dígitos.");
    }

    using (var client = new HttpClient())
    {
        client.BaseAddress = new System.Uri("https://viacep.com.br/");
        var response = await client.GetAsync($"ws/{cep}/json/");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var endereco = JsonSerializer.Deserialize<ViaCepAddress>(content);
            return Ok(endereco);
        }
    }

    return BadRequest("CEP não encontrado.");
}

[HttpGet]
[Route("GetCpf/{id}")]
public async Task<IActionResult> GetCpf(int id)
{
    var employee = await _dbContext.Employee.FindAsync(id);

    if (employee == null)
    {
        return NotFound();
    }

    return Ok(employee.Cpf);
}

}

}
*/