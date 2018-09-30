
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
    /// Class:          ArcadeDrive
    /// Description:    This class controls the robot using arcade drive which uses one
    ///                 joystick as the throttle and the other as the steering.  The
    ///                 speeds on each side are the robot are calculated as follows:
    ///                      left = throttle - steer
    ///                      right = throttle + steer
    ///
    ///                 Since this can yield values outside the nominal -1.0 to 1.0 range,
    ///                 so the each value is then divided by the maximum value if it is 
    ///                 outside this range to scale the calculated values to be within 
    ///                 range. 
    /// </summary>
    //==================================================================================
    public class ArcadeDrive : IDrive
    {
        IChassis m_chassis;

        public ArcadeDrive()
        {
            m_chassis = new PWMChassis();
        }

 
        public override void DriveWithJoysticks()
        {
            TeleopControl gamepad = TeleopControl.GetInstance();
            if ( gamepad != null )
            {
                double throttle = gamepad.GetAxisValue( TeleopControl.FUNCTION_IDENTIFIER.ARCADE_DRIVE_THROTTLE );
                double steer    = gamepad.GetAxisValue( TeleopControl.FUNCTION_IDENTIFIER.ARCADE_DRIVE_STEER );

                double left = throttle - steer;
                double right = throttle + steer;

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