using System.ComponentModel.DataAnnotations;

namespace EasyLangCsharp.Models
{
    public class User {
        public enum UserType
        {
            User,
            Translator,
            SeniorTranslator,
            Manager
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserMember {get; set;}

    }
}
