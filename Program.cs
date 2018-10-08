
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
            /*====================================================================
             * Test harness to see of motors and solenoids are working
             * =================================================================== */
            bool testHW = true;

            Test test = new Test();
            Test.TEST_ID testId = Test.TEST_ID.RUN_LEFT_DRIVE;
            /*
            Test.TEST_ID testId = Test.TEST_ID.RUN_RIGHT_DRIVE;
            Test.TEST_ID testId = Test.TEST_ID.RUN_INTAKE;
            Test.TEST_ID testId = Test.TEST_ID.RUN_KICKER;
            Test.TEST_ID testId = Test.TEST_ID.RUN_CLAMP_JAWS;
            Test.TEST_ID testId = Test.TEST_ID.RUN_OPEN_JAWS;
            Test.TEST_ID testId = Test.TEST_ID.RUN_LIFT_JAWS;
            Test.TEST_ID testId = Test.TEST_ID.RUN_LOWER_JAWS;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_ABUTTON;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_BBUTTON;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_XBUTTON;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_YBUTTON;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_LEFTBUMPER;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_RIGHTBUMPER;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_BACKBUTTON;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_STARTBUTTON;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_CENTER1BUTTON;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_CENTER2BUTTON;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_POV0;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_POV45;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_POV90;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_POV135;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_POV180;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_POV225;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_POV270;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_POV315;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_LEFTTRIGGERBUTTON;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_RIGHTTRIGGERBUTTON;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_LEFTJOYSTICKX;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_LEFTJOYSTICKY;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_RIGHTJOYSTICKX;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_RIGHTJOYSTICKY;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_LEFTTRIGGER;
            Test.TEST_ID testId = Test.TEST_ID.RUN_GAMEPAD_RIGHTTRIGGER;
            */

            ArcadeDrive drive = new ArcadeDrive();
            BallHandler mechanism = new BallHandler();

            while ( true )
            {
                CTRE.Phoenix.Watchdog.Feed(); // keep feed the watchdow to enable the motors
                if ( testHW )
                {
                    test.Run(testId);
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
