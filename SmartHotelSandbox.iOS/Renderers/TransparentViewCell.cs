using UIKit;
using ViewCellRenderer = Microsoft.Maui.Controls.Handlers.Compatibility.ViewCellRenderer;

namespace SmartHotel.Clients.iOS.Renderers;

public class TransparentViewCell : ViewCellRenderer
{
    public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
    {
        var cell = base.GetCell(item, reusableCell, tv);

        if (cell != null)
        {
            cell.SelectionStyle = UITableViewCellSelectionStyle.None;
        }

        return cell;
    }
}