using MIS442Store.DataLayer.DataModels;
using MIS442Store.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS442Store.DataLayer.Repositories
{
    public class StateRepository : IStateRepository 
    {
        public List<USState> Get()
        {
            List<USState> a = new List<USState>();
            return a;
            
        }
    }
}