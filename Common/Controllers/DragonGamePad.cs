
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

using HeroDemoBots.Common.Controllers.Axis;
using HeroDemoBots.Common.Controllers.Button;

using CTRE.Phoenix;
using CTRE.Phoenix.Controller;

namespace HeroDemoBots.Common.Controllers
{
    //==================================================================================
    /// <summary>
    /// Class:          DragonGamePad
    /// Description:    This class is handles the Logitec Gamepad Controller used with
    ///                 a hero board-based robot.
    /// </summary>
    //==================================================================================
    public class DragonGamePad : IDragonGamePad
    {

        private GameController m_gamepad;       /// controller 
        private IButton[] m_buttonAr = new IButton[(int)IDragonGamePad.BUTTON_IDENTIFIER.MAX_BUTTONS];         /// array of button objects that can be queried to see if they are pressed or not
        private AnalogAxis[] m_axisAr = new AnalogAxis[(int)IDragonGamePad.AXIS_IDENTIFIER.MAX_AXIS];          /// array of axis objects that can be queried for values
        
        
        //==================================================================================
        /// <summary>
        /// Method:         DragonGamePad
        /// Description:    Create the controller and map the default buttons.
        /// </summary>
        //==================================================================================
        public DragonGamePad()
        {
            m_gamepad = new GameController(UsbHostDevice.GetInstance());
            int slot = 0;
            for (AXIS_IDENTIFIER i = 0; i < AXIS_IDENTIFIER.MAX_AXIS; ++i)
            {
                if ( i == IDragonGamePad.AXIS_IDENTIFIER.LEFT_JOYSTICK_Y || 
                     i == IDragonGamePad.AXIS_IDENTIFIER.RIGHT_JOYSTICK_Y )
                {
                    m_axisAr[slot] = new FlippedAxis(m_gamepad, i);     // These axis give values inverted from what is expected, so flip the values
                }
                else
                {
                    m_axisAr[slot] = new AnalogAxis(m_gamepad, i);      // Normal axis
                }
                slot++;
            }
            slot = 0;
            for (BUTTON_IDENTIFIER i = 0; i < BUTTON_IDENTIFIER.MAX_BUTTONS; ++i)
            {
                if (i < BUTTON_IDENTIFIER.POV_0)
                {
                    m_buttonAr[slot] = new DigitalButton(m_gamepad, i);     // Normal Analog inputs on the controller
                }
                else if ( i < IDragonGamePad.BUTTON_IDENTIFIER.LEFT_TRIGGER_BUTTON )
                {
                    m_buttonAr[slot] = new POVButton(m_gamepad, i);         // POV inputs on the controller
                }
                else
                {
                    IDragonGamePad.AXIS_IDENTIFIER id = (i == IDragonGamePad.BUTTON_IDENTIFIER.LEFT_TRIGGER_BUTTON) ? 
                                                                    IDragonGamePad.AXIS_IDENTIFIER.LEFT_TRIGGER : 
                                                                    IDragonGamePad.AXIS_IDENTIFIER.RIGHT_TRIGGER;
                    AnalogAxis axis = new AnalogAxis(m_gamepad, id);         // Analog inputs that are being treated as digital (buttons)
                    m_buttonAr[slot] = new AnalogButton( axis );            // Create an axis and then decorate it as a button
                }
                slot++;
            }
        }
        
        
        //==================================================================================
        /// <summary>
        /// Method:         IsButtonPressed
        /// Description:    Call the appropriate button to see if it is pressed or not.
        /// </summary>
        //==================================================================================
        public override bool IsButtonPressed
        (
            BUTTON_IDENTIFIER button      // <I> - button to check
        )
        {
            bool isPressed = false;         // returned values
            int slot = (int) button;
            if ( slot < m_buttonAr.Length )
            {
                isPressed = m_buttonAr[slot].IsButtonPressed();
            }
            return isPressed;
        }

        
        
        //==================================================================================
        /// <summary>
        /// Method:         SetButtonMode
        /// Description:    Allow the button(s) to have extra behavior added using a 
        ///                 decorator. 
        /// </summary>
        //==================================================================================
        public override void SetButtonMode
        (
            BUTTON_IDENTIFIER button,                   // <I> - button to check
            BUTTON_MODE mode                            // <I> - button behavior
        )
        {
            int slot = (int)button;
            IButton thisButton = m_buttonAr[slot];
            switch (mode)
            {
                case BUTTON_MODE.STANDARD:
                    break;

                case BUTTON_MODE.DEBOUNCED:
                    m_buttonAr[slot] = new DebounceButton(thisButton);
                    break;

                case BUTTON_MODE.TOGGLE:
                    m_buttonAr[slot] = new ToggleButton(thisButton);
                    break;

                case BUTTON_MODE.DEBOUNCED_TOGGLE:
                    thisButton = new ToggleButton(thisButton);
                    m_buttonAr[slot] = new DebounceButton(thisButton);
                    break;

                default:
                    break;

            }
        }


        //==================================================================================
        /// <summary>
        /// Method:         GetAxisValue
        /// Description:    Read the appropriate axis to get its value.
        /// </summary>
        //==================================================================================
        public override double GetAxisValue
        (
            AXIS_IDENTIFIER axis        // <I> - axis to check
        )
        {
            double value = 0.0;         // returned values
            int slot = (int)axis;
            if (slot < m_axisAr.Length)
            {
                value = m_axisAr[slot].GetAxisValue();
            }
            return value;
        }

        //==================================================================================
        /// <summary>
        /// Method:         SetAxisDeadband
        /// Description:    Specify what deadband behavior is desired such as none, standard,
        ///                 standard with scaling.
        /// Returns:        void
        /// </summary>
        //==================================================================================        
        public override void SetAxisDeadband
        (
            AXIS_IDENTIFIER axis,           /// <I> - axis to modify
            AXIS_DEADBAND   type            /// <I> - deadband option
        )
        {
            int slot = (int) axis;
            if ( slot < m_axisAr.Length )
            {
                m_axisAr[slot].SetDeadBand( type );
            }
            else
            {
                Debug.Print("==>> SetAxisDeadband: Invalid Axis specified ");
                Debug.Print( slot.ToString() );
                Debug.Print( "\n" );
            }
        }



        //==================================================================================
        /// <summary>
        /// Method:         SetAxisProfile
        /// Description:    Specify the profile of the inputs such as direct, squared, cubed.
        /// Returns:        void
        /// </summary>
        //==================================================================================
        public override void SetAxisProfile
        (
            AXIS_IDENTIFIER axis,           /// <I> - axis to modify
            AXIS_PROFILE    profile         /// <I> - axis profile
        )
        {
            int slot = (int) axis;
            if ( slot < m_axisAr.Length )
            {
                m_axisAr[slot].SetAxisProfile( profile );
            }
            else
            {
                Debug.Print("==>> SetAxisProfile:  Invalid Axis specified ");
                Debug.Print( slot.ToString() );
                Debug.Print( "\n" );
            }
        }


        //==================================================================================
        /// <summary>
        /// Method:         SetAxisScaleFactor
        /// Description:    Specify the how to scale the output for an axis.
        /// Returns:        void
        /// </summary>
        //==================================================================================
        public override void SetAxisScaleFactor
        (
           AXIS_IDENTIFIER axis,            /// <I> - axis to check
           double scale                     /// <I> - sacle factor
        )
        {
            int slot = (int) axis;
            if ( slot < m_axisAr.Length )
            {
                m_axisAr[slot].SetAxisScaleFactor( scale );
            }
            else
            {
                Debug.Print("==>> SetAxisScaleFactor:  Invalid Axis specified ");
                Debug.Print( slot.ToString() );
                Debug.Print( "\n" );
            }
        }
    }
}
