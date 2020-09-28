using ChrisCafe.Data.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChrisCafe.Data
{
    static class Cache
    {
        public static readonly MenuCache Menu;
        public static readonly CateringCache CateringMenu;
        public static readonly NoticeCache Notices;

        static Cache()
        {
            Menu = new MenuCache();
            CateringMenu = new CateringCache();
            Notices = new NoticeCache();

            InitializeDataSources();
        }

        public static void InitializeDataSources()
        {
            CateringMenu.Setup();
            Menu.Setup();
            Notices.Setup();
        }
    }
}
