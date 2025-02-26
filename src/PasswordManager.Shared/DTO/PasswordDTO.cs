using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Shared.DTO;

public class PasswordDTO
{
    public Guid Id { get; set; }
    public Guid Account { get; set; }
    public string Login { get; set; } = "";
    public string Password { get; set; } = "";
    public string Description { get; set; } = "";
}