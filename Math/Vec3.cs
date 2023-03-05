using System.Numerics;

namespace RTOW.Math;

public struct Vec3<T> where T: struct, INumber<T>, IConvertible
{
    public T X, Y, Z;

    public Vec3(T x, T y, T z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    
    public Vec3((T, T, T) v): this(v.Item1, v.Item2, v.Item3) {}

    public Vec3() : this(default, default, default) {}

    public static Vec3<T> operator -(Vec3<T> v)
    {
        return new Vec3<T>(-v.X, -v.Y, -v.Z);
    }

    public static Vec3<T> operator +(Vec3<T> a, Vec3<T> b)
    {
        return new Vec3<T>(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Vec3<T> operator -(Vec3<T> a, Vec3<T> b)
    {
        return new Vec3<T>(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Vec3<T> operator *(T k, Vec3<T> v)
    {
        return new Vec3<T>(k * v.X, k * v.Y, k * v.Z);
    }

    public static Vec3<T> operator *(Vec3<T> v, T k) => k * v;

    public static Vec3<T> operator /(Vec3<T> v, T k)
    {
        return new Vec3<T>(v.X / k, v.Y / k, v.Z / k);
    }

    public T Dot(Vec3<T> v) => (X * v.X + Y * v.Y + Z * v.Z);

    public Vec3<T> Cross(Vec3<T> v)
    {
        return new Vec3<T>(
            Y * v.Z - Z * v.Y,
            Z * v.X - X * v.Z,
            X * v.Y - Y * v.X
        );
    }
    
    public double Length()
    {
        return System.Math.Sqrt(LengthSquared());
    }

    public Vec3<double> ToDouble()
    {
        // TODO: 有待优化
        return new Vec3<double>(
            Convert.ToDouble(X),
            Convert.ToDouble(Y),
            Convert.ToDouble(Z)
        );
    }

    public double LengthSquared()
    {
        var dv = this.ToDouble();
        return dv.Dot(dv);
    }

    public (T, T, T) ToTuple() => (X, Y, Z);

    public Vec3<double> UnitVector()
    {
        var dv = this.ToDouble();
        return dv / dv.Length();
    }
}