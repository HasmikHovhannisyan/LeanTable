using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeanTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Lean lean = new Lean()
            // {
            //     principal = 15000,
            //     Interest = 3200
            //
            // };

            List<Lean> leans = new List<Lean>();


            var principalAmounts = new Dictionary<DateTime, decimal>();
            principalAmounts.Add(new DateTime(2022, 1, 10), 15000);
            principalAmounts.Add(new DateTime(2022, 2, 10), 15000);
            principalAmounts.Add(new DateTime(2022, 5, 10), 15000);
            principalAmounts.Add(new DateTime(2022, 6, 10), 15000);
            principalAmounts.Add(new DateTime(2022, 7, 10), 15000);
            principalAmounts.Add(new DateTime(2022, 9, 10), 15000);
            principalAmounts.Add(new DateTime(2022, 10, 10), 15000);
            principalAmounts.Add(new DateTime(2022, 11, 10), 15000);
            principalAmounts.Add(new DateTime(2022, 12, 10), 15000);

            var interestAmounts = new Dictionary<DateTime, decimal>();
            interestAmounts.Add(new DateTime(2022, 1, 10), 3200);
            interestAmounts.Add(new DateTime(2022, 2, 10), 3100);
            interestAmounts.Add(new DateTime(2022, 3, 10), 3000);
            interestAmounts.Add(new DateTime(2022, 4, 10), 2900);
            interestAmounts.Add(new DateTime(2022, 7, 10), 2800);
            interestAmounts.Add(new DateTime(2022, 8, 10), 2700);
            interestAmounts.Add(new DateTime(2022, 9, 10), 2600);
            interestAmounts.Add(new DateTime(2022, 11, 10), 2500);
            interestAmounts.Add(new DateTime(2022, 12, 10), 2400);
            Lean lean;
            foreach (var item in principalAmounts)
            {
                lean = new Lean();
                lean.principal = item.Value;
                lean.date = item.Key;
                if (interestAmounts.ContainsKey(item.Key))
                {
                    lean.Interest = interestAmounts[item.Key];
                }

                leans.Add(lean);
            }

            foreach (var item in interestAmounts)
            {
                if (principalAmounts.ContainsKey(item.Key))
                {
                    leans.Where(x => x.date == item.Key).FirstOrDefault().Interest = item.Value;
                }
                else
                {
                    lean = new Lean();
                    lean.date = item.Key;
                    lean.Interest = item.Value;
                    leans.Add(lean);
                }

            }

            
            foreach (var leann in leans.OrderBy(x => x.date))
            {
                Console.Write($"{leann.date}  ");
                Console.Write($"{leann.principal}      ");
                Console.Write(leann.Interest);
                Console.WriteLine();
            }

            Console.WriteLine();

            foreach (var leann in leans)
            {
                if (leann.date >= DateTime.Now)
                {
                    Console.Write($"{leann.date}  ");
                    Console.Write($"{leann.principal}      ");
                    Console.Write(leann.Interest);
                    Console.WriteLine();
                    break;
                }
            }
        }
    }

    class Lean
    {
        public DateTime date { get; set; }
        public decimal principal { get; set; }
        public decimal Interest { get; set; }

    }
}



//{
//    date = new DateTime(2022, 1, 10),
//    principal = 15000,
//    Interest = 3200

//});

//leans.Add(new Lean()
//{
//    date = new DateTime(2022, 2, 10),
//    principal = 15000,
//    Interest = 3100

//});

//leans.Add(new Lean()
//{
//    date = new DateTime(2022, 3, 10),
//    principal = 0,
//    Interest = 3000
//});

//leans.Add(new Lean()
//{
//    date = new DateTime(2022, 4, 10),
//    principal = 0,
//    Interest = 2900
//});

//leans.Add(new Lean()
//{
//    date = new DateTime(2022, 5, 10),
//    principal = 15000,
//    Interest = 0
//});

//leans.Add(new Lean()
//{
//    date = new DateTime(2022, 6, 10),
//    principal = 15000,
//    Interest = 0
//});

//leans.Add(new Lean()
//{
//    date = new DateTime(2022, 7, 10),
//    principal = 15000,
//    Interest = 2800
//});

//leans.Add(new Lean()
//{
//    date = new DateTime(2022, 8, 10),
//    principal = 0,
//    Interest = 2700
//});

//leans.Add(new Lean()
//{
//    date = new DateTime(2022, 9, 10),
//    principal = 15000,
//    Interest = 2600
//});

//leans.Add(new Lean()
//{
//    date = new DateTime(2022, 10, 10),
//    principal = 15000,
//    Interest = 0
//});

// leans.Add(new Lean()
//{
//    date = new DateTime(2022, 11, 10),
//    principal = 15000,
//    Interest = 0
//});

//  leans.Add(new Lean()
//{
//    date = new DateTime(2022, 12, 10),
//    principal = 15000,
//    Interest = 0
//});