using System;
using System.Collections.Generic;


namespace excalidrawCloud.Models
{
    public class Excalidraw
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string elements{ get; set; }
        public string state { get; set; }
        public long owner {get; set;}
        public DateTime lastSaved{get; set;}
    }

    public class ExcalidrawHistory:Excalidraw
    {
     public DateTime startDate{get;set;}
     public DateTime endDate {get;set;}
    }
}
    