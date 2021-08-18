using System;
using System.Collections.Generic;
using System.Text;

namespace TestingCSVHelper
{
    class Course
    {
        #region Private Field Variables
        private string _code;
        private string _name;
        private int _units;
        #endregion Private Field Variables

        #region Public Field Variables
        public string Code
        {
            get => _code;
            set => _code = value;
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public int Units
        {
            get => _units;
            set => _units = value;
        }
        #endregion Public Field Variables
    }
}
