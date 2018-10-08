
using Microsoft.SPOT.Hardware;

using CTRE.Phoenix;
using CTRE.Phoenix.MotorControl;
using CTRE.Phoenix.MotorControl.CAN;

using HeroDemoBots.Common.Hardware;

namespace HeroDemoBots.AerialAssist.Subsys
{
    class TestHW
    {
        private PWMSpeedController m_leftDrive;
        private PWMSpeedController m_rightDrive;

        private PWMSpeedController m_intake;

        private TalonSRX m_kicker;

        public TestHW()
        {
            RobotMap map = RobotMap.GetInstance();

            PWM leftChannel = HeroPWM.StartPWM(map.GetLeftDriveMotorID());
            m_leftDrive = new PWMSpeedController(map.GetLeftDriveMotorID());

            PWM rightChannel = HeroPWM.StartPWM(map.GetRightDriveMotorID());
            m_rightDrive = new PWMSpeedController(map.GetRightDriveMotorID());

            PWM intakeChannel = HeroPWM.StartPWM(map.GetIntakeMotorID());
            m_intake = new PWMSpeedController(map.GetIntakeMotorID());

            m_kicker = new TalonSRX(map.GetKickerMotorID());
        }

        public void RunLeftDrive
        (
            float speed
        )
        {
            m_leftDrive.Set(speed);
        }
        public void RunRightDrive
        (
            float speed
        )
        {
            m_rightDrive.Set(speed);
        }
        public void RunIntake
        (
            float speed
        )
        {
            m_intake.Set(speed);
        }
        public void RunKicker
        (
            double speed
        )
        {
            m_kicker.Set(CTRE.Phoenix.MotorControl.ControlMode.PercentOutput, speed);
        }
        public void RunOpenJawsSolenoid
        (
            bool run
        )
        {
            RobotMap map = RobotMap.GetInstance();
            PneumaticControlModule pcm = PCM.GetInstance().GetPCM();
            pcm.SetSolenoidOutput(map.GetOpenJawsSolenoidID(), run);
        }
        public void RunClampJawsSolenoid
        (
            bool run
        )
        {
            RobotMap map = RobotMap.GetInstance();
            PneumaticControlModule pcm = PCM.GetInstance().GetPCM();
            pcm.SetSolenoidOutput(map.GetCloseJawsSolenoidID(), run);
        }
        public void RunLiftJaws
        (
            bool run
        )
        {
            RobotMap map = RobotMap.GetInstance();
            PneumaticControlModule pcm = PCM.GetInstance().GetPCM();
            pcm.SetSolenoidOutput(map.GetLiftJawsSolenoidID(), run );
        }
        public void RunLowerJaws
        (
            bool run
        )
        {
            RobotMap map = RobotMap.GetInstance();
            PneumaticControlModule pcm = PCM.GetInstance().GetPCM();
            pcm.SetSolenoidOutput(map.GetLowerJawsSolenoidID(), run);

        }


    }
}
