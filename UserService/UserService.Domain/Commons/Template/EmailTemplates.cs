using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.Commons.Template;

public class EmailTemplates
{
    public const string RegistrationEmailTemplate =
        @"
<body style=""padding: 0; margin: 0; background: #2f2f2f; font-family: Helvetica; border-radius: 10px;"">
    <header style=""background: linear-gradient(to right,#ff4b2c, #ff416b); display: flex; padding: 5px;"">
        <svg width=""30"" height=""30"" viewBox=""0 0 365 446"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
<path d=""M285 34C285 52.7777 269.778 68 251 68C232.222 68 217 52.7777 217 34C217 15.2223 232.222 0 251 0C269.778 0 285 15.2223 285 34Z"" fill=""white""/>
<path d=""M156.5 374L263.5 254C172 280 125.5 236.5 166.5 162C212.5 73.9999 92 65.5 1 122.5C85.5 27 178 44.5 217.5 70C292 118.095 192.5 202 192.5 202C192.5 202 463.5 199 156.5 374Z"" fill=""white""/>
<path d=""M266 122.5C267.54 145.319 263.755 155.919 251 172C304 179.5 371.5 137 364.5 36L357.5 38C344.5 113 303.607 153.083 266 122.5Z"" fill=""white""/>
<path d=""M0 446L150 243.5C159.306 266.009 169.73 272.074 195 274.5L0 446Z"" fill=""white""/>
</svg>

        <h2>СпортТех</h2>
    </header>
    <div style=""padding: 20px;"">
        <p style=""color: #fff"">Уважаемый(ая) <span style=""color: #ff416b;"">@fullname</span>,</p>
        <p style=""color: #fff"">Благодарим вас за регистрацию в нашей системе.</p>
        <br>
        <p style=""color: #fff"">Для завершения процесса регистрации, пожалуйста, введите следующий код для подтверждения email.</p>
        <center><span style=""color: #ff416b;""><h1>@code</h1></span></center>
        <p style=""color: #fff"">С уважением, СпортТех</p>
    </div>
</body>";
}
