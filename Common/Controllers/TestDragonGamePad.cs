using System;
using Microsoft.SPOT;

using HeroDemoBots.Common.Controllers;

namespace HeroDemoBots.Common.Controllers
{
    class TestDragonGamePad
    {
        private DragonGamePad m_gamepad;

        public TestDragonGamePad()
        {
            m_gamepad = new DragonGamePad();
        }

        public void CheckAButton()
        {
            Debug.Print("Button A: " + m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.A_BUTTON).ToString());
        }

        public void CheckBButton()
        {
            Debug.Print("Button B: " + m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.B_BUTTON).ToString());
        }

        public void CheckXButton()
        {
            Debug.Print("Button X: " + m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.X_BUTTON).ToString());
        }

        public void CheckYButton()
        {
            Debug.Print("Button Y: " + m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.Y_BUTTON).ToString());
        }

        public void CheckLeftBumper()
        {
            Debug.Print("Left Bumper: " + m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.LEFT_BUMPER).ToString());
        }

        public void CheckRightBumper()
        {
            Debug.Print("Right Bumper: " + m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.RIGHT_BUMPER).ToString());
        }

        public void CheckBackButton()
        {
            Debug.Print("Back Button: " + m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.BACK_BUTTON).ToString());
        }

        public void CheckStartButton()
        {
            Debug.Print("Start Button: " + m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.START_BUTTON).ToString());
        }
        public void CheckCenter1Button()
        {
            Debug.Print("Center 1 Button: " + m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.CENTER1_BUTTON).ToString());
        }

        public void CheckCenter2Button()
        {
            Debug.Print("Center 2 Button: " + m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.CENTER2_BUTTON).ToString());
        }

        public void CheckPOV0()
        {
            Debug.Print("POV 0: " + m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.POV_0).ToString());
        }

        public void CheckPOV45()
        {
            Debug.Print("POV 45: " + m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.POV_45).ToString());
        }

        public void CheckPOV90()
        {
            Debug.Print("POV 90: " + m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.POV_90).ToString());
        }

        public void CheckPOV135()
        {
            Debug.Print("POV 135: " + m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.POV_135).ToString());
        }

        public void CheckPOV180()
        {
            Debug.Print("POV 180: " + m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.POV_180).ToString());
        }

        public void CheckPOV225()
        {
            Debug.Print("POV 225: " + m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.POV_225).ToString());
        }

        public void CheckPOV270()
        {
            Debug.Print("POV 270: " + m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.POV_270).ToString());
        }

        public void CheckPOV315()
        {
            Debug.Print("POV 315: " + m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.POV_315).ToString());
        }

        public void CheckLeftTriggerButton()
        {
            Debug.Print("Left Trigger Button: " + m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.LEFT_TRIGGER_BUTTON).ToString());
        }

        public void CheckRightTriggerButton()
        {
            Debug.Print("Right Trigger Button: " + m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.RIGHT_TRIGGER_BUTTON).ToString());
        }

        public void CheckLeftJoyStickX()
        {
            Debug.Print("Left Joystick X: " + m_gamepad.GetAxisValue(IDragonGamePad.AXIS_IDENTIFIER.LEFT_JOYSTICK_X).ToString());
        }
        public void CheckLeftJoyStickY()
        {
            Debug.Print("Left Joystick X: " + m_gamepad.GetAxisValue(IDragonGamePad.AXIS_IDENTIFIER.LEFT_JOYSTICK_Y).ToString());
        }
        public void CheckRightJoyStickX()
        {
            Debug.Print("Right Joystick X: " + m_gamepad.GetAxisValue(IDragonGamePad.AXIS_IDENTIFIER.RIGHT_JOYSTICK_X).ToString());
        }
        public void CheckRightJoyStickY()
        {
            Debug.Print("Right Joystick X: " + m_gamepad.GetAxisValue(IDragonGamePad.AXIS_IDENTIFIER.RIGHT_JOYSTICK_Y).ToString());
        }
        public void CheckLeftTrigger()
        {
            Debug.Print("Left Trigger: " + m_gamepad.GetAxisValue(IDragonGamePad.AXIS_IDENTIFIER.LEFT_TRIGGER).ToString());
        }
        public void CheckRightTrigger()
        {
            Debug.Print("Right Trigger: " + m_gamepad.GetAxisValue(IDragonGamePad.AXIS_IDENTIFIER.RIGHT_TRIGGER).ToString());
        }
    }
}
