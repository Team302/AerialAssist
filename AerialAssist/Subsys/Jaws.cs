using System;
using Microsoft.SPOT;

using CTRE.Phoenix;

namespace HeroDemoBots.AerialAssist.Subsys
{
    class Jaws
    {
        public Jaws()
        {
        }

        public void Open()
        {
            RobotMap map = RobotMap.GetInstance();
            PneumaticControlModule pcm = PCM.GetInstance().GetPCM();
            pcm.SetSolenoidOutput(map.GetCloseJawsSolenoidID(), false);
            pcm.SetSolenoidOutput(map.GetOpenJawsSolenoidID(), true);
        }

        public void Close()
        {
            RobotMap map = RobotMap.GetInstance();
            PneumaticControlModule pcm = PCM.GetInstance().GetPCM();
            pcm.SetSolenoidOutput(map.GetCloseJawsSolenoidID(), true);
            pcm.SetSolenoidOutput(map.GetOpenJawsSolenoidID(), false);

        }

        public void Neutral()
        {
            RobotMap map = RobotMap.GetInstance();
            PneumaticControlModule pcm = PCM.GetInstance().GetPCM();
            pcm.SetSolenoidOutput(map.GetCloseJawsSolenoidID(), false);
            pcm.SetSolenoidOutput(map.GetOpenJawsSolenoidID(), false);
        }
    }
}
