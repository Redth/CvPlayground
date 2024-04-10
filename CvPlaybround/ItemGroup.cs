namespace CvPlaybround;

public class ItemGroup : List<Item>
{
    public ItemGroup(string title) : base()
    {
        Height = HeightHelper.Next();
        // var c = ColorHelper.Next();
        // Color = c.Color;
        Color = UIColor.Magenta;
        
        GroupTitle = $"{title} (Height: {Height})";
    }
    
    public string GroupTitle { get; set; }
    
    public nfloat Height { get; set; }
    
    public UIColor Color { get; private set; }
}