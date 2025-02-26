using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Shared.Codes;

namespace PasswordManager.Shared.Lib;

public class GenericResult : OneOf<SuccessCode, ErrorCode>
{
    public GenericResult() { }
    public GenericResult(SuccessCode t0) : base(t0) { }
    public GenericResult(ErrorCode t1) : base(t1) { }
    public GenericResult(SuccessCode? t0, ErrorCode? t1) : base(t0, t1) { } 

    public static implicit operator GenericResult(SuccessCode value) => new(value);
    public static implicit operator GenericResult(ErrorCode value) => new(value);
    public static GenericResult FromOneOf(OneOf<SuccessCode, ErrorCode> value) => new(value.T_0, value.T_1);

    public bool IsSuccess()
    {
        return (T_0 != null);
    }

    public bool IsError()
    {
        return (T_1 != null);
    }

    public SuccessCode GetSuccess()
    {
        return (T_0!);
    }

    public ErrorCode GetError()
    {
        return (T_1!);
    }
}