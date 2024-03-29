﻿using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RcdbContext>, ICarDal
    {
        public List<CarDetailsDto> GetDetails()
        {
            using (RcdbContext context = new RcdbContext())
            {
                var carDetails = from c in context.Cars
                                 join b in context.Brands
                                 on c.BrandId equals b.BrandId
                                 join co in context.Colors
                                 on c.ColorId equals co.ColorId
                                 select new CarDetailsDto { BrandName = b.BrandName, CarName = c.CarName, ColorName = co.ColorName, DailyPrice = c.DailyPrice };
                return carDetails.ToList();
            }
        }
    }
}
