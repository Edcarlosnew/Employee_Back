/*

namespace Back_End_Employee.Data.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        //("João Silva")
        public string? NameEmployee { get; set; }

        //("123.456.789-00")
        public string? Cpf { get; set; }

        //("12.345.678-9")
        public string? Rg { get; set; }

        //("SSP/SP")
        public string? ExpeditionAgency { get; set; }

        //("01/01/2022")
        public DateTime HiringDate { get; set; }

        
        public int DepartamentId { get; set; }

        //("(11) 99999-9999")
        public string? MobilePhone { get; set; }

        //("Rua A, 123")
        public string? Address { get; set; }

        //("Bloco B, Apto 456")
        public string? Complement { get; set; }

        //("Centro")
        public string? Neighborhood { get; set; }

        //("SP")
        public string? State { get; set; }

        //("São Paulo")
        public string? City { get; set; }

        //("01234-567")
        public string? ZipCode { get; set; }

        //("1500.50")
        public decimal Salary { get; set; }

    }
}


*/




namespace Back_End_Employee.Data.Entities
{
    // esta é a entidade/model que determina o formato dos dados que serão manipulados pela aplicação
    public class Employee
    {
        // definir as props 

        public int Id { get; set; } // Id
        public string? NameEmployee { get; set; } // Nome Funcionário
        public string? Cpf { get; set; } //Embora seja um número, na prática ele é tratado como uma cadeia de caracteres (string) devido à sua formatação com pontos e hífen. 
        public string? Rg { get; set; } //Embora seja um número, na prática ele é tratado como uma cadeia de caracteres (string) devido à sua formatação com pontos e hífen.
        public string? ExpeditionAgency { get; set; } // Nome do Orgão Expeditor
        public DateTime HiringDate { get; set;} // Data de Contratação
        //public byte[]? PhotoImage { get; set;} // Foto
        public int DepartamentId { get; set; } // FK Referente ao Id da tabela Deparatament 
        public string? MobilePhone { get; set; } // Telefone Celular
        public string? Address { get; set; } // Endereço
        public string? Complement { get; set; } // Complemento
        public string? Neighborhood { get; set; } // Bairro
        public string? State { get; set; } // Estado
        public string? City { get; set; } // Cidade
        public string? ZipCode { get; set; } // Cep
        public decimal Salary { get; set; } // Decimal. No caso, (18, 2) significa que pode armazenar 18 dígitos no total, sendo 2 deles após o ponto decimal. Por exemplo, um salário de 1500,50 seria armazenado como 1500.50 no banco de dados.
        
    }
}
