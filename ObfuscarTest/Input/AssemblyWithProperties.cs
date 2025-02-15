#region Copyright (c) 2007 Ryan Williams <drcforbin@gmail.com>
/// <copyright>
/// Copyright (c) 2007 Ryan Williams <drcforbin@gmail.com>
/// 
/// Permission is hereby granted, free of charge, to any person obtaining a copy
/// of this software and associated documentation files (the "Software"), to deal
/// in the Software without restriction, including without limitation the rights
/// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
/// copies of the Software, and to permit persons to whom the Software is
/// furnished to do so, subject to the following conditions:
/// 
/// The above copyright notice and this permission notice shall be included in
/// all copies or substantial portions of the Software.
/// 
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
/// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
/// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
/// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
/// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
/// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
/// THE SOFTWARE.
/// </copyright>
#endregion

using System.ComponentModel;

namespace TestClasses
{
    internal class ClassA
    {
        private int property1 = 17;
        private int property2 = 17;
        private int propertyA = 17;

        public int Property1
        {
            get { return property1; }
            set { property1 = value; }
        }

        public int Property2
        {
            get { return property2; }
            set { property2 = value; }
        }

        public int PropertyA
        {
            get { return propertyA; }
            set { propertyA = value; }
        }
    }
    internal class ClassB : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged { add { } remove { } }
    }
    internal enum TestEnum { Value1, Value2 }
    internal class ClassC : ClassB
    {
        public TestEnum PropertyB { get; set; }
        private TestEnum PropertyC { get; set; }
        protected TestEnum PropertyD { get; set; }
        internal TestEnum PropertyE { get; set; }
    }
    internal class ClassD : ClassB
    {
        public int PropertyB { get; set; }
        private int PropertyC { get; set; }
        protected int PropertyD { get; set; }
        internal int PropertyE { get; set; }
    }
}
