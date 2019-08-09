using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Production.Class
{
    public class Resources
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private int _IdSort;

        public int IdSort
        {
            get { return _IdSort; }
            set { _IdSort = value; }
        }
        private int _ParentId;

        public int ParentId
        {
            get { return _ParentId; }
            set { _ParentId = value; }
        }

        private string _Subject;

        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }

        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        private string _Color;

        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }
        private string _Image;

        public string Image
        {
            get { return _Image; }
            set { _Image = value; }
        }
        private string _CustomField1;

        public string CustomField1
        {
            get { return _CustomField1; }
            set { _CustomField1 = value; }
        } 

        
    }
}
