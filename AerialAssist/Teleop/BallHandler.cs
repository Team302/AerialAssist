using HeroDemoBots.AerialAssist.Subsys;

namespace HeroDemoBots.AerialAssist.Teleop
{
    class BallHandler
    {
        private Intake      m_intake;
        private Kicker      m_kicker;
        private ShooterAim  m_aimer;
       

        public BallHandler()
        {
            m_intake = new Intake();
            m_kicker = new Kicker();
            m_aimer  = new ShooterAim();
        }

        public void ProcessTelopCommands()
        {
        
        }
    }
}
