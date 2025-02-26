using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Shared.Payloads;

public class CreatePasswordPayload
{
    [Required] 
    public string Identifiant { get; set; } = "";
    public string Description { get; set; } = "";
    [Required]
    public string Service { get; set; } = "";
    [Required]
    public string Password { get; set; } = "";
}