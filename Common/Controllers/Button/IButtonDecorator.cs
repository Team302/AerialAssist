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


namespace HeroDemoBots.Common.Controllers.Button
{
    //==================================================================================
    /// <summary>
    /// Class:          IButtonDecorator
    /// Description:    This is a decorator for modifying button behavior.
    /// </summary>
    //==================================================================================
    public abstract class IButtonDecorator : IButton
    {
        IButton m_button;
        protected IButtonDecorator
        (
            IButton button      // <I> - concrete button to decorate
        ) : base()
        {
            m_button = button;
        }

        protected IButton GetButton()
        {
            return m_button;
        }

        // interface members
        public abstract override bool IsButtonPressed();


    }
}
