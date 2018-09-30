
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


using HeroDemoBots.Common.Utils;
using CTRE.Phoenix.MotorControl;


namespace HeroDemoBots.AerialAssist.Subsys
{
    //==================================================================================
    /// <summary>
    /// Class:          PWMChassis
    /// Description:    This class is a chassis that uses PWM Talons.
    /// </summary>
    //==================================================================================
    class PWMChassis : IChassis
    {
        private PWMSpeedController m_leftDrive;
        private PWMSpeedController m_rightDrive;

        public PWMChassis()
        {
            //==================================================================
            // Hardware Map
            // Left Drive  PWM 9
            // Right Drive PWM 7
            //
            //  Solenoid 4 shifter
            //
            // Kicker CAN Talon with encode
            //==================================================================
            RobotMap map = RobotMap.GetInstance();

            m_leftDrive = new PWMSpeedController( map.GetLeftDriveMotorID() );
            m_rightDrive = new PWMSpeedController( map.GetRightDriveMotorID() );
        }

        public override void Drive
        (
            double leftSpeed,        // <I> - % power for the left side ( range -1.0 to 1.0 )
            double rightSpeed        // <I> - % power for the right side ( range -1.0 to 1.0 )
        )
        {
            m_leftDrive.Set(  (float)LimitValue.GetInRange(leftSpeed) );
            m_rightDrive.Set( (float)LimitValue.GetInRange(rightSpeed) );
        }

    }
}
