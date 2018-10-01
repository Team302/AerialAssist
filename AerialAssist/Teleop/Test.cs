using System;
using CTRE.Phoenix;
using CTRE.Phoenix.MotorControl;
using CTRE.Phoenix.MotorControl.CAN;
using HeroDemoBots.AerialAssist.Subsys;
using HeroDemoBots.Common.Controllers;
using Microsoft.SPOT;

namespace HeroDemoBots.AerialAssist.Teleop
{
    class Test
    {
        private DragonGamePad m_gamepad;

        private PWMSpeedController m_leftDrive;
        private PWMSpeedController m_rightDrive;

        private PWMSpeedController m_intake;

        private TalonSRX m_kicker;

        public Test()
        {
            m_gamepad = new DragonGamePad();


        }

        public void Run()
        {
            RobotMap map = RobotMap.GetInstance();
            PneumaticControlModule pcm = PCM.GetInstance().GetPCM();

            m_leftDrive.Set((float)m_gamepad.GetAxisValue(IDragonGamePad.AXIS_IDENTIFIER.LEFT_JOYSTICK_Y));
            m_rightDrive.Set((float)m_gamepad.GetAxisValue(IDragonGamePad.AXIS_IDENTIFIER.RIGHT_JOYSTICK_Y));
            m_intake.Set((float)m_gamepad.GetAxisValue(IDragonGamePad.AXIS_IDENTIFIER.LEFT_TRIGGER));
            m_kicker.Set(CTRE.Phoenix.MotorControl.ControlMode.PercentOutput, m_gamepad.GetAxisValue(IDragonGamePad.AXIS_IDENTIFIER.RIGHT_TRIGGER));

            pcm.SetSolenoidOutput(0, m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.A_BUTTON));
            pcm.SetSolenoidOutput(1, m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.B_BUTTON));
            pcm.SetSolenoidOutput(2, m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.X_BUTTON));
            pcm.SetSolenoidOutput(3, m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.Y_BUTTON));
            pcm.SetSolenoidOutput(4, m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.LEFT_BUMPER));
            pcm.SetSolenoidOutput(5, m_gamepad.IsButtonPressed(IDragonGamePad.BUTTON_IDENTIFIER.RIGHT_BUMPER));



        }
    }
}
