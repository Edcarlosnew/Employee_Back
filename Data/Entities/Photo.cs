namespace Back_End_Employee.Data.Entities
{
    public class Photo
    {
        public int Id { get; set; } // Id
        public string? NamePhoto { get; set; } // Nome da Foto
        public byte[]? PhotoImage { get; set; } // Imagem em Binario
        public byte[]? ImageFile { get; set; } // Imagem em Binario
        public int EmployeeId { get; set; } // FK referente a Tabela Employee


    }
}
