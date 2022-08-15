using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC.DTO
{
    public class ProductionListDTO
    {
        public int ID { get; set; }
        public string ProductionName { get; set; }
        public double Price { get; set; }
        public UInt32 Amount { get; set; }
        public string Description { get; set; }
        public string Manufacture { get; set; }
        public DateTime InsertDate { get; set; }
        public DepartmentEntities department { get; set; }
    }
}
