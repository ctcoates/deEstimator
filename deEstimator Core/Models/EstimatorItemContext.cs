using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace deEstimator_Core.Models
{
    public class EstimatorItemContext : DbContext
    {
        public EstimatorItemContext(DbContextOptions<EstimatorItemContext> options) : base(options)
        {

        }
        public DbSet<EstimatorItem> EstimatorItems { get; set; }
    }
}
