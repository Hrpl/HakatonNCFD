using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.Commons.Template;

public class EmailTemplates
{
    public const string RegistrationEmailTemplate =
        "<div class=\"content\">\n  " +
        "<p>Уважаемый(ая) @fullname,</p>\n  " +
        "<p>Благодарим вас за регистрацию в нашей системе.</p>\n  " +
        "<p>Для завершения процесса регистрации, пожалуйста, введите следующий код для подтверждения email.</p>\n  " +
        "<h1>@code</h1>\n  ";
}
