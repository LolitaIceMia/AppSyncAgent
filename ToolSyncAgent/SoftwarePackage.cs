namespace ToolSyncAgent;

public class SoftwarePackage
{
    //数据库主键
    public int Id { get; set; }

    public string Name { get; set; }

    public string CurrentVersion { get; set; }
    public string Status { get; set; }
    public string DownloadUrl { get; set; }
    public DateTime LastCheckedTime { get; set; }
}