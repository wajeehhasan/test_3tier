using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using DAL.Entities;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Person;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    public class Person_Service : IPerson_Service
    {

        //Reference to our crud functions
        private ICRUD _crud = new CRUD();

        public async Task<Generic_ResultSet<Person_ResultSet>> AddPerson(string name, Int64 price, string description, string pictureUrl, string brand, string type )
        {
            Generic_ResultSet<Person_ResultSet> result = new Generic_ResultSet<Person_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Applicant
                Person Person = new Person
                {
                    name= name,
                    price = price,
                    description=description,
                    pictureUrl=pictureUrl,
                    brand=brand,
                    type=type
            
                 };

                //ADD Applicant TO DB
                Person = await _crud.Create<Person>(Person);

                //MANUAL MAPPING OF RETURNED Applicant VALUES TO OUR Applicant_ResultSet
                Person_ResultSet PersonAdded = new Person_ResultSet
                {
                    Id = Person.Id,
                    name = Person.name,
                    description = Person.description,
                    type = Person.type,
                    brand=Person.brand,
                    price=Person.price,
                    pictureUrl=Person.pictureUrl
            
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Your child {0} was registered successfully", Person.name);
                result.internalMessage = "LOGIC.Services.Implementation.Product_Service: AddProduct() method executed successfully.";
                result.result_set = PersonAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for your child. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Product_Service: AddProduct(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Person_ResultSet>> GetPersonById(Int64 Id)
        {
            Generic_ResultSet<Person_ResultSet> result = new Generic_ResultSet<Person_ResultSet>();
            try
            {
                //GET Person FROM DB
                Person Person = await _crud.Read<Person>(Id);

                //MANUAL MAPPING OF RETURNED Applicant VALUES TO OUR Applicant_ResultSet
                Person_ResultSet PersonReturned = new Person_ResultSet
                {
                    Id = Person.Id,
                    name = Person.name,
                    description = Person.description,
                    type = Person.type,
                    brand=Person.brand,
                    price=Person.price,
                    pictureUrl=Person.pictureUrl
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Person {0} was found successfully", PersonReturned.name);
                result.internalMessage = "LOGIC.Services.Implementation.Product_Service: GetProductById() method executed successfully.";
                result.result_set = PersonReturned;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = string.Format("We failed find the Product you are looking for. {0}", exception.Message);
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Person_Service: AddSPersonById(): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<bool>> DelPersonById(Int64 Id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //GET Person FROM DB
                var Person = await _crud.Delete<Person>(Id);

                //MANUAL MAPPING OF RETURNED Applicant VALUES TO OUR Applicant_ResultSet
        
                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Product with Id {0} was Deleted successfully", Id);
                result.internalMessage = "LOGIC.Services.Implementation.Product_Service: DelPersonById() method executed successfully.";
                result.result_set = Person;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed find the Product you are looking for.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Product_Service: AddSProductById(): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<Person_ResultSet>> UpdatePerson(Int64 id, string name, Int64 price, string description, string pictureUrl, string brand, string type )
        {
            Generic_ResultSet<Person_ResultSet> result = new Generic_ResultSet<Person_ResultSet>();
            try
            {
                Person PersonToUpdate = new Person
                {
                    Id = id,
                    name = name,
                    description = description,
                    type = type,
                    brand=brand,
                    price=price,
                    pictureUrl=pictureUrl
                };
                //UPDATE Applicant FROM DB
                PersonToUpdate = await _crud.Update<Person>(PersonToUpdate, id);

                //MANUAL MAPPING OF UPDATED Applicant VALUES TO OUR Applicant_ResultSet
                Person_ResultSet PersonUpdated = new Person_ResultSet
                {
                    Id = PersonToUpdate.Id,
                    Person_Name = PersonToUpdate.Person_Name,
                    Person_Surname = PersonToUpdate.Person_Surname,
                    name = PersonToUpdate.name,
                    description = PersonToUpdate.description,
                    type = PersonToUpdate.type,
                    brand=PersonToUpdate.brand,
                    price=PersonToUpdate.price,
                    pictureUrl=PersonToUpdate.pictureUrl
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Product {0} was updated successfully", PersonUpdated.name);
                result.internalMessage = "LOGIC.Services.Implementation.Person_Service: UpdatePerson() method executed successfully.";
                result.result_set = PersonUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update the supplied Person.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Person_Service: UpdatePerson(): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
        public async Task<Generic_ResultSet<List<Person_ResultSet>>> GetAllPerson()
        {
            Generic_ResultSet<List<Person_ResultSet>> result = new Generic_ResultSet<List<Person_ResultSet>>();
            try
            {
                //GET ALL GRADES
                List<Person> Person = await _crud.ReadAll<Person>();
                //MAP DB GRADE RESULTS
                result.result_set = new List<Person_ResultSet>();
                Person.ForEach(dg => {
                    result.result_set.Add(new Person_ResultSet {
                    Id = dg.Id,
                    name = dg.name,
                    description = dg.description,
                    type = dg.type,
                    brand=dg.brand,
                    price=dg.price,
                    pictureUrl=dg.pictureUrl
                        
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Products obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Products_Service: GetAllProducts() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Products from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Product_Service: GetAllProduct(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
        
    }

}