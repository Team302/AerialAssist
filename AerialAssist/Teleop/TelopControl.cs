
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


using HeroDemoBots.Common.Controllers;

namespace HeroDemoBots.AerialAssist.Teleop
{
    //==================================================================================
    /// <summary>
    /// Class:          TeleopControl
    /// Description:    This class is used for mapping specific robot functions to 
    ///                 gamepad inputs.  This class abstracts the behavior of the robot
    ///                 from the gamepad inputs, so that if a behavior is moved from one
    ///                 input to another, this is the only class that needs to be modified.
    /// </summary>
    //==================================================================================
    public sealed class TeleopControl
    {

        public enum FUNCTION_IDENTIFIER
        {
            ARCADE_DRIVE_THROTTLE,
            ARCADE_DRIVE_STEER,
            TANK_DRIVE_LEFT,
            TANK_DRIVE_RIGHT,
            INTAKE_BALL,
            OPEN_JAW,
            CLOSE_JAW_LOOSELY,
            CLOSE_JAW_TIGHT,
            KICK_BALL,
            RAISE_JAW,
            LOWER_JAW,
            SWITCH_DRIVE_MODE,
            MAX_FUNCTIONS
        }

        private DragonGamePad m_gamepad;
        private IDragonGamePad.AXIS_IDENTIFIER[]   m_axisIDs = new IDragonGamePad.AXIS_IDENTIFIER[(int) FUNCTION_IDENTIFIER.MAX_FUNCTIONS ];
        private IDragonGamePad.BUTTON_IDENTIFIER[] m_buttonIDs = new IDragonGamePad.BUTTON_IDENTIFIER[(int)FUNCTION_IDENTIFIER.MAX_FUNCTIONS];
        /// <summary>
        /// Method:         GetInstance
        /// Description:    Create a singleton object for mapping functionality to controller
        ///                 inputs.
        /// Returns:        TeleopControl   the mapper for functions to controller
        /// </summary>
        //==================================================================================
        private static TeleopControl instance = null;
        public static TeleopControl GetInstance()
        {
            if (instance == null)
            {
                instance = new TeleopControl();
            }
            return instance;
        }


        //==================================================================================
        /// <summary>
        /// Method:         TeleopControl
        /// Description:    Create the controller and map the functions to buttons and axis 
        ///                 inputs on the controller.
        /// </summary>
        //==================================================================================
        private TeleopControl()
        {
            m_gamepad = new DragonGamePad();

            // Initialize the Axis and Button to be unknown (not mapped) for each function
            for ( FUNCTION_IDENTIFIER inx=0; inx<FUNCTION_IDENTIFIER.MAX_FUNCTIONS; inx++ )
            {
                m_axisIDs[(int)inx] = IDragonGamePad.AXIS_IDENTIFIER.UNKNOWN_AXIS;
                m_buttonIDs[(int)inx] = IDragonGamePad.BUTTON_IDENTIFIER.UNKNOWN_BUTTON;
            }

            // Map functions to Gamepad along with their behavior
            IDragonGamePad.AXIS_IDENTIFIER axis;
            IDragonGamePad.BUTTON_IDENTIFIER button;

            // Arcade Drive
            axis = IDragonGamePad.AXIS_IDENTIFIER.LEFT_JOYSTICK_Y;
            m_axisIDs[(int)FUNCTION_IDENTIFIER.ARCADE_DRIVE_THROTTLE] = axis;
            m_gamepad.SetAxisDeadband(axis, IDragonGamePad.AXIS_DEADBAND.APPLY_SCALED_DEADBAND);
            m_gamepad.SetAxisProfile(axis, IDragonGamePad.AXIS_PROFILE.CUBED);
            m_gamepad.SetAxisScaleFactor(axis, 1.0);

            axis = IDragonGamePad.AXIS_IDENTIFIER.RIGHT_JOYSTICK_X;
            m_axisIDs[(int)FUNCTION_IDENTIFIER.ARCADE_DRIVE_STEER] = axis;
            m_gamepad.SetAxisDeadband(axis, IDragonGamePad.AXIS_DEADBAND.APPLY_SCALED_DEADBAND);
            m_gamepad.SetAxisProfile(axis, IDragonGamePad.AXIS_PROFILE.CUBED);
            m_gamepad.SetAxisScaleFactor(axis, 1.0);

            // Tank Drive
            axis = IDragonGamePad.AXIS_IDENTIFIER.LEFT_JOYSTICK_Y;
            m_axisIDs[(int)FUNCTION_IDENTIFIER.TANK_DRIVE_LEFT] = axis;
            m_gamepad.SetAxisDeadband(axis, IDragonGamePad.AXIS_DEADBAND.APPLY_SCALED_DEADBAND);
            m_gamepad.SetAxisProfile(axis, IDragonGamePad.AXIS_PROFILE.CUBED);
            m_gamepad.SetAxisScaleFactor(axis, 1.0);

            axis = IDragonGamePad.AXIS_IDENTIFIER.RIGHT_JOYSTICK_Y;
            m_axisIDs[(int)FUNCTION_IDENTIFIER.TANK_DRIVE_RIGHT] = axis;
            m_gamepad.SetAxisDeadband(axis, IDragonGamePad.AXIS_DEADBAND.APPLY_SCALED_DEADBAND);
            m_gamepad.SetAxisProfile(axis, IDragonGamePad.AXIS_PROFILE.CUBED);
            m_gamepad.SetAxisScaleFactor(axis, 1.0);

            // Switch Drive Mode
            button = IDragonGamePad.BUTTON_IDENTIFIER.BACK_BUTTON;
            m_buttonIDs[(int)FUNCTION_IDENTIFIER.SWITCH_DRIVE_MODE] = button;
            m_gamepad.SetButtonMode(button, IDragonGamePad.BUTTON_MODE.DEBOUNCED);

            // Ball Manipulation
            axis = IDragonGamePad.AXIS_IDENTIFIER.LEFT_TRIGGER;
            m_axisIDs[(int)FUNCTION_IDENTIFIER.INTAKE_BALL] = axis;
            m_gamepad.SetAxisDeadband(axis, IDragonGamePad.AXIS_DEADBAND.APPLY_STANDARD_DEADBAND);
            m_gamepad.SetAxisProfile(axis, IDragonGamePad.AXIS_PROFILE.CUBED);
            m_gamepad.SetAxisScaleFactor(axis, 1.0);

            button = IDragonGamePad.BUTTON_IDENTIFIER.RIGHT_TRIGGER_BUTTON;
            m_buttonIDs[(int)FUNCTION_IDENTIFIER.OPEN_JAW] = button;
            m_gamepad.SetButtonMode(button, IDragonGamePad.BUTTON_MODE.DEBOUNCED_TOGGLE);

            button = IDragonGamePad.BUTTON_IDENTIFIER.LEFT_BUMPER;
            m_buttonIDs[(int)FUNCTION_IDENTIFIER.CLOSE_JAW_TIGHT] = button;
            m_gamepad.SetButtonMode(button, IDragonGamePad.BUTTON_MODE.DEBOUNCED_TOGGLE);

            button = IDragonGamePad.BUTTON_IDENTIFIER.RIGHT_BUMPER;
            m_buttonIDs[(int)FUNCTION_IDENTIFIER.KICK_BALL] = button;
            m_gamepad.SetButtonMode(button, IDragonGamePad.BUTTON_MODE.DEBOUNCED_TOGGLE);

            button = IDragonGamePad.BUTTON_IDENTIFIER.B_BUTTON;
            m_buttonIDs[(int)FUNCTION_IDENTIFIER.CLOSE_JAW_LOOSELY] = button;
            m_gamepad.SetButtonMode(button, IDragonGamePad.BUTTON_MODE.DEBOUNCED_TOGGLE);
        }


        //==================================================================================
        /// <summary>
        /// Method:         IsButtonPressed
        /// Description:    Check if the button controlling a particular function is pressed
        ///                 or not.
        /// Returns:        bool    true - button is pressed, false - button is not pressed
        /// </summary>
        //==================================================================================
        public bool IsButtonPressed
        (
            FUNCTION_IDENTIFIER   function      // <I> - function to check
        )
        {
            bool isPressed = false;
            IDragonGamePad.BUTTON_IDENTIFIER id = m_buttonIDs[(int)function];
            if ( m_gamepad != null && id != IDragonGamePad.BUTTON_IDENTIFIER.UNKNOWN_BUTTON )
            {
                isPressed = m_gamepad.IsButtonPressed( id );  
            }
            return isPressed;
        }


        //==================================================================================
        /// <summary>
        /// Method:         GetAxisValue
        /// Description:    Get the axis value that is controlling a particular function 
        /// Returns:        double    axis value
        /// </summary>
        //==================================================================================
        public double GetAxisValue
        (
            FUNCTION_IDENTIFIER   function      // <I> - function to check
        )
        {
            double val = 0.0;
            IDragonGamePad.AXIS_IDENTIFIER id = m_axisIDs[(int)function];
            if ( m_gamepad != null && id != IDragonGamePad.AXIS_IDENTIFIER.UNKNOWN_AXIS)
            {
                val = m_gamepad.GetAxisValue( id ); 
            }
            return val;
        } 
    }
}
