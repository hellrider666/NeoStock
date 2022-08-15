using LOGIC.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC.Interfaces
{
    public interface IProductionService
    {
        IEnumerable<ProductionListDTO> GetProductionByDepartmentId(int Id);
        ProductionListDTO GetProductionById(int Id);
        bool CreateProduction(ProductionListDTO production);
        bool DeleteProductionById(int Id);
        bool ChangeProduction(ProductionListDTO production);
    }
}
