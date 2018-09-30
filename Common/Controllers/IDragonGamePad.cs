
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


using CTRE.Phoenix.Controller;

namespace HeroDemoBots.Common.Controllers
{
    //==================================================================================
    /// <summary>
    /// Class:          IDragonGamePad
    /// Description:    This class provides a common interface for gamepads, joysticks, 
    ///                 controllers, etc.
    /// </summary>
    //==================================================================================
    public abstract class IDragonGamePad
    {
        // enums that interface with the IDragonGamePad methods
        public enum BUTTON_IDENTIFIER
        {

            //----dinput------
            //    4
            //  1   3
            //    2
            //5  6  (shoulder)
            //9  10 (back start)
            //11 12 (center press)

            UNKNOWN_BUTTON = -1,
            X_BUTTON,
            A_BUTTON,
            B_BUTTON,
            Y_BUTTON,
            LEFT_BUMPER,
            RIGHT_BUMPER,
            BACK_BUTTON,
            START_BUTTON,
            CENTER1_BUTTON,
            CENTER2_BUTTON,
            POV_0,
            POV_45,
            POV_90,
            POV_135,
            POV_180,
            POV_225,
            POV_270,
            POV_315,
            LEFT_TRIGGER_BUTTON,
            RIGHT_TRIGGER_BUTTON,
            MAX_BUTTONS
        }

        public enum BUTTON_MODE
        {
            STANDARD,
            DEBOUNCED,
            TOGGLE,
            DEBOUNCED_TOGGLE,
            MAX_BUTTON_MODES
        }


        public enum AXIS_IDENTIFIER
        {
            UNKNOWN_AXIS        = -1,
            LEFT_JOYSTICK_X     = AbstractLocalGamepad.kAxis_LeftX,
            LEFT_JOYSTICK_Y     = AbstractLocalGamepad.kAxis_LeftY,
            RIGHT_JOYSTICK_X    = AbstractLocalGamepad.kAxis_RightX,
            RIGHT_JOYSTICK_Y    = AbstractLocalGamepad.kAxis_RightY,
            LEFT_TRIGGER        = AbstractLocalGamepad.kAxis_LeftShoulder,
            RIGHT_TRIGGER       = AbstractLocalGamepad.kAxis_RightShoulder,
            MAX_AXIS
        }
        
        public enum AXIS_DEADBAND
        {
            NONE, 
            APPLY_STANDARD_DEADBAND,
            APPLY_SCALED_DEADBAND,
            MAX_DEADBANDS
        }
        
        public enum AXIS_PROFILE
        {
            LINEAR, 
            SQUARED,
            CUBED,
            MAX_PROFILES
        }

        public enum AXIS_MODE
        {
            LINEAR,
            LINEAR_WITH_DEADBAND,
            CUBED,
            CUBED_WITH_DEADBAND,
            MAX_AXIS_MODES
        }


        //==================================================================================
        /// <summary>
        /// Method:         IDragonGamePad
        /// Description:    Constructor 
        /// </summary>
        //==================================================================================
        public IDragonGamePad()
        {
        }


        //==================================================================================
        /// <summary>
        /// Method:         IsButtonPressed
        /// Description:    Checks if a particular button is pressed or not
        /// Returns:        bool   true - button is pressed, false button is not pressed
        /// </summary>
        //==================================================================================
        public abstract bool IsButtonPressed
        (
            BUTTON_IDENTIFIER button                    /// <I> - button to check
        );


        //==================================================================================
        /// <summary>
        /// Method:         SetButtonMode
        /// Description:    Specify how the button should behave.  Examples include (but
        ///                 not limited to):
        ///                 - pressed / not pressed
        ///                 - toggle
        /// Returns:        void
        /// </summary>
        //==================================================================================
        public abstract void SetButtonMode
        (
            BUTTON_IDENTIFIER button,                   /// <I> - button to check
            BUTTON_MODE mode                            /// <I> - button behavior
        );


        //==================================================================================
        /// <summary>
        /// Method:         GetAxisValue
        /// Description:    Returns the axis value
        /// Returns:        double - axis value
        /// </summary>
        //==================================================================================
        public abstract double GetAxisValue
        (
            AXIS_IDENTIFIER axis                        /// <I> - axis to check
        );


        //==================================================================================
        /// <summary>
        /// Method:         SetAxisDeadband
        /// Description:    Specify what deadband behavior is desired such as none, standard,
        ///                 standard with scaling.
        /// Returns:        void
        /// </summary>
        //==================================================================================
        public abstract void SetAxisDeadband
        (
            AXIS_IDENTIFIER axis,                       /// <I> - axis to modify
            AXIS_DEADBAND   type                        /// <I> - deadband option
        );



        //==================================================================================
        /// <summary>
        /// Method:         SetAxisProfile
        /// Description:    Specify the profile of the inputs such as direct, squared, cubed.
        /// Returns:        void
        /// </summary>
        //==================================================================================
        public abstract void SetAxisProfile
        (
            AXIS_IDENTIFIER axis,                       /// <I> - axis to modify
            AXIS_PROFILE    profile                     /// <I> - axis profile
        );


        //==================================================================================
        /// <summary>
        /// Method:         SetAxisScaleFactor
        /// Description:    Specify the how to scale the output for an axis.
        /// Returns:        void
        /// </summary>
        //==================================================================================
        public abstract void SetAxisScaleFactor
        (
           AXIS_IDENTIFIER  axis,                       /// <I> - axis to check
           double           scale                       /// <I> - sacle factor
        );

    }
}
