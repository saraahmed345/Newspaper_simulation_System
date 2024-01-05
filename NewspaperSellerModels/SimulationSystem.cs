using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewspaperSellerModels
{
    public class SimulationSystem
    {
        public SimulationSystem()
        {
            DayTypeDistributions = new List<DayTypeDistribution>();
            DemandDistributions = new List<DemandDistribution>();
            SimulationTable = new List<SimulationCase>();
            PerformanceMeasures = new PerformanceMeasures();
        }
        ///////////// INPUTS /////////////
        public int NumOfNewspapers { get; set; }
        public int NumOfRecords { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal ScrapPrice { get; set; }
        public decimal UnitProfit { get; set; }
        public List<DayTypeDistribution> DayTypeDistributions { get; set; }
        public List<DemandDistribution> DemandDistributions { get; set; }
        public List<decimal> P1 { get; set; }
        public List<decimal> P2 { get; set; }
        public List<decimal> P3 { get; set; }

        ///////////// OUTPUTS /////////////
        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }


        public void Read_file(string file)
        {

            P1 = new List<decimal>();
            P2 = new List<decimal>();
            P3 = new List<decimal>();

            decimal cumprop = 0;
            int min = 0, max = 0;
           // int dt = -1;

            int count = 0;

            using (StreamReader r = new StreamReader(file))
            {
                string Linee;
                string key = null;

                while ((Linee = r.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(Linee))
                        continue;

                    if (Linee == "NumOfNewspapers")
                    {
                        key = "NumOfNewspapers";
                    }
                    else if (Linee == "NumOfRecords")
                    {
                        key = "NumOfRecords";
                    }
                    else if (Linee == "PurchasePrice")
                    {
                        key = "PurchasePrice";
                    }
                    else if (Linee == "ScrapPrice")
                    {
                        key = "ScrapPrice";
                    }
                    else if (Linee == "SellingPrice")
                    {
                        key = "SellingPrice";
                    }
                    else if (Linee == "DayTypeDistributions")
                    {
                        key = "DayTypeDistributions";
                    }
                    else if (Linee == "DemandDistributions")
                    {
                        key = "DemandDistributions";
                    }

                    else
                    {
                        int x;
                        decimal z;
                        if (key == "NumOfNewspapers" && int.TryParse(Linee, out x))
                        {
                            NumOfNewspapers = x;
                        }
                        else if (key == "NumOfRecords" && int.TryParse(Linee, out x))
                        {
                            NumOfRecords = x;
                        }
                        else if (key == "PurchasePrice" && decimal.TryParse(Linee, out z))
                        {
                            PurchasePrice = z;
                        }
                        else if (key == "ScrapPrice" && decimal.TryParse(Linee, out z))
                        {
                            ScrapPrice = z;
                        }
                        else if (key == "SellingPrice" && decimal.TryParse(Linee, out z))
                        {
                            SellingPrice = z;
                        }


                        else if (key == "DayTypeDistributions")
                        {


                            //string[] p = Linee.Split(',');


                            string[] distrubution = Linee.Split(',');
                            for (int i = 0; i < distrubution.Length; i++) // the loop to fill the interarrival time s
                            {




                                decimal y = decimal.Parse(distrubution[i]);
                                //decimal y = decimal.Parse(distrubution[1]);
                                DayTypeDistributions.Add(new DayTypeDistribution());
                                DayTypeDistributions[i].DayType = (Enums.DayType)i;
                                DayTypeDistributions[i].Probability = y;
                                cumprop+=y;
                                DayTypeDistributions[i].CummProbability = cumprop;
                                min = max + 1;
                                max = (int)(cumprop * 100);
                                DayTypeDistributions[i].MinRange = min;
                                DayTypeDistributions[i].MaxRange = max;

                                //System.Console.WriteLine("Inter arrival time ");
                                System.Console.WriteLine(y);
                                System.Console.WriteLine(DayTypeDistributions[i].DayType + "   " + DayTypeDistributions[i].Probability);


                            }

                        }

                        else if (key == "DemandDistributions")
                        {


                            //string[] p = Linee.Split(',');

                          
                            string[] lines = Linee.Split('\n');

                            foreach (string line in lines)
                            {
                                // Split the line by comma
                                //string[] distributionData = line.Split(',');

                                //// Parse demand value
                                //int demand = int.Parse(distributionData[0]);

                                //DemandDistribution demandDistribution = new DemandDistribution();
                                //demandDistribution.Demand = demand;

                                //// Loop through the rest of the values (starting from index 1) and create DayTypeDistribution objects
                                //for (int i = 1; i < distributionData.Length; i++)
                                //{
                                //    DayTypeDistribution dayTypeDistribution = new DayTypeDistribution();

                                //    dayTypeDistribution.DayType = (Enums.DayType)(i - 1); // Enums.DayType.Good, Enums.DayType.Fair, Enums.DayType.Poor

                                //    dayTypeDistribution.Probability = decimal.Parse(distributionData[i]);

                                //    demandDistribution.DayTypeDistributions.Add(dayTypeDistribution);
                                //}

                                //DemandDistributions.Add(demandDistribution);




                                // public Enums.DayType DayType { get; set; }
                                //public decimal Probability { get; set; }
                                //public decimal CummProbability { get; set; }
                                //public int MinRange { get; set; }
                                //public int MaxRange { get; set; }

                                 //public int Demand { get; set; }
                                 //public List<DayTypeDistribution> DayTypeDistributions { get; set; }
                                 


                               DemandDistributions.Add(new DemandDistribution());
                               


                                string[] s = line.Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
                                DemandDistributions[count].Demand = int.Parse(s[0]);
                                for(int i = 0; i <3 ; i++)
                                {
                                    DemandDistributions[count].DayTypeDistributions.Add(new DayTypeDistribution()) ;

                                }
                                //DemandDistributions[count].DayTypeDistributions[0].Probability = (decimal.Parse(s[1]));
                                //DemandDistributions[count].DayTypeDistributions[1].Probability = (decimal.Parse(s[2]));
                                //DemandDistributions[count].DayTypeDistributions[2].Probability = (decimal.Parse(s[3]));

                                this.P1.Add(decimal.Parse(s[1]));
                                this.P2.Add(decimal.Parse(s[2]));
                                this.P3.Add(decimal.Parse(s[3]));

                                count ++;

                            }






                        }

                        }
                    }
                }
            int max1 = 0; decimal cumprob1 = 0;int min1 = 0;
            int max2 = 0; decimal cumprob2 = 0;int min2 = 0;
            int max3 = 0; decimal cumprob3 = 0;int min3 = 0;




            for (int i = 0; i < DemandDistributions.Count; i++)
            {
                for(int j = 0; j < 1 ; j++)
                {
                    DemandDistributions[i].DayTypeDistributions[0].Probability = P1[i];
                    cumprob1 += P1[i];
                    DemandDistributions[i].DayTypeDistributions[0].CummProbability =cumprob1;
                    min1 = max1 + 1;
                    max1 = (int)(cumprob1 * 100);
                    DemandDistributions[i].DayTypeDistributions[0].MinRange = min1;
                    DemandDistributions[i].DayTypeDistributions[0].MaxRange =max1 ;




                    DemandDistributions[i].DayTypeDistributions[1].Probability = P2[i];
                    cumprob2 += P2[i];
                    DemandDistributions[i].DayTypeDistributions[1].CummProbability = cumprob2;

                    min2 = max2 + 1;
                    max2 = (int)(cumprob2 * 100);
                    DemandDistributions[i].DayTypeDistributions[1].MinRange =min2;
                    DemandDistributions[i].DayTypeDistributions[1].MaxRange =max2;






                    DemandDistributions[i].DayTypeDistributions[2].Probability = P3[i];
                    cumprob3 += P3[i];
                    DemandDistributions[i].DayTypeDistributions[2].CummProbability =cumprob3;
                    min3= max3 + 1;
                    max3 = (int)(cumprob3 * 100);

                    DemandDistributions[i].DayTypeDistributions[2].MinRange = min3;
                    DemandDistributions[i].DayTypeDistributions[2].MaxRange = max3;

                }

            }
          

        }
        public Enums.DayType map_TypeofNewsday(List<DayTypeDistribution> lst, int randomnum)
        {
            // Initialize with a default value
            Enums.DayType x = Enums.DayType.Good;
            for (int i = 0; i < lst.Count; i++)
            {
                if (randomnum >= lst[i].MinRange && randomnum <= lst[i].MaxRange)
                {
                    x = lst[i].DayType;
                }
            }

            return x;

        }
        public int map_randomnumbers(List<DemandDistribution> dt, int randomnum , int v )
        {
            int i = 0;
            int Range = -1;

            for (; i < dt.Count; i++)
            {
                //if (randomnum >= dt[i].MinRange && randomnum <= dt[i].MaxRange)
                //{
                //    Range = dt[i].Time;
                //}
                if(randomnum >= dt[i].DayTypeDistributions[v].MinRange && randomnum <= dt[i].DayTypeDistributions[v].MaxRange) { 

                Range = dt[i].Demand;
                
                }
            }


            return Range;


        }

        public void simulation_table_records()
        {
            Random r = new Random();

            for (int i = 0; i < NumOfRecords; i++)
            {
                SimulationTable.Add(new SimulationCase());
                int random_for_Day_type = r.Next(1, 101);
                Enums.DayType Day_T = map_TypeofNewsday(DayTypeDistributions, random_for_Day_type);

                int random_for_demand = r.Next(1, 101);

                SimulationTable[i].DayNo = i +1 ;

                SimulationTable[i].Demand = map_randomnumbers(DemandDistributions, random_for_demand, (int)Day_T);
                SimulationTable[i].NewsDayType = Day_T;
                SimulationTable[i].RandomDemand = random_for_demand;
                SimulationTable[i].RandomNewsDayType = random_for_Day_type;
                // SimulationTable[i].SalesProfit = (decimal)0.5 * SimulationTable[i].Demand;

                //SimulationTable[i].LostProfit = (decimal)(0.5 * NumOfNewspapers) - SimulationTable[i].SalesProfit;
                //SimulationTable[i].ScrapProfit = (decimal)(0.05 * (NumOfNewspapers - SimulationTable[i].Demand));
                //SimulationTable[i].DailyNetProfit = (decimal)(SimulationTable[i].SalesProfit - (PurchasePrice) - SimulationTable[i].LostProfit + SimulationTable[i].ScrapProfit);
                SimulationTable[i].DailyCost = NumOfNewspapers * PurchasePrice;
                if (SimulationTable[i].Demand > NumOfNewspapers)
                {
                    SimulationTable[i].SalesProfit = Decimal.Round(NumOfNewspapers * SellingPrice, 1);
                    SimulationTable[i].LostProfit = (SimulationTable[i].Demand - NumOfNewspapers) * (SellingPrice - PurchasePrice);
                    SimulationTable[i].ScrapProfit = 0;
                }
                else if (SimulationTable[i].Demand < NumOfNewspapers)
                {
                    SimulationTable[i].SalesProfit = Decimal.Round(SimulationTable[i].Demand * SellingPrice, 1);
                    SimulationTable[i].LostProfit = 0;
                    SimulationTable[i].ScrapProfit = ScrapPrice * (NumOfNewspapers - SimulationTable[i].Demand);
                }
                else
                {
                    SimulationTable[i].SalesProfit = Decimal.Round(NumOfNewspapers * SellingPrice, 1);
                    SimulationTable[i].LostProfit = 0;
                    SimulationTable[i].ScrapProfit = 0;
                }
                SimulationTable[i].DailyNetProfit = SimulationTable[i].SalesProfit - SimulationTable[i].DailyCost - SimulationTable[i].LostProfit + SimulationTable[i].ScrapProfit;

            }

        }


        public void calculate_Performance()
        {
            int dem_days = 0, unsold_days = 0;
            decimal total_netprofit = 0, total_scrap = 0, total_lostProfit = 0, total_revenue = 0;
            foreach (SimulationCase sc in SimulationTable)
            {
                if (sc.Demand > NumOfNewspapers)
                {
                    dem_days++;
                }
                else if (NumOfNewspapers > sc.Demand)
                {
                    unsold_days++;
                }
                total_lostProfit += sc.LostProfit;
                total_netprofit += sc.DailyNetProfit;
                total_revenue += sc.SalesProfit;
                total_scrap += sc.ScrapProfit;
            }
            PerformanceMeasures.TotalSalesProfit = total_revenue;
            PerformanceMeasures.TotalCost = (NumOfNewspapers * PurchasePrice) * NumOfRecords;
            PerformanceMeasures.TotalLostProfit = total_lostProfit;
            PerformanceMeasures.TotalScrapProfit = total_scrap;
            PerformanceMeasures.TotalNetProfit = total_netprofit;
            PerformanceMeasures.DaysWithMoreDemand = dem_days;
            PerformanceMeasures.DaysWithUnsoldPapers = unsold_days;
        }
     






        }
    }


