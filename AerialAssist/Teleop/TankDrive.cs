
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
using HeroDemoBots.AerialAssist.Subsys;

namespace HeroDemoBots.AerialAssist.Teleop
{
    //==================================================================================
    /// <summary>
    /// Class:          TankDrive
    /// Description:    This class controls the robot by using two joysticks each 
    ///                 controlling a separate side of the robot.
    /// </summary>
    //==================================================================================
    public class TankDrive : IDrive
    {
        IChassis m_chassis;

        TankDrive()
        {
            m_chassis = new PWMChassis();
        }

        public override void DriveWithJoysticks()
        {
            TeleopControl gamepad = TeleopControl.GetInstance();
            if ( gamepad != null )
            {
                double left  = gamepad.GetAxisValue( TeleopControl.FUNCTION_IDENTIFIER.TANK_DRIVE_LEFT );
                double right = gamepad.GetAxisValue( TeleopControl.FUNCTION_IDENTIFIER.TANK_DRIVE_RIGHT );

                double maxValue = LimitValue.GetMaxValue( left, right );
                if ( maxValue > 1.0 )
                {
                    left /= maxValue;
                    right /= maxValue;
                }
                m_chassis.Drive(left, right);
            }
        }
        
    }
}
