using MyShop.Filters;
using System.ComponentModel.DataAnnotations;

namespace Bizcom_Task.Entities.DTO.Student
{
    public class StudentFilterDTO : PaginationParams
    {
        public int? FromAge { get; set; }
        public int? ToAge { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        [Phone]
        public string? AbonentNumber { get; set; }
        public string? StudentName { get; set; }

    }
}
