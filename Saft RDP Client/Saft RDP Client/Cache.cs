using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaftRDPClient
{
  public static class Cache
    {

        public static class MainForm
        {
            public static bool changes { get; set; }
            public static string[] laststrings { get; set; }
            public static bool groupscached { get; set; }
            public static string[] grouplist { get; set; }
            public static bool groupschanged { get; set; }
            public static string lasteditedalias { get; set; }
            public static string lasteditedserver { get; set; }
            public static string lasteditedgroup { get; set; }
            public static bool groupisediting { get; set; }
            public static bool serverisediting { get; set; }

            public static void SetValues()
            {
                changes = false;
                laststrings = new string[10];
                groupscached = false;
                grouplist = new string[5];
                groupschanged = true;

            }
        }

        public static class AddChangeServerForm
        {
            public static bool changes { get; set; }
            public static string[] laststrings { get; set; }

            public static void MakeCache(IntPtr Caller)
            {
                SaftRDPClient.frm_addserver OriginalForm = new frm_addserver();
                OriginalForm = frm_addserver.FromHandle(Caller) as SaftRDPClient.frm_addserver;
                SaftRDPClient.frm_addserver CachedForm = new frm_addserver();
                CachedForm = OriginalForm;
                OriginalForm.Text = "Оригинал";
                CachedForm.Text = "Кэшированная форма";
                
            }
            //MakeCache += EventHandler(SaftRDPClient.frm_addserver);
        }

        public static class PairsForm
        {
            public static bool changes { get; set; }
            public static string[] laststrings { get; set; }
        }

        public static class Other
        {
        }

    }
}
