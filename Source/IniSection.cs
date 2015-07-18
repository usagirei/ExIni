// --------------------------------------------------
// ExIni - IniSection.cs
// --------------------------------------------------

#region Usings
using System.Collections.Generic;
using System.Linq;
#endregion

namespace ExIni
{

    public class IniSection
    {
        #region Fields
        private readonly IniComment _comments;
        private readonly List<IniKey> _keys;
        #endregion

        #region Properties
        public IniKey this[string key]
        {
            get { return CreateKey(key); }
        }

        public IniComment Comments
        {
            get { return _comments; }
        }

        public List<IniKey> Keys
        {
            get { return _keys; }
        }

        public string Section { get; set; }
        #endregion

        #region (De)Constructors
        public IniSection(string section)
        {
            Section = section;

            _comments = new IniComment();
            _keys = new List<IniKey>();
        }
        #endregion

        #region Public Methods
        public override string ToString()
        {
            return string.Format("[{0}]", Section);
        }

        public IniKey CreateKey(string key)
        {
            IniKey get = GetKey(key);
            if (get != null)
                return get;

            IniKey gen = new IniKey(key);
            _keys.Add(gen);
            return gen;
        }

        public IniKey GetKey(string key)
        {
            if (HasKey(key))
                return _keys.FirstOrDefault(iniKey => iniKey.Key == key);
            return null;
        }

        public bool HasKey(string key)
        {
            return _keys.Any(iniKey => iniKey.Key == key);
        }
        #endregion
    }

}