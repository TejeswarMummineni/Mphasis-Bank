using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Bussiness_Entities;

namespace DAL
{
    public class LoanDAL
    {
        private MphasisBankEntities db;
        
        public int LoanAc(Loan_Account_Entites la)
        {
            int d=0;
            int age=0;
            db = new MphasisBankEntities();
            var res = db.Customers.Where(t => t.CustId == la.CustId);

            if (res.Count() > 0)
            {
                var cd = db.LoanAccounts.OrderByDescending(t => t.LnAccountid).First();
                if (cd == null)
                {
                    la.LnAccountid = "LN10001";
                }
                else
                {
                    la.LnAccountid = "LN" + (Convert.ToInt32(cd.LnAccountid.Substring(2, 5)) + 1).ToString();
                }
                foreach (var item in res)
                {
                    DateTime dt = Convert.ToDateTime(item.Dob);
                    DateTime today = DateTime.Today;
                    age += today.Year - dt.Year;
                }
                if (age > 60)
                {
                    if (la.lnAmount < 100000)
                    {
                        la.ROI = 0.095;
                        d = 1;
                    }
                    else
                        d = 0;
                }
                else
                {

                    if (la.lnAmount > 10000 && la.lnAmount <= 500000)
                    {
                        la.ROI = 0.1;
                        d = 1;
                    }
                    else if (la.lnAmount > 500000 && la.lnAmount <= 1000000)
                    {
                        la.ROI = 0.095;
                        d = 1;
                    }
                    else if (la.lnAmount > 1000000)
                    {
                        la.ROI = 0.09;
                        d = 1;
                    }
                    else
                    {
                        d = 0;
                    }
                }
                if (d == 1)
                {
                    la.EMI = la.lnAmount * la.ROI * (1 + la.ROI) * la.Tenure / ((1 + la.ROI) * la.Tenure - 1);
                    la.StartDate = DateTime.Now;
                    LoanAccount l = new LoanAccount()
                    {
                        LnAccountid = la.LnAccountid,
                        CustId = la.CustId,
                        lnAmount = la.lnAmount,
                        StartDate = la.StartDate,
                        Tenure = la.Tenure,
                        ROI = la.ROI,
                        EMI = la.EMI
                    };
                    db.LoanAccounts.Add(l);
                    db.SaveChanges();
                }
            }
            else
                d = 0;
            return d;
        }
            public int LoanTrans(Loan_Transcation_Entites lt)
            {
                db = new MphasisBankEntities();
                var r = db.LoanAccounts.Where(t => t.LnAccountid == lt.LnAccountid);
                if (r.Count() > 0)
                {
                    foreach (var item in r)
                    {
                        lt.Outstanding =item.lnAmount-lt.Amount;
                    }
                    LoanTranscation l = new LoanTranscation()
                    {
                        LnAccountid = lt.LnAccountid,
                        Emidate = DateTime.Today,
                        Amount = lt.Amount,
                        Outstanding = lt.Outstanding
                    };
                    db.LoanTranscations.Add(l);
                    db.SaveChanges();
                    return 1;
                }
                else
                    return 0;
            }
        
    }
}
