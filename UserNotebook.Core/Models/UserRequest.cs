using System.ComponentModel.DataAnnotations;
using UserNotebook.Core.Models;

namespace UsersNotebook.Core.Models
{
    public class UserRequest
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(150)]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public List<AdditionalParametersDto> Parameters { get; set; } = new List<AdditionalParametersDto>();
    }

    public class CreateUserRequest : UserRequest
    {

    }
    public class UpdateUserRequest : UserRequest
    {
        
    }
}
