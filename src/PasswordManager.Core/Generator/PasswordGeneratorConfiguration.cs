using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Core.Generator;

public class PasswordGeneratorConfiguration
{
    public bool UseCapital = true;
    public bool UseNumbers = true;
    public bool UseSymbols = true;
    public int Length = 12;
}