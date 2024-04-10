using CvPlaybround;

internal class PgCell : UICollectionViewCell
{
    UILabel titleLabel;
    NSLayoutConstraint widthConstraint;
    NSLayoutConstraint heightConstraint;
    NSLayoutConstraint topConstraint;
    
    public Item Item { get; private set; }
    
    [Export("initWithFrame:")]
    public PgCell(CGRect frame) : base(frame)
    {
        titleLabel = new UILabel();
        titleLabel.Frame = frame;
        
        ContentView.AddSubview(titleLabel);
        
        // Seems that autoresizemask isn't as successful here as constraints
        titleLabel.TranslatesAutoresizingMaskIntoConstraints = false;
        
        widthConstraint = titleLabel.WidthAnchor.ConstraintEqualTo(ContentView.WidthAnchor);
        topConstraint = titleLabel.TopAnchor.ConstraintEqualTo(ContentView.TopAnchor);
        heightConstraint = titleLabel.BottomAnchor.ConstraintEqualTo(ContentView.BottomAnchor);

        widthConstraint.Active = true;
        topConstraint.Active = true;
        heightConstraint.Active = true;
    }
    
    public void SetItem(Item item)
    {
        Item = item;
        titleLabel.Text = $"{item.ItemTitle} (Height: {Item.Height})";
        titleLabel.BackgroundColor = item.Color;
    }
    
    public override UICollectionViewLayoutAttributes PreferredLayoutAttributesFittingAttributes(UICollectionViewLayoutAttributes layoutAttributes)
    {
        var newLayoutAttributes = base.PreferredLayoutAttributesFittingAttributes(layoutAttributes);

        newLayoutAttributes.Frame = new CGRect(
            newLayoutAttributes.Frame.X,
            newLayoutAttributes.Frame.Y,
            newLayoutAttributes.Frame.Width,
            Item?.Height ?? newLayoutAttributes.Size.Height);
        
        newLayoutAttributes.ZIndex = 2;
        
        return newLayoutAttributes;
    }
}