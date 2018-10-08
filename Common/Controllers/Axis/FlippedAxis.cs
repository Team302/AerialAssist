using CTRE.Phoenix.Controller;

namespace HeroDemoBots.Common.Controllers.Axis
{

    //==================================================================================
    /// <summary>
    /// Class:          FlippedAxis
    /// Description:    This class is used to process joystick inputs where the axis
    ///                 is reversed from expected (e.g. Y-axis is positive when it is
    ///                 pulled and negative when it is pushed).
    /// </summary>
    //==================================================================================
    public class FlippedAxis : AnalogAxis
    {
   
        
        //==================================================================================
        /// <summary>
        /// Method:         FlippedAxis
        /// Description:    Call base class constructor
        /// </summary>
        //==================================================================================
        public FlippedAxis
        (
            GameController                      gamepad,            // <I> - owning game pad 
            IDragonGamePad.AXIS_IDENTIFIER      index               // <I> - button index
        ) : base( gamepad, index )
        {
        }        
    
        
        //==================================================================================
        /// <summary>
        /// Method:         GetRawValue
        /// Description:    Returns the analog input's raw value.
        ///                 If there is a connection problem, 0.0 will be returned and 
        ///                 a debug message will be written.
        /// </summary>
        //==================================================================================
        protected override double GetRawValue()
        {
            return (-1.0 * base.GetRawValue());
        }
    }
}

