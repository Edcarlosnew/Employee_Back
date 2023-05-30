using Microsoft.AspNetCore.Mvc;
// importar as diretivas que devem ser referenciadas  // 12ª passo
using Microsoft.EntityFrameworkCore;
using Back_End_Employee.Data;
using Back_End_Employee.Data.Entities;

// 11ª passo criar o Controller

namespace Back_End_Employee.Controllers
{
    // 13ª Passo é necessario fazer uso/referencia do atributo que identifica este controller como uma API
    [ApiController]
    // 14ª definir a rota da API
    [Route("api/[controller]")]  // rota da API
    //15ª praticar o mecanismo de herança com a superclasse ControllerBase
    public class DepartamentController : Controller
    {
        /* 16ª é remover a estrutura
           IActionResult Index()
           {
              return View();
           }
        */

        /* 17ª Passo é necessario praticar a referencia de instancia da classe MyDbContext que auxiliará na manipulação dos dados         
        */

        private readonly MyDbContext _dbContext;

        // 18ª Passo definir o construtor da classe/controller/api para referenciar a injeção de dependencia
        public DepartamentController(MyDbContext dbContext)
        {
            // 19ª acessar a prop private e atribui-la com qualquer valor que em algum momento, sera dado ao paramentro do contrutor
            _dbContext = dbContext;
        }

        //TAREFA ASSINCRONA PARA RECUPERAR TODOS OS DADOS DA BASE - será responsavel por fazer uso da injeção de dependencia para acessar a entyti Departament - que é a representação da table da base - e listar os dados que serão exibidos em uma view.

        // 20ª definir a tarefa assincrona com o atributo - de forma explicita - [HttpGet]

        [HttpGet]
        [Route("All_Records")]
        public async Task<IActionResult> GetAllRecords()
        {
            //definir uma prop para receber - de maneira assincrona -todos os registros da base a partir do acesso a entity
            var DepartamentList = await _dbContext.Departament.ToListAsync();
            //retornar a lista atribuida como valor da variavel DepartamentList
            return Ok(DepartamentList);
        }
        /*
        1ª definir o atributo [HttpGet] 
        2ª definir a tarefa do tipo public async Task que será do tipo <IActionResult> chamando o metodo GetAllRecords()
        3ª agora vamos criar uma variavel com o nome DepartamentList, que de maneira assincrona await, e pegaremos nossa injeção de dependencia _dbContext e faremos uso da entity Departament e quando chamamos a entity nós queremos fazer uso da tabela que vai listar nossos registros que é chamando o metodo ToListAsync(); que de forma assincrona vai lista todos os registros e por nosso metodo assincrono ser diferente de void temos que ter uma expressão de retorno, então vamos retornar um OK que é o verbete que dizse esta requisição funcionou retornando nossa lista DepartamentList

         */
        // ACESSO DE TODOS OS REGISTROS
        //===================================================================

        // ACTION PARA RESGATAR UM UNICO REGISTRO DA BASE - será responsavel por recuperar um registro - devidamente identificado e armazenar na base - e disponibiliza-lo para o front

        // 21ª definir a tarefa assincrona para recuperar o registro - já na referencia do atributo [HttpGet] é necessario indicar o elemento identificador do registro
        [HttpGet]
        [Route("GetIdentifiedRecord/{id}")]
        public async Task<IActionResult> GetIdentifiedRecord(int id)
        {
            // definir uma prop para receber - de maneira assincrona -um registro da base, acessando a entity, devidamente identificado com o valor do parametro
            var IdentifiedRecord = await _dbContext.Departament.FindAsync(id);
            //verificar se o valor dado ao parametro existe
            if (IdentifiedRecord == null)
            {
                return NotFound();
            }

            //se o valor do parametro id existir, o registro será retornado e disponibilizado para o front
            return Ok(IdentifiedRecord);
        }

        // ACESSO DE REGISTRO IDENTIFICADO NO CASO O ID
        //===================================================================


        // ACTION PARA INSERIR DADOS NA BASE - será responsavel por adicionar registros - de forma assincrona - na base de dados dentro da table Departament


        // definir a tarefa assincrona - fazendo uso do atributo [HttpPost] - para que a entity seja acessada e o envio dos dados para a base possa ocorrer tranquilamente
        [HttpPost]
        [Route("AddRegister")]
        public async Task<IActionResult> Post(Departament register)
        {
            //consiste em fazer acesso a entity Departament para que os dados recebidos pelo parametro register possam ser enviados para base
            _dbContext.Departament.Add(register);

            //de forma assincrona é necessario indicar que a alteração - inserção de um conjunto de valores - precisa ser salva e, assim definitivamente, armazenado na base
            await _dbContext.SaveChangesAsync();

            return Ok(register);
        }

        // ACESSO PARA ADICIONAR REGISTRO
        //===================================================================

        // ACTION PARA EXECUTAR A ATUALIZAÇÃO/ALTERAÇÃO DE REGISTROS -  será responsavel por, atraves do acesso a entity, possibilitar a atualização/alteração de um registro devidamente identificado

        //definir a tarefa assincrona - fazendo uso do atributo [HttpPut] para que o registro seja alterado/atualizado
        [HttpPut]
        [Route("ChangeUpdate/{id}")]
        public async Task<IActionResult> PutChangeUpdate([FromRoute] int id, Departament newResgister)
        {
            //definir uma prop para receber - de maneira assincrona -um registro da base, acessando a entity, devidamente identificado com o valor dado ao parametro id
            var Departamentfound = await _dbContext.Departament.FindAsync(id);

            //verificar a existencia do valor do id
            if (Departamentfound == null)
            {
                return NotFound();
            }

            //consiste em definir, acessando a entity, a operação necessaria para a atualização do registro e seu devido rearmazenamento
            Departamentfound.NameDepartament = newResgister.NameDepartament;
            Departamentfound.Description = newResgister.Description;

            // de forma assincrona, fazer uso da operação de "salvamento" da alteração realizada
            await _dbContext.SaveChangesAsync();

            //retornar o registro devidamente atualizado / alterado
            return Ok(Departamentfound);
        }

        // ACESSO PARA ALTERAR/ATUALIZAR OS REGISTROS
        //===================================================================

        // ACTION PARA EXCLUSÃO DE REGISTRO - será responsavel por executar a ação de exclusão de um registro da base

        // definir a tarefa assincrona com o atributo necessario para a exclusão de um registro

        [HttpDelete]
        [Route("DeleteRegister/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // definir uma prop para receber como valor uma busca para um determinado registro
            var deleteRegister = await _dbContext.Departament.FindAsync(id);

            // verificar se o registro existe
            if (deleteRegister == null)
            {
                return NotFound();
            }

            // se o registro existir será excluido
            _dbContext.Departament.Remove(deleteRegister);

            // "salvar" as alterações
            await _dbContext.SaveChangesAsync();

            //return o método ok() pois o registro foi excluido
            // return Ok();
            return Ok(deleteRegister);
        }

        // ACESSO PARA DELETAR OS REGISTROS
        //===================================================================
    }
}
    

