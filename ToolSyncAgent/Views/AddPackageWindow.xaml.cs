using System.Windows;
using ToolSyncAgent.ViewModels;

namespace ToolSyncAgent.Views;

public partial class AddPackageWindow : Window
{
    public AddPackageViewModel ViewModel { get; }

    public AddPackageWindow()
    {
        InitializeComponent();
        ViewModel = new AddPackageViewModel();
        DataContext = ViewModel;
    }

    // 我们手动处理按钮点击事件来关闭窗口
    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        // DialogResult 用于告诉打开它的窗口，用户是点击了“确定”还是“取消”
        this.DialogResult = true;
    }
}