namespace CvPlaybround;

public class MainViewController : UIViewController
{
    PgCollectionView cv;
    PgDataSource dataSource;
    UICollectionViewLayout tableLayout;
    
    readonly List<ItemGroup> itemGroups = new ();
    
    public MainViewController() : base()
    {
        // Generate some test data (a lot of it)
        var rnd = new Random();
        for (int i = 1; i <= 20000; i++)
        {
            var itemGroup = new ItemGroup($"Group {i}");
            
            for (int j = 1; j <= rnd.Next(5, 25); j++)
            {
                itemGroup.Add(new Item($"Item {j}"));    
            }
            
            itemGroups.Add(itemGroup);
        }

        // Create a layout config for list
        var layoutConfig = new UICollectionLayoutListConfiguration(UICollectionLayoutListAppearance.Plain);
        layoutConfig.HeaderMode = UICollectionLayoutListHeaderMode.Supplementary;
        layoutConfig.HeaderTopPadding = 0;
        
        // Create the actual layout from our config
        tableLayout = UICollectionViewCompositionalLayout.GetLayout(layoutConfig);

        // Create the collectionview with our layout
        cv = new PgCollectionView(this.View!.Frame, tableLayout);
        
        // Data source
        dataSource = new PgDataSource(itemGroups);
    
        // Assign the data source
        cv.DataSource = dataSource;

        // Add our view
        View!.AddSubview(cv);
    }
}