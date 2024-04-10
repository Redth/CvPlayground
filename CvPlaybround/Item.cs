namespace CvPlaybround;

public class Item : NSObject
{
    public Item(string title)
    {
        Height = HeightHelper.Next();
        var c = ColorHelper.Next();
        Color = c.Color;
        
        ItemTitle = $"{title}, {Height}, {c.Name}";
    }
    
    public string ItemTitle { get; set; }
    
    public nfloat Height { get; set; }
    public UIColor Color { get; private set; }
}