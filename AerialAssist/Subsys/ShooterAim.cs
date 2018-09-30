
//====================================================================================================================================================
// Copyright 2018 Lake Orion Robobitcs FIRST Team 302
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
// to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE 
// OR OTHER DEALINGS IN THE SOFTWARE.
//====================================================================================================================================================


using CTRE.Phoenix;

namespace HeroDemoBots.AerialAssist.Subsys
{
    //==================================================================================
    /// <summary>
    /// Class:          ShooterAim
    /// Description:    This class is used to aim the shooter.
    /// </summary>
    //==================================================================================
    public class ShooterAim
    {

        public ShooterAim()
        {
        }

        //==============================================================================
        /// <summary>
        /// Method:         AimHigh
        /// Description:    Aim the shooter to the high position
        /// </summary>
        //==============================================================================
        public void AimHigh()
        {
            RobotMap map = RobotMap.GetInstance();
            PneumaticControlModule pcm = PCM.GetInstance().GetPCM();
            pcm.SetSolenoidOutput(map.GetLiftJawsSolenoidID(), true );
            pcm.SetSolenoidOutput(map.GetLowerJawsSolenoidID(), false );
        }

       //==============================================================================
       /// <summary>
       /// Method:         AimLow
       /// Description:    Aim the shooter to the low position
       /// </summary>
       //==============================================================================
       public void AimLow()
        {
            RobotMap map = RobotMap.GetInstance();
            PneumaticControlModule pcm = PCM.GetInstance().GetPCM();
            pcm.SetSolenoidOutput(map.GetLiftJawsSolenoidID(), false );
            pcm.SetSolenoidOutput(map.GetLowerJawsSolenoidID(), true );
        }
        
    }
}