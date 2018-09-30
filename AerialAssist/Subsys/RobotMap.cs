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


namespace HeroDemoBots.AerialAssist.Subsys
{
    //==================================================================================
    /// <summary>
    /// Class:          RobotMap
    /// Description:    This Singleton class defines the key hardware features.
    /// </summary>
    //==================================================================================
    public sealed class RobotMap
    {
        private RobotMap()
        {
        }
        private static RobotMap instance = null;
        public static RobotMap GetInstance()
        {
            if (instance == null)
            {
                instance = new RobotMap();
            }
            return instance;
        }

        private const int m_pwmLeftDrive = 9;
        private const int m_pwmRightDrive = 7;

        private const int m_pwmIntake = 8;

        private const int m_canKicker = 1;

        private const int m_pcm = 0;
        private const int m_liftJawsUp = 0;
        private const int m_lowerJaws = 1;
        private const int m_openJaws = 2;
        private const int m_closeJaws = 3;
        private const int m_shifter = 4;
        private const int m_holdKicker = 5;




        public Microsoft.SPOT.Hardware.Cpu.PWMChannel GetLeftDriveMotorID()
        {
            return (Microsoft.SPOT.Hardware.Cpu.PWMChannel)m_pwmLeftDrive;
        }

        public Microsoft.SPOT.Hardware.Cpu.PWMChannel GetRightDriveMotorID()
        {
            return (Microsoft.SPOT.Hardware.Cpu.PWMChannel)m_pwmRightDrive;
        }

        public Microsoft.SPOT.Hardware.Cpu.PWMChannel GetIntakeMotorID()
        {
            return (Microsoft.SPOT.Hardware.Cpu.PWMChannel)m_pwmIntake;
        }

        public int GetKickerMotorID()
        {
            return m_canKicker;
        }

        public int GetPCMID()
        {
            return m_pcm;
        }
        
        public int GetLiftJawsSolenoidID()
        {
            return m_liftJawsUp;
        }

        public int GetLowerJawsSolenoidID()
        {
            return m_lowerJaws;
        }

        public int GetOpenJawsSolenoidID()
        {
            return m_openJaws;
        }

        public int GetCloseJawsSolenoidID()
        {
            return m_closeJaws;
        }

        public int GetReleaseKickerSolenoidID()
        {
            return m_holdKicker;
        }

        public int GetHoldKickerSolenoidID()
        {
            return m_holdKicker;
        }

        public int GetShifterSolenoidID()
        {
            return m_shifter;
        }
    }
}
