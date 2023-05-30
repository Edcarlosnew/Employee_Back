API de Gerenciamento de Funcionários
Esta API permite o gerenciamento de funcionários e departamentos em uma empresa.

Endpoints
Departamento

Listar todos os registros

GET /api/Departamento/All_Records
Retorna todos os registros de departamentos.


Obter registro identificado
GET /api/Departamento/GetIdentifiedRecord/{id}


Retorna o registro de departamento com o ID especificado.


Adicionar novo registro

POST /api/Departamento/AddRegister

Adiciona um novo registro de departamento.


Atualizar registro existente

PUT /api/Departamento/ChangeUpdate/{id}


Atualiza o registro de departamento com o ID especificado.

Excluir registro

DELETE /api/Departamento/DeleteRegister/{id}

Exclui o registro de departamento com o ID especificado.



Funcionário


Listar todos os registros

GET /api/Funcionario/All_Records
Retorna todos os registros de funcionários.

Obter registro identificado

GET /api/Funcionario/GetIdentifiedRecord/{id}
Retorna o registro de funcionário com o ID especificado.

Adicionar novo registro

POST /api/Funcionario/AddRegister
Adiciona um novo registro de funcionário.

Atualizar registro existente

PUT /api/Funcionario/ChangeUpdate/{id}
Atualiza o registro de funcionário com o ID especificado.

Excluir registro

DELETE /api/Funcionario/DeleteRegister/{id}
Exclui o registro de funcionário com o ID especificado.


Como Usar

Clone este repositório para sua máquina local.
Abra o arquivo de solução (EmployeeManagement.sln) em seu IDE preferido.
Restaure os pacotes NuGet para a solução.
Atualize a string de conexão no arquivo appsettings.json com os detalhes da sua própria conexão de banco de dados.
Compile a solução para garantir que não haja erros de compilação.
Execute as migrações do banco de dados para criar as tabelas necessárias no banco de dados:


dotnet ef database update


Inicie a aplicação.
Use uma ferramenta de desenvolvimento de API como o Postman ou cURL para fazer solicitações aos endpoints disponíveis.


Tecnologias Utilizadas


ASP.NET Core
Entity Framework Core
Microsoft SQL Server


Contribuição


Contribuições são bem-vindas! Se você encontrar algum problema ou tiver sugestões de melhoria, abra uma issue ou envie um pull request.

Licença
Este projeto está licenciado sob a Licença MIT.
