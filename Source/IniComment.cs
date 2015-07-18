// --------------------------------------------------
// ExIni - IniComment.cs
// --------------------------------------------------

#region Usings

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace ExIni
{

    public class IniComment
    {
        #region Properties
        public List<string> Comments { get; set; }
        #endregion

        #region (De)Constructors
        public IniComment()
        {
            Comments = new List<string>();
        }
        #endregion

        #region Public Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Comments.Count; i++)
            {
                string comment = Comments[i];

                string value = i < Comments.Count - 1
                    ? ";" + comment + Environment.NewLine
                    : ";" + comment;

                sb.Append(value);
            }
            return sb.ToString();
        }

        public void Append(params string[] comments)
        {
            Comments.AddRange(comments);
        }
        #endregion
    }

}