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


namespace HeroDemoBots.Common.Utils
{
    //==================================================================================
    /// <summary>
    /// Class:          LimitValue
    /// Description:    This class is a series of utility methods
    /// </summary>
    //==================================================================================
    class LimitValue
    {
        public static double GetInRange
        (
            double value
        )
        {
            double output = value;
            if ( output > 1.0 )
            {
                output = 1.0;
            }
            else if ( output < -1.0 )
            {
                output = -1.0;
            }
            return output;
        }

        public static double GetMaxValue
        (
            double value1,
            double value2
        )
        {
               double maxValue = 0;
                if ( System.Math.Abs( value1 ) > maxValue)
                {
                    maxValue = System.Math.Abs( value1 );
                }

                if ( System.Math.Abs( value2 ) > maxValue )
                {
                    maxValue = System.Math.Abs( value2 );
                }       
                return maxValue;     
        }
    }
}
