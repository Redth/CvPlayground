namespace CvPlaybround;

public class MainViewController : UIViewController
{
    private PgCollectionView cv;
    private PgLayout layout;
    private PgDataSource dataSource;
    
    public MainViewController() : base()
    {
        
        layout = new PgLayout();
    
        cv = new PgCollectionView(this.View!.Frame, layout);
        
        cv.RegisterClassForSupplementaryView(typeof(PgHeader), UICollectionElementKindSectionKey.Header, "HEADER");
        cv.RegisterClassForCell(typeof(PgCell), "CELL");

        layout.EstimatedItemSize = UICollectionViewFlowLayout.AutomaticSize;
        layout.ItemSize = UICollectionViewFlowLayout.AutomaticSize;
        layout.SectionInset = new UIEdgeInsets(0, 0, 0, 0);
        layout.MinimumInteritemSpacing = 0f;
        layout.MinimumLineSpacing = 0f;
        layout.HeaderReferenceSize = UICollectionViewFlowLayout.AutomaticSize;
        
        dataSource = new PgDataSource();

        cv.DataSource = dataSource;
        cv.Delegate = layout;

        View!.AddSubview(cv);
    }

}

public static class HeightHelper
{
    private static Random rnd = new Random();
    
    public static nfloat Next()
    {
        return rnd.Next(30, 120);
    }
}

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

public class ItemGroup : List<Item>
{
    public ItemGroup(string title) : base()
    {
        Height = HeightHelper.Next();
        // var c = ColorHelper.Next();
        // Color = c.Color;
        Color = UIColor.Magenta;
        
        GroupTitle = $"{title}, {Height}";
    }
    
    public string GroupTitle { get; set; }
    
    public nfloat Height { get; set; }
    
    public UIColor Color { get; private set; }
}

public class Item
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