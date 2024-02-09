using DbTest1.Entities;
using DbTest1.Repositories;

namespace DbTest1.Services;

internal class RoleService
{

    private readonly RoleRepository _roleRepository;

    public RoleService(RoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public RoleEntity CreateRole(string roleName)
    {
        var RoleEntity = _roleRepository.Get(x => x.RoleName == roleName);
        if (RoleEntity == null)
        {
            RoleEntity = _roleRepository.Create(new RoleEntity { RoleName = roleName });
        }

        return RoleEntity;
    }

    public RoleEntity GetRoleByRoleName(string roleName)
    {
        var RoleEntity = _roleRepository.Get(x => x.RoleName == roleName);
        return RoleEntity;
    }

    public RoleEntity GetRoleByRoleId(int id)
    {
        var RoleEntity = _roleRepository.Get(x => x.Id == id);
        return RoleEntity;
    }

    public IEnumerable<RoleEntity> GetRoles()
    {
        return _roleRepository.GetAll();
    }

    public RoleEntity UpdateRole(RoleEntity roleEntity)
    {
        var updatedRoleEntity = _roleRepository.Update(x => x.Id == roleEntity.Id, roleEntity);
        return updatedRoleEntity;
    }

    public void DeleteRole(int id)
    {
        _roleRepository.Delete(x => x.Id == id);
    }
}
