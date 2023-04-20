using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Application.Dtos
{
    public class TagDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório."),
        StringLength(50, MinimumLength = 3, ErrorMessage = "Insira de 2 a 30 caracteres.")]
        public string Title { get; set; }
        public int UserId { get; set; }
        public IEnumerable<JobDto> Jobs { get; set; }

        // todo - verificar se há necessidade de utilizar os Dtos.
    }
}
