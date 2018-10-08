
using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using CTRE.Phoenix;
using CTRE.Phoenix.MotorControl;
using CTRE.Phoenix.MotorControl.CAN;

using HeroDemoBots.AerialAssist.Subsys;
using HeroDemoBots.Common.Controllers;
using CTRE.Phoenix.Controller;

namespace HeroDemoBots.AerialAssist.Teleop
{
    class Test
    {
        private TestHW m_hwTest;
        private TestDragonGamePad m_gpTest;

        public enum TEST_ID
        {
            RUN_LEFT_DRIVE,
            RUN_RIGHT_DRIVE,
            RUN_INTAKE,
            RUN_KICKER,
            RUN_CLAMP_JAWS,
            RUN_OPEN_JAWS,
            RUN_LIFT_JAWS,
            RUN_LOWER_JAWS,
            RUN_GAMEPAD_ABUTTON,
            RUN_GAMEPAD_BBUTTON,
            RUN_GAMEPAD_XBUTTON,
            RUN_GAMEPAD_YBUTTON,
            RUN_GAMEPAD_LEFTBUMPER,
            RUN_GAMEPAD_RIGHTBUMPER,
            RUN_GAMEPAD_BACKBUTTON,
            RUN_GAMEPAD_STARTBUTTON,
            RUN_GAMEPAD_CENTER1BUTTON,
            RUN_GAMEPAD_CENTER2BUTTON,
            RUN_GAMEPAD_POV0,
            RUN_GAMEPAD_POV45,
            RUN_GAMEPAD_POV90,
            RUN_GAMEPAD_POV135,
            RUN_GAMEPAD_POV180,
            RUN_GAMEPAD_POV225,
            RUN_GAMEPAD_POV270,
            RUN_GAMEPAD_POV315,
            RUN_GAMEPAD_LEFTTRIGGERBUTTON,
            RUN_GAMEPAD_RIGHTTRIGGERBUTTON,
            RUN_GAMEPAD_LEFTJOYSTICKX,
            RUN_GAMEPAD_LEFTJOYSTICKY,
            RUN_GAMEPAD_RIGHTJOYSTICKX,
            RUN_GAMEPAD_RIGHTJOYSTICKY,
            RUN_GAMEPAD_LEFTTRIGGER,
            RUN_GAMEPAD_RIGHTTRIGGER,
            MAX_TESTS
        }

        public Test()
        {
            m_hwTest = new TestHW();
            m_gpTest = new TestDragonGamePad();
        }

        public void Run
        (
            TEST_ID test    // <I> - test identifier
        )
        {
            switch (test)
            {
                case TEST_ID.RUN_LEFT_DRIVE:
                    m_hwTest.RunLeftDrive(0.5f);
                    break;

                case TEST_ID.RUN_RIGHT_DRIVE:
                    m_hwTest.RunRightDrive(0.5f);
                    break;

                case TEST_ID.RUN_INTAKE:
                    m_hwTest.RunIntake(0.5f);
                    break;

                case TEST_ID.RUN_KICKER:
                    m_hwTest.RunKicker(0.5);
                    break;

                case TEST_ID.RUN_OPEN_JAWS:
                    m_hwTest.RunOpenJawsSolenoid(true);
                    break;

                case TEST_ID.RUN_CLAMP_JAWS:
                    m_hwTest.RunClampJawsSolenoid(true);
                    break;

                case TEST_ID.RUN_LIFT_JAWS:
                    m_hwTest.RunLiftJaws(true);
                    break;

                case TEST_ID.RUN_LOWER_JAWS:
                    m_hwTest.RunLowerJaws(true);
                    break;

                case TEST_ID.RUN_GAMEPAD_ABUTTON:
                    m_gpTest.CheckAButton();
                    break;
                case TEST_ID.RUN_GAMEPAD_BBUTTON:
                    m_gpTest.CheckBButton();
                    break;
                case TEST_ID.RUN_GAMEPAD_XBUTTON:
                    m_gpTest.CheckXButton();
                    break;
                case TEST_ID.RUN_GAMEPAD_YBUTTON:
                    m_gpTest.CheckYButton();
                    break;
                case TEST_ID.RUN_GAMEPAD_LEFTBUMPER:
                    m_gpTest.CheckLeftBumper();
                    break;
                case TEST_ID.RUN_GAMEPAD_RIGHTBUMPER:
                    m_gpTest.CheckRightBumper();
                    break;
                case TEST_ID.RUN_GAMEPAD_BACKBUTTON:
                    m_gpTest.CheckBackButton();
                    break;
                case TEST_ID.RUN_GAMEPAD_STARTBUTTON:
                    m_gpTest.CheckStartButton();
                    break;

                case TEST_ID.RUN_GAMEPAD_CENTER1BUTTON:
                    m_gpTest.CheckCenter1Button();
                    break;

                case TEST_ID.RUN_GAMEPAD_CENTER2BUTTON:
                    m_gpTest.CheckCenter2Button();
                    break;

                case TEST_ID.RUN_GAMEPAD_POV0:
                    m_gpTest.CheckPOV0();
                    break;

                case TEST_ID.RUN_GAMEPAD_POV45:
                    m_gpTest.CheckPOV45();
                    break;

                case TEST_ID.RUN_GAMEPAD_POV90:
                    m_gpTest.CheckPOV90();
                    break;

                case TEST_ID.RUN_GAMEPAD_POV135:
                    m_gpTest.CheckPOV135();
                    break;

                case TEST_ID.RUN_GAMEPAD_POV180:
                    m_gpTest.CheckPOV180();
                    break;

                case TEST_ID.RUN_GAMEPAD_POV225:
                    m_gpTest.CheckPOV225();
                    break;

                case TEST_ID.RUN_GAMEPAD_POV270:
                    m_gpTest.CheckPOV270();
                    break;

                case TEST_ID.RUN_GAMEPAD_POV315:
                    m_gpTest.CheckPOV315();
                    break;

                case TEST_ID.RUN_GAMEPAD_LEFTTRIGGERBUTTON:
                    m_gpTest.CheckLeftTriggerButton();
                    break;

                case TEST_ID.RUN_GAMEPAD_RIGHTTRIGGERBUTTON:
                    m_gpTest.CheckRightTriggerButton();
                    break;

                case TEST_ID.RUN_GAMEPAD_LEFTJOYSTICKX:
                    m_gpTest.CheckLeftJoyStickX();
                    break;

                case TEST_ID.RUN_GAMEPAD_LEFTJOYSTICKY:
                    m_gpTest.CheckLeftJoyStickY();
                    break;

                case TEST_ID.RUN_GAMEPAD_RIGHTJOYSTICKX:
                    m_gpTest.CheckRightJoyStickX();
                    break;

                case TEST_ID.RUN_GAMEPAD_RIGHTJOYSTICKY:
                    m_gpTest.CheckRightJoyStickY();
                    break;

                case TEST_ID.RUN_GAMEPAD_LEFTTRIGGER:
                    m_gpTest.CheckLeftTrigger();
                    break;

                case TEST_ID.RUN_GAMEPAD_RIGHTTRIGGER:
                    m_gpTest.CheckRightTrigger();
                    break;

                default:
                    Debug.Print("Invalid Test " + test.ToString());
                    break;
            }           
        }
    }
}

