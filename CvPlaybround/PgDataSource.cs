using CvPlaybround;

public class PgDataSource : UICollectionViewDataSource
{
    
    public PgDataSource() : base()
    {
        ItemGroups = new List<ItemGroup>();

        for (int i = 1; i <= 20000; i++)
        {
            var itemGroup = new ItemGroup($"Group {i}");
            
            for (int j = 1; j <= 10; j++)
            {
                itemGroup.Add(new Item($"Item {j}"));    
            }
            
            ItemGroups.Add(itemGroup);
        }
    }

    public Item GetItem(NSIndexPath indexPath)
    {
        return ItemGroups[indexPath.Section][indexPath.Row];
    }
    
    public ItemGroup GetSection(NSIndexPath indexPath)
    {
        return ItemGroups[indexPath.Section];
    }

    public readonly List<ItemGroup> ItemGroups;
    
    public override nint NumberOfSections(UICollectionView collectionView)
    {
        return ItemGroups.Count;
    }

    public override nint GetItemsCount(UICollectionView collectionView, nint section)
    {
        return new nint(ItemGroups[section.ToInt32()].Count);
    }

    

    // public override UICollectionReusableView GetViewForSupplementaryElement(UICollectionView collectionView, NSString elementKind,
    //     NSIndexPath indexPath)
    // {
    //     if (elementKind == UICollectionElementKindSectionKey.Header)
    //     {
    //         var itemGroup = ItemGroups[indexPath.Section];
    //         
    //         var v = collectionView.DequeueReusableSupplementaryView(elementKind, "HEADER", indexPath);
    //
    //         if (v is null)
    //         {
    //             Console.WriteLine("NULL HEADER");
    //         }
    //         if (v is PgHeader header)
    //         {
    //             Console.WriteLine($"HEADERVIEW: {indexPath.Section}");
    //             header.SetItemGroup(itemGroup);
    //         }
    //
    //         return v;
    //     }
    //     
    //     return base.GetViewForSupplementaryElement(collectionView, elementKind, indexPath);
    // }
    
    public UICollectionViewSupplementaryRegistration HeaderRegistration { get; set; }

    public override UICollectionReusableView GetViewForSupplementaryElement(UICollectionView collectionView, NSString elementKind,
        NSIndexPath indexPath)
    {
        return collectionView.DequeueConfiguredReusableSupplementaryView(HeaderRegistration, indexPath);
    }

    public UICollectionViewCellRegistration CellRegistration { get; set; }
    public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
    {
        var itemGroup = ItemGroups[indexPath.Section];
        var item = itemGroup[indexPath.Row];
        return collectionView.DequeueConfiguredReusableCell(CellRegistration, indexPath, item);
    }
    
}