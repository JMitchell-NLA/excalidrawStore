using System;
using System.Collections.Generic;


namespace excalidrawCloud.Models
{
    public class CloudDocInfo
    {
      
      public CloudDocInfo (int id,string name,DateTime dt){
        this.id = id;
        this.name = name;
        this.dateLastSaved = dt;
      }

      public string name {get; set;}

      public int id {get; set;}

      public DateTime dateLastSaved {get; set;}

      // Okay, that's this DTO written.
      // Time to make the controller serve it up.
    }
}