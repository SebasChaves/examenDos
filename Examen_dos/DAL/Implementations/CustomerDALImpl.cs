using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class CustomerDALImpl : ICustomerDAL
    {
        AdventureWorks2016Context context;


        public CustomerDALImpl()
        {
            context = new AdventureWorks2016Context();

        }

        public CustomerDALImpl(AdventureWorks2016Context _Context)
        {
            context = _Context;

        }


        public bool Add(Customer entity)
        {
            try
            {
                using (UnidadDeTrabajo<Customer> unidad = new UnidadDeTrabajo<Customer>(context))
                {
                    unidad.genericDAL.Add(entity);
                    unidad.Complete();
                }


                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void AddRange(IEnumerable<Customer> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            Customer empleado;
            using (UnidadDeTrabajo<Customer> unidad = new UnidadDeTrabajo<Customer>(context))
            {

                empleado = unidad.genericDAL.Get(id);
            }
            return empleado;
        }

        public IEnumerable<Customer> GetAll()
        {
            try
            {
                IEnumerable<Customer> empleados;
                using (UnidadDeTrabajo<Customer> unidad = new UnidadDeTrabajo<Customer>(context))
                {
                    empleados = unidad.genericDAL.GetAll();
                }
                return empleados;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Customer entity)
        {
            try
            {
                using (UnidadDeTrabajo<Customer> unidad = new UnidadDeTrabajo<Customer>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    unidad.Complete();
                }


                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void RemoveRange(IEnumerable<Customer> entities)
        {
            throw new NotImplementedException();
        }

        public Customer SingleOrDefault(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer entity)
        {
            try
            {
                using (UnidadDeTrabajo<Customer> unidad = new UnidadDeTrabajo<Customer>(context))
                {
                    unidad.genericDAL.Update(entity);
                    unidad.Complete();
                }


                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
