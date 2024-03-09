using MilitaryElite.Enums;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionState state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; private set; }

        public MissionState State { get; private set; }

        public void CompleteMission()
        {
            State = MissionState.Finished;
        }

        public override string ToString()
            => $"Code Name: {CodeName} State: {State}";        
    }
}
