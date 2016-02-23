using System;
using System.Data;

namespace KarmaRunner
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
        public string Checked
        {
            get;
            set;
        }
        #endregion
    }
}
