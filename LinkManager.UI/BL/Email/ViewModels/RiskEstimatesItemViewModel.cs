using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkManager.UI.BL.Email.ViewModels
{
    public class RiskEstimatesItemViewModel
    {
        public string Supervisor { get; set; }
        public string Project { get; set; }
        public double SelfCost { get; set; }
        public double ProposedExternalRate { get; set; }
        public double CurrentRate { get; set; }
        public string RowColor
        {
            get
            {
                if(CurrentRate < SelfCost)
                {
                    return Colors.Red;
                }
                else if(CurrentRate < ProposedExternalRate)
                {
                    return Colors.Yellow;
                }
                else
                {
                    return Colors.Green;
                }
            }
        }

        private struct Colors
        {
            public const string Red = "#f26363";
            public const string Yellow = "#fff482";
            public const string Green = "#98ff82";
        } 
    }
}