using LinkManager.UI.BL.Email;
using LinkManager.UI.BL.Email.ViewModels;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkManager.UI.BL.Scheduler
{
    public class SchedulerFinancialJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            EmailHelper email = new EmailHelper();
            email.SendRiskEstimatesMessage(
                new List<string> { "olegshandra77@gmail.com" },
                "Risk Estimates",
                new List<RiskEstimatesItemViewModel> {
                new RiskEstimatesItemViewModel { Supervisor = "Oleg", Project = "Test1", SelfCost = 32, ProposedExternalRate = 1, CurrentRate = 4  },
                new RiskEstimatesItemViewModel { Supervisor = "WAFeff", Project = "Test2", SelfCost = 1.2, ProposedExternalRate = 23, CurrentRate = 4  },
                new RiskEstimatesItemViewModel { Supervisor = "awdawffwe", Project = "Test3", SelfCost = 1.2, ProposedExternalRate = 13, CurrentRate = 4  },
                new RiskEstimatesItemViewModel { Supervisor = "Osefseleg", Project = "Test32235", SelfCost = 1.2, ProposedExternalRate = 1, CurrentRate = 4  },
                new RiskEstimatesItemViewModel { Supervisor = "wqef", Project = "Te124st", SelfCost = 122, ProposedExternalRate = 1, CurrentRate = 4  },
                new RiskEstimatesItemViewModel { Supervisor = "wef", Project = "Test124", SelfCost = 1.2, ProposedExternalRate = 1, CurrentRate = 4  },
                new RiskEstimatesItemViewModel { Supervisor = "124142", Project = "Tes214t", SelfCost = 1.2, ProposedExternalRate = 14, CurrentRate = 4  },
                new RiskEstimatesItemViewModel { Supervisor = "wafdf", Project = "Tesweat", SelfCost = 12, ProposedExternalRate = 1, CurrentRate = 4  },
                new RiskEstimatesItemViewModel { Supervisor = "sdf", Project = "TesWEEWt", SelfCost = 1.2, ProposedExternalRate = 1, CurrentRate = 4  },
                new RiskEstimatesItemViewModel { Supervisor = "Oleg", Project = "TestWEF", SelfCost = 1.2, ProposedExternalRate = 13, CurrentRate = 4  },
                new RiskEstimatesItemViewModel { Supervisor = "sag", Project = "TesWt", SelfCost = 1.2, ProposedExternalRate = 1, CurrentRate = 4  },
                new RiskEstimatesItemViewModel { Supervisor = "Oleg", Project = "Tt", SelfCost = 1.2, ProposedExternalRate = 12, CurrentRate = 4  },
                new RiskEstimatesItemViewModel { Supervisor = "Olagaseg", Project = "TWEest", SelfCost = 112, ProposedExternalRate = 1, CurrentRate = 4  }
            });
        }
    }
}