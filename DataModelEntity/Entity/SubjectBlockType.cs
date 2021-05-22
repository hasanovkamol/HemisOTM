using System;
using System.Collections.Generic;
using System.Text;

namespace DataModelEntity.Entity
{
    public class SubjectBlockType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<HarvestPlan> harvestPlans { get; set; }
    }
}
