using System;
using System.Collections.Generic;
using System.Text;

namespace ME.Api.Settings.Extensions
{
    public class FriendlyNameAttribute : Attribute
    {
        public FriendlyNameAttribute(string pNameSingle, string pNamePlural)
        {
            NameSingle = pNameSingle;
            NamePlural = pNamePlural;
        }

        public FriendlyNameAttribute(string pNameSingle)
        {
            NameSingle = pNameSingle;
            NamePlural = "";
        }

        public string NameSingle { get; }

        public string NamePlural { get; }
    }
}
