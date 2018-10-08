
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


using Microsoft.SPOT.Hardware;


namespace HeroDemoBots.Common.Hardware
{
    //==================================================================================
    /// <summary>
    /// Class:          HeroPWM
    /// Description:    Static class creates and starts a PWM "channel" for a given pin. 
    /// </summary>
    //==================================================================================
    public static class HeroPWM
    {
        private const uint m_period = 50000;  //period between pulses
        private const uint m_duration = 1500; //duration of pulse


        //==================================================================================
        /// <summary>
        /// Method:         StartPWM
        /// Description:    Create a PWM channgel and start it.
        /// Returns:        PWM - the started channel.
        /// </summary>
        //==================================================================================
        public static PWM StartPWM
        (
             Cpu.PWMChannel pwmID           // <I> - pin number to activate IO.Port3.PWM_Pinx where x is 4, 6, 7, 8 or 9
        )
        {
            PWM pwm = new PWM(pwmID, m_period, m_duration, PWM.ScaleFactor.Microseconds, false);
            pwm.Start();
            return pwm;
        }
    }
}
