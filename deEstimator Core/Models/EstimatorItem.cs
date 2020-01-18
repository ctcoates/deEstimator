using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace deEstimator_Core.Models
{
    public class EstimatorItem
    {
        public long Id { get; set; }
        public string Description { get; set; }
    }
}
