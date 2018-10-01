using System;
using Microsoft.SPOT;

using HeroDemoBots.AerialAssist.Subsys;

namespace HeroDemoBots.AerialAssist.Teleop
{
    class BallHandler
    {
        private Intake m_intake;
        private Jaws m_jaws;
        private Kicker m_kicker;
        private ShooterAim m_aim;

        private enum AIMSTATE
        {
            HIGH,
            MIDDLE,
            LOW
        }
        private AIMSTATE m_lastAimState;

        public BallHandler()
        {
            m_intake = new Intake();
            m_jaws = new Jaws();
            m_kicker = new Kicker();
            m_aim = new ShooterAim();

            m_lastAimState = AIMSTATE.LOW;
        }
        
        public void Run()
        {
            TeleopControl gamepad = TeleopControl.GetInstance();
            if (gamepad != null)
            {
                // Aim Control
                bool moveUp = gamepad.IsButtonPressed(TeleopControl.FUNCTION_IDENTIFIER.RAISE_JAW);
                bool moveDown = gamepad.IsButtonPressed(TeleopControl.FUNCTION_IDENTIFIER.LOWER_JAW);

                switch ( m_lastAimState )
                {
                    case AIMSTATE.HIGH:
                    {
                        if (moveDown)
                        {
                            m_aim.AimMiddle();
                            m_lastAimState = AIMSTATE.MIDDLE;
                        }
                    }
                    break;

                    case AIMSTATE.MIDDLE:
                    { 
                        if (moveUp)
                        {
                            m_aim.AimHigh();
                            m_lastAimState = AIMSTATE.HIGH;
                        }
                        else if ( moveDown )
                        {
                            m_aim.AimLow();
                            m_lastAimState = AIMSTATE.LOW;
                        }
                    }
                    break;

                    case AIMSTATE.LOW:
                    {
                        if ( moveUp)
                        {
                            m_aim.AimMiddle();
                            m_lastAimState = AIMSTATE.MIDDLE;
                        }
                    }
                    break;

                    default:
                        break;
                }

                // Jaw Control
                bool closeJaw = gamepad.IsButtonPressed(TeleopControl.FUNCTION_IDENTIFIER.CLOSE_JAW_LOOSELY);
                bool closeJawTight = gamepad.IsButtonPressed(TeleopControl.FUNCTION_IDENTIFIER.CLOSE_JAW_TIGHT);
                bool openJaw = gamepad.IsButtonPressed(TeleopControl.FUNCTION_IDENTIFIER.OPEN_JAW);

                // Kicker Control
                bool runKicker = gamepad.IsButtonPressed(TeleopControl.FUNCTION_IDENTIFIER.KICK_BALL);
                if (runKicker)
                {
                    openJaw = true;
                }
                
                if ( openJaw )
                {
                    m_jaws.Open();
                }
                else if ( closeJawTight )
                {
                    m_jaws.Close();
                }
                else
                {
                    m_jaws.Neutral();
                }

                if ( runKicker )
                {
                    m_kicker.Kick();
                }
                else
                {
                    m_kicker.Hold();
                }

                // Intake Control
                double intakeSpeed = gamepad.GetAxisValue(TeleopControl.FUNCTION_IDENTIFIER.INTAKE_BALL);
                if ( intakeSpeed > 0.0 )
                {
                    m_intake.Run();
                }
                else if ( intakeSpeed < 0.0 )
                {
                    m_intake.Expel();
                }
                else
                {
                    m_intake.Stop();
                }
            }
        }
    }
}
