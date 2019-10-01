using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketApp.Contract;
using MarketApp.Entities;
using MarketApp.Interfaces;

namespace Market.Servises
{
    public class RackService
    {
        public IRackRepository RackRepository { get; set; }


        public void CreateOrUpdate(RackContract rackContract)
        {
            var rack = RackRepository.Get(rackContract.Id);
            if (rack != null)
            {
                rack.RackParent = RackRepository.Get(rackContract.RackId);
                rack.Code = rackContract.Code;
                rack.Limit = rackContract.Limit;
                rack.Location = rackContract.Location;
                rack.Name = rackContract.Name;

                RackRepository.Update(rack);
            }
            else
            {
                rack = new Rack();
                rack.RackParent = RackRepository.Get(rackContract.RackId);
                rack.Code = rackContract.Code;
                rack.Limit = rackContract.Limit;
                rack.Location = rackContract.Location;
                rack.Name = rackContract.Name;

                RackRepository.Insert(rack);
            }

        }

        public void Delete(RackContract rackContract)
        {
            var rack = RackRepository.Get(rackContract.Id);
            RackRepository.Delete(rack);
        }
    }

}

