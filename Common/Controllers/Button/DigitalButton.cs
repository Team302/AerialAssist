
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

using Microsoft.SPOT;

using CTRE.Phoenix;
using CTRE.Phoenix.Controller;

namespace HeroDemoBots.Common.Controllers.Button
{
    //==================================================================================
    /// <summary>
    /// Class:          DigitalButton
    /// Description:    This class is a physical button or bumper on the joystick.
    /// </summary>
    //==================================================================================
    public class DigitalButton : IButton
    {
        private GameController          m_gamepad;
        private uint                    m_buttonID;
        
        
        //==================================================================================
        /// <summary>
        /// Method:         DigitalButton
        /// Description:    Retain the gamepad and the digital (button) input id.
        /// </summary>
        //==================================================================================
        public DigitalButton 
        (
            GameController                      gamepad,            // <I> - owning game pad 
            IDragonGamePad.BUTTON_IDENTIFIER    index               // <I> - button index
        )
        {
            m_gamepad = gamepad;
            m_buttonID = (uint) index;
            if ( index > IDragonGamePad.BUTTON_IDENTIFIER.RIGHT_BUMPER )
            {
                m_buttonID += 2;
            }
        }
        
        
        //==================================================================================
        /// <summary>
        /// Method:         IsButtonPressed
        /// Description:    If  the gamepad is connected, read the desired button and 
        ///                 return whether it is pressed or not.  Otherwise, return false.
        /// </summary>
        //==================================================================================
        public override bool IsButtonPressed()
        {
            bool isPressed = false;
            if ( m_gamepad != null && m_gamepad.GetConnectionStatus() == UsbDeviceConnection.Connected )
            {
                isPressed = m_gamepad.GetButton(m_buttonID);               
            }
            else
            {
                Debug.Print("==>> Gamepad isn't connected \n");
            }
            return isPressed;
        }      
    }
}
