namespace CvPlaybround;

public class PgCollectionView : UICollectionView
{
    public PgCollectionView(CGRect frame, UICollectionViewLayout layout) : base(frame, layout)
    {
        
    }
    
    

    public override UICollectionViewCell? CellForItem(NSIndexPath indexPath)
    {
        return base.CellForItem(indexPath);
    }
}
