using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


  public  interface IDao
    {

        bool Delete(object model);
        bool Save(object model);
        bool Update(object model, string id);
        List<object> SelectAll();
        object SelectById(string id);
        List<object> SelectByCriterias(ArrayList criterias);
        string GetPrimaryKey();

    }

