using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EasyLangCsharp.Data;
using System;
using System.Linq;

namespace EasyLangCsharp.Models
{
    public class SeedUser
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
             using (var context = new EasyLangCsharpContext(
                        serviceProvider.GetRequiredService<
                            DbContextOptions<EasyLangCsharpContext>>()))
             {
                 if (context.User.Any())
                 {
                     return;
                 }
                context.User.AddRange(
                    new User
                    {
                        Id = 1,
                        Name = "Yusup",
                        Surname = "Beregovich",
                        Email = "yusup.bereg@yahoo.com",
                        Password = "12345",
                        UserMember = User.UserType.Translator
                    },
                    new User
                    {
                        Id = 2,
                        Name = "Pavel",
                        Surname = "Chasovnik",
                        Email = "pavel.chasov@yahoo.com",
                        Password = "12345",
                        UserMember = User.UserType.SeniorTranslator
                    },
                    new User
                    {
                        Id = 3,
                        Name = "Oleg",
                        Surname = "Dolgoruk",
                        Email = "olegdlyni1997@yandex.ru",
                        Password = "12345",
                        UserMember = User.UserType.User
                    }
                    );
             }
        }
    }
}
