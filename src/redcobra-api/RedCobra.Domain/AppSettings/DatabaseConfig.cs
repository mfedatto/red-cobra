namespace RedCobra.Domain.AppSettings;

public class DatabaseConfig : IConfig
{
    public string Section => "Database";
    
    public string? ConnectionString { get; set; }
    public bool IncludeErrorDetail { get; set; }
}
