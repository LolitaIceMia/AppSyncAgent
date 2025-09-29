using System.Collections.ObjectModel;
using System.Windows;

namespace ToolSyncAgent; // 你的项目命名空间

public partial class MainWindow : Window
{
    public ObservableCollection<SoftwarePackage> Packages { get; set; }

    public MainWindow()
    {
        InitializeComponent();

        // 3. 初始化这个列表，并添加一些测试数据
        Packages = new ObservableCollection<SoftwarePackage>
        {
            new SoftwarePackage { Name = "Git", CurrentVersion = "2.44.0", Status = "已安装" },
            new SoftwarePackage { Name = "7-Zip", CurrentVersion = "23.01", Status = "已安装" },
            new SoftwarePackage { Name = "FFmpeg", CurrentVersion = "N/A", Status = "未安装" },
        };

        this.DataContext = this;
    }
}