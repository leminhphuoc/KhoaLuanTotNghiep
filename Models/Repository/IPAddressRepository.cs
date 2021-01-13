﻿using Models.Entity;
using System;
using System.Linq;

namespace Models.Repository
{
    public class IPAddressRepository : IIPAddressRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        public IPAddressRepository()
        {
            _db = new FonNatureDbContext();
        }

        public bool AddIpAddress(string IpAddress)
        {
            if (IpAddress == null) return false;
            if (_db.IPAddresses.Where(x => x.IP == IpAddress).SingleOrDefault() != null) return false;
            var IP = new IPAddress() { IP = IpAddress, date = DateTime.Now };
            _db.IPAddresses.Add(IP);
            var Visitor = _db.UsefulInformations.Where(x => x.Name == "Visitor").SingleOrDefault();
            Visitor.Value += 1;
            _db.SaveChanges();
            return true;
        }

        public bool AddVisitor(string infor)
        {
            try
            {
                var IP = new IPAddress() { IP = infor, date = DateTime.Now };
                _db.IPAddresses.Add(IP);
                var Visitor = _db.UsefulInformations.Where(x => x.Name == "Visitor").SingleOrDefault();
                Visitor.Value += 1;
                _db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public int? CountVisitor()
        {
            var visitor = _db.UsefulInformations.Where(x => x.Name == "Visitor").SingleOrDefault();
            var value = visitor.Value;
            return value;
        }

        public int CountByMonth(int month)
        {
            return _db.IPAddresses.Where(x => x.date.Month == month).Count();
        }
    }
}
