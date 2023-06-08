using Microsoft.EntityFrameworkCore.Metadata.Internal;
using one.hr.api.Models;
using One.HR.DataAccess;
using One.HR.DataAccess.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace one.hr.api.Services
{
    public class AddressCRUDService : IGenericCRUDService<AddressModel>
    {
        private readonly IAddressRepository _addressRepository;
        public AddressCRUDService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<AddressModel> Create(AddressModel model)
        {
            var address = new Address()
            {
               Addressline1= model.Addressline1,
               Addressline2= model.Addressline2,
               PostalCode= model.PostalCode,
               Country= model.Country,
               City = model.City,
            };
            var createdAddress= await _addressRepository.CreateAddress(address);
            var result = new AddressModel()
            {
               Addressline1 = createdAddress.Addressline1,
               Addressline2 = createdAddress.Addressline2,
               PostalCode= createdAddress.PostalCode,
               Country= createdAddress.Country,
               City = createdAddress.City,
               ID= createdAddress.ID,
            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            return await _addressRepository.DeleteAddress(id);
        }

        public async  Task<IEnumerable<AddressModel>> GetAll()
        {
           var result = new List<AddressModel>();
           var addresses = await _addressRepository.GetAll();
            foreach (var address in addresses)
            {
                var model = new AddressModel()
                {
                   ID = address.ID,
                   Addressline1= address.Addressline1,
                   Addressline2= address.Addressline2,
                   PostalCode= address.PostalCode,
                   Country= address.Country,
                   City = address.City,

                };
                result.Add(model);
            }
            return result;
        }

        public async Task<AddressModel> GetById(int id)
        {
            var address =  await _addressRepository.GetById(id);
            var model = new AddressModel()
            {
                ID=address.ID,
                Addressline1 = address.Addressline1,
                Addressline2 = address.Addressline2,
                PostalCode= address.PostalCode,
                Country= address.Country,
                City= address.City,
            };
            return model;
        }

        public async  Task<AddressModel> Update(int id, AddressModel model)
        {
            var address = new Address()
            {
               ID = model.ID,
               Addressline1= model.Addressline1,
               Addressline2= model.Addressline2,
               PostalCode= model.PostalCode,
               Country= model.Country,
               City= model.City,
            };
            var createdAddress = await _addressRepository.UpdateAddress(id, address);
            var result = new AddressModel()
            {
               ID=createdAddress.ID,
               Addressline1=createdAddress.Addressline1,
               Addressline2=createdAddress.Addressline2,
               PostalCode= createdAddress.PostalCode,
               Country= createdAddress.Country,
               City= createdAddress.City,
            };
            return result;
        }
    }
}
