namespace CvPlaybround;

public class PgHeader : UICollectionReusableView
{
    UILabel titleLabel;
    NSLayoutConstraint widthConstraint;
    NSLayoutConstraint heightConstraint;
    NSLayoutConstraint topConstraint;
    
    [Export("initWithFrame:")]
    public PgHeader(CGRect frame) : base(frame)
    {
        titleLabel = new UILabel();
        titleLabel.Frame = frame;
        titleLabel.BackgroundColor = UIColor.Magenta;
        
        AddSubview(titleLabel);
        
        // Seems that autoresizemask isn't as successful here as constraints
        titleLabel.TranslatesAutoresizingMaskIntoConstraints = false;
        
        widthConstraint = titleLabel.WidthAnchor.ConstraintEqualTo(this.WidthAnchor);
        topConstraint = titleLabel.TopAnchor.ConstraintEqualTo(this.TopAnchor);
        heightConstraint = titleLabel.BottomAnchor.ConstraintEqualTo(this.BottomAnchor);

        widthConstraint.Active = true;
        topConstraint.Active = true;
        heightConstraint.Active = true;
    }

    public ItemGroup ItemGroup { get; private set; }
    public void SetItemGroup(ItemGroup itemGroup)
    {
        ItemGroup = itemGroup;
        titleLabel!.Text = ItemGroup.GroupTitle;
    }
    
    public override UICollectionViewLayoutAttributes PreferredLayoutAttributesFittingAttributes(
        UICollectionViewLayoutAttributes layoutAttributes)
    {
        var newLayoutAttributes = base.PreferredLayoutAttributesFittingAttributes(layoutAttributes);
        
        // Resize the frame to the calculated height (for a vertical list)
        newLayoutAttributes.Frame = new CGRect(
            newLayoutAttributes.Frame.X,
            newLayoutAttributes.Frame.Y,
            newLayoutAttributes.Frame.Width,
            ItemGroup?.Height ?? layoutAttributes.Size.Height);
    
        newLayoutAttributes.ZIndex = 1;
        
        return newLayoutAttributes;
    }
}