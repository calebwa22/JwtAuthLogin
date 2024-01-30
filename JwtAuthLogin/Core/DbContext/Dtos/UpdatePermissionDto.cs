using System.ComponentModel.DataAnnotations;

namespace JwtAuthLogin.Core.DbContext.Dtos
{
    public class UpdatePermissionDto
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }


    }
}
