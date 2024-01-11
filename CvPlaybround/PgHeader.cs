namespace CvPlaybround;

public class PgHeader : UICollectionReusableView
{
    [Export("initWithFrame:")]
    public PgHeader(CGRect frame) : base(frame)
    {
        
    }

    public ItemGroup ItemGroup { get; private set; }
    public void SetItemGroup(ItemGroup itemGroup)
    {
        ItemGroup = itemGroup;
        if (!SetupView())
        {
            //titleLabel!.Frame = new CGRect(this.Frame.X, this.Frame.Y, this.Frame.Width, ItemGroup.Height);
        }
        titleLabel!.Text = ItemGroup.GroupTitle;
        titleLabel.BackgroundColor = UIColor.Magenta;
        SetNeedsDisplay();
    }

    private UILabel? titleLabel;

    bool SetupView()
    {
        if (titleLabel is not null)
            return false;

        this.BackgroundColor = UIColor.Magenta;
        titleLabel = new UILabel(this.Frame);
        titleLabel.BackgroundColor = UIColor.Magenta;
        titleLabel.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
        this.AddSubview(titleLabel);
        return true;
    }

    public override CGSize SizeThatFits(CGSize size)
    {
        return new CGSize(size.Width, ItemGroup.Height);
        
    }

    public override UICollectionViewLayoutAttributes PreferredLayoutAttributesFittingAttributes(
        UICollectionViewLayoutAttributes layoutAttributes)
    {
        // Get the smaller of available space or requested item space
        var actualHeight = ItemGroup?.Height ?? layoutAttributes.Size.Height; // Math.Min(layoutAttributes.Size.Height, ItemGroup?.Height ?? layoutAttributes.Size.Height);
        
        layoutAttributes.Frame = new CGRect(0, layoutAttributes.Frame.Y, layoutAttributes.Frame.Width, actualHeight);
    
        //titleLabel.Frame = layoutAttributes.Frame;
        
        return layoutAttributes;
    }
}