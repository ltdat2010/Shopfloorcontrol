using System;
using DevExpress.Xpo;
using System.ComponentModel;
using System.Collections.Generic;
using DevExpress.Xpo.Metadata;

namespace DevExpressCls
{
    [NonPersistent, MemberDesignTimeVisibility(false), OptimisticLocking(true)]
    public class XPObject : PersistentBase, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged = (s, e) => { };
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public XPObject(Session session)
            : base(session)
        {

        }
        
        public void Reload()
        {
            work.Reload(this);
        }
        
        public virtual void Delete()
        {
            Session.Delete(this);
        }
        
        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            OnPropertyChanged(propertyName);
        }
        private Dictionary<XPMemberInfo, object> customPropertyStore;

        internal Dictionary<XPMemberInfo, object> CustomPropertyStore
        {
            get
            {
                if (customPropertyStore == null)
                {
                    customPropertyStore = new Dictionary<XPMemberInfo, object>();
                }
                return customPropertyStore;
            }
        }
        protected virtual XPCollection<T> CreateCollection<T>(XPMemberInfo property)
        {
            XPCollection<T> xps = new XPCollection<T>(base.Session, this, property);
            GC.SuppressFinalize(xps);
            return xps;
        }


        protected XPCollection<T> GetCollection<T>(string propertyName)
            where T : class
        {
            object obj2;
            XPMemberInfo member = base.ClassInfo.GetMember(propertyName);
            CustomPropertyStore.TryGetValue(member, out obj2);
            XPCollection<T> xps = (XPCollection<T>)obj2;
            if (xps == null)
            {
                xps = CreateCollection<T>(member);
                CustomPropertyStore[member] = xps;
            }
            return xps;
        }

        public delegate void EventHandler(string propertyName, object propertyValueHolder, object newValue);
        public event EventHandler PropertyValueChanged;
        protected virtual new bool SetPropertyValue<T>(string propertyName, ref T propertyValueHolder, T newValue)
        {
            T t = propertyValueHolder;
            propertyValueHolder = newValue;
            if (PropertyValueChanged != null)
            {
                PropertyValueChanged(propertyName, t, newValue);
            }
            if (!IsLoading)
            {
                try
                {
                    OnChanged(propertyName, t, newValue);
                }
                catch
                {
                    if (!IsSaving)
                        Session.Save(this);
                }
            }
            OnPropertyChanged(propertyName);
            return true;
        }
        private int _id;
        [Key(AutoGenerate = true)]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                SetPropertyValue("Id", ref _id, value);
            }
        }
        private bool _active;
        public bool Active
        {
            get
            {
                return _active;
            }
            set
            {
                SetPropertyValue("Active", ref _active, value);
            }
        }
        public UnitOfWork work
        {
            get { return Session as UnitOfWork; }
        }
        public object This
        {
            get
            {
                return this;
            }
        }
        [NonPersistent]
        public bool IsError
        {
            get
            {
                return !string.IsNullOrEmpty(GetError());
            }
        }
        virtual public string GetError() { return null; }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Active = true;
        }
    }
}
