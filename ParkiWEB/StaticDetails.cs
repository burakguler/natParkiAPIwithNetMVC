using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkiWEB
{
    public static class StaticDetails
    {
        public static string APIBaseUrl = "http://localhost:44330/";
        public static string NationalParkAPIPath = APIBaseUrl + "api/v1/nationalparks";
        public static string TrailAPIPath = APIBaseUrl + "api/v1/trails";

    }
}
