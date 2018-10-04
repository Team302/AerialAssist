
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
        private DragonGamePad m_gamepad;

        private CTRE.Phoenix.MotorControl.PWMSpeedController m_leftDrive;
        private CTRE.Phoenix.MotorControl.PWMSpeedController m_rightDrive;

        private PWMSpeedController m_intake;

        private TalonSRX m_kicker;

        public Test()
        {

            m_gamepad = new DragonGamePad();

            
            RobotMap map = RobotMap.GetInstance();

            m_leftDrive = new CTRE.Phoenix.MotorControl.PWMSpeedController(map.GetLeftDriveMotorID());
            m_rightDrive = new CTRE.Phoenix.MotorControl.PWMSpeedController(map.GetRightDriveMotorID());

            m_intake = new PWMSpeedController(map.GetIntakeMotorID());

            m_kicker = new TalonSRX(map.GetKickerMotorID());
            
        }

        public void Run()
        {
//            GameController pad = new GameController(UsbHostDevice.GetInstance());
//            Debug.Print( pad.GetAxis(AbstractLocalGamepad.kAxis_Leftx).ToString() );


            
            RobotMap map = RobotMap.GetInstance();
            PneumaticControlModule pcm = PCM.GetInstance().GetPCM();

            Debug.Print("Joystick values \n");
            Debug.Print(m_gamepad.GetAxisValue(IDragonGamePad.AXIS_IDENTIFIER.LEFT_JOYSTICK_Y).ToString() );
            Debug.Print(m_gamepad.GetAxisValue(IDragonGamePad.AXIS_IDENTIFIER.RIGHT_JOYSTICK_X).ToString() );

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
