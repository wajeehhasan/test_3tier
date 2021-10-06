using LOGIC.Services.Models;
using LOGIC.Services.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LOGIC.Services.Interfaces
{
     public interface IPerson_Service
    {
        
        Task<Generic_ResultSet<List<Person_ResultSet>>> GetAllPerson();
        Task<Generic_ResultSet<Person_ResultSet>> AddPerson(string name, Int64 price, string description, string pictureUrl, string brand, string type );
        Task<Generic_ResultSet<Person_ResultSet>> UpdatePerson(Int64 id, string name, Int64 price, string description, string pictureUrl, string brand, string type );
        Task<Generic_ResultSet<bool>> DelPersonById(Int64 Id);
        Task<Generic_ResultSet<Person_ResultSet>> GetPersonById(Int64 Id);
        
    }
}