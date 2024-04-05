namespace CvPlaybround;

public class ItemGroup : List<Item>
{
    public ItemGroup(string title) : base()
    {
        Id = new Guid().ToString();
        Height = HeightHelper.Next();
        // var c = ColorHelper.Next();
        // Color = c.Color;
        Color = UIColor.Magenta;
        
        GroupTitle = $"{title}, {Height}";
    }
    
    public string Id { get; set; }
    
    public string GroupTitle { get; set; }
    
    public nfloat Height { get; set; }
    
    public UIColor Color { get; private set; }
}