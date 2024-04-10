namespace CvPlaybround;

public static class ColorHelper
{
    private static Random rnd = new Random();

    private static Dictionary<string, UIColor> Colors = new Dictionary<string, UIColor>()
    {
        { "Red", UIColor.Red },
        { "Green", UIColor.Green },
        { "Blue", UIColor.Blue },
    };

    private static int colorOn = 0;

    public static (string Name, UIColor Color) Next()
    {
        var c = Colors.ElementAt(colorOn);
        colorOn++;
        if (colorOn > Colors.Count - 1)
            colorOn = 0;
        return (c.Key, c.Value);
    }
}