using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Bussiness_Entities;
using PagedList;
using PagedList.Mvc;

namespace DAL
{
    public class TranscationDAL
    {
        int d;
        private MphasisBankEntities db;
        public List<TranscationEnties> ViewTrans(string Aid)
        {
            db = new MphasisBankEntities();

            List<TranscationEnties> li = new List<TranscationEnties>();

                var res = db.Transcations.Where(x => x.Accountid.StartsWith(Aid) || Aid==null );
                foreach (var item in res)
                {
                    li.Add(new TranscationEnties()
                    {
                        Accountid = item.Accountid,
                        TranscationId = item.TranscationId,
                        TranscationDate = item.TranscationDate,
                        Balance = item.Balance,
                        TranscationType = item.TranscationType
                    });
                }
                return li;
            

        }
        public int AddTranscation(TranscationEnties te)
        {
            
            db = new MphasisBankEntities();
            var res = db.SavingsAccounts.Where(t => t.Accountid == te.Accountid);
            
            if (res.Count() > 0)
            {
                if (te.TranscationType == "Withdraw")
                {
                    foreach (var item in res)
                    {
                        if (item.Balance < 0 || item.Balance < te.Balance)
                        {
                            d = 0;
                        }
                        else
                        {
                            Transcation t = new Transcation()
                            {
                                Accountid = te.Accountid,
                                TranscationType = te.TranscationType,
                                TranscationDate = DateTime.Now,
                                Balance = te.Balance
                            };
                            db.Transcations.Add(t);
                            item.Balance -= te.Balance;
                            d = 1;
                        }
                    }
                    if (d == 1)
                    {
                        SavingsAccount sa = new SavingsAccount()
                        {
                            Balance = te.Balance
                        };
                        db.SaveChanges();
                    }
                    return 1;
                }
                else if (te.TranscationType == "Deposite")
                {
                    foreach (var item in res)
                    {
                        if (item.Balance < 0 || item.Balance < te.Balance)
                        {
                            d = 0;
                        }
                        else
                        {
                            Transcation t = new Transcation()
                            {
                                Accountid = te.Accountid,
                                TranscationType = te.TranscationType,
                                TranscationDate = DateTime.Now,
                                Balance = te.Balance
                            };
                            db.Transcations.Add(t);
                            item.Balance += te.Balance;
                            d = 1;
                        }
                    }
                    if (d == 1)
                    {
                        SavingsAccount sa = new SavingsAccount()
                        {
                            Balance = te.Balance
                        };
                        db.SaveChanges();
                    }
                    return 1;
                }
                else
                {
                    return 0;
                }
               
            }
            else
            {
                return 0;
            }
            
        }
    }
}
