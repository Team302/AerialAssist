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


namespace HeroDemoBots.Common.Controllers.Axis
{
    //==================================================================================
    /// <summary>
    /// Class:          CubedProfile
    /// Description:    This provides a cubed profile.  This is a Singleton object.
    /// </summary>
    //==================================================================================
    public class CubedProfile : IProfile
    {   


        //==================================================================================
        /// <summary>
        /// Method:         CubedProfile
        /// Description:    Private contructor
        /// </summary>
        //==================================================================================
        private CubedProfile()
        {
        }


        //==================================================================================
        /// <summary>
        /// Method:         GetInstance
        /// Description:    Static singleton method to create the object
        /// </summary>
        //==================================================================================
        private static CubedProfile instance = null;
        public static CubedProfile GetInstance()
        {
            if ( instance == null )
            {
                instance = new CubedProfile();
            }
            return instance;
        }


        //==================================================================================
        /// <summary>
        /// Method:         ApplyProfile
        /// Description:    Apply the linear profile
        /// </summary>
        //==================================================================================
        public override double ApplyProfile
        (
            double      inputVal            // <I> - value to apply profile to
        )
        {
            return System.Math.Pow( inputVal, 3.0 );
        }      
    }
}
