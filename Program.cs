
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

using CTRE.Phoenix;

using HeroDemoBots.AerialAssist.Teleop;

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
            ArcadeDrive drive = new ArcadeDrive();
            BallHandler mechanism = new BallHandler();

            // loop forever 
            while (true)
            {
                // keep feeding watchdog to enable motors 
                Watchdog.Feed();

                drive.DriveWithJoysticks();
                mechanism.ProcessTelopCommands();

                Thread.Sleep(20);
            }
        }
    }
}