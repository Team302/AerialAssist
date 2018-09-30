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
    /// Class:          ToggleButton
    /// Description:    This class is a decorator for an IButton object.  It will
    ///                 treat a button input as a toggle so that it doesn't need
    ///                 to be held to keep a function running.
    /// </summary>
    //==================================================================================
    public class ToggleButton : IButtonDecorator
    {
        private bool        m_isPressed;
        private bool        m_isToggledOn;
    
        public ToggleButton 
        (
            IButton  button            // <I> - button to treat as a toggle 
        ) : base ( button )
        {
            m_isPressed   = false;
            m_isToggledOn = false;
        }

        public override bool IsButtonPressed()
        {
            bool toggleOn = false;
            if ( base.GetButton() != null )
            {
                bool isPressed = GetButton().IsButtonPressed();
                if ( m_isPressed )
                {
                    m_isToggledOn = !m_isToggledOn;
                    m_isPressed   = true;
                }
                else
                {
                    m_isPressed = false;
                }
            }
            return toggleOn;
        }      
    }
}
