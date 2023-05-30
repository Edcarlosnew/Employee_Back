
namespace Back_End_Employee.Data.Entities
{
    public class ViaCepAddress
    {
        // definir as props 
        public int id { get; set; } // Identificador único do endereço (autoincrementado)
        public string? Cep { get; set; } // CEP (código postal) do endereço
        public string? Logradouro { get; set; } // Nome do logradouro (rua, avenida, etc.)
        public string? Complemento { get; set; } // Complemento do endereço (apartamento, bloco, etc.)
        public string? Bairro { get; set; } // Nome do bairro
        public string? Localidade { get; set; } // Nome da cidade
        public string? Uf { get; set; } // Sigla do estado
        public string? Ibge { get; set; } // Código IBGE da cidade
        public string? Gia { get; set; } // Código GIA (Gerência de Informação e Apoio) da cidade
        public string? Ddd { get; set; } // Código DDD (Discagem Direta à Distância) da cidade
        public string? Siafi { get; set; } // Código SIAFI (Sistema Integrado de Administração Financeira do Governo Federal) da cidade

    }
}
