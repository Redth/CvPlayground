using CvPlaybround;

internal class PgCell : UICollectionViewCell
{
    public Item Item { get; private set; }

    public void SetItem(Item item)
    {
        Item = item;
        titleLabel.Text = $"{item.ItemTitle} (Height: {Item.Height})";
        titleLabel.BackgroundColor = item.Color;
    }
    
    [Export("initWithFrame:")]
    public PgCell(CGRect frame) : base(frame)
    {
        titleLabel = new UILabel();
        titleLabel.Frame = this.ContentView.Frame;
        titleLabel.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

        ContentView.AddSubview(titleLabel);
    }
    
    private UILabel titleLabel;
    
    public override UICollectionViewLayoutAttributes PreferredLayoutAttributesFittingAttributes(UICollectionViewLayoutAttributes layoutAttributes)
    {
        // Get the smaller of available space or requested item space
        var actualHeight = Item?.Height ?? layoutAttributes.Size.Height; // Math.Min(layoutAttributes.Size.Height, Item?.Height ?? layoutAttributes.Size.Height);
        
        layoutAttributes.Frame = new CGRect(0, layoutAttributes.Frame.Y, layoutAttributes.Frame.Width, actualHeight);
        
        return layoutAttributes;
    }

    
    // public override void PrepareForReuse()
    // {
    //     ContentView.BackgroundColor = UIColor.Clear;
    //     titleLabel.BackgroundColor = UIColor.Clear;
    //     
    //     base.PrepareForReuse();
    // }
}