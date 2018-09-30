
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

using System;


namespace HeroDemoBots.Common.Controllers.Axis
{
    //==================================================================================
    /// <summary>
    /// Class:          ScaledDeadbandValue
    /// Description:    This class applies a deadband to a value removing values whose
    //                  absolute value is near 0.0.
    /// </summary>
    //==================================================================================
    public class ScaledDeadbandValue : IDeadband
    {

        //==================================================================================
        /// <summary>
        /// Method:         ScaledDeadbandValue
        /// Description:    Private contructor
        /// </summary>
        //==================================================================================
        private ScaledDeadbandValue()
        {
        }


        //==================================================================================
        /// <summary>
        /// Method:         GetInstance
        /// Description:    Static singleton method to create the object
        /// </summary>
        //==================================================================================
        private static ScaledDeadbandValue instance = null;
        public static ScaledDeadbandValue GetInstance()
        {
            if (instance == null)
            {
                instance = new ScaledDeadbandValue();
            }
            return instance;
        }


        //==================================================================================
        /// <summary>
        /// Method:         ApplyDeadband
        /// Description:    Apply the standard deadband
        /// </summary>
        //==================================================================================
        public override double ApplyDeadband
        (
            double inputVal            // <I> - value to apply profile to
        )
        {
            DeadbandValue deadband = DeadbandValue.GetInstance();
            double val = deadband.ApplyDeadband( inputVal );
            double deadbandVal = deadband.GetDeadbandValue();
            double range = 1.0 - deadbandVal;
            double diffFromDeadband = Math.Abs(val) - deadbandVal;
            double multiplier = (val < 0.0) ? -1.0 : 1.0;

            return (multiplier * diffFromDeadband / range );
        }
    }
}

