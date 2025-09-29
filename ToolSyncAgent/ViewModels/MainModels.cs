using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using ToolSyncAgent.Data;

namespace ToolSyncAgent.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public ObservableCollection<SoftwarePackage> Packages { get; set; }

    public MainViewModel()
    {
        // --- 从数据库加载数据 ---
        using (var db = new AppDbContext())
        {

            var packagesFromDb = db.Packages.ToList();

            // 4. 用从数据库加载的数据来初始化界面的 ObservableCollection
            Packages = new ObservableCollection<SoftwarePackage>(packagesFromDb);
        }
    }

    [RelayCommand]
    private void AddPackage()
    {
        var newPackage = new SoftwarePackage { Name = "PowerToys", CurrentVersion = "N/A", Status = "待安装" };
        using (var db = new AppDbContext())
        {
            // 5. 将新创建的包添加到数据库上下文中
            db.Packages.Add(newPackage);

            // 6. 保存所有更改到数据库文件
            db.SaveChanges();
        }

        // 7. 更新界面：将新包也添加到界面的集合中
        Packages.Add(newPackage);
    }
}