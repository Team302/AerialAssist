
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


using CTRE.Phoenix.MotorControl.CAN;
using CTRE.Phoenix;

namespace HeroDemoBots.AerialAssist.Subsys
{
    //==================================================================================
    /// <summary>
    /// Class:          Kicker
    /// Description:    This class propels the ball using the kicking mechanism.
    /// </summary>
    //==================================================================================
    public class Kicker
    {
        private TalonSRX m_motor;
        private static double m_holdSpeed = 0.0;
        private static double m_kickSpeed = 1.0;

        public Kicker()
        {
            RobotMap map = RobotMap.GetInstance();

            m_motor = new TalonSRX( map.GetKickerMotorID() );
            m_motor.SetInverted( false );
        }

        public void Hold()
        {
            // TODO: need to look at encoder to see if it is in position, so we can stop the motor.
            RobotMap map = RobotMap.GetInstance();
            PneumaticControlModule pcm = PCM.GetInstance().GetPCM();
            pcm.SetSolenoidOutput(map.GetReleaseKickerSolenoidID(), false );
            pcm.SetSolenoidOutput(map.GetHoldKickerSolenoidID(), true );
            m_motor.Set( CTRE.Phoenix.MotorControl.ControlMode.PercentOutput,  m_holdSpeed );
        }

        public void Kick()
        {
            RobotMap map = RobotMap.GetInstance();
            PneumaticControlModule pcm = PCM.GetInstance().GetPCM();
            pcm.SetSolenoidOutput(map.GetReleaseKickerSolenoidID(), true );
            pcm.SetSolenoidOutput(map.GetHoldKickerSolenoidID(), false );
            m_motor.Set( CTRE.Phoenix.MotorControl.ControlMode.PercentOutput,  m_kickSpeed );
        }
        
    }
}
