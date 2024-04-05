namespace CvPlaybround;

public class MainViewController : UIViewController
{
    private PgCollectionView cv;
    private UICollectionViewLayout layout;
    private PgDataSource dataSource;
    
    public MainViewController() : base()
    {

        var config = new UICollectionLayoutListConfiguration(UICollectionLayoutListAppearance.Plain);
        config.HeaderMode = UICollectionLayoutListHeaderMode.Supplementary;
        
        layout = UICollectionViewCompositionalLayout.GetLayout(config);

        
        
        
        cv = new PgCollectionView(this.View!.Frame, layout);
        cv.SetCollectionViewLayout(layout, false);
        
        
        var cellRegistration = UICollectionViewCellRegistration.GetRegistration(typeof(PgCell), (cell, indexPath, item) =>
        {
            var dsItem = dataSource.GetItem(indexPath);
            (cell as PgCell)?.SetItem(dsItem);
        });

        var headerRegistration = UICollectionViewSupplementaryRegistration.GetRegistration(typeof(PgHeader),
            UICollectionElementKindSectionKey.Header,
            (view, kind, indexPath) =>
            {
                if (view is PgHeader header)
                {
                    var dsSection = dataSource.GetSection(indexPath);
                    (view as PgHeader)?.SetItemGroup(dsSection);
                }
            });
        // cv.RegisterClassForSupplementaryView(typeof(PgHeader), UICollectionElementKindSectionKey.Header, "HEADER");
        // cv.RegisterClassForCell(typeof(PgCell), "CELL");

        // layout.EstimatedItemSize = UICollectionViewFlowLayout.AutomaticSize;
        // layout.ItemSize = UICollectionViewFlowLayout.AutomaticSize;
        // layout.SectionInset = new UIEdgeInsets(0, 0, 0, 0);
        // layout.MinimumInteritemSpacing = 0f;
        // layout.MinimumLineSpacing = 0f;
        // layout.HeaderReferenceSize = UICollectionViewFlowLayout.AutomaticSize;
        
        dataSource = new PgDataSource();
        dataSource.CellRegistration = cellRegistration;
        dataSource.HeaderRegistration = headerRegistration;
        
        cv.DataSource = dataSource;
        //cv.Delegate = layout;

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