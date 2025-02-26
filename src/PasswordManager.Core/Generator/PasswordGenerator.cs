using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Shared.Codes;
using PasswordManager.Shared.Lib;

namespace PasswordManager.Core.Generator;

public class PasswordGenerator
{
    public readonly PasswordGeneratorConfiguration Configuration = new();

    private readonly Random Random = new();

    private const string Letters = "abcdefghijklmnopqrstuvwxyz";
    private const string Capitals = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string Numbers = "0123456789";
    private const string Symbols = "&#@$_!:.,*+-";

    public OneOf<string, ErrorCode> Generate()
    {
        List<string> sets = new List<string>
        {
            Letters
        };

        if (Configuration.Length <= 0)
            return (ErrorCode.BadRequest);

        if (Configuration.UseCapital)
            sets.Add(Capitals);

        if (Configuration.UseNumbers)
            sets.Add(Numbers);

        if (Configuration.UseSymbols)
            sets.Add(Symbols);

        return (new string(Enumerable.Range(0, Configuration.Length).Select(_ =>
        {
            int setToUse = Random.Next(0, sets.Count);
            ReadOnlySpan<char> str = sets[setToUse].AsSpan();

            return (str[Random.Next(0, str.Length)]);
        }).ToArray()));
    }
}