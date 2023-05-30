namespace Back_End_Employee.Data.Entities
{
    public class EmployeeWithPhoto
    {
        public string? NameEmployee { get; set; }

        public string? Cpf { get; set; }

        public string? Rg { get; set; }

        public string? ExpeditionAgency { get; set; }

        public DateTime HiringDate { get; set; }

        //public IFormFile Photo { get; set; }

        public int DepartamentId { get; set; }

        public string? MobilePhone { get; set; }

        public string? Address { get; set; }

        public string? Complement { get; set; }

        public string? Neighborhood { get; set; }

        public string? State { get; set; }

        public string? City { get; set; }

        public string? ZipCode { get; set; }

        public decimal Salary { get; set; }
    }

}
