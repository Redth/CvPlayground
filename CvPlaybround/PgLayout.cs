namespace CvPlaybround;

public class PgLayout : UICollectionViewFlowLayout, IUICollectionViewDelegateFlowLayout
{
    public PgLayout() : base()
    {
        
    }

    // [Export("collectionView:layout:sizeForItemAtIndexPath:")]
    // public CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
    // {
    //     var width = collectionView.SafeAreaLayoutGuide.LayoutFrame.Width - SectionInset.Left - SectionInset.Right;
    //     var height = new nfloat(0);
    //     
    //     if (collectionView.DataSource is PgDataSource pgDataSource)
    //     {
    //         var item = pgDataSource.ItemGroups[indexPath.Section][indexPath.Row];
    //         height = new nfloat(item.Height);
    //     }
    //
    //     Console.WriteLine($"SizeForItem: {width}, {height}");
    //     return new CGSize(width, height);
    // }

    // private int rsfhCalls = 0;
    //
    // [Export("collectionView:layout:referenceSizeForHeaderInSection:")]
    // public CGSize GetReferenceSizeForHeader(UICollectionView collectionView, UICollectionViewLayout layout, nint section)
    // {
    //     var width = collectionView.SafeAreaLayoutGuide.LayoutFrame.Width - SectionInset.Left - SectionInset.Right;
    //     var height = new nfloat(0);
    //     
    //     if (collectionView.DataSource is PgDataSource pgDataSource)
    //     {
    //         var itemGroup = pgDataSource.ItemGroups[section.ToInt32()];
    //         height = new nfloat(itemGroup.Height);
    //     }
    //
    //     rsfhCalls++;
    //     
    //     Console.WriteLine($"GetReferenceSizeForHeader: {width}, {height} ({rsfhCalls} calls)");
    //     return new CGSize(width, height);
    // }

    public override UICollectionViewLayoutAttributes LayoutAttributesForItem(NSIndexPath path)
    {
        var layoutAttributes = base.LayoutAttributesForItem(path);
    
        var width = CollectionView.SafeAreaLayoutGuide.LayoutFrame.Width - SectionInset.Left - SectionInset.Right;
       
        layoutAttributes.Frame = new CGRect(SectionInset.Left, layoutAttributes.Frame.Y, width, layoutAttributes.Frame.Height);
       
        return layoutAttributes;
    }
    
    public override UICollectionViewLayoutAttributes LayoutAttributesForSupplementaryView(NSString kind, NSIndexPath indexPath)
    {
        var layoutAttributes =  new UICollectionViewLayoutAttributes();
    
        var width = CollectionView.SafeAreaLayoutGuide.LayoutFrame.Width - SectionInset.Left - SectionInset.Right;
       
        layoutAttributes.Frame = new CGRect(SectionInset.Left, layoutAttributes.Frame.Y, width, layoutAttributes.Frame.Height);

        return layoutAttributes;
    }
    
    public override UICollectionViewLayoutAttributes[] LayoutAttributesForElementsInRect(CGRect rect)
    {
        var layoutAttributesObjects = base.LayoutAttributesForElementsInRect(rect);
    
        foreach (var layoutAttributes in layoutAttributesObjects)
        {
            if (layoutAttributes.RepresentedElementCategory == UICollectionElementCategory.Cell)
            {
                var newFrame = LayoutAttributesForItem(layoutAttributes.IndexPath).Frame;
                layoutAttributes.Frame = newFrame;
            }
            else if (layoutAttributes.RepresentedElementKind == UICollectionElementKindSectionKey.Header)
            {
                var newFrame = LayoutAttributesForSupplementaryView(UICollectionElementKindSection.Header, layoutAttributes.IndexPath).Frame;
                layoutAttributes.Frame = newFrame;
            }
        }
    
        return layoutAttributesObjects;
    }
}