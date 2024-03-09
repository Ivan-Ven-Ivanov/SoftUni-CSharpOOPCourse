using MilitaryElite.Enums;

namespace MilitaryElite.Models.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }
        MissionState State { get; }
        void CompleteMission();
    }
}
