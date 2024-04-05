namespace CvPlaybround;

public class Item : NSObject
{
    public Item(string title)
    {
        Id = new Guid().ToString();
        Height = HeightHelper.Next();
        var c = ColorHelper.Next();
        Color = c.Color;
        
        ItemTitle = $"{title}, {Height}, {c.Name}";
    }
    
    public string Id { get; set; }
    
    public string ItemTitle { get; set; }
    
    public nfloat Height { get; set; }
    public UIColor Color { get; private set; }
}