using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Database.Models;

namespace PasswordManager.Core.Session;

public class SessionContainer
{
    public Guid Id;
    public Account? Account { get; set; }
}