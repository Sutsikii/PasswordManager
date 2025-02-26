namespace PasswordManager.Shared.Lib;

public class OneOf<T0, T1>
{
    public T0? T_0 { get; set; }
    public T1? T_1 { get; set; }

    public OneOf() { }

    public OneOf(T0 t0)
    {
        T_0 = t0;
    }

    public OneOf(T1 t1)
    {
        T_1 = t1;
    }

    public OneOf(T0? _0, T1? _1)
    {
        T_0 = _0;
        T_1 = _1;
    }

    public static implicit operator OneOf<T0, T1>(T0 value) => new(value);
    public static implicit operator OneOf<T0, T1>(T1 value) => new(value);

    public OneOf<T0, T1> Match(Action<T0> t0, Action<T1> t1)
    {
        if (T_0 != null)
            t0(T_0);
        else
            t1(T_1!);

        return (this);
    }

    public OneOf<T0, T1> Match(Func<T0, Task> t0, Func<T1, Task> t1)
    {
        if (T_0 != null)
            t0(T_0);
        else
            t1(T_1!);

        return (this);
    }

    public OneOf<R0, R1> Match<R0, R1>(Func<T0, R0> t0, Func<T1, R1> t1)
    {
        if (T_0 != null)
            return (t0(T_0));

        return (t1(T_1!));
    }

    public bool Is<T>()
    {
        if (T_0 != null && typeof(T0) == typeof(T))
            return (true);

        if (T_1 != null && typeof(T1) == typeof(T))
            return (true);

        return (false);
    }
}