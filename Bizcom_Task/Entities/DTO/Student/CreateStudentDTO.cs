﻿using Bizcom_Task.Entities.Model.Enum;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Bizcom_Task.Entities.DTO.Student
{
    public class CreateStudentDTO
    {
        [Required]
        public string FirstName { get; set; }
        public string? LastName { get; set; }

        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public List<CreateStudentSubjectDTO> StudentSubjectDTOs { get; set; }
        [Required]
        public List<CreateStudentTeacherDTO>? TeacherSubjectDTOs { get; set; }
    }
}
