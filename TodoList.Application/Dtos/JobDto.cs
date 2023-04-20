using System;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Application.Dtos
{
    public class JobDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório."),
        StringLength(50, MinimumLength = 3, ErrorMessage = "Insira de 2 a 30 caracteres.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório."),
            StringLength(200, MinimumLength = 6, ErrorMessage = "Insira de 5 á 140 caracteres.")]
        public string Description { get; set; }
        public int TagId { get; set; }
        public TagDto TagDto {get; set; }
        public int UserId { get; set; }
        public UserDto UserDto { get; set; }

        public DateTime CreateDate { get; set; }

        // todo - verificar necessidade de utilizar os Dtos.
    }
}
