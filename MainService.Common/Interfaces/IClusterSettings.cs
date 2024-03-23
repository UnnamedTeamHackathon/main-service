namespace MainService.Common.Interfaces;

public interface IClusterSettings
{
    public string TaskService { get; }
    public string AwardService { get; }
    public string StorageService { get; }
}