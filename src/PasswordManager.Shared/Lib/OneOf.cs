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

    public static implicit operator OneOf<T0, T1>(T0 value) => new(value);
    public static implicit operator OneOf<T0, T1>(T1 value) => new(value);

    public void Match(Action<T0> t0, Action<T1> t1)
    {
        if (T_0 != null)
        {
            t0(T_0);
            return;
        }

        t1(T_1!);
    }
}