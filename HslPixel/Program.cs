using System;

namespace HslPixel;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("=== HSL Pixel Demo (Variant 4) ===");

        ShowNormalization();
        ShowOperations();
        ShowConversions();
    }

    private static void ShowNormalization()
    {
        Console.WriteLine("\n1) Normalization and clamping:");

        var pixelFromOutOfRange = new HslPixel(-30, -5, 130);
        Console.WriteLine($"Constructed with (-30, -5, 130): {pixelFromOutOfRange}");

        var pixelWithLargeHue = new HslPixel(390, 40, 70);
        Console.WriteLine($"Constructed with (390, 40, 70): {pixelWithLargeHue}");
    }

    private static void ShowOperations()
    {
        Console.WriteLine("\n2) Operator overloads:");

        var a = new HslPixel(40, 30, 20);
        var b = new HslPixel(330, 80, 70);

        Console.WriteLine($"a = {a}");
        Console.WriteLine($"b = {b}");

        Console.WriteLine($"a + b = {a + b}");
        Console.WriteLine($"a - b = {a - b}");
        Console.WriteLine($"a * b = {a * b}");

        Console.WriteLine($"a + 15 = {a + 15}");
        Console.WriteLine($"a - 20 = {a - 20}");
        Console.WriteLine($"a * 1.5 = {a * 1.5}");
        Console.WriteLine($"a / 2 = {a / 2}");

        Console.WriteLine($"a == b -> {a == b}");
        Console.WriteLine($"a != b -> {a != b}");
        Console.WriteLine($"a == new HslPixel(40, 30, 20) -> {a == new HslPixel(40, 30, 20)}");

        try
        {
            _ = a / 0;
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"a / 0 -> exception: {ex.Message}");
        }
    }

    private static void ShowConversions()
    {
        Console.WriteLine("\n3) HSL -> RGB/HEX:");

        ShowColorCheck(new HslPixel(0, 100, 50), "#FF0000");
        ShowColorCheck(new HslPixel(120, 100, 50), "#00FF00");
        ShowColorCheck(new HslPixel(240, 100, 50), "#0000FF");

        var sample = new HslPixel(210, 50, 60);
        var (r, g, b) = sample.ToRgb();
        Console.WriteLine($"{sample} -> RGB({r}, {g}, {b}) -> {sample.ToHex()}");
    }

    private static void ShowColorCheck(HslPixel pixel, string expectedHex)
    {
        var (r, g, b) = pixel.ToRgb();
        Console.WriteLine($"{pixel} -> RGB({r}, {g}, {b}), HEX {pixel.ToHex()} (expected {expectedHex})");
    }
}
