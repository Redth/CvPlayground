namespace CvPlaybround;

public class PgDataSource : UICollectionViewDataSource
{
    readonly List<ItemGroup> itemGroups;
    readonly UICollectionViewSupplementaryRegistration headerRegistration;
    readonly UICollectionViewCellRegistration cellRegistration;
    
    public PgDataSource(IEnumerable<ItemGroup> itemGroups) : base()
    {
        this.itemGroups = new List<ItemGroup>(itemGroups);
        
        cellRegistration = UICollectionViewCellRegistration.GetRegistration(typeof(PgCell),
            (cell, indexPath, item) =>
                (cell as PgCell)?.SetItem(this.itemGroups[indexPath.Section][indexPath.Row]));

        headerRegistration = UICollectionViewSupplementaryRegistration.GetRegistration(typeof(PgHeader),
            UICollectionElementKindSectionKey.Header,
            (view, kind, indexPath) =>
                (view as PgHeader)?.SetItemGroup(this.itemGroups[indexPath.Section]));
    }
    
    public override nint NumberOfSections(UICollectionView collectionView)
        => itemGroups.Count;

    public override nint GetItemsCount(UICollectionView collectionView, nint section)
        => new nint(itemGroups[section.ToInt32()].Count);
    
    public override UICollectionReusableView GetViewForSupplementaryElement(UICollectionView collectionView, NSString elementKind,
        NSIndexPath indexPath)
        => collectionView.DequeueConfiguredReusableSupplementaryView(headerRegistration, indexPath);

    public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
    {
        var itemGroup = itemGroups[indexPath.Section];
        var item = itemGroup[indexPath.Row];
        return collectionView.DequeueConfiguredReusableCell(cellRegistration, indexPath, item);
    }
}
