﻿using Core.DataAccsess.EntityFramework;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectDBContext context=new ReCapProjectDBContext())
            {
                var result = from c in context.Cars join b in context.Brands on c.BrandId equals b.BrandId join co in context.Colors on c.ColorId equals co.ColorId select new CarDetailDto { CarId = c.CarId, CarName = c.CarName, BrandName = b.BrandName, ColorName = co.ColorName, DailyPrice = c.DailyPrice, ModelYear = c.ModelYear, Description = c.Description };
                return result.ToList();
            }
        }
    }
}