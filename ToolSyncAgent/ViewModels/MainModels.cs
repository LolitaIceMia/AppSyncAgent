using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToolSyncAgent.Data;
using ToolSyncAgent.Views;

namespace ToolSyncAgent.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public ObservableCollection<SoftwarePackage> Packages { get; } = new();

    public MainViewModel()
    {
        using var db = new AppDbContext();
        foreach (var p in db.Packages.ToList())
            Packages.Add(p);
    }

    // 打开添加软件对话框
    [RelayCommand]
    private void AddPackage()
    {
        var win = new AddPackageWindow
        {
            Owner = Application.Current.MainWindow
        };

        var result = win.ShowDialog();
        if (result != true)
            return;

        var vm = win.ViewModel;
        var name = vm.PackageName?.Trim();
        if (string.IsNullOrEmpty(name))
            return;

        var version = string.IsNullOrWhiteSpace(vm.PackageVersion)
            ? "N/A"
            : vm.PackageVersion!.Trim();

        var newPkg = new SoftwarePackage
        {
            Name = name,
            CurrentVersion = version,
            Status = "待安装"
        };

        try
        {
            using var db = new AppDbContext();
            db.Packages.Add(newPkg);
            db.SaveChanges();
            Packages.Add(newPkg);
        }
        catch
        {
            // 生产中可加日志或消息提示
        }
    }
}
