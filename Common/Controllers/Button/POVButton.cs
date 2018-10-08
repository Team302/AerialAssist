
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


using CTRE.Phoenix;
using CTRE.Phoenix.Controller;
using Microsoft.SPOT;

namespace HeroDemoBots.Common.Controllers.Button
{
    //==================================================================================
    /// <summary>
    /// Class:          POVButton
    /// Description:    This class handles POV items as buttons.
    /// </summary>
    //==================================================================================
    public class POVButton : IButton
    {
        private GameController                      m_gamepad;
        private IDragonGamePad.BUTTON_IDENTIFIER    m_buttonID;

        public POVButton
        (
            GameController                              gamepad,            // <I> - owning game pad 
            IDragonGamePad.BUTTON_IDENTIFIER            index               // <I> - button index
        )
        {
            m_gamepad  = gamepad;
            m_buttonID = index;
        }

        //==================================================================================
        /// <summary>
        /// Method:         IsButtonPressed
        /// Description:    Read the POV value using GetAllValues and checking the value
        ///                 to see if it matches the desired button angle.  Note:  this
        ///                 returns -1 if it isn't pressed otherwise the degree value is 
        ///                 returned (0,45,90,135,180,225,270,315).  This angle gets checked
        ///                 against the desired button identifier.
        ///
        ///                 If there is an issue with the gamepad, return false.
        /// </summary>
        //==================================================================================
        public override bool IsButtonPressed()
        {
            bool isPressed = false;             // returned value, initialized to false
            if ( m_gamepad != null && m_gamepad.GetConnectionStatus() == UsbDeviceConnection.Connected )
            {
                GameControllerValues values = new GameControllerValues();
                GameControllerValues newVals = m_gamepad.GetAllValues( ref values );
                int pov = newVals.pov;
                // TODO::  Documentation indicates 0, 45, 90, 135, 180, 225, 270, 315 will be returned, but
                //         Example shows 0 thru 7 as the return values, so need to test to see what we actually get
                if ( pov > -1 ) // POV is pressed
                {
                    switch ( m_buttonID )
                    {
                        case IDragonGamePad.BUTTON_IDENTIFIER.POV_0:
                            isPressed = pov == 0;
                            break;

                        case IDragonGamePad.BUTTON_IDENTIFIER.POV_45:
                            isPressed = pov == 45;
                            break;

                        case IDragonGamePad.BUTTON_IDENTIFIER.POV_90:
                            isPressed = pov == 90;
                            break;

                        case IDragonGamePad.BUTTON_IDENTIFIER.POV_135:
                            isPressed = pov == 135;
                            break;
;

                        case IDragonGamePad.BUTTON_IDENTIFIER.POV_180:
                            isPressed = pov == 180;
                            break;

                        case IDragonGamePad.BUTTON_IDENTIFIER.POV_225:
                            isPressed = pov == 225;
                            break;

                        case IDragonGamePad.BUTTON_IDENTIFIER.POV_270:
                            isPressed = pov == 270;
                            break;

                        case IDragonGamePad.BUTTON_IDENTIFIER.POV_315:
                            isPressed = pov == 315;
                            break;

                        default:
                           break;
                    }
                }
            }
            else
            {
                Debug.Print("==>> Gamepad isn't connected \n");
            }
            return isPressed;
        }
    }
}
