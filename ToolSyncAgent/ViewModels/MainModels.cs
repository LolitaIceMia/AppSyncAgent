using System.Collections.ObjectModel;
using System;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToolSyncAgent.Data;
using ToolSyncAgent.Views;

namespace ToolSyncAgent.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public ObservableCollection<SoftwarePackage> Packages { get; set; }

    public MainViewModel()
    {
        // 初始化集合，防止后续 Add 时出现 NullReferenceException
        Packages = new ObservableCollection<SoftwarePackage>();
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
            Status = "待安装",
            LastCheckedTime = DateTime.Now
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
            // TODO: 生产环境可记录日志
        }
    }

    [RelayCommand]
    private void CheckForUpdates(SoftwarePackage package)
    {
        if (package == null) return;

        // 模拟检查更新
        MessageBox.Show($"正在为 '{package.Name}' 检查更新...\n下载地址: {package.DownloadUrl}", "检查更新");

        // 更新状态和最后检查时间（触发属性变更通知）
        package.Status = "检查完成";
        package.LastCheckedTime = DateTime.Now;

        // 更新数据库
        using (var db = new AppDbContext())
        {
            db.Packages.Update(package);
            db.SaveChanges();
        }
        // 不再需要手动强制刷新，SoftwarePackage 实现了 INotifyPropertyChanged
    }
}
