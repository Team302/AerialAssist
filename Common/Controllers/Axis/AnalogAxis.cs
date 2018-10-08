
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

namespace HeroDemoBots.Common.Controllers.Axis
{
    //==================================================================================
    /// <summary>
    /// Class:          AnalogAxis
    /// Description:    This is a template class is used to process joystick and trigger
    ///                 inputs
    /// </summary>
    //==================================================================================
    public class AnalogAxis
    {
        private GameController      m_gamepad;
        private uint                m_axis;
        private IProfile            m_profile;
        private IDeadband           m_deadband;
        private double              m_scale;



        //==================================================================================
        /// <summary>
        /// Method:         AnalogAxis
        /// Description:    Retain the gamepad and the analog input id.
        /// </summary>
        //==================================================================================
        public AnalogAxis
        (
            GameController                      gamepad,            // <I> - owning game pad
            IDragonGamePad.AXIS_IDENTIFIER      index               // <I> - button index
        )
        {
            m_gamepad  = gamepad;
            m_axis     = (uint) index;
            m_profile  = LinearProfile.GetInstance();
            m_deadband = DeadbandValue.GetInstance();
        }


        //==================================================================================
        /// <summary>
        /// Method:         GetAxisValue
        /// Description:    Read the analog (axis) value and return it.  If the gamepad
        ///                 has an issue, return 0.0.
        /// </summary>
        //==================================================================================
        public double GetAxisValue()
        {
            double value = 0.0;
            if ( m_gamepad != null && m_gamepad.GetConnectionStatus() == UsbDeviceConnection.Connected )
            {
                value = GetRawValue();
                value = m_deadband.ApplyDeadband( value );
                value = m_profile.ApplyProfile( value );
                value *= m_scale;
            }
            else
            {
                Debug.Print("==>> Gamepad isn't connected \n");
            }
            return value;
        }
        
        
    
        
        //==================================================================================
        /// <summary>
        /// Method:         GetRawValue
        /// Description:    Returns the analog input's raw value.
        ///                 If there is a connection problem, 0.0 will be returned and 
        ///                 a debug message will be written.
        /// </summary>
        //==================================================================================
        protected virtual double GetRawValue()
        {
            double value = 0.0;
            if ( m_gamepad != null && m_gamepad.GetConnectionStatus() == UsbDeviceConnection.Connected )
            {
                value = m_gamepad.GetAxis( m_axis );
            }
            else
            {
                Debug.Print("==>> Gamepad isn't connected \n");
            }
            return value;
        }
       
        
        public void SetDeadBand
        (
            IDragonGamePad.AXIS_DEADBAND   type            /// <I> - deadband option
        )
        {
            switch ( type )
            {
                case IDragonGamePad.AXIS_DEADBAND.NONE:
                    m_deadband = NoDeadbandValue.GetInstance();
                    break;
                    
                case IDragonGamePad.AXIS_DEADBAND.APPLY_STANDARD_DEADBAND:
                    m_deadband = DeadbandValue.GetInstance();
                    break;

                case IDragonGamePad.AXIS_DEADBAND.APPLY_SCALED_DEADBAND:
                    m_deadband = ScaledDeadbandValue.GetInstance();
                    break;
                    
                default:
                    m_deadband = DeadbandValue.GetInstance();
                    Debug.Print("==>> Invalid deadband option passed in  \n");
                    break;
            }
        }

        public void SetAxisProfile
        (
            IDragonGamePad.AXIS_PROFILE    profile         /// <I> - axis profile
        )
        {
            switch ( profile )
            {
                case IDragonGamePad.AXIS_PROFILE.LINEAR:
                    m_profile  = LinearProfile.GetInstance();
                    break;
                
                case IDragonGamePad.AXIS_PROFILE.SQUARED:
                    m_profile  = SquaredProfile.GetInstance();
                    break;
                
                case IDragonGamePad.AXIS_PROFILE.CUBED:
                    m_profile  = CubedProfile.GetInstance();
                    break;
                
                default:
                    m_profile  = LinearProfile.GetInstance();
                    Debug.Print("==>> Invalid profile passed in  \n");
                    break;
            }
        }

        public void SetAxisScaleFactor
        (
           double scale                     /// <I> - sacle factor
        )
        {
            if ( scale > 0.0 && scale <= 1.0 )
            {
                m_scale = scale;
            }
            else
            {
                Debug.Print("==>> Invalid scale factor passed in  \n");
            }
        }


    }
}
