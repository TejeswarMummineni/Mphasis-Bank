﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Bussiness_Entities;

namespace Blogic
{
    public class TranscationBL
    {
        TranscationDAL ts = new TranscationDAL();
        public List<TranscationEnties> ViewTrans(string Aid)
        {
           // List<TranscationEnties> li = new List<TranscationEnties>();
            return ts.ViewTrans(Aid);
           // return li;
        }
            public TranscationEnties ViewTrans(DateTime StartDate, DateTime EndDate)
        {
            TranscationEnties te = new TranscationEnties();
            return te;
        }
            public int AddTranscation(TranscationEnties te)
        {
            return ts.AddTranscation(te);
        }
    }
}