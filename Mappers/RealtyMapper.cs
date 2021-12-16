using System;
using System.Collections.Generic;
using Domain;
using Entities;
using Models;

namespace Mappers
{
    public static class RealtyMapper
    {
        public static RealtyEntity ToEntity(this Realty realty)
        {
            return new RealtyEntity
            {
                ID = realty.ID,
                dateTime = realty.dateTime,
                RealtyID = realty.RealtyID,
                City = realty.City,
                RealtyType = realty.RealtyType,
                RoomsNumber = realty.RoomsNumber,
                Area = realty.Area,
                Price = realty.Price
            };
        }

        public static Realty ToDomain(this RealtyEntity realty)
        {
            return new Realty
            {
                ID = realty.ID,
                dateTime = realty.dateTime,
                RealtyID = realty.RealtyID,
                City = realty.City,
                RealtyType = realty.RealtyType,
                RoomsNumber = realty.RoomsNumber,
                Area = realty.Area,
                Price = realty.Price
            };
        }

        public static Realty ToDomain(this RealtyModel realty)
        {
            return new Realty
            {
                RealtyID = realty.RealtyID,
                City = realty.City,
                RealtyType = realty.RealtyType,
                RoomsNumber = realty.RoomsNumber,
                Area = realty.Area,
                Price = realty.Price
            };
        }

        public static List<Realty> ToDomainList(this List<RealtyEntity> realties)
        {
            List<Realty> domainRealties = new List<Realty>();

            if (realties == null)
            {
                return domainRealties;
            }

            foreach (var realty in realties)
            {
                domainRealties.Add(new Realty()
                {
                    ID = realty.ID,
                    dateTime = realty.dateTime,
                    RealtyID = realty.RealtyID,
                    City = realty.City,
                    RealtyType = realty.RealtyType,
                    RoomsNumber = realty.RoomsNumber,
                    Area = realty.Area,
                    Price = realty.Price
                });
            }

            return domainRealties;
        }

        public static List<RealtyModel> ToModelList(this List<Realty> realties)
        {
            List<RealtyModel> domainRealties = new List<RealtyModel>();

            if (realties == null)
            {
                return domainRealties;
            }

            foreach (var realty in realties)
            {
                domainRealties.Add(new RealtyModel()
                {
                    RealtyID = realty.RealtyID,
                    City = realty.City,
                    RealtyType = realty.RealtyType,
                    RoomsNumber = realty.RoomsNumber,
                    Area = realty.Area,
                    Price = realty.Price
                });
            }

            return domainRealties;
        }

        public static List<RealtyEntity> ToEntityList(this List<Realty> realties)
        {
            List<RealtyEntity> entityRealties = new List<RealtyEntity>();

            if (realties == null)
            {
                return entityRealties;
            }

            foreach (var realty in realties)
            {
                entityRealties.Add(new RealtyEntity()
                {
                    RealtyID = realty.RealtyID,
                    City = realty.City,
                    RealtyType = realty.RealtyType,
                    RoomsNumber = realty.RoomsNumber,
                    Area = realty.Area,
                    Price = realty.Price
                });
            }

            return entityRealties;
        }

        public static RealtyModel ToModel(this Realty realty)
        {
            return new RealtyModel
            {
                RealtyID = realty.RealtyID,
                City = realty.City,
                RealtyType = realty.RealtyType,
                RoomsNumber = realty.RoomsNumber,
                Area = realty.Area,
                Price = realty.Price
            };
        }
    }
}
