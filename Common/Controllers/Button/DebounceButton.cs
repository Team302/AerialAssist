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



namespace HeroDemoBots.Common.Controllers.Button
{
    //==================================================================================
    /// <summary>
    /// Class:          DebounceBuutton
    /// Description:    This class is a decorator for an IButton object.  It will
    //                  prevent one press from registering multiple presses.
    /// </summary>
    //==================================================================================
    public class DebounceButton : IButtonDecorator
    {
        private double m_now;
        private const double m_period = 0.2;
        private double       m_lastPressedTime;
    
        public DebounceButton 
        (
            IButton  button            // <I> - button to treat as a toggle 
        ) : base( button )
        {
            m_lastPressedTime = 0.0;
            m_now = 0.0;
        }

        public override bool IsButtonPressed()
        {
            m_now += m_period;
            bool newPress = false;
            if ( base.GetButton() != null )
            {
//                double now = Timer.GetFPGATimestamp();
                bool isPressed = base.GetButton().IsButtonPressed();
                if ( isPressed )
                {
                    if ( ( m_now - m_lastPressedTime ) > m_period )
                    {
                        m_lastPressedTime = m_now;
                        newPress = true;
                    }
                }
            }
            return newPress;
        }      
    }
}
