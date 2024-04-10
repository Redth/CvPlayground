namespace CvPlaybround;

public static class HeightHelper
{
    private static Random rnd = new Random();
    
    public static nfloat Next()
    {
        return rnd.Next(30, 120);
    }
}