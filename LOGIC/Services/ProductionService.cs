﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using DAL.Entities;
using DAL.Interfaces;
using LOGIC.DTO;
using LOGIC.Interfaces;

namespace LOGIC.Services
{
    public class ProductionService : IProductionService
    {
        IUnitOfWork database { get; set; }
        public ProductionService(IUnitOfWork uow)
        {
            database = uow;
        }
        public bool ChangeProduction(ProductionListDTO production)
        {
            throw new NotImplementedException();
        }

        public bool CreateProduction(ProductionListDTO production, int DepartId)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductionListDTO, ProductionEntities>()).CreateMapper();
                var product = mapper.Map<ProductionListDTO, ProductionEntities>(production);
                var depart = database.DepartmentEntities.GetByID(DepartId);
                product.Department = depart;
                database.ProductionEntities.Create(product);
                database.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteProductionById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductionListDTO> GetProductionByDepartmentId(int Id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductionEntities, ProductionListDTO>().ForMember(x => x.department, y => y.MapFrom(z => z.Department))).CreateMapper();
            return mapper.Map<IEnumerable<ProductionEntities>, List<ProductionListDTO>>(database.ProductionEntities.GetAll().Where(x => x.Department.ID == Id));
        }

        public ProductionListDTO GetProductionById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
