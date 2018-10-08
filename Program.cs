
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

using System.Threading;

using Microsoft.SPOT.Hardware;

using HeroDemoBots.AerialAssist.Teleop;
using HeroDemoBots.Common.Hardware;

namespace AerialAssist
{
    //==================================================================================
    /// <summary>
    /// Class:          Program
    /// Description:    This is the main class that sets up the main robot loop making 
    ///                 sure the watchdog is fed and calls the appropriate teleop code.
    /// </summary>
    //==================================================================================
    public class Program
    {
        public static void Main()
        {
            // Start PWM Signals
            PWM channel7 = HeroPWM.StartPWM(CTRE.HERO.IO.Port3.PWM_Pin7);
            PWM channel8 = HeroPWM.StartPWM(CTRE.HERO.IO.Port3.PWM_Pin8);
            PWM channel9 = HeroPWM.StartPWM(CTRE.HERO.IO.Port3.PWM_Pin9);
            
            /*====================================================================
             * Test harness to see of motors and solenoids are working
             * =================================================================== */
            bool testHW = true;

            Test test = new Test();

            ArcadeDrive drive = new ArcadeDrive();
            BallHandler mechanism = new BallHandler();

            while ( true )
            {
                CTRE.Phoenix.Watchdog.Feed(); // keep feed the watchdow to enable the motors
                if ( testHW )
                {
                    test.Run(Test.TEST_ID.RUN_LEFT_DRIVE);
                }
                else
                {
                    drive.DriveWithJoysticks();
                    mechanism.Run();
                }
                Thread.Sleep(20);

            }
        }
    }
}
