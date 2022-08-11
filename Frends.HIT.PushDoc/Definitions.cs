using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Frends.HIT.PushDoc;

public enum ServerTypes
{
    [Display(Name = "SMB/Windows Share")]
    Smb,
    
    [Display(Name = "FTP")]
    Ftp,
    
    [Display(Name = "SFTP")]
    Sftp,
    
    [Display(Name = "SCP")]
    Scp,
    
    [Display(Name = "Database")]
    Database,
    
    [Display(Name = "Web Service")]
    WebService,
    
    [Display(Name = "Rest API")]
    RestApi,
    
    [Display(Name = "Email")]
    Email,
    
    [Display(Name = "Bank")]
    Bank
}

[DisplayName("Metadata")]
public class IntegrationMetadata
{
    public string IntegrationName { get; set; }
    public string IntegrationVersion { get; set; }
    public string IntegrationAuthor { get; set; }
    public string IntegrationDescription { get; set; }
    
    public ServerTypes SourceServerType { get; set; }
    public string SourceServerName { get; set; }
    public ServerTypes TargetServerType { get; set; }
    public string TargetServerName { get; set; }
}

[DisplayName("Run Log")]
public class RunLogInput
{
    [Display(Name = "Insert Result Variable")]
    [DisplayFormat(DataFormatString = "Expression")]
    public object[] ResultInput { get; set; }
}


public class RunLogItem
{
    public DateTime Timestamp { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public string Metadata { get; set; }
    
    public RunLogItem(
        DateTime timestamp,
        bool success,
        string message,
        string metadata)
    {
        Timestamp = timestamp;
        Success = success;
        Message = message;
        Metadata = metadata;
    }
}