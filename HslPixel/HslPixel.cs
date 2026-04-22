using System;

namespace HslPixel;

public sealed class HslPixel : IEquatable<HslPixel>
{
    public int Hue { get; }
    public int Saturation { get; }
    public int Lightness { get; }

    public HslPixel(int hue, int saturation, int lightness)
    {
        Hue = NormalizeHue(hue);
        Saturation = ClampPercent(saturation);
        Lightness = ClampPercent(lightness);
    }

    public (byte R, byte G, byte B) ToRgb()
    {
        double h = Hue / 360.0;
        double s = Saturation / 100.0;
        double l = Lightness / 100.0;

        double r;
        double g;
        double b;

        if (s == 0)
        {
            r = l;
            g = l;
            b = l;
        }
        else
        {
            double q = l < 0.5 ? l * (1 + s) : (l + s - l * s);
            double p = 2 * l - q;

            r = HueToRgb(p, q, h + 1.0 / 3.0);
            g = HueToRgb(p, q, h);
            b = HueToRgb(p, q, h - 1.0 / 3.0);
        }

        return (ToByte(r), ToByte(g), ToByte(b));
    }

    public string ToHex()
    {
        var (r, g, b) = ToRgb();
        return $"#{r:X2}{g:X2}{b:X2}";
    }

    public override string ToString()
    {
        return $"rgba({Hue},{Saturation}%,{Lightness}%)";
    }

    public bool Equals(HslPixel? other)
    {
        if (other is null)
        {
            return false;
        }

        return Hue == other.Hue && Saturation == other.Saturation && Lightness == other.Lightness;
    }

    public override bool Equals(object? obj)
    {
        return obj is HslPixel other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Hue, Saturation, Lightness);
    }

    public static bool operator ==(HslPixel? left, HslPixel? right)
    {
        if (ReferenceEquals(left, right))
        {
            return true;
        }

        if (left is null || right is null)
        {
            return false;
        }

        return left.Equals(right);
    }

    public static bool operator !=(HslPixel? left, HslPixel? right)
    {
        return !(left == right);
    }

    public static HslPixel operator +(HslPixel left, HslPixel right)
    {
        return new HslPixel(
            left.Hue + right.Hue,
            left.Saturation + right.Saturation,
            left.Lightness + right.Lightness);
    }

    public static HslPixel operator +(HslPixel pixel, double scalar)
    {
        return new HslPixel(
            RoundToInt(pixel.Hue + scalar),
            RoundToInt(pixel.Saturation + scalar),
            RoundToInt(pixel.Lightness + scalar));
    }

    public static HslPixel operator +(double scalar, HslPixel pixel)
    {
        return pixel + scalar;
    }

    public static HslPixel operator -(HslPixel left, HslPixel right)
    {
        return new HslPixel(
            left.Hue - right.Hue,
            left.Saturation - right.Saturation,
            left.Lightness - right.Lightness);
    }

    public static HslPixel operator -(HslPixel pixel, double scalar)
    {
        return new HslPixel(
            RoundToInt(pixel.Hue - scalar),
            RoundToInt(pixel.Saturation - scalar),
            RoundToInt(pixel.Lightness - scalar));
    }

    public static HslPixel operator *(HslPixel left, HslPixel right)
    {
        return new HslPixel(
            left.Hue * right.Hue,
            left.Saturation * right.Saturation,
            left.Lightness * right.Lightness);
    }

    public static HslPixel operator *(HslPixel pixel, double scalar)
    {
        return new HslPixel(
            RoundToInt(pixel.Hue * scalar),
            RoundToInt(pixel.Saturation * scalar),
            RoundToInt(pixel.Lightness * scalar));
    }

    public static HslPixel operator *(double scalar, HslPixel pixel)
    {
        return pixel * scalar;
    }

    public static HslPixel operator /(HslPixel pixel, double scalar)
    {
        if (scalar == 0)
        {
            throw new DivideByZeroException("Scalar for HSL division cannot be zero.");
        }

        return new HslPixel(
            RoundToInt(pixel.Hue / scalar),
            RoundToInt(pixel.Saturation / scalar),
            RoundToInt(pixel.Lightness / scalar));
    }

    private static int NormalizeHue(int hue)
    {
        int normalized = hue % 360;
        return normalized < 0 ? normalized + 360 : normalized;
    }

    private static int ClampPercent(int value)
    {
        return Math.Clamp(value, 0, 100);
    }

    private static int RoundToInt(double value)
    {
        return (int)Math.Round(value, MidpointRounding.AwayFromZero);
    }

    private static byte ToByte(double value)
    {
        int scaled = RoundToInt(value * 255.0);
        return (byte)Math.Clamp(scaled, 0, 255);
    }

    private static double HueToRgb(double p, double q, double t)
    {
        if (t < 0)
        {
            t += 1;
        }

        if (t > 1)
        {
            t -= 1;
        }

        if (t < 1.0 / 6.0)
        {
            return p + (q - p) * 6 * t;
        }

        if (t < 1.0 / 2.0)
        {
            return q;
        }

        if (t < 2.0 / 3.0)
        {
            return p + (q - p) * (2.0 / 3.0 - t) * 6;
        }

        return p;
    }
}
