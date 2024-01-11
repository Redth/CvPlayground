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

    public readonly List<ItemGroup> ItemGroups;
    
    public override nint NumberOfSections(UICollectionView collectionView)
    {
        return ItemGroups.Count;
    }

    public override nint GetItemsCount(UICollectionView collectionView, nint section)
    {
        return new nint(ItemGroups[section.ToInt32()].Count);
    }
    
    

    public override UICollectionReusableView GetViewForSupplementaryElement(UICollectionView collectionView, NSString elementKind,
        NSIndexPath indexPath)
    {
        if (elementKind == UICollectionElementKindSectionKey.Header)
        {
            var itemGroup = ItemGroups[indexPath.Section];
            
            var v = collectionView.DequeueReusableSupplementaryView(elementKind, "HEADER", indexPath);

            if (v is PgHeader header)
            {
                header.SetItemGroup(itemGroup);
            }

            return v;
        }
        
        return base.GetViewForSupplementaryElement(collectionView, elementKind, indexPath);
    }
    
    public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
    {
        var itemGroup = ItemGroups[indexPath.Section];
        var item = itemGroup[indexPath.Row];
        
        var v = collectionView.DequeueReusableCell("CELL", indexPath) as PgCell;
        v.SetItem(item);
        
        return v;
    }
    
    
}