using MainService.Common.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MainService.Common;

public class ClusterSettings(IConfiguration configuration) : IClusterSettings
{
    public string TaskService => configuration["ClusterSettings:TaskService"];
    public string AwardService => configuration["ClusterSettings:AwardService"];
    public string StorageService => configuration["ClusterSettings:StorageService"];
}