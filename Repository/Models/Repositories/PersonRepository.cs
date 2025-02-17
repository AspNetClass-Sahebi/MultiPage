using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Models.DomainModels;
using Repository.Models.Framworks.Contract;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Repository.Models.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ProjectDbContext _context;
        #region - ctor -
        public PersonRepository(ProjectDbContext context)
        {
            _context = context;
        }

              #endregion

        #region - Select() -
        public async Task<List<Person>> Select()
        {
            
            using (_context)
            {
                try
                {
                    var persons = await _context.person.ToListAsync();
                    return persons;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (_context.person != null) _context.Dispose();
                }
            }
        }
        #endregion

        #region - Insert() - 
        public async Task Insert(Person person)
                    {
            try
            {
                var P = new Person()
                {
                    Id = Guid.NewGuid(),
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Email = person.Email

                };

                _context.Add(P);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (_context.person != null) _context.Dispose();
            }

        }


        #endregion

        #region - Edit() -
       

        public async Task Edit(Person person)
        {
            using (_context)
                try
                {
                    _context.Update(person);
                   
                    await _context.SaveChangesAsync();

                }
                catch (Exception)
                {

                    throw;
                }
        }


        #endregion

        #region - Delete() -
        // GET: People/Delete/5
        public async Task Delete(Person person)
        {
            using (_context)
                try
                {
                   ;
                    _context.Remove(person);

                    await _context.SaveChangesAsync();

                }
                catch (Exception)
                {

                    throw;
                }
        }
        #endregion

        #region - Details()-
        public async Task<Person> Details(Guid? Id)
        {
             
            using (_context)
                try
                {

                    var persons = await _context.person
                     .FirstOrDefaultAsync(m => m.Id == Id);
                     return persons;
                  
                                    }
                catch (Exception)
                {

                    throw;
                }
            
        }

        #endregion
    }
}
