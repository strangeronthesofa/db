using DbTest1.Entities;
using DbTest1.Repositories;

namespace DbTest1.Services;

internal class AddressService
{
    private readonly AddressRepository _addressRepository;

    public AddressService(AddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public AddressEntity CreateAddress(string streetName, string postalCode, string city)
    {
        var addressEntity = _addressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
        if (addressEntity == null)
        {
            addressEntity = _addressRepository.Create(new AddressEntity { StreetName = streetName, PostalCode = postalCode, City = city });
        }

        return addressEntity;
    }

    public AddressEntity GetAddress(string streetName, string postalCode, string city)
    {
        var addressEntity = _addressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
        return addressEntity;
    }

    public AddressEntity GetAddressById(int id)
    {
        var addressEntity = _addressRepository.Get(x => x.Id == id);
        return addressEntity;
    }

    public IEnumerable<AddressEntity> GetAddresses()
    {
        return _addressRepository.GetAll();
    }

    public AddressEntity UpdateAddress(AddressEntity addressEntity)
    {
        var updatedAddressEntity = _addressRepository.Update(x => x.Id == addressEntity.Id, addressEntity);
        return updatedAddressEntity;
    }

    public void DeleteAddress(int id)
    {
        _addressRepository.Delete(x => x.Id == id);
    }
}
