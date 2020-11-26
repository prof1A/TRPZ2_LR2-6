using System;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IVisitor
    {
        List<CEO> Ceos { get; set; }
        List<DeliveryManager> DeliveryManagers { get; set; }
        List<SalesManager> SalesManagers { get; set; }
        List<Developer> Developers { get; set; }
        List<Marketer> Marketers { get; set; }
        void CreateNewEmployee(string firstName, string lastName, string position, Guid masterid);
    }
}