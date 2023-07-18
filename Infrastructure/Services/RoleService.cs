using Application.Interfaces.ServiceInterfaces;
using Application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class RoleService : IRoleService
    {
        RoleManager<IdentityRole> _roleManager;
        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager=roleManager;
        }

        public async Task<IdentityRole> AddAsync(IdentityRole entity)
        {
             await  _roleManager.CreateAsync(entity);
            return entity;
        }

        public async Task<ICollection<IdentityRole>> AddRangeAsync(ICollection<IdentityRole> entities)
        {
            foreach (var entity in entities)
            {
                await _roleManager.CreateAsync(entity);
            }
            return entities;
        }

        public async Task<bool> DeleteAsync(IdentityRole entity)
        {
           var result=await _roleManager.DeleteAsync(entity);
            return result.Succeeded;
            
        }

        public async Task<IdentityRole> Get(Guid Id)
        {
            var result =await _roleManager.Roles.SingleOrDefaultAsync(x => x.Id == Id.ToString());
            return result;
        }

        public async Task<List<IdentityRole>> GetAll()
        {
            var result =  _roleManager.Roles.ToList();
            return result;
        }

        public async Task<bool> UpdateAsync(IdentityRole entity)
        {
           var result= await  _roleManager.UpdateAsync(entity);
            return result.Succeeded;
        }

        public async Task<bool> UpdateForPermission(Role role)
        {
            var identityRole=await _roleManager.Roles.SingleOrDefaultAsync(x=>x.Id==role.Id.ToString());
            if (identityRole == null) return false;
            foreach (var permission in role.Permissions)
            {
            await _roleManager.AddClaimAsync(identityRole, new System.Security.Claims.Claim( "Permission", permission.name ));
            }
            return true;
        }
    }
}
