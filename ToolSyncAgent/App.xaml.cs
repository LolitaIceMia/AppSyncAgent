using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using ToolSyncAgent.Data;
using Microsoft.EntityFrameworkCore;

namespace ToolSyncAgent;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        using var db = new AppDbContext();

        Debug.WriteLine("DB File: " + db.Database.GetDbConnection().DataSource);
        
        try
        {
            db.Database.Migrate();
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Migrate failed: " + ex);
        }

        try
        {
            var tableNames = db.Database
                .SqlQueryRaw<string>("SELECT name FROM sqlite_master WHERE type='table'")
                .ToList();
            Debug.WriteLine("Tables: " + string.Join(",", tableNames));
        }
        catch (Exception ex)
        {
            Debug.WriteLine("List tables failed: " + ex.Message);
        }
    }
}
