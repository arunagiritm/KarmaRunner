using System;
using System.Data;

namespace Karmarunner
{
    public class TreeViewSchema
    {
        #region Property

        public DataTable DataSource
        {
            get;
            set;
        }

        public String DisplayMember
        {
            get;
            set;
        }

        public String ValueMember
        {
            get;
            set;
        }

        public String ParentMember
        {
            get;
            set;
        }

        public string KeyMember
        {
            get;
            set;
        }
        #endregion
    }
}
