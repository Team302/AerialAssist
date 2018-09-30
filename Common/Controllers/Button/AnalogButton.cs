
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


using HeroDemoBots.Common.Controllers.Axis;

namespace HeroDemoBots.Common.Controllers.Button
{
    //==================================================================================
    /// <summary>
    /// Class:          AnalogButton
    /// Description:    This class is used to treat analog inputs such as 
    ///                 triggers and joysticks as buttons (true/false)
    /// </summary>
    //==================================================================================
    public class AnalogButton : IButton
    {
        private AnalogAxis       m_axis;
        private const double     m_pressedTol = 0.5;
    
        
        //==================================================================================
        /// <summary>
        /// Method:         AnalogButton
        /// Description:    Retain the analog input (axis) that will be treated as a button.
        /// </summary>
        //==================================================================================
        public AnalogButton 
        (
            AnalogAxis            axis                // <I> - axis to treat as a button
        )
        {
            m_axis = axis;
        }

        //==================================================================================
        /// <summary>
        /// Method:         IsButtonPressed
        /// Description:    Read the analog input.   If its value is greater than the 
        ///                 threshhold, return true. Otherwise return false.
        /// </summary>
        //==================================================================================
        public override bool IsButtonPressed()
        {
            bool isPressed = false;
            if ( m_axis != null )
            {
                double val = m_axis.GetAxisValue();
                if ( System.Math.Abs( val ) > m_pressedTol )
                {
                    isPressed = true; 
                }
            }
            return isPressed;
        }      
    }
}
