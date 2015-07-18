// --------------------------------------------------
// ExIni - IniFile.cs
// --------------------------------------------------

#region Usings
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

#endregion

namespace ExIni
{

    public class IniFile
    {
        #region Fields
        private readonly IniComment _comments;
        private readonly List<IniSection> _sections;
        #endregion

        #region Properties
        public IniSection this[string sec]
        {
            get { return CreateSection(sec); }
        }

        public IniComment Comments
        {
            get { return _comments; }
        }

        public List<IniSection> Sections
        {
            get { return _sections; }
        }
        #endregion

        #region (De)Constructors
        public IniFile()
        {
            _comments = new IniComment();
            _sections = new List<IniSection>();
        }
        #endregion

        #region Public Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Sections.Count; i++)
            {
                IniSection s = Sections[i];

                if (s.Comments.Comments.Any())
                    sb.AppendLine(s.Comments.ToString());
                sb.AppendLine(s.ToString());

                foreach (IniKey k in s.Keys)
                {
                    if (k.Comments.Comments.Any())
                        sb.AppendLine(k.Comments.ToString());
                    sb.AppendLine(k.ToString());
                }

                if (i < Sections.Count - 1)
                    sb.AppendLine();
            }

            if (Comments.Comments.Any())
            {
                sb.AppendLine();
                sb.AppendLine(Comments.ToString());
            }

            return sb.ToString();
        }

        public IniSection CreateSection(string section)
        {
            IniSection get = GetSection(section);
            if (get != null)
                return get;

            IniSection gen = new IniSection(section);
            _sections.Add(gen);
            return gen;
        }

        public IniSection GetSection(string section)
        {
            if (HasSection(section))
                return _sections.FirstOrDefault(iniSection => iniSection.Section == section);
            return null;
        }

        public bool HasSection(string section)
        {
            return _sections.Any(iniSection => iniSection.Section == section);
        }

        public void Merge(IniFile ini)
        {
            Comments.Append(ini.Comments.Comments.ToArray());
            foreach (IniSection sOther in ini.Sections)
            {
                IniSection sThis = this[sOther.Section];
                sThis.Comments.Append(sOther.Comments.Comments.ToArray());
                foreach (IniKey kOther in sOther.Keys)
                {
                    IniKey kThis = sThis[kOther.Key];
                    kThis.Comments.Append(kOther.Comments.Comments.ToArray());
                    kThis.Value = kOther.Value;
                }
            }
        }

        public void Save(string filePath)
        {
            File.WriteAllText(filePath, ToString(), Encoding.UTF8);
        }
        #endregion

        #region Public Static Methods
        public static IniFile FromFile(string iniString)
        {
            return IniParser.Parse(File.ReadAllText(iniString));
        }

        public static IniFile FromString(string iniString)
        {
            return IniParser.Parse(iniString);
        }
        #endregion
    }

}