using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_app_Gruncl
{
    class MainViewModel
    {
        public static ObservableCollection<SpaceObject> spaceObjects { get; set; }
        public static APIHandler apiHandler = APIHandler.GetInstance();

        public MainViewModel()
        {
            if (spaceObjects == null) { spaceObjects = new ObservableCollection<SpaceObject>(); }
            GetColl();
        }

        public static async Task GetColl()
        {
            List<SpaceObject> temp = await apiHandler.GetAPIData();
            foreach (SpaceObject spaceObject in temp)
            {
                spaceObjects.Add(spaceObject);
            }
        }
    }
}
