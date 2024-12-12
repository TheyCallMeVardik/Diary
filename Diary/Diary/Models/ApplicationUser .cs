using Microsoft.AspNetCore.Identity;

namespace Diary.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserType {  get; set; }//тип пользователя 
    }
}
